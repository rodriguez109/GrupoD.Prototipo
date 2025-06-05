using GrupoD.Prototipo;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo.Almacenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
//{
//    public class GenerarOrdendeEntregaModelo
//    {
//       public List<OrdenesDePreparacion> OrdenesPreparacionDisponibles { get; set; }

//        public List<OrdenesDePreparacion> OrdenesAgregadas { get; set; }  // Lista de órdenes ya agregadas

//        //Obtener las órdenes de preparación pendientes desde el almacenamiento
//        public GenerarOrdenSeleccionModelo()
//        {
//            OrdenesPreparacionDisponibles = (
//                    from orden in OrdenDePreparacionAlmacen.OrdenesDePreparacion
//                    where orden.Estado == EstadoOrdenDePreparacionEnum.Preparada
//                    join cliente in ClienteAlmacen.Clientes
//                        on orden.NumeroCliente equals cliente.Numero into clientesJoin
//                    from cliente in clientesJoin.DefaultIfEmpty()
//                    where cliente != null  // evitamos que cliente sea null

//                    join transportista in TransportistaAlmacen.Transportistas
//                     on orden.Nombre equals transportista.Nombre into transportistasJoin
//                    from transportista in transportistasJoin.DefaultIfEmpty()
//                    where transportista != null  // evitamos que transportista sea null

//                    select new OrdenesDePreparacion(
//                        orden.Numero,
//                        cliente.RazonSocial, // seguro no es null porque filtramos arriba
//                        orden.FechaRetirar,
//                        orden.DNITransportista
                        
                        
//                    )
//                ).ToList();

//            OrdenesAgregadas = new List<OrdenesDePreparacion>();
//        }

//        public int ObtenerProximoNumero()
//        {
//            return OrdenDeEntregaAlmacen.OrdenesDeEntrega.Max(o => o.Numero) + 1;
//        }
//        public void AgregarOrdenDeEntrega(List<OrdenDePreparacionEntidad> OPseleccionadas)
//        {
//            // Obtener el número ID para la nueva Orden de Entrega
//            int nuevoNumeroOrdenEntrega = ObtenerProximoNumero();

//            // Crear la nueva orden de entrega
//            var nuevaOrdenEntrega = new OrdenDeEntregaEntidad
//            {
//                Numero = nuevoNumeroOrdenEntrega,
//                FechaGeneracion = DateTime.Now,
//                OrdenesPreparacion = OPseleccionadas
//                    .Select(op => op.Numero)
//                    .ToList(),
//                EstadoOrdenDeEntrega = EstadoOrdenDeEntregaEnum.Pendiente
//            };

//            // Agregarla al almacén
//            OrdenDeEntregaAlmacen.Agregar(nuevaOrdenEntrega);
//        }
//    }
//}

        //public void CambioEstadoOP(OrdenDePreparacionEntidad ordenActual)
        //{
            
        //    // Buscar la orden original en OrdenDePreparacionAlmacen y actualizar su estado
        //    var ordenEnAlmacen = OrdenDePreparacionAlmacen.OrdenesDePreparacion
        //        .FirstOrDefault(op => op.Numero == ordenActual.Numero);

        //    if (ordenEnAlmacen != null)
        //    {
        //        ordenEnAlmacen.Estado = EstadoOrdenDePreparacionEnum.EnDespacho;
        //    }


           
        //}
        //// formulario? public void ActualizarOrdenesDisponibles()
        //{
        //    OrdenesEnPreparacionDisponibles.Clear();
        //    OrdenesEnPreparacionDisponibles.AddRange(OrdenDePreparacionAlmacen.OrdenesDePreparacion
        //        .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.Preparada));
        //}

        ////ActualizarOrdenesDisponibles();
   




        //public void CambioEstadoOP(OrdenDePreparacionEntidad ordenActual)
        //{
        //    //ordenActual.Estado = EstadoOrdenDePreparacionEnum.Preparada;
        //    //OrdenesEnPreparacionDisponibles.Remove(ordenActual); // Remueve de la lista interna

        //    //ordenActual.Estado = EstadoOrdenDePreparacionEnum.Preparada;

        //    // Buscar la orden original en OrdenDePreparacionAlmacen y actualizar su estado
        //    var ordenEnAlmacen = OrdenDePreparacionAlmacen.OrdenesDePreparacion
        //        .FirstOrDefault(op => op.Numero == ordenActual.Numero);

        //    if (ordenEnAlmacen != null)
        //    {
        //        ordenEnAlmacen.Estado = EstadoOrdenDePreparacionEnum.EnDespacho;
        //    }


        //    ActualizarOrdenesDisponibles();
        //}

        //public void ActualizarOrdenesDisponibles()
        //{
        //    OrdenesEnPreparacionDisponibles.Clear();
        //    OrdenesEnPreparacionDisponibles.AddRange(OrdenDePreparacionAlmacen.OrdenesDePreparacion
        //        .Where(op => op.Estado == EstadoOrdenDePreparacionEnum.Preparada));
       



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
