using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _view.MostrarOrdenes(_ordenes);
        }

        public void OrdenSeleccionadaCambiada()
        {
            var orden = _view.ObtenerOrdenSeleccionada();
            if (orden != null)
                _view.MostrarProductosEnListView(orden.Productos);
        }

        public void ConfirmarSeleccion()
        {
            var orden = _view.ObtenerOrdenSeleccionada();
            if (orden == null || orden.Productos == null || orden.Productos.Count == 0)
            {
                _view.MostrarAdvertencia("Por favor, seleccione una orden válida antes de confirmar.", "Advertencia");
                return;
            }

            _view.MostrarMensaje("¡Orden de selección confirmada!", "Confirmación");
        }

        private List<OrdenSeleccion> ObtenerOrdenesMock()
        {
            return new List<OrdenSeleccion>
        {
            new OrdenSeleccion
                {
                    NombreOrden = "1",
                    Productos = new List<OrdenDeSeleccion>
                    {
                        new OrdenDeSeleccion { Ubicacion = "01-01-1", SKUProducto = "SKU001", Cantidad = 10 },
                        new OrdenDeSeleccion { Ubicacion = "01-01-2", SKUProducto = "SKU002", Cantidad = 5 },
                        new OrdenDeSeleccion { Ubicacion = "01-01-3", SKUProducto = "SKU003", Cantidad = 8 },
                        new OrdenDeSeleccion { Ubicacion = "01-01-4", SKUProducto = "SKU004", Cantidad = 12 },
                        new OrdenDeSeleccion { Ubicacion = "01-01-5", SKUProducto = "SKU005", Cantidad = 7 },
                        new OrdenDeSeleccion { Ubicacion = "01-01-6", SKUProducto = "SKU006", Cantidad = 3 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "2",
                    Productos = new List<OrdenDeSeleccion>
                    {
                        new OrdenDeSeleccion { Ubicacion = "02-01-1", SKUProducto = "SKU007", Cantidad = 15 },
                        new OrdenDeSeleccion { Ubicacion = "02-01-2", SKUProducto = "SKU008", Cantidad = 9 },
                        new OrdenDeSeleccion { Ubicacion = "02-01-3", SKUProducto = "SKU009", Cantidad = 4 },
                        new OrdenDeSeleccion { Ubicacion = "02-01-4", SKUProducto = "SKU010", Cantidad = 6 },
                        new OrdenDeSeleccion { Ubicacion = "02-01-5", SKUProducto = "SKU011", Cantidad = 11 },
                        new OrdenDeSeleccion { Ubicacion = "02-01-6", SKUProducto = "SKU012", Cantidad = 2 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "3",
                    Productos = new List<OrdenDeSeleccion>
                    {
                        new OrdenDeSeleccion { Ubicacion = "03-01-1", SKUProducto = "SKU013", Cantidad = 20 },
                        new OrdenDeSeleccion { Ubicacion = "03-01-2", SKUProducto = "SKU014", Cantidad = 5 },
                        new OrdenDeSeleccion { Ubicacion = "03-01-3", SKUProducto = "SKU015", Cantidad = 3 },
                        new OrdenDeSeleccion { Ubicacion = "03-01-4", SKUProducto = "SKU016", Cantidad = 7 },
                        new OrdenDeSeleccion { Ubicacion = "03-01-5", SKUProducto = "SKU017", Cantidad = 9 },
                        new OrdenDeSeleccion { Ubicacion = "03-01-6", SKUProducto = "SKU018", Cantidad = 14 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "4",
                    Productos = new List<OrdenDeSeleccion>
                    {
                        new OrdenDeSeleccion { Ubicacion = "04-01-1", SKUProducto = "SKU019", Cantidad = 6 },
                        new OrdenDeSeleccion { Ubicacion = "04-01-2", SKUProducto = "SKU020", Cantidad = 13 },
                        new OrdenDeSeleccion { Ubicacion = "04-01-3", SKUProducto = "SKU021", Cantidad = 11 },
                        new OrdenDeSeleccion { Ubicacion = "04-01-4", SKUProducto = "SKU022", Cantidad = 4 },
                        new OrdenDeSeleccion { Ubicacion = "04-01-5", SKUProducto = "SKU023", Cantidad = 8 },
                        new OrdenDeSeleccion { Ubicacion = "04-01-6", SKUProducto = "SKU024", Cantidad = 3 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "5",
                    Productos = new List<OrdenDeSeleccion>
                    {
                        new OrdenDeSeleccion { Ubicacion = "05-01-1", SKUProducto = "SKU025", Cantidad = 10 },
                        new OrdenDeSeleccion { Ubicacion = "05-01-2", SKUProducto = "SKU026", Cantidad = 2 },
                        new OrdenDeSeleccion { Ubicacion = "05-01-3", SKUProducto = "SKU027", Cantidad = 7 },
                        new OrdenDeSeleccion { Ubicacion = "05-01-4", SKUProducto = "SKU028", Cantidad = 9 },
                        new OrdenDeSeleccion { Ubicacion = "05-01-5", SKUProducto = "SKU029", Cantidad = 1 },
                        new OrdenDeSeleccion { Ubicacion = "05-01-6", SKUProducto = "SKU030", Cantidad = 6 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "6",
                    Productos = new List<OrdenDeSeleccion>
                    {
                        new OrdenDeSeleccion { Ubicacion = "06-01-1", SKUProducto = "SKU031", Cantidad = 3 },
                        new OrdenDeSeleccion { Ubicacion = "06-01-2", SKUProducto = "SKU032", Cantidad = 8 },
                        new OrdenDeSeleccion { Ubicacion = "06-01-3", SKUProducto = "SKU033", Cantidad = 5 },
                        new OrdenDeSeleccion { Ubicacion = "06-01-4", SKUProducto = "SKU034", Cantidad = 12 },
                        new OrdenDeSeleccion { Ubicacion = "06-01-5", SKUProducto = "SKU035", Cantidad = 9 },
                        new OrdenDeSeleccion { Ubicacion = "06-01-6", SKUProducto = "SKU036", Cantidad = 2 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "7",
                    Productos = new List<OrdenDeSeleccion>
                    {
                        new OrdenDeSeleccion { Ubicacion = "07-01-1", SKUProducto = "SKU037", Cantidad = 10 },
                        new OrdenDeSeleccion { Ubicacion = "07-01-2", SKUProducto = "SKU038", Cantidad = 4 },
                        new OrdenDeSeleccion { Ubicacion = "07-01-3", SKUProducto = "SKU039", Cantidad = 6 },
                        new OrdenDeSeleccion { Ubicacion = "07-01-4", SKUProducto = "SKU040", Cantidad = 11 },
                        new OrdenDeSeleccion { Ubicacion = "07-01-5", SKUProducto = "SKU041", Cantidad = 5 },
                        new OrdenDeSeleccion { Ubicacion = "07-01-6", SKUProducto = "SKU042", Cantidad = 7 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "8",
                    Productos = new List<OrdenDeSeleccion>
                    {
                        new OrdenDeSeleccion { Ubicacion = "08-01-1", SKUProducto = "SKU043", Cantidad = 9 },
                        new OrdenDeSeleccion { Ubicacion = "08-01-2", SKUProducto = "SKU044", Cantidad = 3 },
                        new OrdenDeSeleccion { Ubicacion = "08-01-3", SKUProducto = "SKU045", Cantidad = 4 },
                        new OrdenDeSeleccion { Ubicacion = "08-01-4", SKUProducto = "SKU046", Cantidad = 6 },
                        new OrdenDeSeleccion { Ubicacion = "08-01-5", SKUProducto = "SKU047", Cantidad = 13 },
                        new OrdenDeSeleccion { Ubicacion = "08-01-6", SKUProducto = "SKU048", Cantidad = 2 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "9",
                    Productos = new List<OrdenDeSeleccion>
                    {
                        new OrdenDeSeleccion { Ubicacion = "09-01-1", SKUProducto = "SKU049", Cantidad = 8 },
                        new OrdenDeSeleccion { Ubicacion = "09-01-2", SKUProducto = "SKU050", Cantidad = 5 },
                        new OrdenDeSeleccion { Ubicacion = "09-01-3", SKUProducto = "SKU051", Cantidad = 3 },
                        new OrdenDeSeleccion { Ubicacion = "09-01-4", SKUProducto = "SKU052", Cantidad = 7 },
                        new OrdenDeSeleccion { Ubicacion = "09-01-5", SKUProducto = "SKU053", Cantidad = 4 },
                        new OrdenDeSeleccion { Ubicacion = "09-01-6", SKUProducto = "SKU054", Cantidad = 6 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "10",
                    Productos = new List<OrdenDeSeleccion>
                    {
                        new OrdenDeSeleccion { Ubicacion = "10-01-1", SKUProducto = "SKU055", Cantidad = 10 },
                        new OrdenDeSeleccion { Ubicacion = "10-01-2", SKUProducto = "SKU056", Cantidad = 9 },
                        new OrdenDeSeleccion { Ubicacion = "10-01-3", SKUProducto = "SKU057", Cantidad = 6 },
                        new OrdenDeSeleccion { Ubicacion = "10-01-4", SKUProducto = "SKU058", Cantidad = 4 },
                        new OrdenDeSeleccion { Ubicacion = "10-01-5", SKUProducto = "SKU059", Cantidad = 8 },
                        new OrdenDeSeleccion { Ubicacion = "10-01-6", SKUProducto = "SKU060", Cantidad = 1 }
                    }
                }
            };      
        }
    }
}


