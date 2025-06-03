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
            //Aca lo que deberia hacer mi modelo post prototipo:

            //Seleccionar las OP Pendientes y generar una nueva OS a partir de ellas, con estado "Pendiente"

            // Agregar la nueva orden a la lista de Ordenes de Seleccion

            // Grabar la lista actualizada en el archivo JSON


            //Actualizar los datos: 
            //Ordenes de preparacion disponibles
            // Eliminar las órdenes seleccionadas de la lista de disponibles
            //OrdenesPreparacionDisponibles.RemoveAll(o => ordenesSeleccionadas.Any(sel => sel.NumeroOrden == o.NumeroOrden));
            //OrdenesDeSeleccion

            // Agregar la nueva orden a la lista de órdenes de selección
            // OrdenDeSeleccionAlmacen.Agregar(nuevaOrdenSeleccion);

            // Grabar la lista actualizada en el archivo JSON
            // OrdenDeSeleccionAlmacen.Grabar();

            // Obtener el número ID para la nueva Orden de Selección
            int nuevoIdOrdenSeleccion = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion.Max(o => o.Numero) + 1;

            // Creao una instancia de OrdenDeSeleccionEnt
            var nuevaOrdenSeLeccion = new OrdenDeSeleccionEntidad(
                numero: nuevoIdOrdenSeleccion,
                fechaGeneracion: DateTime.Now,
                ordenesPreparacion: OPseleccionadas
                    .Select(op => new OrdenDePreparacionEntidad
                    {
                        Numero = op.NumeroOrden,
                        FechaRetirar = op.FechaEntrega,
                        Prioridad = (PrioridadEnum)Enum.Parse(typeof(PrioridadEnum), op.Prioridad),
                    })
                    .Select(opEnt => opEnt.Numero)
                    .ToList(),
                estado: EstadoOrdenDeSeleccionEnum.Pendiente   
            );

            // Agregar la nueva orden a la lista de Ordenes de Seleccion
            OrdenDeSeleccionAlmacen.Agregar(nuevaOrdenSeLeccion);

            // Grabar la lista actualizada en el archivo JSON
            OrdenDeSeleccionAlmacen.Grabar(); //TODO: Grabar deberia estar en el almacen?

            //Cambiar estado Orden de Preparacion    
            //foreach (var op in OPseleccionadas)
            //{
            //    OrdenDePreparacionAlmacen.cambiarEstado(int.Parse(op.Numero), EstadoOrdenDePreparacionEnum.Procesamiento);
            //}
        }

    }
}
