using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    internal static class OrdenDeEntregaAlmacen
    {
        private static List<OrdenDeEntregaEntidad> ordenesDeEntrega = new List<OrdenDeEntregaEntidad>();

        public static IReadOnlyCollection<OrdenDeEntregaEntidad> OrdenesDeEntrega => ordenesDeEntrega.AsReadOnly();
        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(ordenesDeEntrega, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(@"Datos\OrdenDeEntrega.json", datos); //Esta parte lo termina de escribir
        }
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
        

        //Metodo para grabar los datos al archivo:
        //Aca pasamos la lista de OS a formato JSON (la transformamos a un string con los datos de todas las OS)

        

        public static void Agregar(OrdenDeEntregaEntidad ordenDeEntrega)
        {
            ordenesDeEntrega.Add(ordenDeEntrega);
            Grabar();
        }

        public static OrdenDeEntregaEntidad Buscar(int numero)
        {
            return ordenesDeEntrega.FirstOrDefault(o => o.Numero == numero);
        }


        public static void cambiarEstadoOE(int IdOP, EstadoOrdenDeEntregaEnum estado)
        {
            foreach (var ordEnt in ordenesDeEntrega)
            {
                if (ordEnt.Numero == IdOP)
                {
                    ordEnt.EstadoOrdenDeEntrega = estado;
                    Grabar();
                    return;
                }

            }
        }

        //cambiar el estado de las OE .cambiarEstadoOE
        //public static void cambiarEstadoOE
    }
}
