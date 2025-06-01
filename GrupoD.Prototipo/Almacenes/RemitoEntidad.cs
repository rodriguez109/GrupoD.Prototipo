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
        public string NombreTransportista { get; set; } 
        public DateTime FechaEmision { get; set; }
        public List<int> OrdenesPreparacion { get; }

        public RemitoEntidad(int numero, int dniTransportista, string nombreTransportista, DateTime fechaEmision)
        {
            Numero = numero;
            DNITransportista = dniTransportista;
            NombreTransportista = nombreTransportista;
            FechaEmision = fechaEmision;
            OrdenesPreparacion = new List<int>();
        }
    }
}
