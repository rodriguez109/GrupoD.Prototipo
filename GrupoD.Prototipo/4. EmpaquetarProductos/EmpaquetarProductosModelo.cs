using System.Reflection;
using GrupoD.Prototipo.Almacenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GrupoD.Prototipo._4._EmpaquetarProductos;
using System.Collections;

namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    internal class EmpaquetarProductosModelo
    {
         public List<OrdenPreparacion> OrdenesEnPreparacionDisponibles
    => OrdenDePreparacionAlmacen.OrdenesDePreparacion
       .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion)
       .Select(op => new OrdenPreparacion(
           op.Numero, // Cambio de `Numero` a `NumeroOP`
           op.Estado,
           op.Prioridad,
           op.FechaRetirar,
           op.Detalle.Select(detallep =>
           {
               var productoEntidad = ProductoAlmacen.Productos.FirstOrDefault(p => p.SKU == detallep.SKU);
               return new ProductoOP
               {
                   SKU = detallep.SKU,
                   Nombre = productoEntidad?.Nombre ?? "Desconocido",
                   CantidadSolicitada = detallep.Cantidad
               };
           }).ToList()
       )).ToList();

        public EmpaquetarProductosModelo()
        {
            //ActualizarOrdenesDisponibles();  ahora se calcula arriba automaticamente
            // Llena la lista interna con órdenes en preparación
        }


        /*Cuando usar ObtenerOrdenesDisponibles()?
            - Devuelve una lista completa de órdenes en preparación, permitiendo visualizar todas. 
            - Útil si necesitas mostrar varias órdenes en una vista, como un listado en el formulario. 
            - Ideal para reportes o para elegir manualmente qué orden procesar, en lugar de que el sistema seleccione automáticamente.*/
        public List<OrdenPreparacion> ObtenerOrdenesDisponibles()
        {
            return OrdenDePreparacionAlmacen.OrdenesDePreparacion
                .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion)
                .Select(op => new OrdenPreparacion(
                    op.Numero,
                    op.Estado,
                    op.Prioridad,
                    op.FechaRetirar,
                    op.Detalle.Select(dp =>
                    {
                        var productoEntidad = ProductoAlmacen.Productos.FirstOrDefault(p => p.SKU == dp.SKU);
                        return new ProductoOP
                        {
                            SKU = dp.SKU,
                            Nombre = productoEntidad?.Nombre ?? "Desconocido",
                            CantidadSolicitada = dp.Cantidad
                        };
                    }).ToList()
                )).ToList();
        }

        public OrdenPreparacion BusquedaOrdenDisponible() //primer ordend e preparacion mas prox a retirar
            //falta que tenga en cuenta la prioridad
        {
            return OrdenesEnPreparacionDisponibles
                .Where(op => op.EstadoOP == EstadoOrdenDePreparacionEnum.EnPreparacion)
                .OrderBy(op => op.FechaRetirar)
                .FirstOrDefault()!;
        }

        public void CambioEstadoOP(OrdenPreparacion ordenActual)
        {
            // Buscar la orden original en OrdenDePreparacionAlmacen y actualizar su estado
            var ordenEnAlmacen = OrdenDePreparacionAlmacen.OrdenesDePreparacion
                .FirstOrDefault(op => op.Numero == ordenActual.NumeroOP);

            if (ordenEnAlmacen != null)
            {
                ordenEnAlmacen.Estado = EstadoOrdenDePreparacionEnum.Preparada;
            }

            //ActualizarOrdenesDisponibles();
        }

        //public void ActualizarOrdenesDisponibles()      // se calcula automaticamente ahora
        //{
        //    OrdenesEnPreparacionDisponibles.Clear();
        //    OrdenesEnPreparacionDisponibles.AddRange(OrdenDePreparacionAlmacen.OrdenesDePreparacion
        //        .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion && op.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual)
        //        .OrderBy(o => o.FechaRetirar));
        //}

        public ProductoOP ObtenerProductoPorSKU(int sku, int cantidadSolicitada)
        {
            var productoEntidad = ProductoAlmacen.Productos.FirstOrDefault(p => p.SKU == sku); //devuelve solo el primer producto???

            if (productoEntidad == null) return null;

            return new ProductoOP
            {
                SKU = productoEntidad.SKU,
                Nombre = productoEntidad.Nombre,
                CantidadSolicitada = cantidadSolicitada // cantidad pedida en la orden
            };
        }
    }
}


