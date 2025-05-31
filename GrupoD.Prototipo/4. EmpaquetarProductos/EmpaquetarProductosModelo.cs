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
                    new Producto(1, "Mesa ratona de madera", 2),
                    new Producto(2, "Lámpara colgante LED", 5),
                    new Producto(3, "Smart TV 43 pulgadas", 1)
                };

            OrdenesEnPreparacionDisponibles = new List<OrdenPreparacion>
                {
                    new OrdenPreparacion
                    {
                        NumeroOrdenPreparacion = 1,
                        EstadoOrdenPreparacion = "En Preparacion",
                        Productos = productosEjemplo
                    },
                    new OrdenPreparacion
                    {
                        NumeroOrdenPreparacion = 2,
                        EstadoOrdenPreparacion = "En Preparacion",
                        Productos = new List<Producto>
                        {
                            new Producto(4, "Pintura látex interior 20L", 1),
                            new Producto(5, "Silla de comedor moderna", 1)
                        }
                    }
                };
        }
    }
}


