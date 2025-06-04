using System.Reflection;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo.Almacenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



using GrupoD.Prototipo._4._Empaquetar_Productos;
using GrupoD.Prototipo._3._PrepararProductos;

namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    internal class EmpaquetarProductosModelo
    {
        public List<OrdenDePreparacionEntidad> OrdenesEnPreparacionDisponibles { get; } = new();
        /*public List<OrdenDePreparacionEntidad> OrdenesEnPreparacionDisponibles
    => OrdenDePreparacionAlmacen.OrdenesDePreparacion
       .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion)
       .ToList(); //te aseguras de siempre trabajar con datos actualizados sin necesidad de sincronización manual.+/


        //public OrdenPreparacion ordenActual;
        public EmpaquetarProductosModelo()
        {
            OrdenesEnPreparacionDisponibles = OrdenDePreparacionAlmacen.OrdenesDePreparacion
            .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion)
            .ToList(); //OrdenesEnPreparacionDisponibles solo contenga órdenes que están en preparación.
        }


        /*public EmpaquetarProductosModelo() //datos hardcodeados:
        {
            var productosEjemplo = new List<Producto>
                {
                    new Producto(1, "Mesa ratona de madera", 2),
                    new Producto(2, "Lámpara colgante LED", 5),
                    new Producto(3, "Smart TV 43 pulgadas", 1)
                };

            OrdenesEnPreparacionDisponibles = new List<OrdenPreparacion>
                {
                    new OrdenPreparacion
                    {
                        NumeroOrdenPreparacion = 1,
                        EstadoOrdenPreparacion = "En Preparacion",
                        Productos = productosEjemplo
                    },
                    new OrdenPreparacion
                    {
                        NumeroOrdenPreparacion = 2,
                        EstadoOrdenPreparacion = "En Preparacion",
                        Productos = new List<Producto>
                        {
                            new Producto(4, "Pintura látex interior 20L", 1),
                            new Producto(5, "Silla de comedor moderna", 1)
                        }
                    }
                };
        }*/

        public OrdenDePreparacionEntidad BusquedaOrdenDisponible() //EXP
        {
            // Buscar próxima orden "En Preparacion"
            //ordenActual = OrdenesEnPreparacionDisponibles.FirstOrDefault(o => o.EstadoOrdenPreparacion == "En Preparacion")!;



            //var ordenActual = OrdenDePreparacionAlmacen.OrdenesDePreparacion.FirstOrDefault(o => o.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion);

            //tendria q devolver la primer orden de preparacion con prioridad Alta, con fecha mas cercana a retirar

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
            //ordenActual.Estado = EstadoOrdenDePreparacionEnum.Preparada;
            //OrdenesEnPreparacionDisponibles.Remove(ordenActual); // Remueve de la lista interna

            //ordenActual.Estado = EstadoOrdenDePreparacionEnum.Preparada;

            // Buscar la orden original en OrdenDePreparacionAlmacen y actualizar su estado
            var ordenEnAlmacen = OrdenDePreparacionAlmacen.OrdenesDePreparacion
                .FirstOrDefault(op => op.Numero == ordenActual.Numero);

            if (ordenEnAlmacen != null)
            {
                ordenEnAlmacen.Estado = EstadoOrdenDePreparacionEnum.Preparada;
            }

            // Guardar los cambios en el almacenamiento
            OrdenDePreparacionAlmacen.Grabar();
        }

        public void ActualizarOrdenesDisponibles()
        {
            OrdenesEnPreparacionDisponibles.Clear();
            OrdenesEnPreparacionDisponibles.AddRange(OrdenDePreparacionAlmacen.OrdenesDePreparacion
                .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion));
        }
    }
}


