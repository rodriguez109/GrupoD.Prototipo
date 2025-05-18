using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._1._OrdenDePreparacion
{
    internal class Transportista
    {
        //Atributos
        public int DNITransportista { get; set; } //CAMBIARLO A INT DNITransportista
        public string NombreTransportista { get; set; }

        public Transportista(int dniTransportista, string nombreTransportista)
        {
            DNITransportista = dniTransportista;
            NombreTransportista = nombreTransportista;
        }

    }
}
