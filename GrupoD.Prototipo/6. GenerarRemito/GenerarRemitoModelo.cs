using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo.Almacenes;
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

            foreach (var OrdenPreparacionEntidad in OrdenDePreparacionAlmacen.OrdenesDePreparacion.Where(o => o.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual))
            {
                OrdenesPreparacion.Add(new OrdenPreparacion(OrdenPreparacionEntidad.Numero,
                OrdenPreparacionEntidad.DNITransportista, OrdenPreparacionEntidad.Estado));

            }
        }

        public List<OrdenPreparacion> ObtenerOrdenesPorDNI(string dni)
        {
            if (!int.TryParse(dni, out int dniNumerico))
            {
                return new List<OrdenPreparacion>(); 
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


        internal void CambiarEstadoOP(List<int> ordenes)
        {

            foreach (var nroOp in ordenes)
            {
                OrdenDePreparacionAlmacen.cambiarEstado(nroOp, EstadoOrdenDePreparacionEnum.Despachada);
            }

        }


        internal void CambiarEstadoOE(List<int> ordenesDePreparacion)
        {
            foreach (var ordenEntrega in OrdenDeEntregaAlmacen.OrdenesDeEntrega)
            {
                bool contieneOP = ordenEntrega.OrdenesPreparacion.Any(opNumero => ordenesDePreparacion.Contains(opNumero));
                if (contieneOP)
                {
                    var ordenesPrepDeOE = OrdenDePreparacionAlmacen.OrdenesDePreparacion
                        .Where(op => ordenEntrega.OrdenesPreparacion.Contains(op.Numero))
                        .ToList();
                    
                    bool todasDespachadas = ordenesPrepDeOE
                        .All(op => op.Estado == EstadoOrdenDePreparacionEnum.Despachada);

                    if (todasDespachadas)
                    {
                        OrdenDeEntregaAlmacen.cambiarEstadoOE(ordenEntrega.Numero, EstadoOrdenDeEntregaEnum.Confirmada);
                    }
                }
            }
        }











    }
}
