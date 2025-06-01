using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion
{
    internal class Transportista
    {
        //Atributos
        public int DNITransportista { get; set; } 
        public string NombreTransportista { get; set; }

        public Transportista(int dniTransportista, string nombreTransportista)
        {
            DNITransportista = dniTransportista;
            NombreTransportista = nombreTransportista;
        }

    }
}
