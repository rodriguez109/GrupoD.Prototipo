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
        private List<OrdenDePreparacionEntidad> ordenesPreparadas;

        // Constructor
        public GenerarOrdenEntregaModelo()
        {
            // PASO 2: Buscar y cargar las órdenes en estado "Preparada"
            BuscarOrdenesPreparadas();
        }

        /// <summary>
        /// PASO 2: Cargar todas las órdenes en estado "Preparada"
        /// </summary>
        private void BuscarOrdenesPreparadas()
        {
            ordenesPreparadas = OrdenDePreparacionAlmacen.OrdenesDePreparacion
                .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.Preparada)
                .ToList();
        }

        /// <summary>
        /// PASO 2: Devolver las órdenes preparadas para mostrar en pantalla
        /// </summary>
        /// <returns>Lista de órdenes preparadas</returns>
        public List<OrdenDePreparacionEntidad> ObtenerOrdenesPreparadas()
        {
            return ordenesPreparadas;
        }

        /// <summary>
        /// PASO 3: Obtener el próximo número disponible para una orden de entrega
        /// </summary>
        /// <returns>Próximo número de orden</returns>
        public int ObtenerProximoNumero()
        {
            if (OrdenDeEntregaAlmacen.OrdenesDeEntrega.Any())
            {
                return OrdenDeEntregaAlmacen.OrdenesDeEntrega.Max(o => o.Numero) + 1;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// PASO 4: Crear y guardar una nueva orden de entrega con las órdenes seleccionadas
        /// </summary>
        /// <param name="OPseleccionadas">Órdenes de preparación seleccionadas</param>
        public void CrearYGuardarOrdenDeEntrega(List<OrdenDePreparacionEntidad> OPseleccionadas)
        {
            if (OPseleccionadas == null || !OPseleccionadas.Any())
                throw new ArgumentException("Debe seleccionar al menos una Orden de Preparación.");

            int nuevoNumero = ObtenerProximoNumero();

            var nuevaOrdenEntrega = new OrdenDeEntregaEntidad
            {
                Numero = nuevoNumero,
                FechaGeneracion = DateTime.Now,
                OrdenesPreparacion = OPseleccionadas.Select(op => op.Numero).ToList(),
                EstadoOrdenDeEntrega = EstadoOrdenDeEntregaEnum.Pendiente
            };

            OrdenDeEntregaAlmacen.Agregar(nuevaOrdenEntrega);
            OrdenDeEntregaAlmacen.Grabar();

            // PASO 5: Cambiar estado de las órdenes de preparación a "En Despacho"
            foreach (var orden in OPseleccionadas)
            {
                CambiarEstadoOrdenPreparacion(orden);
            }

            // Recargar la lista después de actualizar
            BuscarOrdenesPreparadas();
        }

        /// <summary>
        /// PASO 5: Cambiar estado de una orden de preparación a "En Despacho"
        ///
        ///
        private void CambiarEstadoOrdenPreparacion(OrdenDePreparacionEntidad orden)
        {
            var ordenEnAlmacen = OrdenDePreparacionAlmacen.OrdenesDePreparacion
                .FirstOrDefault(op => op.Numero == orden.Numero);

            if (ordenEnAlmacen != null)
            {
                ordenEnAlmacen.Estado = EstadoOrdenDePreparacionEnum.EnDespacho;
            }

            OrdenDePreparacionAlmacen.Grabar();
        }
    }
}









//formulario ? public void ActualizarOrdenesDisponibles()
//{
//    OrdenesEnPreparacionDisponibles.Clear();
//    OrdenesEnPreparacionDisponibles.AddRange(OrdenDePreparacionAlmacen.OrdenesDePreparacion
//        .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.Preparada));
//}

//ActualizarOrdenesDisponibles();







//    ActualizarOrdenesDisponibles();
//}

//public void ActualizarOrdenesDisponibles()
//{
//    OrdenesEnPreparacionDisponibles.Clear();
//    OrdenesEnPreparacionDisponibles.AddRange(OrdenDePreparacionAlmacen.OrdenesDePreparacion
//        .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.Preparada));
//}



//public List<OrdenDeEntregaPendiente> Ordenes { get; set; } = new()

//        {
//            new OrdenDeEntregaPendiente(1, "DecoHogar S.A.", new DateTime(2025, 5, 3), 24209350, "Transporte Sur"),
//            new OrdenDeEntregaPendiente(2, "MaxiLuz Iluminación SRL", new DateTime(2025, 5, 4), 24209351, "Express Cargo"),
//            new OrdenDeEntregaPendiente(3, "MundoFOX S.A.", new DateTime(2025, 5, 5), 24209352, "Logística Norte"),
//            new OrdenDeEntregaPendiente(4, "FullColor Pinturerías SRL", new DateTime(2025, 5, 6), 24209353, "Transporte Sur"),
//            new OrdenDeEntregaPendiente(5, "Hogar Urbano S.A.", new DateTime(2025, 5, 7), 24209354, "Rápido S.A."),
//            new OrdenDeEntregaPendiente(6, "Todo Obra Ferretería SRL", new DateTime(2025, 5, 8), 24209355, "Logística Norte"),
//            new OrdenDeEntregaPendiente(7, "Casa Nova Equipamientos S.A.", new DateTime(2025, 5, 9), 24209356, "Transporte Sur"),
//            new OrdenDeEntregaPendiente(8, "OfiMarket SRL", new DateTime(2025, 5, 10), 24209357, "Express Cargo"),
//            new OrdenDeEntregaPendiente(9, "Red Tools S.A.", new DateTime(2025, 5, 11), 24209358, "Logística Norte"),
//            new OrdenDeEntregaPendiente(10, "MegaMuebles SRL", new DateTime(2025, 5, 12), 24209359, "Rápido S.A."),
//            new OrdenDeEntregaPendiente(11, "ElectroCity S.A.", new DateTime(2025, 5, 13), 24209360, "Transporte Sur"),
//            new OrdenDeEntregaPendiente(12, "PlastiSur SRL", new DateTime(2025, 5, 14), 24209361, "Logística Norte"),
//            new OrdenDeEntregaPendiente(13, "Tecnoshop S.A.", new DateTime(2025, 5, 15), 24209362, "Rápido S.A."),
//            new OrdenDeEntregaPendiente(14, "Urban Market SRL", new DateTime(2025, 5, 16), 24209363, "Express Cargo"),
//            new OrdenDeEntregaPendiente(15, "DecoCentro S.A.", new DateTime(2025, 5, 17), 24209364, "Transporte Sur"),
//            new OrdenDeEntregaPendiente(16, "Centro Herramientas SRL", new DateTime(2025, 5, 18), 24209365, "Logística Norte"),
//            new OrdenDeEntregaPendiente(17, "FullOffice S.A.", new DateTime(2025, 5, 19), 24209366, "Rápido S.A."),
//            new OrdenDeEntregaPendiente(18, "DecorArte SRL", new DateTime(2025, 5, 20), 24209367, "Express Cargo"),
//            new OrdenDeEntregaPendiente(19, "EasyTech Distribuciones S.A.", new DateTime(2025, 5, 21), 24209368, "Transporte Sur"),
//            new OrdenDeEntregaPendiente(20, "FerreMarket SRL", new DateTime(2025, 5, 22), 24209369, "Logística Norte"),
//        };
