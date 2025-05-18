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
        public int NumeroOrdenPreparacion { get; set; }
        public string EstadoOrdenPreparacion { get; set; }

        //agregar Prioridad
        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}
