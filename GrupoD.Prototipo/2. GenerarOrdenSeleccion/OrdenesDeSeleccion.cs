using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._2._GenerarOrdenSeleccion
{
    class OrdenesDeSeleccion
    {
        // Atributos
        public int IDOrdenSeleccion { get; set; }
        public int NumeroOrdenSeleccion { get; set; }
        public List<OrdenesDePreparacion> OrdenesPreparacion { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public string EstadoOrdenDeSeleccion { get; set; }

        // Constructor
        public OrdenesDeSeleccion(int numeroOrdenSeleccion, List<OrdenesDePreparacion> ordenesPreparacion, DateTime fechaGeneracion, string estadoOrden)
        {
            NumeroOrdenSeleccion = numeroOrdenSeleccion;
            OrdenesPreparacion = ordenesPreparacion;
            FechaGeneracion = fechaGeneracion;
            EstadoOrdenDeSeleccion = estadoOrden;
        }

    }

}
