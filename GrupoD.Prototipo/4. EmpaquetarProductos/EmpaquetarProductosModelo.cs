using GrupoD.Prototipo._4._Empaquetar_Productos;

namespace GrupoD.Prototipo._4._EmpaquetarProductos;

internal class EmpaquetarProductosModelo
{
    public List<OrdenPreparacion> OrdenesEnPreparacionDisponibles { get; set; }
    public List<Producto> ProductosOrden { get; set; }


    public EmpaquetarProductosModelo()
    {
        //hardcodeamos datos
        OrdenesEnPreparacionDisponibles =
        [
            new OrdenPreparacion { NumeroOrden = 1},
            new OrdenPreparacion { NumeroOrden = 2},
        ];

        ProductosOrden =
        [
            new Producto { SKUProducto = "A1", NombreProducto = "Mesa", CantidadProducto = 10},
            new Producto { SKUProducto = "A2", NombreProducto = "Esmaltex6", CantidadProducto = 999},
        ];
    }

    //Cambiar estado de orden de "en preparacion" a "preparada"
    //Salir
    //Confirmar
}

