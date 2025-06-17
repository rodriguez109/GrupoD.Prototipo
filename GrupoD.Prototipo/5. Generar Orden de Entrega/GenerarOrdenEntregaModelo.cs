using GrupoD.Prototipo.Almacenes;
using GrupoD.Prototipo;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;


namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    internal class GenerarOrdenEntregaModelo
    {
        // Preparo la lista de Ordenes de Preparación
        private List<OrdenDePreparacionClase> ordenesPreparadas;

        // Constructor: carga todas las órdenes en estado "Preparada"
        public GenerarOrdenEntregaModelo()
        {
            BuscarOrdenesPreparadas();
        }
        //Obtener las órdenes de preparación Preparadas desde el almacenamiento
        private void BuscarOrdenesPreparadas()
        {
            ordenesPreparadas = new List<OrdenDePreparacionClase>();

            foreach (var op in OrdenDePreparacionAlmacen.OrdenesDePreparacion.Where(op => op.Estado == EstadoOrdenDePreparacionEnum.Preparada &&
            op.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual))
            
            {
                var cliente = ClienteAlmacen.Buscar(op.NumeroCliente);
                var transportista = TransportistaAlmacen.Buscar(op.DNITransportista);
                // Carga la lista y avisa si no encuentra RZ cliente o transportista segun identificador
                var nombreCliente = cliente?.RazonSocial ?? "Cliente no encontrado";
                var nombreTransportista = transportista?.Nombre ?? "Transportista no encontrado";

                var clase = new OrdenDePreparacionClase(
                    op.Numero,
                    nombreCliente,
                    op.FechaRetirar,
                    op.DNITransportista,
                    nombreTransportista
                );
                ordenesPreparadas.Add(clase);
            }
        }
        

        /// PASO 2: Devolver las órdenes preparadas para mostrar en pantalla
        public List<OrdenDePreparacionClase> ObtenerOrdenesPreparadas()
        {
            return ordenesPreparadas;
        }
        //Crea y guarda una nueva OE basado en las órdenes de preparación seleccionadas
        public void CrearYGuardarOrdenDeEntrega(List<OrdenDePreparacionClase> ordenesSeleccionadas)
        {
            // Obtiene un nuevo número identificador para la Orden de Entrega
            int nuevoNumero = ObtenerProximoNumero();
            // Creo una instancia de OrdenDeEntregaEntidad
            var nuevaOrdenEntrega = new OrdenDeEntregaEntidad
            {
                Numero = nuevoNumero,
                FechaGeneracion = DateTime.Now,
                OrdenesPreparacion = ordenesSeleccionadas.Select(op => op.NumeroOrden).ToList(),
                EstadoOrdenDeEntrega = EstadoOrdenDeEntregaEnum.Pendiente
            };
            // Agrega la nueva orden de entrega al almacén
            OrdenDeEntregaAlmacen.Agregar(nuevaOrdenEntrega);

            // Cambia estado de las órdenes de preparación a "En Despacho"
            foreach (var orden in ordenesSeleccionadas)
            {
                CambiarEstadoOrdenPreparacion(orden.NumeroOrden);
            }
            BuscarOrdenesPreparadas();
        }
        // Devuelve el próximo número de orden disponible; si no hay órdenes, empieza en 1
        public int ObtenerProximoNumero()
        {
            if (OrdenDeEntregaAlmacen.OrdenesDeEntrega.Any())
            {
                return OrdenDeEntregaAlmacen.OrdenesDeEntrega.Max(o => o.Numero) + 1;
            }
            else
            {
                return 1; // Primera orden
            }
        }
        // metodo para cambiar estado de una orden de preparación a "En Despacho"
        private void CambiarEstadoOrdenPreparacion(int numeroOrden)
        {
            OrdenDePreparacionAlmacen.cambiarEstado(numeroOrden, EstadoOrdenDePreparacionEnum.EnDespacho);
        }
    }
}


