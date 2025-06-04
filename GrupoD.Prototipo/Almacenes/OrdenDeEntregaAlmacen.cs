using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    internal static class OrdenDeEntregaAlmacen
    {
        private static List<OrdenDeEntregaEntidad> ordenesDeEntrega = new List<OrdenDeEntregaEntidad>();

        static OrdenDeEntregaAlmacen()
        {
            if (!File.Exists(@"Datos\OrdenDeEntrega.json")) 
            {
                return;
            }
            var datos = File.ReadAllText(@"Datos\OrdenDeEntrega.json"); //Esta parte lo termina de leer

            ordenesDeEntrega = JsonSerializer.Deserialize<List<OrdenDeEntregaEntidad>>(datos)!;

        }
        //Muestro una lista publica con todas las OS para que el resto del sistema consulte ReadOnly
        public static IReadOnlyCollection<OrdenDeEntregaEntidad> OrdenesDeEntrega => ordenesDeEntrega.AsReadOnly();

        //Metodo para grabar los datos al archivo:
        //Aca pasamos la lista de OS a formato JSON (la transformamos a un string con los datos de todas las OS)

        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(ordenesDeEntrega);
            File.WriteAllText(@"Datos\OrdenDeEntrega.json", datos); //Esta parte lo termina de escribir
        }

        public static void Agregar(OrdenDeEntregaEntidad ordenDeEntrega)
        {
            ordenesDeEntrega.Add(ordenDeEntrega);
        }

        //cambiar el estado de las OE .cambiarEstadoOE
        //public static void cambiarEstadoOE
    }
}
