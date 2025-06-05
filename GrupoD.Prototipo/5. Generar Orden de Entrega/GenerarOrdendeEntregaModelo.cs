using GrupoD.Prototipo;
using GrupoD.Prototipo.Almacenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    public class GenerarOrdendeEntregaModelo
    {
       
        public List<OrdenDeEntregaPendiente> Ordenes
        {
            get
            {
                var lista = new List<OrdenDeEntregaPendiente>();

                foreach (var ordenEntidad in OrdenDeEntregaAlmacen.OrdenesDeEntrega)
                {
                    // Tomamos la primera orden de preparación relacionada
                    var idOrdenPreparacion = ordenEntidad.OrdenesPreparacion.FirstOrDefault();
                    if (idOrdenPreparacion == 0) continue;

                    var ordenPreparacion = OrdenDePreparacionAlmacen.Buscar(idOrdenPreparacion);
                    if (ordenPreparacion == null) continue;

                    var cliente = ClienteAlmacen.Buscar(ordenPreparacion.NumeroCliente);
                    var transportista = TransportistaAlmacen.Buscar(ordenPreparacion.DNITransportista);

                    if (cliente == null || transportista == null) continue;

                    var ordenPendiente = new OrdenDeEntregaPendiente(
                        ordenEntidad.Numero,
                        cliente.RazonSocial,
                        ordenPreparacion.FechaRetirar,
                        transportista.DNI,
                        transportista.Nombre
                    );

                    lista.Add(ordenPendiente);
                }

                return lista;
            }
        }
    }


}



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
