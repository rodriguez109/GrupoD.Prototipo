using GrupoD.Prototipo._0._Menu_Principal;
using GrupoD.Prototipo._6._GenerarRemito;

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
            Application.Run(new MenuForm());
        }
    }
}
