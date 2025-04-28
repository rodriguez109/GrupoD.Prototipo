using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._2___GenerarOrdenSeleccion
{
    class OrdenesDeSeleccion
    {
        public int NumeroOrden { get; set; } // Número de la orden de preparación
        public string NombreCliente { get; set; } // Identificación del cliente
        public DateTime Fecha { get; set; } // Fecha de la orden (día, mes, año)
        public string Transportista { get; set; } // Nombre del transportista
        public string Prioridad { get; set; } // Prioridad de la orden
        public bool OrdenGenerada { get; set; } = false; // Campo para marcar si la orden fue generada

        // Constructor
        public OrdenesDeSeleccion(int numeroOrden, string nombreCliente, DateTime fecha, string transportista, string prioridad)
        {
            NumeroOrden = numeroOrden;
            NombreCliente = nombreCliente;
            Fecha = fecha;
            Transportista = transportista;
            Prioridad = prioridad;
        }
    }
}
