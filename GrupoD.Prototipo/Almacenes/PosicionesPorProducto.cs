using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    class PosicionesPorProducto
    {
        public string Codigo { get; set; }
        public int Stock { get; set; }
        public string CodigoDeposito { get; set; }
        /*
        public PosicionesPorProducto(string codigo, int stock, string codigoDeposito)
        {
            Codigo = codigo;
            Stock = stock;
            CodigoDeposito = codigoDeposito;
        }*/
    }
}
