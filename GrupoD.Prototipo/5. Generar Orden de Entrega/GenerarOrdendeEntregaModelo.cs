using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    public class GenerarOrdendeEntregaModelo
    {
       public List<OrdenEntrega> Ordenes { get; set; } = new List<OrdenEntrega> ()

        {
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 3), NumeroOrden = 1, Cliente = "DecoHogar S.A.", Transportista = "Transporte Sur", CUIL = 20242093500L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 4), NumeroOrden = 2, Cliente = "MaxiLuz Iluminación SRL", Transportista = "Express Cargo", CUIL = 27242093513L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 5), NumeroOrden = 3, Cliente = "MundoFOX S.A.", Transportista = "Logística Norte", CUIL = 20242093527L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 6), NumeroOrden = 4, Cliente = "FullColor Pinturerías SRL", Transportista = "Transporte Sur", CUIL = 27242093534L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 7), NumeroOrden = 5, Cliente = "Hogar Urbano S.A.", Transportista = "Rápido S.A.", CUIL = 20242093543L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 8), NumeroOrden = 6, Cliente = "Todo Obra Ferretería SRL", Transportista = "Logística Norte", CUIL = 27242093552L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 9), NumeroOrden = 7, Cliente = "Casa Nova Equipamientos S.A.", Transportista = "Transporte Sur", CUIL = 20242093560L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 10), NumeroOrden = 8, Cliente = "OfiMarket SRL", Transportista = "Express Cargo", CUIL = 27242093577L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 11), NumeroOrden = 9, Cliente = "Red Tools S.A.", Transportista = "Logística Norte", CUIL = 20242093586L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 12), NumeroOrden = 10, Cliente = "MegaMuebles SRL", Transportista = "Rápido S.A.", CUIL = 27242093593L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 13), NumeroOrden = 11, Cliente = "ElectroCity S.A.", Transportista = "Transporte Sur", CUIL = 20242093608L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 14), NumeroOrden = 12, Cliente = "PlastiSur SRL", Transportista = "Logística Norte", CUIL = 27242093615L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 15), NumeroOrden = 13, Cliente = "Tecnoshop S.A.", Transportista = "Rápido S.A.", CUIL = 20242093624L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 16), NumeroOrden = 14, Cliente = "Urban Market SRL", Transportista = "Express Cargo", CUIL = 27242093631L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 17), NumeroOrden = 15, Cliente = "DecoCentro S.A.", Transportista = "Transporte Sur", CUIL = 20242093640L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 18), NumeroOrden = 16, Cliente = "Centro Herramientas SRL", Transportista = "Logística Norte", CUIL = 27242093658L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 19), NumeroOrden = 17, Cliente = "FullOffice S.A.", Transportista = "Rápido S.A.", CUIL = 20242093667L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 20), NumeroOrden = 18, Cliente = "DecorArte SRL", Transportista = "Express Cargo", CUIL = 27242093674L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 21), NumeroOrden = 19, Cliente = "EasyTech Distribuciones S.A.", Transportista = "Transporte Sur", CUIL = 20242093683L },
            new OrdenEntrega { FechaEntrega = new DateTime(2025, 5, 22), NumeroOrden = 20, Cliente = "FerreMarket SRL", Transportista = "Logística Norte", CUIL = 27242093690L }

        };
        

 
    }

}

