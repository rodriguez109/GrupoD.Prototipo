using GrupoD.Prototipo.Almacenes;
using GrupoD.Prototipo.CDU2._GenerarOrdenSeleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._2._GenerarOrdenSeleccion
{
    class GenerarOrdenSeleccionModelo
    {
        public List<OrdenesDePreparacion> OrdenesPreparacionDisponibles { get; } = new();

        //Esta hay que borrarla y ver cómo reemplazar su uso en el formulario en cada caso
        public List<OrdenesDeSeleccion> OrdenesDeSeleccion { get; set; }  // Agregar esta propiedad


        public List<OrdenesDePreparacion> OrdenesAgregadas { get; set; } // Lista de órdenes ya agregadas


        //Aca lo que deberia hacer mi modelo post prototipo:

        //Obtener las órdenes de preparación pendientes desde el almacenamiento

        //Seleccionar las OP Pendientes y generar una nueva OS a partir de ellas, con estado "Pendiente"

        //Guarda los cambios

        public GenerarOrdenSeleccionModelo()
        {            
            foreach (var ordenEntidad in OrdenDePreparacionAlmacen.OrdenesDePreparacion)
            {
                var cliente = ClienteAlmacen.Clientes.FirstOrDefault(c => c.Numero == ordenEntidad.NumeroCliente);

                string prioridad;
                if (ordenEntidad.Prioridad == PrioridadEnum.Alta)
                {
                    prioridad = "Alta";
                }
                else if (ordenEntidad.Prioridad == PrioridadEnum.Media)
                {
                    prioridad = "Media";
                }
                else
                {
                    prioridad = "Baja";
                }

                var ordenPrep = new OrdenesDePreparacion(
                    ordenEntidad.Numero, cliente.RazonSocial, ordenEntidad.FechaRetirar, ordenEntidad.DNITransportista, prioridad);

                OrdenesPreparacionDisponibles.Add(ordenPrep);
            }

            OrdenesAgregadas = new List<OrdenesDePreparacion>(); // Inicializar la nueva lista


            //Esta hay que borrarla.
            OrdenesDeSeleccion = new List<OrdenesDeSeleccion>();  // Lista de órdenes de selección
        }

    }
}
