using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    class OrdenDeSeleccionEntidad
    {
        public int Numero { get; }
        public DateTime FechaGeneracion { get; }
        public EstadoOrdenDeSeleccionEnum EstadoOrdenDeSeleccion { get; }
        public List<int> OrdenesPreparacion { get; }

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
