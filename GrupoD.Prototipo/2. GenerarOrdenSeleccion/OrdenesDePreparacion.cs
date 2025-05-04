using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._2._GenerarOrdenSeleccion
{
    class OrdenesDePreparacion
    {
        // Atributos
        public int NumeroOrden { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaEntrega { get; set; }
        public long Transportista { get; set; }
        public string Prioridad { get; set; }

        // Constructor
        public OrdenesDePreparacion(int numeroOrden, string nombreCliente, DateTime fechaEntrega, long transportista, string prioridad)
        {
            NumeroOrden = numeroOrden;
            NombreCliente = nombreCliente;
            FechaEntrega = fechaEntrega;
            Transportista = transportista;
            Prioridad = prioridad;
        }
    }
}
