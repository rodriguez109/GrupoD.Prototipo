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
        public PrioridadEnum Prioridad { get; set; } //-------------va?
        public EstadoOrdenDeSeleccionEnum EstadoOrdenDeSeleccion { get; set; }
        public List<int> OrdenesPreparacion { get; set; }

        public OrdenDeSeleccionEntidad(int numero, DateTime fechaGeneracion, PrioridadEnum prioridad)
        {
            Numero = numero;
            FechaGeneracion = fechaGeneracion;
            Prioridad = prioridad; //-------??
            EstadoOrdenDeSeleccion = EstadoOrdenDeSeleccionEnum.Pendiente;
            OrdenesPreparacion = new List<int>();
        }
    }
}
