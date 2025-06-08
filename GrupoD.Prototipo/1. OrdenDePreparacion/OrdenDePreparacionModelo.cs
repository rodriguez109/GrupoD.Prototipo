using GrupoD.Prototipo.Almacenes;

namespace GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion;

internal class OrdenDePreparacionModelo
{
    public List<Cliente> Clientes { get; set; }
    public List<Producto> Productos { get; set; }
    public List<Transportista> Transportistas { get; set; }

    public OrdenDePreparacionModelo()
    {
        Clientes = ClienteAlmacen.Clientes.Select(c => new Cliente(c.Numero, c.RazonSocial)).ToList();
        Transportistas = TransportistaAlmacen.Transportistas.Select(t => new Transportista(t.DNI, t.Nombre)).ToList();
        CargarDatosIniciales();
    }

    public int ObtenerProximoNumero() => OrdenDePreparacionAlmacen.OrdenesDePreparacion.Select(o => o.Numero).DefaultIfEmpty().Max() + 1;

    public bool ValidarDNITransportista(int dni) => Transportistas.Any(t => t.DNITransportista == dni);

    public void CrearOrdenesDesdeItems(
        IEnumerable<ListViewItem> items,
        int numeroCliente,
        string razonSocialCliente,
        DateTime fechaRetirar,
        string prioridadSeleccionada,
        int dniTransportista,
        bool pallet)
    {
        if (items == null || !items.Any())
        {
            throw new Exception("Debe agregar productos a la Orden de Preparación antes de generarla.");
        }

        var orden = new OrdenDePreparacionEntidad
        {
            Numero = ObtenerProximoNumero(),
            Pallet = pallet,
            CodigoDeposito = DepositoAlmacen.CodigoDepositoActual,
            FechaRetirar = fechaRetirar,
            Prioridad = prioridadSeleccionada switch
            {
                "Alta" => PrioridadEnum.Alta,
                "Media" => PrioridadEnum.Media,
                "Baja" => PrioridadEnum.Baja,

            },
            NumeroCliente = numeroCliente,
            DNITransportista = dniTransportista,
            Estado = EstadoOrdenDePreparacionEnum.Pendiente,
            Detalle = []
        };

        foreach (var item in items)
        {
            var skuTexto = item.SubItems[0].Text;
            var nombreProducto = item.SubItems[1].Text;
            var cantidadTexto = item.SubItems[2].Text;
            var sku = int.Parse(item.SubItems[0].Text);
            var cantidad = int.Parse(item.SubItems[2].Text);

            var productoStock = ProductoAlmacen.Productos.FirstOrDefault(p => p.SKU == sku);
            if (productoStock == null)
            {
                throw new Exception($"Producto no encontrado (SKU: {sku}).");
            }

            var cantidadEnDepositoActual = productoStock.CantidadEnDeposito(DepositoAlmacen.CodigoDepositoActual);
            if (cantidadEnDepositoActual < cantidad)
            {
                throw new Exception($"Stock insuficiente para el producto {productoStock.Nombre}. Stock disponible: {cantidadEnDepositoActual}");
            }

            var codigoDeposito = string.Empty;
            if (productoStock.Posiciones != null && productoStock.Posiciones.Any())
            {
                codigoDeposito = productoStock.Posiciones.First().CodigoDeposito;
            }
            else
            {
                throw new Exception($"No se encontró una posición para el producto {productoStock.Nombre}.");
            }

            orden.Detalle.Add(new ProductosPorOrden { SKU = sku, Cantidad = cantidad });
        }

        OrdenDePreparacionAlmacen.Agregar(orden);
        _ = MessageBox.Show($"Orden de Preparación Nº {orden.Numero} generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        CargarDatosIniciales();
    }

    private void CargarDatosIniciales()
    {
        Productos = ProductoAlmacen.Productos
                    .Where(p => p.Posiciones != null &&
                                p.Posiciones.Any(pos => pos.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual))
                    .Select(p => new Producto(
                        p.SKU,
                        p.Nombre,
                        p.CantidadEnDeposito(DepositoAlmacen.CodigoDepositoActual),
                        ConvertirPosicionesAString(p.Posiciones),
                        p.NumeroCliente))
                    .ToList() ?? [];

        foreach (var producto in Productos)
        {
            producto.Cantidad -= OrdenDePreparacionAlmacen.OrdenesDePreparacion
                                                          .Where(o => o.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual)
                                                          .Where(o => o.Estado is EstadoOrdenDePreparacionEnum.Pendiente or EstadoOrdenDePreparacionEnum.Procesamiento)
                                                          .SelectMany(o => o.Detalle)
                                                          .Where(o => o.SKU == producto.SKUProducto)
                                                          .Sum(o => o.Cantidad);
        }
    }

    private string ConvertirPosicionesAString(List<PosicionesPorProducto> posiciones)
    {

        if (posiciones == null || posiciones.Count == 0)
        {
            return string.Empty;
        }

        return string.Join(",", posiciones.Select(pos => $"{pos.Codigo}:{pos.Stock}:{pos.CodigoDeposito}")); 


    }


}





