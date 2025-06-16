using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    internal class ProductoEntidad
    {
        public int SKU { get; set; }
        public string Nombre { get; set; }
        public List<PosicionesPorProducto> Posiciones { get; set; }
        public int NumeroCliente { get; set; }
        //public int Stock { get; set; }

        public int CantidadEnDeposito(string codigoDeposito)
        {
            return Posiciones.Where(p => p.CodigoDeposito == codigoDeposito).Select(p => p.Stock).DefaultIfEmpty().Sum();
        }
    }
}
