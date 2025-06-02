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
            if (!File.Exists(@"Datos\Remitos.json"))
            {
                return;
            }
            var datos = File.ReadAllText(@"Datos\Remitos.json"); // Lee los datos del archivo
            remitos = JsonSerializer.Deserialize<List<RemitoEntidad>>(datos)!; // Deserializa los datos a la lista
        }

        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(remitos);
            File.WriteAllText(@"Datos\Remitos.json", datos); // Escribe los datos al archivo
        }

        public static void Agregar(RemitoEntidad remito)
        {
            remitos.Add(remito); // Agrega el nuevo remito a la lista
            Grabar(); // Graba los cambios al archivo
        }

       




    }





}
