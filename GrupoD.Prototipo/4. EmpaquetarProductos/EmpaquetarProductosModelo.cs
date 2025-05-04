using GrupoD.Prototipo._4._Empaquetar_Productos;

namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    internal class EmpaquetarProductosModelo
    {
        public List<OrdenPreparacion> OrdenesEnPreparacionDisponibles { get; set; }

        public EmpaquetarProductosModelo()
        {
            var productosEjemplo = new List<Producto>
                {
                    new Producto(1, "Laptop", 2),
                    new Producto(2, "Mouse óptico", 5),
                    new Producto(3, "Teclado mecánico", 3)
                };

            OrdenesEnPreparacionDisponibles = new List<OrdenPreparacion>
                {
                    new OrdenPreparacion
                    {
                        NumeroOrden = 1,
                        EstadoOrden = "En Preparacion",
                        Productos = productosEjemplo
                    },
                    new OrdenPreparacion
                    {
                        NumeroOrden = 2,
                        EstadoOrden = "En Preparacion",
                        Productos = new List<Producto>
                        {
                            new Producto(4, "Monitor LED", 1),
                            new Producto(5, "SSD", 2)
                        }
                    }
                };
        }
    }
}




//internal class EmpaquetarProductosModelo
//{
//    public List<OrdenPreparacion> OrdenesEnPreparacionDisponibles { get; set; }
//    public List<Producto> ProductosOrden { get; set; }


//    public EmpaquetarProductosModelo()
//    {
//        //hardcodeamos datos
//        OrdenesEnPreparacionDisponibles =
//        [
//            new OrdenPreparacion { NumeroOrden = 1},
//            new OrdenPreparacion { NumeroOrden = 2},
//        ];

//        ProductosOrden =
//        [
//            new Producto { SKUProducto = "A1", NombreProducto = "Mesa", CantidadProducto = 10},
//            new Producto { SKUProducto = "A2", NombreProducto = "Esmaltex6", CantidadProducto = 999},
//        ];
//    }

//    //Cambiar estado de orden de "en preparacion" a "preparada"
//    //Salir
//    //Confirmar
//}

