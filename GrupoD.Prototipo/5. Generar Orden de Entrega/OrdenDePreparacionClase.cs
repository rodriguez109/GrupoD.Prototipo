using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
     class OrdenDePreparacionClase
    {
        
            // Atributos
            public int NumeroOrden { get; set; }
            public string NombreCliente { get; set; }
            public int DNITransportista { get; set; }
            public DateTime FechaEntrega { get; set; }

        // Constructor
        public OrdenDePreparacionClase(int numeroOrden, string nombreCliente, DateTime fechaEntrega, int dniTransportista)
            {
                NumeroOrden = numeroOrden;
                NombreCliente = nombreCliente;
                DNITransportista = dniTransportista;
                FechaEntrega = fechaEntrega;
        }
        
    }
}
