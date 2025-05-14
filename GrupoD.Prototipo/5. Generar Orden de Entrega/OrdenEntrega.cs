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
       
        public OrdenEntrega() { }

      
        public OrdenEntrega(DateTime fecha, int numero, string cliente, string transportista, long cuil)
        {
            NumeroOrden = numero;
            Cliente = cliente;
            FechaEntrega = fecha;
            CUIL = cuil;
            Transportista = transportista;
        }

       
        public DateTime FechaEntrega { get; set; }
        public int NumeroOrden { get; set; }
        public string Cliente { get; set; }
        public long CUIL { get; set; }
        public string Transportista { get; set; }
    }
}

