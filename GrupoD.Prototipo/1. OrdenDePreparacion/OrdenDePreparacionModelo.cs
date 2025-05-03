using GrupoD.Prototipo._1._OrdenDePreparacion;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;

namespace GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion;

internal class OrdenDePreparacionModelo
{
    //internal string? OrdenDePreparacion { OrdenDePreparacion ordenDePreparacion } => {throw new NotImplementedException()

    //public List<OrdenesDePreparacion> OrdenesPreparacionDisponibles { get; set; }
    //public List<OrdenesDeSeleccion> OrdenesDeSeleccion { get; set; }  // Agregar esta propiedad
    //public List<OrdenesDePreparacion> OrdenesAgregadas { get; set; } // Lista de órdenes ya agregadas

    public List<Cliente> Cliente { get; set; } // Lista de clientes
    //public List<ProductosPorCliente> ProductosPorCliente { get; set; } // Lista de productos por cliente

    public List<Producto> Producto { get; set; } // Lista de productos
    public List<OrdenesDePreparacion> OrdenesDePreparaciones { get; set; } // Lista de órdenes de preparación

    public OrdenDePreparacionModelo()
    {
        Cliente = new List<Cliente>
        {
            new(10, "Agroexportadora del Litoral S.A."),
            new(1, "Distribuidora San Martín S.A."),
            new(2, "Transporte del Sur SRL."),
            new(3, "Almacen La Cumbre S.A."),
            new(4, "Servicios Integrales Patagónicos SRL"),
            new(5, "Industrias Mendoza S.A.I.C."),
            new(6, "Tecnología Andina SRL"),
            new(7, "Comercializadora Norte Grande S.A."),
            new(8, "Textiles del Oeste SRL"),
            new(9, "Constructora Río de la Plata S.A."),
        };
    }

    public static List<Producto> ListaProductos =
    [
        new Producto(1, "Laptop", 10, "12-45-78", 1),
        new Producto(2, "Mouse óptico", 50, "33-66-99", 1),
        new Producto(3, "Teclado mecánico", 25, "07-31-56", 5),
        new Producto(4, "Monitor LED 24''", 15, "89-23-45", 2),
        new Producto(5, "Impresora láser", 8, "62-44-11", 3),
        new Producto(6, "Silla ergonómica", 5, "18-27-36", 4),
        new Producto(7, "Disco duro SSD 1TB", 30, "54-67-82", 6),
        new Producto(8, "Auriculares inalámbricos", 40, "22-39-71", 7),
        new Producto(9, "Tablet 10''", 20, "93-12-56", 8),
        new Producto(10, "Cámara web HD", 12, "05-88-64", 9),
    ];

    public static List<Transportista> ListaTransportistas =
     [
         new Transportista(20-12345678-3, "Juan Pérez"),
         new Transportista(27-87654321-5, "María Gómez"),
         new Transportista(23-45678901-7, "Carlos Rodríguez"),
         new Transportista(30-23456789-9, "Laura Fernández"),
         new Transportista(24-98765432-1, "Diego Sánchez"),
         new Transportista(22-65432198-4, "Ana López"),
         new Transportista(21-34567890-6, "Pedro Martínez"),
         new Transportista(26-10987654-2, "Sofía Torres"),
         new Transportista(28-56789012-8, "Roberto Vargas"),
         new Transportista(29-76543210-0, "Elena Ramírez")
     ];
}

//    Producto = new List<Productos>
//{
//    new Productos(1, "Laptop", 10, "12-45-78", 1),
//    new Productos(2, "Mouse óptico", 50, "33-66-99", 1),
//    new Productos(3, "Teclado mecánico", 25, "07-31-56", 5),
//    new Productos(4, "Monitor LED 24''", 15, "89-23-45", 2),
//    new Productos(5, "Impresora láser", 8, "62-44-11", 3),
//    new Productos(6, "Silla ergonómica", 5, "18-27-36", 4),
//    new Productos(7, "Disco duro SSD 1TB", 30, "54-67-82", 6),
//    new Productos(8, "Auriculares inalámbricos", 40, "22-39-71", 7),
//    new Productos(9, "Tablet 10''", 20, "93-12-56", 8),
//    new Productos(10, "Cámara web HD", 12, "05-88-64", 9),
//};




//ProductosPorCliente = new List<ProductosPorCliente>
//{
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




// };

//public List<Cliente> listaClientes = new List<Cliente>
//{ 
//  new Cliente

//}


//}
//}
