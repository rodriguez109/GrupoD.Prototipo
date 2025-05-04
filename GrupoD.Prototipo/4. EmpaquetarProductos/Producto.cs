namespace GrupoD.Prototipo._4._Empaquetar_Productos
{
    internal class Producto
    {
        // Atributos
        public int SKUProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadProducto { get; set; }

        // Constructor
        public Producto(int skuProducto, string nombreProducto, int cantidadProducto)
        {
            SKUProducto = skuProducto;
            NombreProducto = nombreProducto;
            CantidadProducto = cantidadProducto;
        }
    }
}