using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using GrupoD.Prototipo._4._OrdenPreparacion;
using GrupoD.Prototipo._4._Empaquetar_Productos;
//using GrupoD.Prototipo._1._OrdenDePreparacion;

namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    class OrdenPreparacion
    {
        // Atributos.
        public int NumeroOrden { get; set; }
        public List<Producto> Productos { get; set; } = new List<Producto>();
        public override string ToString()
        {
            return $"{NumeroOrden}";
        }
    }
}
