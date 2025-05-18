namespace GrupoD.Prototipo._4._Empaquetar_Productos
{
    internal class Producto
    {
        // Atributos
        public int SKUProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadSeleccionada { get; set; }

        // Constructor
        public Producto(int skuProducto, string nombreProducto, int cantidadSeleccionada)
        {
            SKUProducto = skuProducto;
            NombreProducto = nombreProducto;
            CantidadSeleccionada = cantidadSeleccionada; // CantidadSeleccionada o CantidadProducto??? OrdenSeleccionada
        }
    }
}