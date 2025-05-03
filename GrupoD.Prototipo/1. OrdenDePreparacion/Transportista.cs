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
        public int CUILTransportista { get; set; }
        public string NombreTransportista { get; set; }

        public Transportista(int cUILTransportista, string nombreTransportista)
        {
            CUILTransportista = cUILTransportista;
            NombreTransportista = nombreTransportista;
        }

    }
}
