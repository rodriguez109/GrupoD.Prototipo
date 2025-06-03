using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    class RemitoEntidad
    {
        public int Numero { get; set; }
        public int DNITransportista { get; set; }
        public DateTime FechaEmision { get; set; }
        public List<int> OrdenesPreparacion { get; }

        public RemitoEntidad(int numero, int dniTransportista, DateTime fechaEmision)
        {
            Numero = numero;
            DNITransportista = dniTransportista;
            FechaEmision = fechaEmision;
            OrdenesPreparacion = new List<int>();
        }
    }
}
