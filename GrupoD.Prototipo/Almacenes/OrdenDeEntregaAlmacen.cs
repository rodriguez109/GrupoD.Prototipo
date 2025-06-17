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
        // lista privada para modificar
        private static List<OrdenDeEntregaEntidad> ordenesDeEntrega = new List<OrdenDeEntregaEntidad>();
        // metodo para leer los datos del archivo:
        static OrdenDeEntregaAlmacen()
        {
            if (!File.Exists(@"Datos\OrdenDeEntrega.json"))
            {
                return;
            }
            var datos = File.ReadAllText(@"Datos\OrdenDeEntrega.json"); //Esta parte lo termina de leer

            ordenesDeEntrega = JsonSerializer.Deserialize<List<OrdenDeEntregaEntidad>>(datos)!;

        }
        //Muestro una lista publica con todas las OE para que el resto del sistema consulte ReadOnly
        public static IReadOnlyCollection<OrdenDeEntregaEntidad> OrdenesDeEntrega => ordenesDeEntrega.AsReadOnly();
        //Metodo para grabar los datos al archivo: pasamos la lista de OE a formato JSON (la transformamos a un string con los datos de todas las OE)
        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(ordenesDeEntrega, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(@"Datos\OrdenDeEntrega.json", datos); //Esta parte lo termina de escribir
        }
        //Metodo para agregar una nueva orden de entrega
        public static void Agregar(OrdenDeEntregaEntidad ordenDeEntrega)
        {
            ordenesDeEntrega.Add(ordenDeEntrega);
            Grabar(); // <--- guardar cambios en archivo JSON
        }

        public static OrdenDeEntregaEntidad Buscar(int numero)
        {
            return ordenesDeEntrega.FirstOrDefault(o => o.Numero == numero);
        }
        //public static void cambiarEstadoOE
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
    }
}
