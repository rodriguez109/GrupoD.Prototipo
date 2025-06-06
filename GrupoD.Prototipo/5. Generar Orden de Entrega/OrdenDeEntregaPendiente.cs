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
    class OrdenDeEntregaPendiente //refleja datos del json
    {
        public int NumeroOrden { get; set; }

        public DateTime FechaEntrega { get; set; }

        public string EstadoOrdenDeEntrega { get; set; }
        public List<OrdenDePreparacionClase> OrdenDePreparacionClase { get; set; }


        public OrdenDeEntregaPendiente(int numeroOrden, DateTime fechaEntrega, string estadoOrdenDeEntrega, List<OrdenDePreparacionClase> ordenesPreparacion)
        {
            NumeroOrden = numeroOrden;

            FechaEntrega = fechaEntrega;

            EstadoOrdenDeEntrega = estadoOrdenDeEntrega;
            OrdenDePreparacionClase = ordenesPreparacion;
        }

        //// Constructor vacío para formulario
        //public OrdenDeEntregaPendiente()
        //{
        //    FechaEntrega = DateTime.Now;
        //    EstadoOrdenDeEntrega = "Pendiente";
        //}
    }

}

