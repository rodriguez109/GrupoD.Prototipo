using GrupoD.Prototipo;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo._3._PrepararProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo
{
    public class OrdenDeEntregaPendiente
    {
        public int NumeroOrden { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaEntrega { get; set; }
        public long DniTransportista { get; set; }
        public string NombreTransportista { get; set; }
        public string EstadoOrdenDeEntrega { get; set; }
       


        public OrdenDeEntregaPendiente(int numeroOrden,  string nombreCliente, DateTime fechaEntrega, long dniTransportista, string nombreTransportista, string estadoOrdenDeEntrega)
        {
            NumeroOrden = numeroOrden;
           
            NombreCliente = nombreCliente;
            FechaEntrega = fechaEntrega;
            DniTransportista = dniTransportista;
            NombreTransportista = nombreTransportista;
            EstadoOrdenDeEntrega = estadoOrdenDeEntrega;

        }

        // Constructor vacío para formulario
        public OrdenDeEntregaPendiente()
        {
            FechaEntrega = DateTime.Now;
            EstadoOrdenDeEntrega = "Pendiente";
        }
    }

}

