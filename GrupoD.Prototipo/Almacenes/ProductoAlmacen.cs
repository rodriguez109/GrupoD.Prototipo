using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    internal static class ProductoAlmacen
    {
        //Tengo una lista privada que yo puedo modificar (ProductoAlmacen)
        private static List<ProductoEntidad> productos = new List<ProductoEntidad>();

        //Muestro una lista publica con todos los productos para que el resto del sistema consulte ReadOnly
        public static IReadOnlyCollection<ProductoEntidad> Productos => productos.AsReadOnly();

        //Metodo para grabar los datos al archivo:
        //Aca pasamos la lista de Productos a formato JSON (la transformamos a un string con los datos de todos los Productos)
        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(productos);
            File.WriteAllText(@"Datos\Productos.json", datos); //Esta parte lo termina de escribir
        }

        //Metodo para leer los datos del archivo:
        public static void Leer()
        {
            if (!File.Exists(@"Datos\Productos.json")) //Si el archivo no existe, no hay mucho mas que hacer
            {
                return;
            }

            var datos = File.ReadAllText(@"Datos\Productos.json"); //Esta parte lo termina de leer

            productos = JsonSerializer.Deserialize<List<ProductoEntidad>>(datos)!;

        }
        public static void Agregar(ProductoEntidad producto)
        {
            productos.Add(producto);
            Grabar();
        }
    }
}

