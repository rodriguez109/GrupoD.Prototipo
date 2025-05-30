﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.Almacenes
{
    class OrdenDePreparacionEntidad
    {
        public int Numero { get; set; }
        public bool Pallet { get; set; }
        public string CodigoAlmacen { get; set; }
        public List<ProductosPorOrden> Detalle { get; set; }
        public DateTime FechaRetirar { get; set; }
        public PrioridadEnum Prioridad { get; set; }
        public int NumeroCliente { get; set; }
        public int DNITransportista { get; set; }
        public EstadoOrdenDePreparacionEnum Estado { get; set; }

        public OrdenDePreparacionEntidad(int numero, string codigoAlmacen, DateTime fechaRetirar, PrioridadEnum prioridad, int numeroCliente, int dniTransportista)
        {
            Numero = numero;
            CodigoAlmacen = codigoAlmacen;
            FechaRetirar = fechaRetirar;
            Prioridad = prioridad;
            NumeroCliente = numeroCliente;
            DNITransportista = dniTransportista;
            Detalle = new List<ProductosPorOrden>();
            Estado = EstadoOrdenDePreparacionEnum.Pendiente;
            Pallet = false; //------
        }
    }
}
