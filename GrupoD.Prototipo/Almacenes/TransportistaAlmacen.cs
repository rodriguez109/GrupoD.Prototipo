﻿using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    class TransportistaAlmacen
    {
        private static List<TransportistaEntidad> transportistas = new List<TransportistaEntidad>();
        public static IReadOnlyCollection<TransportistaEntidad> Transportistas => transportistas.AsReadOnly();

        static TransportistaAlmacen()
        {
            if (!File.Exists(@"Datos\Transportista.json")) 
            {
                return;
            }
            var datos = File.ReadAllText(@"Datos\Transportista.json"); 
            transportistas = JsonSerializer.Deserialize<List<TransportistaEntidad>>(datos)!; 
        }

        public static void Grabar()
        {
            var datos = JsonSerializer.Serialize(transportistas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(@"Datos\Transportista.json", datos); 
        }

        public static void Agregar(TransportistaEntidad transportista)
        {
            transportistas.Add(transportista); 
            Grabar(); 
        }

        public static TransportistaEntidad Buscar(int dni)
        {
            return transportistas.FirstOrDefault(t => t.DNI == dni);
        }


    }
}
