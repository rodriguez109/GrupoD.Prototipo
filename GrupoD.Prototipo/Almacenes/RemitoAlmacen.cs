using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    internal static class RemitoAlmacen
    {

        private static List<RemitoEntidad> remitos = new List<RemitoEntidad>();
        public static IReadOnlyList<RemitoEntidad> Remitos = remitos.AsReadOnly();


        static RemitoAlmacen() 
        {
            if (!File.Exists(@"Datos\Remito.json"))
            {
                return;
            }
            var datos = File.ReadAllText(@"Datos\Remito.json"); // Lee los datos del archivo
            remitos = JsonSerializer.Deserialize<List<RemitoEntidad>>(datos)!; // Deserializa los datos a la lista
        }

        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(remitos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(@"Datos\Remito.json", datos); // Escribe los datos al archivo
        }

        public static int NumeroRemito()
        {
            if (remitos.Any())
            {
                return remitos.Max(r => r.Numero) + 1;
            }
            else
            {
                return 1;
            }


        }

        public static void Agregar(RemitoEntidad remito)
        {
            remitos.Add(remito); 
            
        }

        
    }
}
