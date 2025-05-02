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
            new OrdenesDePreparacion(1, "DecoHogar S.A.", DateTime.Today.AddDays(0), "Transporte Sur", "Alta"),
            new OrdenesDePreparacion(2, "MaxiLuz Iluminación SRL", DateTime.Today.AddDays(1), "Express Cargo", "Media"),
            new OrdenesDePreparacion(3, "MundoFOX S.A.", DateTime.Today.AddDays(2), "Logística Norte", "Baja"),
            new OrdenesDePreparacion(4, "FullColor Pinturerías SRL", DateTime.Today.AddDays(3), "Transporte Sur", "Alta"),
            new OrdenesDePreparacion(5, "Hogar Urbano S.A.", DateTime.Today.AddDays(4), "Rápido S.A.", "Media"),
            new OrdenesDePreparacion(6, "Todo Obra Ferretería SRL", DateTime.Today.AddDays(5), "Logística Norte", "Alta"),
            new OrdenesDePreparacion(7, "Casa Nova Equipamientos S.A.", DateTime.Today.AddDays(6), "Transporte Sur", "Baja"),
            new OrdenesDePreparacion(8, "OfiMarket SRL", DateTime.Today.AddDays(7), "Express Cargo", "Alta"),
            new OrdenesDePreparacion(9, "Red Tools S.A.", DateTime.Today.AddDays(8), "Logística Norte", "Media"),
            new OrdenesDePreparacion(10, "MegaMuebles SRL", DateTime.Today.AddDays(9), "Rápido S.A.", "Baja"),
            new OrdenesDePreparacion(11, "ElectroCity S.A.", DateTime.Today.AddDays(10), "Transporte Sur", "Alta"),
            new OrdenesDePreparacion(12, "PlastiSur SRL", DateTime.Today.AddDays(11), "Logística Norte", "Media"),
            new OrdenesDePreparacion(13, "Tecnoshop S.A.", DateTime.Today.AddDays(12), "Rápido S.A.", "Baja"),
            new OrdenesDePreparacion(14, "Urban Market SRL", DateTime.Today.AddDays(13), "Express Cargo", "Alta"),
            new OrdenesDePreparacion(15, "DecoCentro S.A.", DateTime.Today.AddDays(14), "Transporte Sur", "Media"),
            new OrdenesDePreparacion(16, "Centro Herramientas SRL", DateTime.Today.AddDays(15), "Logística Norte", "Baja"),
            new OrdenesDePreparacion(17, "FullOffice S.A.", DateTime.Today.AddDays(16), "Rápido S.A.", "Alta"),
            new OrdenesDePreparacion(18, "DecorArte SRL", DateTime.Today.AddDays(17), "Express Cargo", "Media"),
            new OrdenesDePreparacion(19, "EasyTech Distribuciones S.A.", DateTime.Today.AddDays(18), "Transporte Sur", "Alta"),
            new OrdenesDePreparacion(20, "FerreMarket SRL", DateTime.Today.AddDays(19), "Logística Norte", "Baja")
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
