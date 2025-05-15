using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion
{
    internal class OrdenDePreparacionClase
    {
        public int? NumeroOrdenPreparacion { get; set; }

        public int SKUProducto { get; set; }
        public string NombreProducto { get; set; }

        public string CantidadProducto { get; set; }

        public string Posicion { get; set; }
        public DateTime FechaRetirar { get; set; }
      
        public string Prioridad { get; set; }

        public string CUILTransportista { get; set; }

        public int NumeroCliente { get; set; }

        public string RazonSocialCliente { get; set; }

    }
}
