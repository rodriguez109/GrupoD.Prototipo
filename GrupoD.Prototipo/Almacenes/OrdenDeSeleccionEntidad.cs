using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    class OrdenDeSeleccionEntidad
    {
        public int Numero { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public EstadoOrdenDeSeleccionEnum EstadoOrdenDeSeleccion { get; set; }
        public List<int> OrdenesPreparacion { get; set; } = new();

        public OrdenDeSeleccionEntidad(
            int numero,
            DateTime fechaGeneracion,
            List<int> ordenesPreparacion, EstadoOrdenDeSeleccionEnum estado)
        {
            Numero = numero;
            FechaGeneracion = fechaGeneracion;
            EstadoOrdenDeSeleccion = EstadoOrdenDeSeleccionEnum.Pendiente;
            OrdenesPreparacion = ordenesPreparacion ?? new List<int>();
        }
    }
}
