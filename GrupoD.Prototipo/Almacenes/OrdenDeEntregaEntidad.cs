using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    class OrdenDeEntregaEntidad
    {
        public int Numero { get; set; }
        public List<int> OrdenesPreparacion { get; set; }
        public DateTime FechaGeneracion  { get; set; } 
        public EstadoOrdenDeEntregaEnum EstadoOrdenDeEntrega { get; set; }
        
    }
}

