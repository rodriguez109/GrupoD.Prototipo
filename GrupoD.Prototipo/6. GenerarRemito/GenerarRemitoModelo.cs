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
                return new List<OrdenPreparacion>(); //acá iría otro mensaje de error??
            }

            var ordenes = OrdenesPreparacion.Where(o => o.DNITransportista == dniNumerico).ToList();// acá iría la validacion ???

            if (ordenes.Count == 0)
            {
                return new List<OrdenPreparacion>();
            }

            return ordenes;
        }

        internal string Agregar (List<int> ordenes, string dni)
        {

            int numero = RemitoAlmacen.NumeroRemito();
            DateTime fecha = DateTime.Today;
           
            if (int.TryParse(dni, out int Dni))
            {
                return "Debe ingresar un número de DNI valido";
            }

            var remito = new RemitoEntidad(numero, Dni, fecha, ordenes);
            RemitoAlmacen.Agregar(remito); 

            return null;
        }


        // llamaria al metodo del almcaen para cambiar el estado???
        //le paso una lista de ordenes desde el presentador?


    }
}
