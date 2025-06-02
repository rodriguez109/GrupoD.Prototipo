using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    class OrdenDeEntregaEntidad
    {
        public int Numero { get; set; }
        public List<int> OrdenesPreparacion { get; }
        public PrioridadEnum Prioridad { get; set; } //----??
        public EstadoOrdenDeEntregaEnum EstadoOrdenDeEntrega { get; set; }

        public OrdenDeEntregaEntidad(int numero, PrioridadEnum prioridad)
        {
            Numero = numero;
            Prioridad = prioridad; //---?
            EstadoOrdenDeEntrega = EstadoOrdenDeEntregaEnum.Pendiente;
            OrdenesPreparacion = new List<int>();
        }
    }
}
