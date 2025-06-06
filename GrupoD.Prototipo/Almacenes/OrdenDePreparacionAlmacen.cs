﻿using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo.Almacenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    internal static class OrdenDePreparacionAlmacen
    {
        //Lista privada que yo puedo modificar
        private static List<OrdenDePreparacionEntidad> ordenesDePreparacion = new List<OrdenDePreparacionEntidad>();

        //Lista publica con todas las OP para que el resto del sistema consulte ReadOnly
        public static IReadOnlyCollection<OrdenDePreparacionEntidad> OrdenesDePreparacion => ordenesDePreparacion.AsReadOnly();

        //Metodo para grabar los datos al archivo:
        //Aca pasamos la lista de OP a formato JSON
        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(ordenesDePreparacion, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(@"Datos\OrdenDePreparacion.json", datos); //Escribe los datos al archivo
        }

        //Metodo para leer los datos del archivo
        static OrdenDePreparacionAlmacen()
        {
            if (!File.Exists(@"Datos\OrdenDePreparacion.json")) //Si el archivo no existe, no hay mucho mas que hacer
            {
                return;
            }
            var datos = File.ReadAllText(@"Datos\OrdenDePreparacion.json"); //Lee los datos del archivo
            ordenesDePreparacion = JsonSerializer.Deserialize<List<OrdenDePreparacionEntidad>>(datos)!; //Deserializa los datos a la lista
        }

        //Metodo para agregar una nueva orden de preparacion
        public static void Agregar(OrdenDePreparacionEntidad ordenDePreparacion)
        {
            ordenesDePreparacion.Add(ordenDePreparacion); //Agrega la nueva orden a la lista
            Grabar(); //Graba los cambios al archivo
        }

        public static OrdenDePreparacionEntidad Buscar(int numero)
        {
            return ordenesDePreparacion.FirstOrDefault(o => o.Numero == numero);
        }


        public static void cambiarEstado(int IdOP, EstadoOrdenDePreparacionEnum estado)
        {
            foreach (var ordEnt in ordenesDePreparacion)
            {
                if (ordEnt.Numero == IdOP)
                {
                    ordEnt.Estado = estado;
                    Grabar();
                    return;
                }

            }
        }
    }

}
