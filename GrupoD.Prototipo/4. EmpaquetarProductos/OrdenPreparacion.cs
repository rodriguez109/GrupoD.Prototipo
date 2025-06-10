using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoD.Prototipo._4._Empaquetar_Productos;
using GrupoD.Prototipo.Almacenes;

namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    class OrdenPreparacion
    {
        public int NumeroOP { get; set; }
        public EstadoOrdenDePreparacionEnum EstadoOP { get; set; }
        public PrioridadEnum Prioridad { get; set; }
        public DateTime FechaRetirar { get; set; } // Nueva propiedad
        public List<ProductoOP> Productos { get; set; } = new List<ProductoOP>();

        public OrdenPreparacion(int numeroOrden, EstadoOrdenDePreparacionEnum estadoOP, PrioridadEnum prioridad, DateTime fechaRetirar, List<ProductoOP> productos)
        {
            NumeroOP = numeroOrden;
            EstadoOP = estadoOP;
            Prioridad = prioridad;
            FechaRetirar = fechaRetirar; // Asignación correcta
            Productos = productos ?? new List<ProductoOP>();
        }
    }

}
