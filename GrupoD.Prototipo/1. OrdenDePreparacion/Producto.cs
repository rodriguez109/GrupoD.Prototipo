using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._1._OrdenDePreparacion
{
    public class Producto
    {
        //Atributos
        public int SKUProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; } //CantidadProducto
        public string Posicion { get; set; }
        public int NumeroCliente { get; set; }
        public Producto(int skuProducto, string nombreProducto, int cantidad, string posicion, int numeroCliente)
        {
            SKUProducto = skuProducto;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            Posicion = posicion;
            NumeroCliente = numeroCliente;
        }




    }

}
