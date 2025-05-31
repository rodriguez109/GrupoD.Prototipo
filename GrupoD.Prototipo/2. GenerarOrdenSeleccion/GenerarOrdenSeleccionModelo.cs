using GrupoD.Prototipo.CDU2._GenerarOrdenSeleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._2._GenerarOrdenSeleccion
{
    class GenerarOrdenSeleccionModelo
    {
        public List<OrdenesDePreparacion> OrdenesPreparacionDisponibles { get; set; }
        public List<OrdenesDeSeleccion> OrdenesDeSeleccion { get; set; }  // Agregar esta propiedad
        public List<OrdenesDePreparacion> OrdenesAgregadas { get; set; } // Lista de órdenes ya agregadas


        //Aca deberia:

        //Obtener las órdenes de preparación pendientes desde el almacenamiento

        //Seleccionar las OP Pendientes y generar una nueva OS a partir de ellas, con estado "Pendiente"

        //Guarda los cambios

        public GenerarOrdenSeleccionModelo()
        {
            OrdenesPreparacionDisponibles = new List<OrdenesDePreparacion>
            {
                new OrdenesDePreparacion(1, "DecoHogar S.A.", DateTime.Today.AddDays(0), 20242093, "Alta"),
                new OrdenesDePreparacion(2, "MaxiLuz Iluminación SRL", DateTime.Today.AddDays(1), 27242093, "Media"),
                new OrdenesDePreparacion(3, "MundoFOX S.A.", DateTime.Today.AddDays(2), 30242093, "Baja"),
                new OrdenesDePreparacion(4, "FullColor Pinturerías SRL", DateTime.Today.AddDays(3), 31242093, "Alta"),
                new OrdenesDePreparacion(5, "Hogar Urbano S.A.", DateTime.Today.AddDays(4), 36242093, "Media"),
                new OrdenesDePreparacion(6, "Todo Obra Ferretería SRL", DateTime.Today.AddDays(5), 37242093, "Alta"),
                new OrdenesDePreparacion(7, "Casa Nova Equipamientos S.A.", DateTime.Today.AddDays(6), 38242093, "Baja"),
                new OrdenesDePreparacion(8, "OfiMarket SRL", DateTime.Today.AddDays(7), 39242093, "Alta"),
                new OrdenesDePreparacion(9, "Red Tools S.A.", DateTime.Today.AddDays(8), 40242093, "Media"),
                new OrdenesDePreparacion(10, "MegaMuebles SRL", DateTime.Today.AddDays(9), 41242093, "Baja"),
                new OrdenesDePreparacion(11, "ElectroCity S.A.", DateTime.Today.AddDays(10), 42242093, "Alta"),
                new OrdenesDePreparacion(12, "PlastiSur SRL", DateTime.Today.AddDays(11), 43242093, "Media"),
                new OrdenesDePreparacion(13, "Tecnoshop S.A.", DateTime.Today.AddDays(12), 44242093, "Baja"),
                new OrdenesDePreparacion(14, "Urban Market SRL", DateTime.Today.AddDays(13), 45242093, "Alta"),
                new OrdenesDePreparacion(15, "DecoCentro S.A.", DateTime.Today.AddDays(14), 46242093, "Media"),
                new OrdenesDePreparacion(16, "Centro Herramientas SRL", DateTime.Today.AddDays(15), 47242093, "Baja"),
                new OrdenesDePreparacion(17, "FullOffice S.A.", DateTime.Today.AddDays(16), 48242093, "Alta"),
                new OrdenesDePreparacion(18, "DecorArte SRL", DateTime.Today.AddDays(17), 49242093, "Media"),
                new OrdenesDePreparacion(19, "EasyTech Distribuciones S.A.", DateTime.Today.AddDays(18), 50242093, "Alta"),
                new OrdenesDePreparacion(20, "FerreMarket SRL", DateTime.Today.AddDays(19), 51242093, "Baja"),
            };



            OrdenesAgregadas = new List<OrdenesDePreparacion>(); // Inicializar la nueva lista
            OrdenesDeSeleccion = new List<OrdenesDeSeleccion>();  // Lista de órdenes de selección
        }

    }
}
