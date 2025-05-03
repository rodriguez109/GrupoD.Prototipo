
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoD.Prototipo._4._Empaquetar_Productos;



namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    class EmpaquetarProductosModelo
    {
        public List<OrdenPreparacion> OrdenesEnPreparacionDisponibles { get; set; }
        public List<Producto> ProductosOrden { get; set; }

        public EmpaquetarProductosModelo()
        {
            //hardcodeamos datos
            OrdenesEnPreparacionDisponibles = new List<OrdenPreparacion>
            {
                new OrdenPreparacion { NumeroOrden = 1},
                new OrdenPreparacion { NumeroOrden = 2},
            };

            ProductosOrden = new List<Producto>
            {
                new Producto { SKUProducto = "A1", NombreProducto = "Mesa", CantidadProducto = 10},
                new Producto { SKUProducto = "A2", NombreProducto = "Esmaltex6", CantidadProducto = 999},
            };

            OrdenesAgregadas = new List<OrdenPreparacion>();
            ProductosAgregados = new List<Producto>();

           
        }

        //Cambiar estado de orden de "en preparacion" a "preparada"

        //Salir

        //Confirmar
    }
}

