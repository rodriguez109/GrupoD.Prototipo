using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._6._GenerarRemito
{
    internal class OrdenPreparacion
    {
        
        
            public int NumeroOrden { get; set; }
            public int DNITransportista { get; set; }

            public OrdenPreparacion(int numeroOrden, int dniTransportista)
            {
                NumeroOrden = numeroOrden;
                DNITransportista = dniTransportista;
            }

            public override string ToString()
            {
               return NumeroOrden.ToString();
            }
        

    }
}
