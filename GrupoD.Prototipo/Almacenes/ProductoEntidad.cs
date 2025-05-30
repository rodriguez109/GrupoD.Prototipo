﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    class ProductoEntidad
    {
        public int SKU { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public List<PosicionesPorProducto> Posiciones { get; set; }
        public int NumeroCliente { get; set; }

        public ProductoEntidad(int sku, string nombre, int cantidad, int numeroCliente)
        {
            SKU = sku;
            Nombre = nombre;
            Cantidad = cantidad;
            NumeroCliente = numeroCliente;
            Posiciones = new List<PosicionesPorProducto>();
        }
    }
}
