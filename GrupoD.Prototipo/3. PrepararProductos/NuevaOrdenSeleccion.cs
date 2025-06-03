using GrupoD.Prototipo._3._PrepararProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.PrepararProductos.PrepararProductos
{
    public class OrdenDeSeleccion
    {
        public string Posicion { get; set; }
        public string SKUProducto { get; set; }
        public int Cantidad { get; set; }
    }
    public class OrdenSeleccion
    {
        public string NombreOrden { get; set; }
        public List<OrdenDeSeleccion> Productos { get; set; }
        public EstadoOrdenSeleccion Estado { get; set; }
        public Prioridad Prioridad { get; set; }
        public string NombreOrdenConPrioridad => $"Orden n° {NombreOrden} (Prioridad: {Prioridad})";
    }
}
