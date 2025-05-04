using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._6._GenerarRemito
{
    internal class OrdenDeEntrega
    {
        
        
            public string NumeroOrden { get; set; }
            public string CUILTransportista { get; set; }

            public OrdenDeEntrega(string numeroOrden, string cuilTransportista)
            {
                NumeroOrden = numeroOrden;
                CUILTransportista = cuilTransportista;
            }

            public override string ToString()
            {
                return NumeroOrden;
            }
        

    }
}
