using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.PrepararProductos.PrepararProductos
{
    public class OrdenDeSeleccion
    {
        public string Ubicacion { get; set; }
        public string SKUProducto { get; set; }
        public int Cantidad { get; set; }
    }
    public class OrdenSeleccion
    {
        public string NombreOrden { get; set; }
        public List<OrdenDeSeleccion> Productos { get; set; }
    }

}
