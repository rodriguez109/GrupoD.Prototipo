using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._1._OrdenDePreparacion
{
    internal class Producto
    {
        //Atributos
        public int SKUProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public int Posicion { get; set; }
        public Producto(int skuProducto, string nombreProducto, int cantidad, int posicion)
        {
            SKUProducto = skuProducto;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            Posicion = posicion;
        }




    }
}
