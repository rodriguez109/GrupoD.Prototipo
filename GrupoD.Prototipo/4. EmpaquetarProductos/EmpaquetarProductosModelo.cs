using System.Reflection;
using GrupoD.Prototipo.Almacenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    internal class EmpaquetarProductosModelo
    {
        public List<OrdenDePreparacionEntidad> OrdenesEnPreparacionDisponibles { get; } = new();
        //public List<OrdenDePreparacionEntidad> OrdenesEnPreparacionDisponibles { get; private set; } = new ();
        //    public List<OrdenDePreparacionEntidad> OrdenesEnPreparacionDisponibles
        //=> OrdenDePreparacionAlmacen.OrdenesDePreparacion
        //   .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion)
        // .ToList(); //te aseguras de siempre trabajar con datos actualizados sin necesidad de sincronización manual.+/

        public EmpaquetarProductosModelo()
        {
            ActualizarOrdenesDisponibles();   // Llena la lista interna con órdenes en preparación
        }
        


        public OrdenDePreparacionEntidad BusquedaOrdenDisponible() //EXP
        {

            var ordenActual = OrdenesEnPreparacionDisponibles
            .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion && op.Prioridad == PrioridadEnum.Alta)
            .OrderBy(o => o.FechaRetirar)
            .FirstOrDefault()

            ?? OrdenesEnPreparacionDisponibles
            .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion && op.Prioridad == PrioridadEnum.Media)
            .OrderBy(o => o.FechaRetirar)
            .FirstOrDefault()

            ?? OrdenesEnPreparacionDisponibles
            .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion && op.Prioridad == PrioridadEnum.Baja)
            .OrderBy(o => o.FechaRetirar)
            .FirstOrDefault();

            return ordenActual;

        }

        public void CambioEstadoOP(OrdenDePreparacionEntidad ordenActual)
        {
            // Buscar la orden original en OrdenDePreparacionAlmacen y actualizar su estado
            var ordenEnAlmacen = OrdenDePreparacionAlmacen.OrdenesDePreparacion
                .FirstOrDefault(op => op.Numero == ordenActual.Numero);

            if (ordenEnAlmacen != null)
            {
                ordenEnAlmacen.Estado = EstadoOrdenDePreparacionEnum.Preparada;
            }

            ActualizarOrdenesDisponibles();
        }

        public void ActualizarOrdenesDisponibles()
        {
            OrdenesEnPreparacionDisponibles.Clear();
            OrdenesEnPreparacionDisponibles.AddRange(OrdenDePreparacionAlmacen.OrdenesDePreparacion
                .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion));
        }

        public ProductoEntidad ObtenerProductoPorSKU(int sku)
        {
            return ProductoAlmacen.Productos.FirstOrDefault(p => p.SKU == sku);
        }
    }
}


