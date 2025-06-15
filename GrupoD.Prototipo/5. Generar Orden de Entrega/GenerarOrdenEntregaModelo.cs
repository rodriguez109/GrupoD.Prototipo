using GrupoD.Prototipo;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo.Almacenes;
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
        // PASO 1: Preparar la lista de Ordenes de Preparación
        private List<OrdenDePreparacionClase> ordenesPreparadas;

        // Constructor
        public GenerarOrdenEntregaModelo()
        {
            BuscarOrdenesPreparadas();
        }

        /// PASO 2: Cargar todas las órdenes en estado "Preparada"
        private void BuscarOrdenesPreparadas()
        {
            ordenesPreparadas = new List<OrdenDePreparacionClase>();

            foreach (var op in OrdenDePreparacionAlmacen.OrdenesDePreparacion
                .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.Preparada &&
                             op.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual))
            {
                var cliente = ClienteAlmacen.Buscar(op.NumeroCliente);
                var transportista = TransportistaAlmacen.Buscar(op.DNITransportista);

                // Carga razonable incluso si alguno falta
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

        /// PASO 3: Obtener el próximo número disponible para una orden de entrega
        /// 
        //public int ObtenerProximoNumero()
        //{
        //    return OrdenDeEntregaAlmacen.OrdenesDeEntrega.Any()
        //        ? OrdenDeEntregaAlmacen.OrdenesDeEntrega.Max(o => o.Numero) + 1
        //        : 1;
        //}

        /// PASO 4: Crear y guardar una nueva orden de entrega con las órdenes seleccionadas
        /// <param name="ordenesSeleccionadas">Órdenes de preparación seleccionadas</param>
        public void CrearYGuardarOrdenDeEntrega(List<OrdenDePreparacionClase> ordenesSeleccionadas)
        {
            if (ordenesSeleccionadas == null || !ordenesSeleccionadas.Any())
                throw new ArgumentException("Debe seleccionar al menos una orden para continuar.");

            int nuevoNumero = ObtenerProximoNumero();

            var nuevaOrdenEntrega = new OrdenDeEntregaEntidad
            {
                Numero = nuevoNumero,
                FechaGeneracion = DateTime.Now,
                OrdenesPreparacion = ordenesSeleccionadas.Select(op => op.NumeroOrden).ToList(),
                EstadoOrdenDeEntrega = EstadoOrdenDeEntregaEnum.Pendiente
            };

            OrdenDeEntregaAlmacen.Agregar(nuevaOrdenEntrega);

            // PASO 5: Cambiar estado de las órdenes de preparación a "En Despacho"
            foreach (var orden in ordenesSeleccionadas)
            {
                CambiarEstadoOrdenPreparacion(orden.NumeroOrden);
            }

            BuscarOrdenesPreparadas();
        }

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

        /// PASO 5: Cambiar estado de una orden de preparación a "En Despacho"
        private void CambiarEstadoOrdenPreparacion(int numeroOrden)
        {
            OrdenDePreparacionAlmacen.cambiarEstado(numeroOrden, EstadoOrdenDePreparacionEnum.EnDespacho);
        }

    }
}


