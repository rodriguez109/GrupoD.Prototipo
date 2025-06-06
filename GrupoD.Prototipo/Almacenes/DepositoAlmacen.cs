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

        public static string CodigoDepositoActual { get; set; } = "D01"; //TODO: sacar el "D01" cuando se pueda seleccionar desde el menu principal.

        public static IReadOnlyCollection<DepositoEntidad> Depositos => depositos.AsReadOnly();
        // versión pública de la lista, pero solo de lectura.
        // Sirve para que otras partes del sistema puedan consultar los Depositos, pero no puedan modificarlos.

        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(depositos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(@"Datos\Deposito.json", datos);
        }
        //Guarda la lista de depositos en un archivo JSON.
        //Convierte la lista depositos en un texto con formato JSON(Serialize).
        //Guarda ese texto en Datos\Depositos.json.


        static DepositoAlmacen() //Lee el archivo Depositos.json y recupera la lista de depositos.
        {
            // Si el archivo NO existe, sale del método.
            //Si existe, lo lee, lo convierte desde JSON a lista(Deserialize) y lo carga en productos.
            if (!File.Exists(@"Datos\Deposito.json"))
            {
                return;
            }

            var datos = File.ReadAllText(@"Datos\Deposito.json");
            depositos = JsonSerializer.Deserialize<List<DepositoEntidad>>(datos)!;

        }
        public static void Agregar(DepositoEntidad deposito)
        {
            depositos.Add(deposito); //Agrega un producto a la lista.
            Grabar(); //Luego llama a Grabar() para guardar la lista actualizada.
        }
    }
}
