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
        public long CUILTransportista { get; set; } //CAMBIARLO A INT DNITransportista
        public string NombreTransportista { get; set; }

        public Transportista(long cUILTransportista, string nombreTransportista)
        {
            CUILTransportista = cUILTransportista;
            NombreTransportista = nombreTransportista;
        }

    }
}
