using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo.Almacenes;
using Prototipo.PrepararProductos.PrepararProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._6._GenerarRemito
{
    internal class GenerarRemitoModelo
    {        


        public List<OrdenPreparacion> OrdenesPreparacion { get; } = new();
        public GenerarRemitoModelo()
        {

                foreach (var OrdenPreparacionEntidad in OrdenDePreparacionAlmacen.OrdenesDePreparacion)
                {
                        OrdenesPreparacion.Add(new OrdenPreparacion ( OrdenPreparacionEntidad.Numero,
                         OrdenPreparacionEntidad.DNITransportista));
                }

                
            
        }


        public List<OrdenPreparacion> ObtenerOrdenesPorDNI(string dni)
        {
            if (!int.TryParse(dni, out int dniNumerico))
            {
                return new List<OrdenPreparacion>();
            }
            return OrdenesPreparacion.Where(o => o.DNITransportista == dniNumerico).ToList();
        }


    }
}
