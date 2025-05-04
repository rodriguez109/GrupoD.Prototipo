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
                new OrdenesDePreparacion(1, "DecoHogar S.A.", DateTime.Today.AddDays(0), 242093500, "Alta"),
                new OrdenesDePreparacion(2, "MaxiLuz Iluminación SRL", DateTime.Today.AddDays(1), 242093513, "Media"),
                new OrdenesDePreparacion(3, "MundoFOX S.A.", DateTime.Today.AddDays(2), 242093527, "Baja"),
                new OrdenesDePreparacion(4, "FullColor Pinturerías SRL", DateTime.Today.AddDays(3), 242093534, "Alta"),
                new OrdenesDePreparacion(5, "Hogar Urbano S.A.", DateTime.Today.AddDays(4), 242093543, "Media"),
                new OrdenesDePreparacion(6, "Todo Obra Ferretería SRL", DateTime.Today.AddDays(5), 242093552, "Alta"),
                new OrdenesDePreparacion(7, "Casa Nova Equipamientos S.A.", DateTime.Today.AddDays(6), 242093560, "Baja"),
                new OrdenesDePreparacion(8, "OfiMarket SRL", DateTime.Today.AddDays(7), 242093577, "Alta"),
                new OrdenesDePreparacion(9, "Red Tools S.A.", DateTime.Today.AddDays(8), 242093586, "Media"),
                new OrdenesDePreparacion(10, "MegaMuebles SRL", DateTime.Today.AddDays(9), 242093593, "Baja"),
                new OrdenesDePreparacion(11, "ElectroCity S.A.", DateTime.Today.AddDays(10), 242093608, "Alta"),
                new OrdenesDePreparacion(12, "PlastiSur SRL", DateTime.Today.AddDays(11), 242093615, "Media"),
                new OrdenesDePreparacion(13, "Tecnoshop S.A.", DateTime.Today.AddDays(12), 242093624, "Baja"),
                new OrdenesDePreparacion(14, "Urban Market SRL", DateTime.Today.AddDays(13), 242093631, "Alta"),
                new OrdenesDePreparacion(15, "DecoCentro S.A.", DateTime.Today.AddDays(14), 242093640, "Media"),
                new OrdenesDePreparacion(16, "Centro Herramientas SRL", DateTime.Today.AddDays(15), 242093658, "Baja"),
                new OrdenesDePreparacion(17, "FullOffice S.A.", DateTime.Today.AddDays(16), 242093667, "Alta"),
                new OrdenesDePreparacion(18, "DecorArte SRL", DateTime.Today.AddDays(17), 242093674, "Media"),
                new OrdenesDePreparacion(19, "EasyTech Distribuciones S.A.", DateTime.Today.AddDays(18), 242093683, "Alta"),
                new OrdenesDePreparacion(20, "FerreMarket SRL", DateTime.Today.AddDays(19), 242093690, "Baja"),
            };

            OrdenesAgregadas = new List<OrdenesDePreparacion>(); // Inicializar la nueva lista
            OrdenesDeSeleccion = new List<OrdenesDeSeleccion>();  // Lista de órdenes de selección
        }

        //validar todo
        //1) el apellido no puede estar vacio
        //2) el apellido no puede tener mas de X caracteres
        //3) tratamiento no valido
        // ya existe una persona con mismo numero de dni y tipo
        // hacer lo que haiga que hacer para guardar la informacion

        // aca van las listas con datos inventados

    }
}
