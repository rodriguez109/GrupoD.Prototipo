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
        //devuelve una lista actualizada de órdenes en preparación que pertenecen al depósito actual y no están en pallet.
        public List<OrdenPreparacion> OrdenesEnPreparacionDisponibles =>
    OrdenDePreparacionAlmacen.OrdenesDePreparacion
        .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion
            && op.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual
            && op.Pallet == false) // Solo los que NO están en pallet
        .Select(op => new OrdenPreparacion(
            op.Numero,
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
            }).ToList(),
            op.Pallet 
        )).ToList();

        //constructor de la clase que actualmente no realiza lógica, pero permite crear una instancia del modelo.
        public EmpaquetarProductosModelo()
        {
        }

        //recorre todas las órdenes y marca como preparadas aquellas que están en pallet y aún en preparación.
        public void CambiarEstadoOPsConPallet()
        {
            foreach (var orden in OrdenDePreparacionAlmacen.OrdenesDePreparacion)
            {
                if (orden.Pallet && orden.Estado == EstadoOrdenDePreparacionEnum.EnPreparacion)
                {
                    orden.Estado = EstadoOrdenDePreparacionEnum.Preparada;
                }
            }
        }

        //devuelve la orden en preparación más próxima a retirar, teniendo en cuenta la prioridad y fecha de retiro
        public OrdenPreparacion BusquedaOrdenDisponible()
        {
            return OrdenesEnPreparacionDisponibles
                .Where(op => op.EstadoOP == EstadoOrdenDePreparacionEnum.EnPreparacion)
                .OrderBy(op => op.Prioridad) // prioridad (menor = más urgente)
                .ThenBy(op => op.FechaRetirar) // fecha de retiro más próxima
                .FirstOrDefault()!;
        }

        //cambia el estado de una orden específica a "Preparada" en la lista del almacén.
        public void CambioEstadoOP(OrdenPreparacion ordenActual)
        {
            // Buscar la orden original en OrdenDePreparacionAlmacen y actualizar su estado
            var ordenEnAlmacen = OrdenDePreparacionAlmacen.OrdenesDePreparacion
                .FirstOrDefault(op => op.Numero == ordenActual.NumeroOP);

            if (ordenEnAlmacen != null)
            {
                ordenEnAlmacen.Estado = EstadoOrdenDePreparacionEnum.Preparada;
            }
        }

        //busca un producto por su SKU y devuelve un objeto con sus datos y la cantidad solicitada.
        public ProductoOP ObtenerProductoPorSKU(int sku, int cantidadSolicitada)
        {
            var productoEntidad = ProductoAlmacen.Productos.FirstOrDefault(p => p.SKU == sku); //devuelve solo el primer producto?

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


