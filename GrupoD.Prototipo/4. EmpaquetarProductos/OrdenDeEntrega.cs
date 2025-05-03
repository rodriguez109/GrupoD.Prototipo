using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._4._Empaquetar_Productos
{
    class OrdenDeEntrega
    {
        
        // Atributos
        public int NumeroOrden { get; set; }
        public string SKUProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadProducto { get; set; }

        // Constructor
        public OrdenDeEntrega(int numeroOrden, string skuProducto, string nombreProducto, int cantidadProducto)
        {
            NumeroOrden = numeroOrden;
            SKUProducto = skuProducto;
            NombreProducto = nombreProducto;
            CantidadProducto = cantidadProducto;
        }
    }
}
