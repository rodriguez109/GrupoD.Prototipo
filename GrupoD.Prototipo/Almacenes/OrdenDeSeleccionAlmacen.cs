using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    internal static class OrdenDeSeleccionAlmacen
    {
        //Tengo una lista privada que yo puedo modificar (OS Almacen)
        private static List<OrdenDeSeleccionEntidad> ordenesDeSeleccion = new List<OrdenDeSeleccionEntidad>();

        //Metodo para leer los datos del archivo:
        static OrdenDeSeleccionAlmacen() //Metodo estático que me evita poner OrdenDeSeleccionAlmacen.Leer(); en el program
        {

            if (!File.Exists(@"Datos\OrdenesDeSeleccion.json")) //Si el archivo no existe, no hay mucho mas que hacer
            {
                return;
            }

            var datos = File.ReadAllText(@"Datos\OrdenesDeSeleccion.json"); //Esta parte lo termina de leer

            ordenesDeSeleccion = JsonSerializer.Deserialize<List<OrdenDeSeleccionEntidad>>(datos)!;
        }

        //Muestro una lista publica con todas las OS para que el resto del sistema consulte ReadOnly
        public static IReadOnlyCollection<OrdenDeSeleccionEntidad> OrdenesDeSeleccion => ordenesDeSeleccion.AsReadOnly();

        //Metodo para grabar los datos al archivo:
        //Aca pasamos la lista de OS a formato JSON (la transformamos a un string con los datos de todas las OS)

        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(ordenesDeSeleccion);
            File.WriteAllText(@"Datos\OrdenesDeSeleccion.json", datos); //Esta parte lo termina de escribir
        }

        //Metodo para leer los datos del archivo:

        //public static void Leer()
        //{
        //    if (!File.Exists(@"Datos\OrdenesDeSeleccion.json")) //Si el archivo no existe, no hay mucho mas que hacer
        //    {
        //        return;
        //    }

        //    var datos = File.ReadAllText(@"Datos\OrdenesDeSeleccion.json"); //Esta parte lo termina de leer

        //    ordenesDeSeleccion = JsonSerializer.Deserialize<List<OrdenDeSeleccionEntidad>>(datos)!;

        //}

        public static void Agregar(OrdenDeSeleccionEntidad ordenDeSeleccion)
        {
            ordenesDeSeleccion.Add(ordenDeSeleccion);
        }
    }
}
