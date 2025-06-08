using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._3._PrepararProductos
{
     class Producto
    {
        public string SKUProducto { get; set; }
        public string IdCliente { get; set; }

        public string NombreProducto { get; set; }

        public List<UbicacionProdEnDepositoBuscar> Detalle { get; set; }

        public Producto(string skuProducto, string idCliente, string nombreProducto, List<UbicacionProdEnDepositoBuscar> detalle)
        {
            SKUProducto = skuProducto;
            IdCliente = idCliente;
            NombreProducto = nombreProducto;
            Detalle = detalle;
        }
    }
}
