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
                OrdenesPreparacion.Add(new OrdenPreparacion(OrdenPreparacionEntidad.Numero,
                OrdenPreparacionEntidad.DNITransportista, OrdenPreparacionEntidad.Estado));

            }

        }
        public List<OrdenPreparacion> ObtenerOrdenesPorDNI(string dni)
        {
            if (!int.TryParse(dni, out int dniNumerico))
            {
                return new List<OrdenPreparacion>(); //acá iría otro mensaje de error??
            }

            var ordenes = OrdenesPreparacion.Where(o => o.DNITransportista == dniNumerico && o.Estado == EstadoOrdenDePreparacionEnum.EnDespacho).ToList();


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
           
            if (!int.TryParse(dni, out int Dni))
            {
                return "Debe ingresar un número de DNI valido";
            }

            var remito = new RemitoEntidad { Numero = numero, DNITransportista = Dni, FechaEmision = fecha, OrdenesPreparacion = ordenes };
            RemitoAlmacen.Agregar(remito); 

            return null;
        }



        //Cambiar estado Orden de Preparacion despachada
        //Cambiar estado Orden de entrega confirmada  que dato le paso???

        //foreach (var op in OPseleccionadas) //AGREGAR ESTE METODO
        //{
        //    OrdenDePreparacionAlmacen.cambiarEstado((op.NumeroOrden), EstadoOrdenDePreparacionEnum.Despachada);
        //}

        // linq  
        //por cada orden de entrega ver for each ver q las ordenes de preparacion esten todas despachadas entonces cambio el estado sino no

       // Le paso al modelo ordenes de prep les cambia el estado y luego busca la orden de entrega de cada una 
         //   y cheque q todas las ordenes de prep en ella esten despachadas y si lo estan cambia el estado de la orden de entrega a confirmada.
    }
}
//public void DespacharOrdenesDePreparacion(List<int> idsOrdenesPrep)
//{
//    // 1. Cambiar estado a "Despachada"
//    foreach (var id in idsOrdenesPrep)
//    {
//        _almacenOrdenesPrep.CambiarEstado(id, EstadoOrdenDePreparacionEnum.Despachada);
//    }

//    // 2. Agrupar órdenes por orden de entrega
//    var ordenes = idsOrdenesPrep
//        .Select(id => _almacenOrdenesPrep.ObtenerPorId(id))
//        .GroupBy(op => op.IdOrdenEntrega);

//    foreach (var grupo in ordenes)
//    {
//        int idOrdenEntrega = grupo.Key;

//        var ordenEntrega = _almacenOrdenesEntrega.ObtenerPorId(idOrdenEntrega);
//        if (ordenEntrega == null)
//            continue;

//        // 3. Verificar si todas las órdenes de preparación están despachadas
//        bool todasDespachadas = ordenEntrega.OrdenesPreparacion
//            .All(op => op.Estado == EstadoOrdenDePreparacionEnum.Despachada);

//        // 4. Confirmar la orden de entrega si corresponde
//        if (todasDespachadas)
//        {
//            _almacenOrdenesEntrega.Confirmar(idOrdenEntrega);
//        }
