using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._3._PrepararProductos
{
    public class OrdenesDePreparacion
    {
        public int Id { get; set; }
        public string Posicion { get; set; }
        public string SKUProducto { get; set; }
        public int Cantidad { get; set; }

        public OrdenesDePreparacion(int Id, string posicion, string SKUProducto, int cantidad)
        {
            this.Id = Id;
            this.Posicion = posicion;
            this.SKUProducto = SKUProducto;
            this.Cantidad = cantidad;
        }
    }
}
