using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    class OrdenesEnPreparacion
    {
        // Atributos.
        public int NumeroOrden { get; set; }
        public string SKUProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadProducto { get; set; }

        // Constructor.
        public OrdenesEnPreparacion(int numeroOrden, string skuProducto, string nombreProducto, int cantidadProducto)
        {
            NumeroOrden = numeroOrden;
            SKUProducto = skuProducto;
            NombreProducto = nombreProducto;
            CantidadProducto = cantidadProducto;
        }
    }
}
