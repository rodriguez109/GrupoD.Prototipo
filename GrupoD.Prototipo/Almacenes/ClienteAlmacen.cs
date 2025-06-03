using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    internal static class ClienteAlmacen
    {
        private static List<ClienteEntidad> clientes = new List<ClienteEntidad>();
        public static IReadOnlyCollection<ClienteEntidad> Clientes => clientes.AsReadOnly();
   
        static ClienteAlmacen()
        {
            if (!File.Exists(@"Datos\Clientes.json"))
            {
                return;
            }
            var datos = File.ReadAllText(@"Datos\Clientes.json");
            clientes = JsonSerializer.Deserialize<List<ClienteEntidad>>(datos)!;
        }
        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(clientes);
            File.WriteAllText(@"Datos\Clientes.json", datos);
        }
        public static void Agregar(ClienteEntidad cliente)
        {
            clientes.Add(cliente);
            Grabar();
        }
    }
}
