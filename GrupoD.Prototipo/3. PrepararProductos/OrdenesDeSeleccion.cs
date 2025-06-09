using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._3._PrepararProductos
{
    public class OrdenesDeSeleccion
    {
        public int NumeroOrdenSeleccion { get; set; }


        public List<OrdenesDePreparacion> OrdenesPreparacion { get; set; }  // Esta lista se usará solo para mostrar en el ListView
        public DateTime FechaGeneracion { get; set; }
        public string EstadoOrdenDeSeleccion { get; set; }

        public OrdenesDeSeleccion(int numeroOrdenSeleccion, List<OrdenesDePreparacion> ordenesPreparacion, DateTime fechaGeneracion, string estadoOrden)
        {
            NumeroOrdenSeleccion = numeroOrdenSeleccion;
            OrdenesPreparacion = ordenesPreparacion;
            FechaGeneracion = fechaGeneracion;
            EstadoOrdenDeSeleccion = estadoOrden;
        }

        // Constructor vacío para inicializar la lista
        public OrdenesDeSeleccion()
        {
            OrdenesPreparacion = new List<OrdenesDePreparacion>();
            FechaGeneracion = DateTime.Now;
            EstadoOrdenDeSeleccion = "Pendiente";
        }
    }
}

