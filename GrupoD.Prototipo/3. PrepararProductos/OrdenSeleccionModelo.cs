using GrupoD.Prototipo._3._PrepararProductos;  
using GrupoD.Prototipo.Almacenes;               
using Prototipo.PrepararProductos.PrepararProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Prototipo.PrepararProductos.PrepararProductos
{
    public class PrepararProductosPresenter
    {
        private readonly IPrepararProductosView _view;
        private List<OrdenSeleccion> _ordenes = new List<OrdenSeleccion>();

        public PrepararProductosPresenter(IPrepararProductosView view)
        {
            _view = view;
        }

        public void CargarOrdenes()
        {
            var seleccionEntidades = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion.ToList();
            var preparacionEntidades = OrdenDePreparacionAlmacen.OrdenesDePreparacion.ToList();

            _ordenes.Clear();

            foreach (var selEnt in seleccionEntidades)
            {
                if (selEnt.EstadoOrdenDeSeleccion != EstadoOrdenDeSeleccionEnum.Pendiente)
                    continue;

                string nombre = selEnt.Numero.ToString();

              
                var prioridadesDePreparacion = selEnt.OrdenesPreparacion
                    .Select(idPrep => preparacionEntidades
                        .FirstOrDefault(op => op.Numero == idPrep)?.Prioridad)
                    .Where(p => p.HasValue)
                    .Select(p => p.Value)
                    .ToList();

                Prioridad prioVista;
                if (prioridadesDePreparacion.Any())
                {
                    var minPrioEnum = prioridadesDePreparacion.Min();
                    switch (minPrioEnum)
                    {
                        case PrioridadEnum.Alta: prioVista = Prioridad.Alta; break;
                        case PrioridadEnum.Media: prioVista = Prioridad.Media; break;
                        case PrioridadEnum.Baja: prioVista = Prioridad.Baja; break;
                        default: prioVista = Prioridad.Baja; break;
                    }
                }
                else
                {
                    prioVista = Prioridad.Baja;
                }

                var productosVista = new List<OrdenDeSeleccion>();
                foreach (var prepEnt in preparacionEntidades.Where(p => selEnt.OrdenesPreparacion.Contains(p.Numero)))
                {
                    foreach (var linea in prepEnt.Detalle)
                    {
                        productosVista.Add(new OrdenDeSeleccion
                        {
                            Posicion = linea.SKU.ToString(),
                            SKUProducto = linea.SKU.ToString(),
                            Cantidad = linea.Cantidad
                        });
                    }
                }

                _ordenes.Add(new OrdenSeleccion
                {
                    NombreOrden = nombre,
                    Estado = EstadoOrdenSeleccion.Pendiente,
                    Prioridad = prioVista,
                    Productos = productosVista
                });
            }

            ActualizarListaOrdenesSegunPrioridad();
        }

        private void ActualizarListaOrdenesSegunPrioridad()
        {
            var ordenesPendientes = _ordenes
                .Where(o => o.Estado == EstadoOrdenSeleccion.Pendiente)
                .ToList();

            if (!ordenesPendientes.Any())
            {
                // Ya no cerramos el form. Simplemente le avisamos al usuario:
                MessageBox.Show(
                    "No hay órdenes pendientes en este momento.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Limpiamos el combo (si lo estuvieras poblando antes)
                _view.MostrarOrdenes(new List<OrdenSeleccion>());
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

            bool hayMayorPrio = _ordenes
                .Any(o => o.Estado == EstadoOrdenSeleccion.Pendiente
                       && (int)o.Prioridad < (int)ordenSeleccionada.Prioridad);

            if (hayMayorPrio)
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
            var ordenVista = _view.ObtenerOrdenSeleccionada();
            if (ordenVista == null)
            {
                _view.MostrarAdvertencia(
                    "Por favor, seleccione una orden válida antes de confirmar.",
                    "Advertencia");
                return;
            }

            var prioridadesPendientes = _ordenes
                .Where(o => o.Estado == EstadoOrdenSeleccion.Pendiente)
                .Select(o => (int)o.Prioridad)
                .ToList();

            if (!prioridadesPendientes.Any())
            {
                _view.MostrarAdvertencia("No hay órdenes pendientes para confirmar.", "Advertencia");
                return;
            }

            int prioMinima = prioridadesPendientes.Min();
            if ((int)ordenVista.Prioridad > prioMinima)
            {
                _view.MostrarAdvertencia(
                    $"Solo puede confirmar órdenes con prioridad {(Prioridad)prioMinima}.",
                    "Prioridad incorrecta");
                return;
            }

            // 1) Cambio estado de la orden de selección (usa “Confirmada” en lugar de “Seleccionada”):
            if (!int.TryParse(ordenVista.NombreOrden, out int idSel))
            {
                _view.MostrarAdvertencia("ID de orden inválido al confirmar.", "Error interno");
                return;
            }
            OrdenDeSeleccionAlmacen.cambiarEstadoOS(idSel, EstadoOrdenDeSeleccionEnum.Confirmada);
            OrdenDeSeleccionAlmacen.Grabar();

            // 2) Cambio estado de cada orden de preparación asociada a “EnPreparacion”:
            var selEntOriginal = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion
                .FirstOrDefault(o => o.Numero == idSel);

            if (selEntOriginal != null)
            {
                var todasPrep = OrdenDePreparacionAlmacen.OrdenesDePreparacion.ToList();
                foreach (var idPrep in selEntOriginal.OrdenesPreparacion)
                {
                    var prepEnt = todasPrep.FirstOrDefault(p => p.Numero == idPrep);
                    if (prepEnt != null)
                    {
                        // Uso “EnPreparacion” porque es el nombre exacto que sí existe en tu enum:
                        prepEnt.Estado = EstadoOrdenDePreparacionEnum.EnPreparacion;
                    }
                }
                OrdenDePreparacionAlmacen.Grabar();
            }

            // 3) Actualizo en memoria y notifico a la vista:
            ordenVista.Estado = EstadoOrdenSeleccion.EnPreparacion;
            _view.MostrarMensaje(
                $"La orden n° {ordenVista.NombreOrden} cambió a estado \"En Preparación\" ",
                "¡Orden Confirmada!");

            _ordenes.Remove(ordenVista);
            ActualizarListaOrdenesSegunPrioridad();
        }
    }
}
