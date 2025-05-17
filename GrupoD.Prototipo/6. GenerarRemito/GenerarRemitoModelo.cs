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
    new OrdenDeEntrega("1", "20242093"),
    new OrdenDeEntrega("2", "27242093"),
    new OrdenDeEntrega("3", "30242093"),
    new OrdenDeEntrega("4", "31242093"),
    new OrdenDeEntrega("5", "27242093"),  // Repetido
    new OrdenDeEntrega("6", "20242093"),  // Repetido
    new OrdenDeEntrega("7", "30242093"),  // Repetido
    new OrdenDeEntrega("8", "31242093"),  // Repetido
    new OrdenDeEntrega("9", "36242093"),
    new OrdenDeEntrega("10", "37242093"),
    new OrdenDeEntrega("11", "37242093"), // Repetido
    new OrdenDeEntrega("12", "37242093"),  // Repetido
    new OrdenDeEntrega("13", "38242093"),
    new OrdenDeEntrega("14", "39242093"),
    new OrdenDeEntrega("14", "40242093"),
    new OrdenDeEntrega("15", "41242093"),
    new OrdenDeEntrega("16", "42242093"),
    new OrdenDeEntrega("17", "43242093"),
    new OrdenDeEntrega("18", "44242093"),
    new OrdenDeEntrega("19", "45242093"),
    new OrdenDeEntrega("20", "46242093"), // repetido
    new OrdenDeEntrega("21", "46242093"),











};


        public List<OrdenDeEntrega> ObtenerOrdenesPorDNI(string dni)
        {
            return ordenes.Where(o => o.DNITransportista == dni).ToList();
        }


    }
}
