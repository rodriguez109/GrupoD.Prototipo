using GrupoD.Prototipo._3._PrepararProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo.PrepararProductos.PrepararProductos
{
    public class PrepararProductosPresenter
    {
        private readonly IPrepararProductosView _view;
        private List<OrdenSeleccion> _ordenes;

        public PrepararProductosPresenter(IPrepararProductosView view)
        {
            _view = view;
        }

        public void CargarOrdenes()
        {
            _ordenes = ObtenerOrdenesMock();
            ActualizarListaOrdenesSegunPrioridad();
        }

        private void ActualizarListaOrdenesSegunPrioridad() // [2]
        {
            var ordenesPendientes = _ordenes
                .Where(o => o.Estado == EstadoOrdenSeleccion.Pendiente)
                .ToList();

            if (!ordenesPendientes.Any())
            {
                _view.CerrarAplicacion();
                return;
            }

            var ordenesParaMostrar = ordenesPendientes
                .OrderBy(o => (int)o.Prioridad)
                .ThenBy(o => o.NombreOrden)
                .ToList();

            _view.MostrarOrdenes(ordenesParaMostrar);
        }

        public void OrdenSeleccionadaCambiada()
        {
            var ordenSeleccionada = _view.ObtenerOrdenSeleccionada();

            if (ordenSeleccionada == null)
            {
                _view.MostrarProductosEnListView(new List<OrdenDeSeleccion>());
                _view.HabilitarBotonConfirmar(false);
                return;
            }

            _view.MostrarProductosEnListView(ordenSeleccionada.Productos);

            var hayOrdenesDeMayorPrioridad = _ordenes
                .Any(o => o.Estado == EstadoOrdenSeleccion.Pendiente
                       && (int)o.Prioridad < (int)ordenSeleccionada.Prioridad);

            if (hayOrdenesDeMayorPrioridad)
            {
                _view.HabilitarBotonConfirmar(false);
                _view.MostrarMensaje(
                    "No puede confirmar esta orden porque existen órdenes con prioridad más alta pendientes.",
                    "Confirmación no permitida");
            }
            else
            {
                _view.HabilitarBotonConfirmar(true);
            }
        }

        public void ConfirmarSeleccion()
        {
            var orden = _view.ObtenerOrdenSeleccionada();

            if (orden == null)
            {
                _view.MostrarAdvertencia(
                    "Por favor, seleccione una orden válida antes de confirmar.",
                    "Advertencia");
                return;
            }

            var prioridadMaximaPendiente = _ordenes
                .Where(o => o.Estado == EstadoOrdenSeleccion.Pendiente) // Orden estado "Pendiente" [3]
                .Min(o => (int)o.Prioridad);

            if ((int)orden.Prioridad > prioridadMaximaPendiente)
            {
                _view.MostrarAdvertencia(
                    $"Solo puede confirmar órdenes con prioridad {(Prioridad)prioridadMaximaPendiente}.",
                    "Prioridad incorrecta");
                return;
            }

            var ordenEnLista = _ordenes.FirstOrDefault(o => o.NombreOrden == orden.NombreOrden);

            if (ordenEnLista != null)
            {
                ordenEnLista.Estado = EstadoOrdenSeleccion.EnPreparacion; // Orden estado "En preparación" [3]

                _view.MostrarMensaje(
                     $"LA ORDEN N° {ordenEnLista.NombreOrden} CAMBIÓ A ESTADO \"EN PREPARACIÓN\".",
                     "ORDEN CONFIRMADA !");

                _ordenes.Remove(ordenEnLista);
                ActualizarListaOrdenesSegunPrioridad();
            }
        }
        private List<OrdenSeleccion> ObtenerOrdenesMock()
        {
            return new List<OrdenSeleccion>
    {
        new OrdenSeleccion
        {
            NombreOrden = "1",
            Estado = EstadoOrdenSeleccion.Pendiente,
            Prioridad = Prioridad.Alta,
            Productos = new List<OrdenDeSeleccion>
            {
                new OrdenDeSeleccion { Posicion = "QW-01-1", SKUProducto = "SKU003", Cantidad = 10 },
                new OrdenDeSeleccion { Posicion = "DC-01-2", SKUProducto = "SKU003", Cantidad = 5 },
                new OrdenDeSeleccion { Posicion = "SA-01-3", SKUProducto = "SKU003", Cantidad = 7 }, 
                new OrdenDeSeleccion { Posicion = "ZX-01-4", SKUProducto = "SKU008", Cantidad = 4 },
                new OrdenDeSeleccion { Posicion = "XX-01-5", SKUProducto = "SKU009", Cantidad = 6 },
                new OrdenDeSeleccion { Posicion = "EW-01-6", SKUProducto = "SKU004", Cantidad = 3 }
            }
        },
        new OrdenSeleccion
        {
            NombreOrden = "2",
            Estado = EstadoOrdenSeleccion.Pendiente,
            Prioridad = Prioridad.Alta,
            Productos = new List<OrdenDeSeleccion>
            {
                new OrdenDeSeleccion { Posicion = "SA-01-1", SKUProducto = "SKU003", Cantidad = 15 }, 
                new OrdenDeSeleccion { Posicion = "LO-01-1", SKUProducto = "SKU004", Cantidad = 8 },
                new OrdenDeSeleccion { Posicion = "WQ-01-7", SKUProducto = "SKU010", Cantidad = 9 },
                new OrdenDeSeleccion { Posicion = "RV-01-9", SKUProducto = "SKU002", Cantidad = 2 },
                new OrdenDeSeleccion { Posicion = "CD-01-5", SKUProducto = "SKU005", Cantidad = 1 },
                new OrdenDeSeleccion { Posicion = "PO-01-3", SKUProducto = "SKU011", Cantidad = 7 }
            }
        },
        new OrdenSeleccion
        {
            NombreOrden = "3",
            Estado = EstadoOrdenSeleccion.Pendiente,
            Prioridad = Prioridad.Media,
            Productos = new List<OrdenDeSeleccion>
            {
                new OrdenDeSeleccion { Posicion = "RI-01-1", SKUProducto = "SKU004", Cantidad = 12 },  // [1]
                new OrdenDeSeleccion { Posicion = "VR-01-7", SKUProducto = "SKU004", Cantidad = 5 },  
                new OrdenDeSeleccion { Posicion = "NN-01-3", SKUProducto = "SKU006", Cantidad = 9 },
                new OrdenDeSeleccion { Posicion = "SR-01-9", SKUProducto = "SKU012", Cantidad = 3 },
                new OrdenDeSeleccion { Posicion = "PP-01-5", SKUProducto = "SKU001", Cantidad = 4 },
                new OrdenDeSeleccion { Posicion = "CD-01-2", SKUProducto = "SKU007", Cantidad = 6 }
            }
        },
        new OrdenSeleccion
        {
            NombreOrden = "4",
            Estado = EstadoOrdenSeleccion.Pendiente,
            Prioridad = Prioridad.Baja,
            Productos = new List<OrdenDeSeleccion>
            {
                new OrdenDeSeleccion { Posicion = "PÑ-01-7", SKUProducto = "SKU005", Cantidad = 6 },
                new OrdenDeSeleccion { Posicion = "TP-01-2", SKUProducto = "SKU007", Cantidad = 3 },
                new OrdenDeSeleccion { Posicion = "RR-01-9", SKUProducto = "SKU004", Cantidad = 4 },
                new OrdenDeSeleccion { Posicion = "GH-01-4", SKUProducto = "SKU006", Cantidad = 2 },
                new OrdenDeSeleccion { Posicion = "RD-01-9", SKUProducto = "SKU013", Cantidad = 5 },
                new OrdenDeSeleccion { Posicion = "DC-01-6", SKUProducto = "SKU008", Cantidad = 3 }
            }
        }
    };
        }

    }
}


//El modelo ya soporta un SKU en varias posiciones, se debe configurar la lista de productos para determinada orden [1]

// Prioridad en las órdenes [2] se desactiva botón si el usuario elije orden de menor prioridad [2]

// Cambio de estado de la orden, de "Pendiente" a "En preparación" [3]
