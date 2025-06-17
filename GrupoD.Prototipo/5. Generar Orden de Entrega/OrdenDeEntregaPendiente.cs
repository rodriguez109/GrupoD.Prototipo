using GrupoD.Prototipo;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo._3._PrepararProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    class OrdenDeEntregaPendiente
    {
        // Atributos
        public int NumeroOrden { get; set; }
        public List<OrdenDePreparacionClase> OrdenDePreparacionClase { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string EstadoOrdenDeEntrega { get; set; }

        // Constructor
        public OrdenDeEntregaPendiente(int numeroOrden, List<OrdenDePreparacionClase> ordenesPreparacion, DateTime fechaEntrega, string estadoOrdenDeEntrega)
        {
            NumeroOrden = numeroOrden;
            OrdenDePreparacionClase = ordenesPreparacion;
            FechaEntrega = fechaEntrega;
            EstadoOrdenDeEntrega = estadoOrdenDeEntrega;
        }

        // Constructor vacío para formulario
        public OrdenDeEntregaPendiente()
        {
            OrdenDePreparacionClase = new List<OrdenDePreparacionClase>();
            FechaEntrega = DateTime.Now;
            EstadoOrdenDeEntrega = "Pendiente";
        }
    }

}

