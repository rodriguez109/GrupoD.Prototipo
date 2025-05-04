using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    public class OrdenEntregaModelo
    {
        public int NumeroOrden { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaEntrega { get; set; }
        public long CUIL { get; set; }
    }

}

