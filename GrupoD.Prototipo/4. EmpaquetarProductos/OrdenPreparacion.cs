using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoD.Prototipo._4._Empaquetar_Productos;

namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    class OrdenPreparacion
    {
        // Atributos.
        public int NumeroOrden { get; set; }
        public string EstadoOrden { get; set; }
        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}
