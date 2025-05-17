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

        public GenerarOrdenSeleccionModelo()
        {
            OrdenesPreparacionDisponibles = new List<OrdenesDePreparacion>
            {
                new OrdenesDePreparacion(1, "DecoHogar S.A.", DateTime.Today.AddDays(0), 20242093500, "Alta"),
                new OrdenesDePreparacion(2, "MaxiLuz Iluminación SRL", DateTime.Today.AddDays(1), 27242093513, "Media"),
                new OrdenesDePreparacion(3, "MundoFOX S.A.", DateTime.Today.AddDays(2), 20242093527, "Baja"),
                new OrdenesDePreparacion(4, "FullColor Pinturerías SRL", DateTime.Today.AddDays(3), 27242093534, "Alta"),
                new OrdenesDePreparacion(5, "Hogar Urbano S.A.", DateTime.Today.AddDays(4), 20242093543, "Media"),
                new OrdenesDePreparacion(6, "Todo Obra Ferretería SRL", DateTime.Today.AddDays(5), 27242093552, "Alta"),
                new OrdenesDePreparacion(7, "Casa Nova Equipamientos S.A.", DateTime.Today.AddDays(6), 20242093560, "Baja"),
                new OrdenesDePreparacion(8, "OfiMarket SRL", DateTime.Today.AddDays(7), 27242093577, "Alta"),
                new OrdenesDePreparacion(9, "Red Tools S.A.", DateTime.Today.AddDays(8), 20242093586, "Media"),
                new OrdenesDePreparacion(10, "MegaMuebles SRL", DateTime.Today.AddDays(9), 27242093593, "Baja"),
                new OrdenesDePreparacion(11, "ElectroCity S.A.", DateTime.Today.AddDays(10), 20242093608, "Alta"),
                new OrdenesDePreparacion(12, "PlastiSur SRL", DateTime.Today.AddDays(11), 27242093615, "Media"),
                new OrdenesDePreparacion(13, "Tecnoshop S.A.", DateTime.Today.AddDays(12), 20242093624, "Baja"),
                new OrdenesDePreparacion(14, "Urban Market SRL", DateTime.Today.AddDays(13), 27242093631, "Alta"),
                new OrdenesDePreparacion(15, "DecoCentro S.A.", DateTime.Today.AddDays(14), 20242093640, "Media"),
                new OrdenesDePreparacion(16, "Centro Herramientas SRL", DateTime.Today.AddDays(15), 27242093658, "Baja"),
                new OrdenesDePreparacion(17, "FullOffice S.A.", DateTime.Today.AddDays(16), 20242093667, "Alta"),
                new OrdenesDePreparacion(18, "DecorArte SRL", DateTime.Today.AddDays(17), 27242093674, "Media"),
                new OrdenesDePreparacion(19, "EasyTech Distribuciones S.A.", DateTime.Today.AddDays(18), 20242093683, "Alta"),
                new OrdenesDePreparacion(20, "FerreMarket SRL", DateTime.Today.AddDays(19), 27242093690, "Baja"),
            };


            OrdenesAgregadas = new List<OrdenesDePreparacion>(); // Inicializar la nueva lista
            OrdenesDeSeleccion = new List<OrdenesDeSeleccion>();  // Lista de órdenes de selección
        }

    }
}
