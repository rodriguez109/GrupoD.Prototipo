using GrupoD.Prototipo.Almacenes;
using GrupoD.Prototipo.CDU2._GenerarOrdenSeleccion;
using Prototipo.PrepararProductos.PrepararProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._2._GenerarOrdenSeleccion
{
    class GenerarOrdenSeleccionModelo
    {

        //Traigo datos de ordenes de preparacion pendientes.
        public List<OrdenesDePreparacion> OrdenesPreparacionDisponibles { get; set; }

        public List<OrdenesDePreparacion> OrdenesAgregadas { get; set; }  // Lista de órdenes ya agregadas

        //Obtener las órdenes de preparación pendientes desde el almacenamiento
        public GenerarOrdenSeleccionModelo()
        {
            OrdenesPreparacionDisponibles = new List<OrdenesDePreparacion>(); // Inicializar la lista

            foreach (var ordenEntidad in OrdenDePreparacionAlmacen.OrdenesDePreparacion
                    .Where(o => o.Estado == EstadoOrdenDePreparacionEnum.Pendiente)) // Filtra solo las pendientes
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
        }

        //public int ObtenerProximoNumero()
        //{
        //    return OrdenDeSeleccionAlmacen.OrdenesDeSeleccion.Max(o => o.Numero) + 1;
        //}

        public void AgregarOrden(List<OrdenesDePreparacion> OPseleccionadas)
        {
            // Obtener el número ID para la nueva Orden de Selección
            int nuevoIdOrdenSeleccion = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion.Max(o => o.Numero) + 1;

            // Creo una instancia de OrdenDeSeleccionEntidad
            var nuevaOrdenSeLeccion = new OrdenDeSeleccionEntidad
            {
                Numero = nuevoIdOrdenSeleccion,
                FechaGeneracion = DateTime.Now,
                OrdenesPreparacion = OPseleccionadas
                    .Select(op => new OrdenDePreparacionEntidad
                    {
                        Numero = op.NumeroOrden,
                        FechaRetirar = op.FechaEntrega,
                        Prioridad = (PrioridadEnum)Enum.Parse(typeof(PrioridadEnum), op.Prioridad),
                    })
                    .Select(opEnt => opEnt.Numero)
                    .ToList(),
                EstadoOrdenDeSeleccion = EstadoOrdenDeSeleccionEnum.Pendiente
            };

            // Agregar la nueva orden a la lista de Ordenes de Seleccion
            OrdenDeSeleccionAlmacen.Agregar(nuevaOrdenSeLeccion);


            //Cambiar estado Orden de Preparacion
            //foreach (var op in OPseleccionadas) //AGREGAR ESTE METODO
            //{
            //    OrdenDePreparacionAlmacen.cambiarEstado(int.Parse(op.Numero), EstadoOrdenDePreparacionEnum.Procesamiento);
            //}
        }

    }
}
