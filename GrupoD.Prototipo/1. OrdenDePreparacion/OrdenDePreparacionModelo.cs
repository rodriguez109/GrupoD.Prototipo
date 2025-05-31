using GrupoD.Prototipo._1._OrdenDePreparacion;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;

using System;

using System.Collections.Generic;

namespace GrupoD.Prototipo

{

    internal class OrdenDePreparacionModelo

    {

        // Propiedades públicas para almacenar datos

        public List<Cliente> Clientes { get; set; }

        public List<Producto> Productos { get; set; }

        public List<OrdenesDePreparacion> OrdenesDePreparaciones { get; set; }

        public List<Transportista> Transportistas { get; set; }

        // Declaración correcta de listas estáticas

        public static List<Cliente> ListaCliente = new List<Cliente>

        {

            new Cliente(10, "Exportadora del Litoral S.A."),

            new Cliente(1, "Distribuidora San Martín S.A."),

            new Cliente(2, "Transporte del Sur SRL"),

            new Cliente(3, "Almacén La Cumbre S.A."),

            new Cliente(4, "Servicios Integrales Patagónicos SRL"),

            new Cliente(5, "Industrias Mendoza S.A.I.C."),

            new Cliente(6, "Tecnología Andina SRL"),

            new Cliente(7, "Comercializadora Norte Grande S.A."),

            new Cliente(8, "Textiles del Oeste SRL"),

            new Cliente(9, "Constructora Río de la Plata S.A.")

        };

        public static List<Producto> ListaProductos = new List<Producto>

        {

            new Producto(1, "Laptop", 10, "12-45-78", 1),

            new Producto(2, "Mouse óptico", 50, "33-66-99", 1),

            new Producto(3, "Teclado mecánico", 25, "07-31-56", 5),

            new Producto(4, "Monitor LED 24''", 15, "89-23-45", 2),

            new Producto(5, "Impresora láser", 8, "62-44-11", 3),

            new Producto(6, "Silla ergonómica", 5, "18-27-36", 4),

            new Producto(7, "Disco duro SSD 1TB", 30, "54-67-82", 6),

            new Producto(8, "Auriculares inalámbricos", 40, "22-39-71", 7),

            new Producto(9, "Tablet 10''", 20, "93-12-56", 8),

            new Producto(10, "Cámara web HD", 12, "05-88-64", 9)

        };

        public static List<Transportista> ListaTransportistas = new List<Transportista>

        {

            new Transportista(12345678, "Juan Pérez"),

            new Transportista(23456789, "María Gómez"),

            new Transportista(34567890, "Carlos Rodríguez"),

            new Transportista(34567891, "Laura Fernández"),

            new Transportista(34567892, "Diego Sánchez"),

            new Transportista(34567893, "Ana López"),

            new Transportista(34567894, "Pedro Martínez"),

            new Transportista(34567895, "Sofía Torres"),

            new Transportista(34567896, "Roberto Vargas"),

            new Transportista(34567897, "Elena Ramírez")

        };

        // Constructor de la clase

        public OrdenDePreparacionModelo()

        {

            Clientes = new List<Cliente>(ListaCliente);

            Productos = new List<Producto>(ListaProductos);

            Transportistas = new List<Transportista>(ListaTransportistas);

        }

    }
    //class OrdenDePreparacionModelo
    //    {
    //        public List<OrdenDePreparacion> OrdenDePreparacion ES ESTO O SERÍA OTRA LIST?
    //        {
    //          get
    //          {
    //              var ordenesdepreparacion = new List<OrdenDePreparacion>();
    //              foreach (var OrdenDePreparacionEntidad in OrdenDePreparacionAlmacen ordenesdepreparacion)
    //              {
    //                  ordenesdepreparacion.Add(new OrdenDePreparacion)
    //                  { ACÁ ES CON LOS ATRIBUTOS DE LA CLASE OrdenDePreparacionClase?
    //                      NumeroOrdenPreparacion = OrdenDePreparacionEntidad.Numero,
    //                      SKUProducto = no está en la entidad
    //                      NombreProducto = no está en la entidad
    //                      CantidadProducto = no está en la entidad
    //                      FechaRetirar = OrdenDePreparacionEntidad.FechaRetirar
    //                      Prioridad = OrdenDePreparacionEntidad.PrioridadEnum (?)
    //                      DNITransportista = OrdenDePreparacionEntidad.DNITransportista0
    //                      NumeroCliente = OrdenDePreparacionEntidad.NumeroCliente
    //                      Pallet = OrdenDePreparacionEntidad.Pallet,
    //                      RazonSocialCliente = no está en la entidad
    //                      No está en la clase: CodigoDeposito, List<ProductosPorOrden> Detalle, EstadoOrdenDePreparacionEnum Estado
    //                  }
    //              }
    //          }
    //          return OrdenesDePreparacion
    //      }
    //    }    


    //                      

}





