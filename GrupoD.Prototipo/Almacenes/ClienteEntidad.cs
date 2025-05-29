using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    class ClienteEntidad
    {
        public int Numero { get; set; }
        public string RazonSocial { get; set; }
        public List<int> Productos { get; set; }

        public ClienteEntidad(int numero, string razonSocial)
        {
            Numero = numero;
            RazonSocial = razonSocial;
            Productos = new List<int>();
        }
    }
}
