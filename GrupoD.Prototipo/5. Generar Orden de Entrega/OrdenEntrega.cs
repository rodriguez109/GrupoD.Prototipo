using GrupoD.Prototipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo
{
    public class OrdenEntrega
    {
        public int NumeroOrden { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaEntrega { get; set; }
        public long DniTransportista { get; set; }
        public string NombreTransportista { get; set; }


        public OrdenEntrega(int numeroOrden, string nombreCliente, DateTime fechaEntrega, long dniTransportista, string nombreTransportista)
        {
            NumeroOrden = numeroOrden;
            NombreCliente = nombreCliente;
            FechaEntrega = fechaEntrega;
            DniTransportista = dniTransportista;
            NombreTransportista = nombreTransportista;
        }
    }

}
