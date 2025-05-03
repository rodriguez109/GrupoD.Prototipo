using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoD.Prototipo._1._OrdenDePreparacion;

namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    class OrdenPreparacion
    {

        
        // Atributos.
        public int NumeroOrden { get; set; }
        public List<Producto> Productos { get; set; } = new List<Producto>();
        

        // Constructor.
        public OrdenPreparacion(int numeroOrden, string skuProducto, string nombreProducto, int cantidadProducto)
        {
            NumeroOrden = numeroOrden;
            SKUProducto = skuProducto;
            NombreProducto = nombreProducto;
            CantidadProducto = cantidadProducto;
        }

        public override string ToString()
        {
            return $"{NumeroOrden} - {SKUProducto} - {NombreProducto} - {CantidadProducto}";
        }
    }
}
