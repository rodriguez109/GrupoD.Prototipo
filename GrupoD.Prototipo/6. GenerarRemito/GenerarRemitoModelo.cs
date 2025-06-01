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
        private List<OrdenPreparacion> ordenes = new List<OrdenPreparacion>
{
    new OrdenPreparacion("1", "20242093"),
    new OrdenPreparacion("2", "27242093"),
    new OrdenPreparacion("3", "30242093"),
    new OrdenPreparacion("4", "31242093"),
    new OrdenPreparacion("5", "27242093"),  // Repetido
    new OrdenPreparacion("6", "20242093"),  // Repetido
    new OrdenPreparacion("7", "30242093"),  // Repetido
    new OrdenPreparacion("8", "31242093"),  // Repetido
    new OrdenPreparacion("9", "36242093"),
    new OrdenPreparacion("10", "37242093"),
    new OrdenPreparacion("11", "37242093"), // Repetido
    new OrdenPreparacion("12", "37242093"),  // Repetido
    new OrdenPreparacion("13", "38242093"),
    new OrdenPreparacion("14", "39242093"),
    new OrdenPreparacion("14", "40242093"),
    new OrdenPreparacion("15", "41242093"),
    new OrdenPreparacion("16", "42242093"),
    new OrdenPreparacion("17", "43242093"),
    new OrdenPreparacion("18", "44242093"),
    new OrdenPreparacion("19", "45242093"),
    new OrdenPreparacion("20", "46242093"), // repetido
    new OrdenPreparacion("21", "46242093"),











};


        public List<OrdenPreparacion> ObtenerOrdenesPorDNI(string dni)
        {
            return ordenes.Where(o => o.DNITransportista == dni).ToList();
        }


    }
}
