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
            OrdenesPreparacionDisponibles = (
                    from orden in OrdenDePreparacionAlmacen.OrdenesDePreparacion
                    where orden.Estado == EstadoOrdenDePreparacionEnum.Pendiente && orden.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual
                    join cliente in ClienteAlmacen.Clientes
                        on orden.NumeroCliente equals cliente.Numero into clientesJoin
                    from cliente in clientesJoin.DefaultIfEmpty()
                    where cliente != null  // evitamos que cliente sea null
                    select new OrdenesDePreparacion(
                        orden.Numero,
                        cliente.RazonSocial, // seguro no es null porque filtramos arriba
                        orden.FechaRetirar,
                        orden.DNITransportista,
                        orden.Prioridad switch
                        {
                            PrioridadEnum.Alta => "Alta",
                            PrioridadEnum.Media => "Media",
                            _ => "Baja"
                        }
                    )
                ).ToList();

            OrdenesAgregadas = new List<OrdenesDePreparacion>();
        }

        public int ObtenerProximoNumero()
        {
            return OrdenDeSeleccionAlmacen.OrdenesDeSeleccion.Max(o => o.Numero) + 1;
        }

        public void AgregarOrden(List<OrdenesDePreparacion> OPseleccionadas)
        {
            // Obtener el número ID para la nueva Orden de Selección
            int nuevoIdOrdenSeleccion = ObtenerProximoNumero();

            // Creo una instancia de OrdenDeSeleccionEntidad
            var nuevaOrdenSeLeccion = new OrdenDeSeleccionEntidad
            {
                Numero = nuevoIdOrdenSeleccion,
                FechaGeneracion = DateTime.Now,
                OrdenesPreparacion = OPseleccionadas
                    .Select(op => new OrdenDePreparacionEntidad
                    {
                        Numero = op.NumeroOrden,
                    })
                    .Select(opEnt => opEnt.Numero)
                    .ToList(),
                EstadoOrdenDeSeleccion = EstadoOrdenDeSeleccionEnum.Pendiente
            };

            // Agregar la nueva orden a la lista de Ordenes de Seleccion
            OrdenDeSeleccionAlmacen.Agregar(nuevaOrdenSeLeccion);

            // **Mostrar el número recién guardado**
            MessageBox.Show($"Se ha creado la orden de selección exitosamente. Número de Orden: {nuevaOrdenSeLeccion.Numero}",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //Cambiar estado Orden de Preparacion PENDIENTE
            foreach (var op in OPseleccionadas) //AGREGAR ESTE METODO
            {
                OrdenDePreparacionAlmacen.cambiarEstado((op.NumeroOrden), EstadoOrdenDePreparacionEnum.Procesamiento);
            }
        }

    }
}