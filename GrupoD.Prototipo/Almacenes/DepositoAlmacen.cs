using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    internal static class DepositoAlmacen
    {
        private static List<DepositoEntidad> depositos = new List<DepositoEntidad>();
        //Es una lista privada donde se guardan todos los depositos que cargues. Solo la clase DepositoAlmacen puede modificarla directamente.        

        public static string CodigoDepositoActual { get; set; }

        public static IReadOnlyCollection<DepositoEntidad> Depositos => depositos.AsReadOnly();
        // Sirve para que otras partes del sistema puedan consultar los Depositos, pero no puedan modificarlos.

        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(depositos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(@"Datos\Deposito.json", datos);
        }
        //Convierte la lista depositos en un texto con formato JSON(Serialize).

        //Lee el archivo Depositos.json y recupera la lista de depositos.
        static DepositoAlmacen() 
        {
            if (!File.Exists(@"Datos\Deposito.json"))
            {
                return;
            }

            var datos = File.ReadAllText(@"Datos\Deposito.json");
            depositos = JsonSerializer.Deserialize<List<DepositoEntidad>>(datos)!;
        }
        public static void Agregar(DepositoEntidad deposito)
        {
            depositos.Add(deposito); 
            Grabar(); //guarda la lista actualizada
        }
    }
}
