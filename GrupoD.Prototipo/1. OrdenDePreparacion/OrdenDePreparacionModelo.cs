using GrupoD.Prototipo._1._OrdenDePreparacion;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion
{
    internal class OrdenDePreparacionModelo
    {
        //internal string? OrdenDePreparacion { OrdenDePreparacion ordenDePreparacion } => {throw new NotImplementedException()

        //public List<OrdenesDePreparacion> OrdenesPreparacionDisponibles { get; set; }
        //public List<OrdenesDeSeleccion> OrdenesDeSeleccion { get; set; }  // Agregar esta propiedad
        //public List<OrdenesDePreparacion> OrdenesAgregadas { get; set; } // Lista de órdenes ya agregadas

        public List<Cliente> Cliente { get; set; } // Lista de clientes
        public List<ProductosPorCliente> ProductosPorCliente { get; set; } // Lista de productos por cliente
        public List<OrdenesDePreparacion> OrdenesDePreparaciones { get; set; } // Lista de órdenes de preparación


        public OrdenDePreparacionModelo()
        {
            Cliente = new List<Cliente>
            {
                new Cliente(1, "Distribuidora San Martín S.A."),
                new Cliente(2, "Transporte del Sur SRL."),
                new Cliente(3, "Alimentos La Cumbre S.A."),
                new Cliente(4, "Servicios Integrales Patagónicos SRL"),
                new Cliente(5,  "Industrias Mendoza S.A.I.C."),
                new Cliente(6, "Tecnología Andina SRL"),
                new Cliente(7, "Comercializadora Norte Grande S.A."),
                new Cliente(8,  "Textiles del Oeste SRL"),
                new Cliente(9,  "Constructora Río de la Plata S.A."),
                new Cliente(10, "Agroexportadora del Litoral S.A."),


            };
            Producto = new List<Producto>
            {
                new Producto  (1, "Laptop", 10, 12-45-78),
                new Producto  (2, "Mouse óptico", 50, 33-66-99),
                new Producto  (3, "Teclado mecánico", 25, 07-31-56),
                new Producto (4, "Monitor LED 24''", 15, 89-23-45),
                new Producto (5, "Impresora láser", 8, 62-44-11),
                new Producto (6, "Silla ergonómica", 5, 18-27-36),
                new Producto (7, "Disco duro SSD 1TB", 30, 54-67-82),
                new Producto (8, "Auriculares inalámbricos", 40, 22-39-71),
                new Producto (9, "Tablet 10''", 20, 93-12-56),
                new Producto (10, "Cámara web HD", 12, 05-88-64),
            };

            //ProductosPorCliente = new List<ProductosPorCliente>
            {
                //new ProductosPorCliente (1001, "Cemento Portland", 50, 78-45-14),
                //new ProductosPorCliente (1002, "Ladrillo Hueco", 120, 03-29-67),
                //new ProductosPorCliente (1003, "Pintura Blanca 20L", 30, 92-11-08),
                //new ProductosPorCliente (1004, "Cable Eléctrico 2mm", 200, 16-87-43),
                //new ProductosPorCliente (1005, "Caño PVC 110mm", 80, 54-06-33),
                //new ProductosPorCliente (1006, "Cerámico Beige 45x45", 100, 21-58-74),
                //new ProductosPorCliente (1007, "Yeso en Bolsa 25kg", 45, 39-91-27),
                //new ProductosPorCliente (1008, "Aislante Térmico Rollo", 60, 08-67-18),
                //new ProductosPorCliente (1009, "Madera Pino 2x4", 70, 46-22-51),
                //new ProductosPorCliente (1010, "Clavos 3 pulgadas", 150, 70-13-60)),

                //Debería agregar cliente asociado?




            };

            //public List<Cliente> listaClientes = new List<Cliente>
            //{ 
              //  new Cliente
            
            //}


    }   }
}
