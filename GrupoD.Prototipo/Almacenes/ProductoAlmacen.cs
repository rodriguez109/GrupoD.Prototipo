using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Resources.ResXFileRef;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GrupoD.Prototipo.Almacenes
{
    internal static class ProductoAlmacen
    {
        private static List<ProductoEntidad> productos = new List<ProductoEntidad>();
        //Es una lista privada donde se guardan todos los productos que cargues. Solo la clase ProductoAlmacen puede modificarla directamente.

        public static IReadOnlyCollection<ProductoEntidad> Productos => productos.AsReadOnly();
        // versión pública de la lista, pero solo de lectura.
        // Sirve para que otras partes del sistema puedan consultar los productos, pero no puedan modificarlos.
        
        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(productos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(@"Datos\Producto.json", datos);
        }
        //Guarda la lista de productos en un archivo JSON.
        //Convierte la lista productos en un texto con formato JSON(Serialize).
        //Guarda ese texto en Datos\Productos.json.


        static ProductoAlmacen() //Lee el archivo Productos.json y recupera la lista de productos.
        {
            // Si el archivo NO existe, sale del método.
            //Si existe, lo lee, lo convierte desde JSON a lista(Deserialize) y lo carga en productos.
            if (!File.Exists(@"Datos\Producto.json")) 
            {
                return;
            }

            var datos = File.ReadAllText(@"Datos\Producto.json"); 
            productos = JsonSerializer.Deserialize<List<ProductoEntidad>>(datos)!;

        }
        public static void Agregar(ProductoEntidad producto)
        {
            productos.Add(producto); //Agrega un producto a la lista.
            Grabar(); //Luego llama a Grabar() para guardar la lista actualizada.
        }
    }
}

