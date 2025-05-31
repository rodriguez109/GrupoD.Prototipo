using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using Prototipo.PrepararProductos.PrepararProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._6._GenerarRemito
{
    internal class GenerarRemitoModelo
    {
        private List<OrdenDeSeleccion> ordenes = new List<OrdenDeSeleccion>
{
    new OrdenDeSeleccion("1", "20242093"),
    new OrdenDeSeleccion("2", "27242093"),
    new OrdenDeSeleccion("3", "30242093"),
    new OrdenDeSeleccion("4", "31242093"),
    new OrdenDeSeleccion("5", "27242093"),  // Repetido
    new OrdenDeSeleccion("6", "20242093"),  // Repetido
    new OrdenDeSeleccion("7", "30242093"),  // Repetido
    new OrdenDeSeleccion("8", "31242093"),  // Repetido
    new OrdenDeSeleccion("9", "36242093"),
    new OrdenDeSeleccion("10", "37242093"),
    new OrdenDeSeleccion("11", "37242093"), // Repetido
    new OrdenDeSeleccion("12", "37242093"),  // Repetido
    new OrdenDeSeleccion("13", "38242093"),
    new OrdenDeSeleccion("14", "39242093"),
    new OrdenDeSeleccion("14", "40242093"),
    new OrdenDeSeleccion("15", "41242093"),
    new OrdenDeSeleccion("16", "42242093"),
    new OrdenDeSeleccion("17", "43242093"),
    new OrdenDeSeleccion("18", "44242093"),
    new OrdenDeSeleccion("19", "45242093"),
    new OrdenDeSeleccion("20", "46242093"), // repetido
    new OrdenDeSeleccion("21", "46242093"),











};


        public List<OrdenDeSeleccion> ObtenerOrdenesPorDNI(string dni)
        {
            return ordenes.Where(o => o.DNITransportista == dni).ToList();
        }


    }
}
