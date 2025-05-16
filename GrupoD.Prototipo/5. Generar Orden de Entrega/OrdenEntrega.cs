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
        public string Cliente { get; set; }
        public DateTime FechaEntrega { get; set; }
        public long CUIL { get; set; }

        public OrdenEntrega(int numero, string cliente, DateTime fecha, long cuil)
        {
            NumeroOrden = numero;
            Cliente = cliente;
            FechaEntrega = fecha;
            CUIL = cuil;
        }
    }

}
