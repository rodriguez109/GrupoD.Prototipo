using System.Reflection;
using GrupoD.Prototipo.Almacenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GrupoD.Prototipo._4._Empaquetar_Productos;

namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    internal class EmpaquetarProductosModelo
    {
        //public List<OrdenPreparacion> OrdenesEnPreparacionDisponibles { get; } = new();
        //public List<OrdenDePreparacionEntidad> OrdenesEnPreparacionDisponibles { get; private set; } = new ();
        //    public List<OrdenDePreparacionEntidad> OrdenesEnPreparacionDisponibles
        //=> OrdenDePreparacionAlmacen.OrdenesDePreparacion
        //   .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion)
        // .ToList(); //te aseguras de siempre trabajar con datos actualizados sin necesidad de sincronización manual.+/


        public List<OrdenPreparacion> OrdenesEnPreparacionDisponibles
    => OrdenDePreparacionAlmacen.OrdenesDePreparacion
       .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion)
       .Select(op => new OrdenPreparacion(
           op.Numero,
           op.Estado,
           op.Detalle.Select(detallep =>
           {
               var productoEntidad = ProductoAlmacen.Productos.FirstOrDefault(p => p.SKU == detallep.SKU);
               return new ProductoOP
               {
                   SKU = detallep.SKU,
                   Nombre = productoEntidad?.Nombre ?? "Desconocido",
                   CantidadSeleccionada = detallep.Cantidad
               };
           }).ToList()
       )).ToList();
        public EmpaquetarProductosModelo()
        {
            //ActualizarOrdenesDisponibles();  ahora se calcula arriba automaticamente
            // Llena la lista interna con órdenes en preparación
        }


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
                            CantidadSeleccionada = dp.Cantidad
                        };
                    }).ToList()
                )).ToList();
        }


        public OrdenPreparacion BusquedaOrdenDisponible()
        {
            return OrdenesEnPreparacionDisponibles
                .Where(op => op.EstadoOP == EstadoOrdenDePreparacionEnum.EnPreparacion) // Comparación correcta con Enum
                .OrderBy(op => op.FechaRetirar)
                .FirstOrDefault();
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

        //public void ActualizarOrdenesDisponibles()      //YA NO ES NECESARIO XQ SE CALCULA
        //{
        //    OrdenesEnPreparacionDisponibles.Clear();
        //    OrdenesEnPreparacionDisponibles.AddRange(OrdenDePreparacionAlmacen.OrdenesDePreparacion
        //        .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion && op.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual)
        //        .OrderBy(o => o.FechaRetirar));
        //}

        public ProductoOP ObtenerProductoPorSKU(int sku)
        {
            var productoEntidad = ProductoAlmacen.Productos.FirstOrDefault(p => p.SKU == sku);

            if (productoEntidad == null) return null;

            return new ProductoOP
            {
                SKU = productoEntidad.SKU,
                Nombre = productoEntidad.Nombre,
                CantidadSeleccionada = productoEntidad.Stock // Ajusta si necesitas otro valor
            };
        }



    }
}


