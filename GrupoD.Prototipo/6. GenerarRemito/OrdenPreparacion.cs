using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._6._GenerarRemito
{
    internal class OrdenPreparacion
    {
        
        
            public string NumeroOrden { get; set; }
            public string DNITransportista { get; set; }

            public OrdenPreparacion(string numeroOrden, string dniTransportista)
            {
                NumeroOrden = numeroOrden;
                DNITransportista = dniTransportista;
            }

            public override string ToString()
            {
                return NumeroOrden;
            }
        

    }
}
