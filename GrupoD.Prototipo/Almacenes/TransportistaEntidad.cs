using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    class TransportistaEntidad
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }

        public TransportistaEntidad(int dni, string nombre)
        {
            DNI = dni;
            Nombre = nombre;
        }
    }
}
