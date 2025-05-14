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

      
        public OrdenEntrega(DateTime fecha, int numero, string cliente, string transportista, long cuit)
        {
            NumeroOrden = numero;
            Cliente = cliente;
            FechaEntrega = fecha;
            CUIT = cuit;
            Transportista = transportista;
        }

       
        public DateTime FechaEntrega { get; set; }
        public int NumeroOrden { get; set; }
        public string Cliente { get; set; }
        public long CUIT { get; set; }
        public string Transportista { get; set; }
    }
}

