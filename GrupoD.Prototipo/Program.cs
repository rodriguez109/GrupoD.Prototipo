using GrupoD.Prototipo._0._Menu_Principal;
using GrupoD.Prototipo._6._GenerarRemito;
using GrupoD.Prototipo.Almacenes;
using Prototipo.PrepararProductos;
using System.Windows.Forms;

namespace GrupoD.Prototipo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Leer datos desde almacenes (TODOS)
            //OrdenDeSeleccionAlmacen.Leer(); Si hago el metodo estatico en el almacen, no debo hacer esto

            Application.Run(new MenuForm());

            //Grabar datos desde almacenes (TODOS)
            OrdenDeSeleccionAlmacen.Grabar();
        }
    }
}
