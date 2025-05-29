using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    internal static class ClienteAlmacen
    {
        //cambiar nombre a internal static class
        private static List <ClienteEntidad> clientes = new List<ClienteEntidad> ();
        public static IReadOnlyList<ClienteEntidad> Clientes = clientes.AsReadOnly();
        public static void AgregarCliente(ClienteEntidad cliente)
        {
            //validaciones de negocio
            //clientes.Add(cliente)
        }
        public static void BorrarPersonas(int numerocliente)
        {
            //algo aca validaciones
            //clientes = RemoveAll(c => c.==numerocliente);
        }
        //PARA TODOS SON STATIC
        //aca viene el tema de los json --- vinculados a la carpeta datos con los files dentro
        //if(File.Exists("clientes.json") -- OJO con el tema del archivo /Datos/Clientes.json
        //{
        //   var contenido = File.ReadAllText("clientes json"); --- lo devuelve como string
        //   clientes = JsonSerializer.Deserialize<List<ClienteEntidad>>(contenido)
        //}

        //metodo para guardar datos
        public static void GuardarDatos()
        {
            //var contenido = JsonSerializer(clientes);
            //File.WriteAllText("clientes.json", contenido);
        }
        //SOLO EN Program: ClienteAlmacen.GuardarDatos();

        //SOLO EN MODELO:
//        Class NuevaPersonaModelo
//        {
//            Public List<Persona> Personas
//            {
//                Get
//            {
//                    var personas = new List<Persona>();
//                    foreach (var personaEntidad in PersonaAlmacen Personas)
//{
//                        personas.Add(new Persona)
//{
//                            Apellido = personaEntidad.Apellido,
//Documento = personaEntidad.Documento,
//(…)
//}
//                    }
//                }
//            }
//        }
    }
}
