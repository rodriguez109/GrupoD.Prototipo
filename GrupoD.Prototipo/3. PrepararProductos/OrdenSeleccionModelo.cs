using GrupoD.Prototipo.Almacenes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._3._PrepararProductos
{
    internal class PrepararProductosModelo
    {
        public List<OrdenDeSeleccionEntidad> OrdenesDeSeleccion { get; private set; }

        public PrepararProductosModelo()
        {
            //Carga todas las órdenes de selección del almacén, las transforma a un formato propio (OrdenDeSeleccionEnt) y asegura que las referencias a las
            //órdenes de preparación estén validadas contra su almacén correspondiente.
            OrdenesDeSeleccion = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion
                .Select(os => new OrdenDeSeleccionEntidad
                {
                    Numero = os.Numero,
                    FechaGeneracion = os.FechaGeneracion,
                    EstadoOrdenDeSeleccion = os.EstadoOrdenDeSeleccion,

                    // Resolvemos cada ID de preparación contra su almacén
                    OrdenesPreparacion = os.OrdenesPreparacion
                        .Select(idPreparacion =>
                            OrdenDePreparacionAlmacen.OrdenesDePreparacion
                                .First(op => op.Numero == idPreparacion)
                                .Numero
                        )
                        .ToList()
                })
                .ToList();
        }
        //Filtrará lista en memoria tomando sólo las órdenes cuya propiedad EstadoOrden sea PENDIENTE y devolverá una lista de sus IDs.
        public List<int> ObtenerOrdenesDeSeleccion()
        {
            return OrdenesDeSeleccion
                .Where(o => o.EstadoOrdenDeSeleccion == EstadoOrdenDeSeleccionEnum.Pendiente)
                .Select(o => o.Numero)
                .ToList();
        }
        public void ConfirmarOrdenSeleccion(int idOrdenSeleccion)
        {
            // Obtener la orden de selección desde el almacenamiento persistente  
            var ordenSeleccionEntidad = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion
                .FirstOrDefault(o => o.Numero == idOrdenSeleccion);

            if (ordenSeleccionEntidad == null)
            {
                throw new InvalidOperationException("La orden de selección no existe.");
            }

            // Cambiar el estado de las órdenes 
            foreach (var idOrdenPreparacion in ordenSeleccionEntidad.OrdenesPreparacion)
            {
                var ordenPreparacion = OrdenDePreparacionAlmacen.OrdenesDePreparacion
                    .FirstOrDefault(op => op.Numero == idOrdenPreparacion);

                if (ordenPreparacion != null)
                {
                    cambiarStock(ordenPreparacion);

                    // Cambiar el estado de la orden de  
                    ordenPreparacion.Estado = EstadoOrdenDePreparacionEnum.EnPreparacion;
                }
            }

            // Cambiar el estado de la orden de selección a "Confirmada"  
            ordenSeleccionEntidad.EstadoOrdenDeSeleccion = EstadoOrdenDeSeleccionEnum.Confirmada;

            // Eliminar la orden de selección de la lista en memoria de órdenes de selección activas  
            OrdenesDeSeleccion.RemoveAll(o => o.Numero == idOrdenSeleccion);
        }

        private void cambiarStock(OrdenDePreparacionEntidad op)
        {
            // Cada línea en op.Detalle trae SKU y Cantidad  
            foreach (var linea in op.Detalle)
            {

                ProductoAlmacen.RestarStock(linea.SKU, linea.Cantidad); // "RestarStock" en ProductoAlmacen.cs
            }
        }
        
        public void CargarOrdenesSeleccionEnComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            List<int> ordenes = ObtenerOrdenesDeSeleccion();

            foreach (var orden in ordenes)
            {
                comboBox.Items.Add(orden);
            }

            // Seleccionar la primera orden de selección si hay alguna
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0; // Selecciona automáticamente la primera
            }
        }
        // Construye y devuelve, para una orden de selección dada, la lista de productos que hay que reservar de depósitos junto con la cantidad disponible en cada ubicación.
        
        public List<Producto> ObtenerProductosPorOrdenDeSeleccion(int idOrdenSeleccion)
        {
            var orden = OrdenesDeSeleccion.FirstOrDefault(o => o.Numero == idOrdenSeleccion);
            if (orden == null)
            {
                throw new InvalidOperationException($"No se encontró la orden de selección con ID {idOrdenSeleccion}");
            }

            var ordenesPreparacion = orden.OrdenesPreparacion
                .Select(id => OrdenDePreparacionAlmacen.OrdenesDePreparacion.FirstOrDefault(op => op.Numero == id))
                .Where(op => op != null)
                .ToList();

            var cantReqXProducto = new Dictionary<int, int>();
            foreach (var ordenPrep in ordenesPreparacion)
            {
                foreach (var detalleOrdenPrep in ordenPrep.Detalle)
                {
                    if (cantReqXProducto.ContainsKey(detalleOrdenPrep.SKU))
                    {
                        cantReqXProducto[detalleOrdenPrep.SKU] += detalleOrdenPrep.Cantidad;
                    }
                    else
                    {
                        cantReqXProducto.Add(detalleOrdenPrep.SKU, detalleOrdenPrep.Cantidad);
                    }
                }
            }

            var resultado = new List<Producto>();

            foreach (int sku in cantReqXProducto.Keys)
            {
                var productoEntidad = ProductoAlmacen.Productos.FirstOrDefault(p => p.SKU == sku);
                if (productoEntidad == null)
                {
                    throw new InvalidOperationException($"No se encontró el producto con SKU {sku}");
                }

                var productoResultado = new Producto(sku.ToString(), productoEntidad.NumeroCliente.ToString(), productoEntidad.Nombre, new List<UbicacionProdEnDepositoBuscar>());

                foreach (var ubicacionEnStock in productoEntidad.Posiciones)
                {
                    var resultadoUbicacion = new UbicacionProdEnDepositoBuscar
                    {
                        IdUbicacion = ubicacionEnStock.CodigoDeposito,
                        Stock = Math.Min(cantReqXProducto[sku], ubicacionEnStock.Stock)
                    };

                    cantReqXProducto[sku] -= resultadoUbicacion.Stock;
                    productoResultado.Detalle.Add(resultadoUbicacion);

                    if (cantReqXProducto[sku] == 0)
                    {
                        break;
                    }
                }

                resultado.Add(productoResultado);
            }
            return resultado;
        }
    }
}

// PANTALLA:
// 1: Cargar en memoria las órdenes de selección disponibles en el almacén [OS Almacen], Filtrar y devolver aquellas órdenes de selección que están en estado “Pendiente”.
// 2: El usuario selecciona una OS (Pendiente) del CmBox e invoca (por id) las ordenes de preparacion [Almacen OP] asociadas a esta.
// 3: El ListView muestra los productos de las órdenes de preparación asociadas a la OS seleccionada (SKUproducto y cantidad necesarios) y posición de depósito (ProductoAlmacen -> JsonProducto) y lo deserializa en una colección de objetos ProductoEntidad. 
// NOTA: Si al elegir la Orden de Selección no hay ninguna Orden de Preparación en estado “Pendiente”, el listado queda vacío y el botón de “Confirmar” aparece deshabilitado, porque no hay nada que procesar.
// 4: Al confirmar orden Seleccion: Cambio estado de "pendiente" a "confirmada" Y orden de preparacion de "en proceamiento" a "en preparacion" --> Ambos con boton "confirmar"
// 5: Y Modifica cambio de stock --> Impacta en ProductoAlmacen -> Datos\Producto.json

//JSon = OrdenDePreparacion, OrdenDeSeleccion y Productos 
//Almacenes: OrdenDePreparacionAlmacen, OrdenDeSeleccionAlmacen y ProductoAlmacen
//Entidad: OrdenDeSeleccionEntidad, OrdenDePreparacionEntidad y ProductoEntidad

//Resumen: La Pantalla permite ver rápidamente qué productos y su ubicaciones se requieren (buscar) para cumplir una Orden de Selección, y al confirmar ese trabajo se actualizan automáticamente los estados de selección y preparación, así como el stock disponible en el depósito.