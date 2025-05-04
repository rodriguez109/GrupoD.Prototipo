using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;

namespace GrupoD.Prototipo._6._GenerarRemito
{
    internal class GenerarRemitoModelo
    {
        private List<OrdenDeEntrega> ordenes = new List<OrdenDeEntrega>
        {
        new OrdenDeEntrega("1", "20242093500"),
        new OrdenDeEntrega("2", "27242093513"),
        new OrdenDeEntrega("3", "20242093527"),
        new OrdenDeEntrega("4", "27242093534"),
        new OrdenDeEntrega("5", "27242093534"),
        new OrdenDeEntrega("6", "20242093543"),
        new OrdenDeEntrega("7", "20242093543"),
        new OrdenDeEntrega("8", "20242093543"),
        new OrdenDeEntrega("9", "27242093552"),
        new OrdenDeEntrega("9", "20242093560"),
        new OrdenDeEntrega("9", "27242093577"),



        };

        public List<OrdenDeEntrega> ObtenerOrdenesPorCUIL(string cuil)
        {
            return ordenes.Where(o => o.CUILTransportista == cuil).ToList();
        }

    }
}
