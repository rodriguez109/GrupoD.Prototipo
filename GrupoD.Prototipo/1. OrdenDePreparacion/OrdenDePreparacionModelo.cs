using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo.Almacenes;
using System;

using System.Collections.Generic;
using System.Drawing.Text;
using System.Reflection;
using System.Text.Json;

namespace GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion
{
    internal class OrdenDePreparacionModelo
    {
        // Propiedades públicas para almacenar datos

        public List<Cliente> Clientes { get; set; }

        public List<Producto> Productos { get; set; }

        public List<Transportista> Transportistas { get; set; }


        // Declaración correcta de listas estáticas
        //public static List<Cliente> ListaCliente = new List<Cliente>
        //{

        //    new Cliente(10, "Exportadora del Litoral S.A."),

        //    new Cliente(1, "Distribuidora San Martín S.A."),

        //    new Cliente(2, "Transporte del Sur SRL"),

        //    new Cliente(3, "Almacén La Cumbre S.A."),

        //    new Cliente(4, "Servicios Integrales Patagónicos SRL"),

        //    new Cliente(5, "Industrias Mendoza S.A.I.C."),

        //    new Cliente(6, "Tecnología Andina SRL"),

        //    new Cliente(7, "Comercializadora Norte Grande S.A."),

        //    new Cliente(8, "Textiles del Oeste SRL"),

        //    new Cliente(9, "Constructora Río de la Plata S.A.")

        //};

        //public static List<Producto> ListaProductos = new List<Producto>

        //{

        //    new Producto(1, "Laptop", 10, "12-45-78", 1),

        //    new Producto(2, "Mouse óptico", 50, "33-66-99", 1),

        //    new Producto(3, "Teclado mecánico", 25, "07-31-56", 5),

        //    new Producto(4, "Monitor LED 24''", 15, "89-23-45", 2),

        //    new Producto(5, "Impresora láser", 8, "62-44-11", 3),

        //    new Producto(6, "Silla ergonómica", 5, "18-27-36", 4),

        //    new Producto(7, "Disco duro SSD 1TB", 30, "54-67-82", 6),

        //    new Producto(8, "Auriculares inalámbricos", 40, "22-39-71", 7),

        //    new Producto(9, "Tablet 10''", 20, "93-12-56", 8),

        //    new Producto(10, "Cámara web HD", 12, "05-88-64", 9)

        //};

        //public static List<Transportista> ListaTransportistas = new List<Transportista>

        //{

        //    new Transportista(12345678, "Juan Pérez"),

        //    new Transportista(23456789, "María Gómez"),

        //    new Transportista(34567890, "Carlos Rodríguez"),

        //    new Transportista(34567891, "Laura Fernández"),

        //    new Transportista(34567892, "Diego Sánchez"),

        //    new Transportista(34567893, "Ana López"),

        //    new Transportista(34567894, "Pedro Martínez"),

        //    new Transportista(34567895, "Sofía Torres"),

        //    new Transportista(34567896, "Roberto Vargas"),

        //    new Transportista(34567897, "Elena Ramírez")

        //};




        //Constructor de la clase
        public OrdenDePreparacionModelo()
        {
            string ruta = @"Datos\Cliente.json";
            if (!File.Exists(ruta))
            {
                MessageBox.Show("No se encontró el archivo: " + ruta);
            }



            if (ClienteAlmacen.Clientes == null || !ClienteAlmacen.Clientes.Any())
            {
                MessageBox.Show("No se han cargado clientes desde el almacén.");
                Clientes = new List<Cliente>();
            }
            else
            {
                Clientes = ClienteAlmacen.Clientes
                    .Select(c => new Cliente(c.Numero, c.RazonSocial))
                    .ToList();
                MessageBox.Show("Clientes cargados en el modelo: " + Clientes.Count);
            }







            //Clientes = ClienteAlmacen.Clientes.Select(c => new Cliente(c.Numero, c.RazonSocial)).ToList();
            //Clientes = ClienteAlmacen.Clientes
            //.Select(c => new Cliente(c.Numero, c.RazonSocial /* o c.RazonSocialCliente, según tu necesidad */))
            //.ToList();



            Productos = ProductoAlmacen.Productos
                            .Where(p => p.Posiciones.Any(p => p.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual))
                            .Select(p => new Producto(p.SKU, p.Nombre, p.CantidadEnDeposito(DepositoAlmacen.CodigoDepositoActual), ConvertirPosicionesAString(p.Posiciones), p.NumeroCliente)).ToList();

            Transportistas = TransportistaAlmacen.Transportistas.Select(t => new Transportista(t.DNI, t.Nombre)).ToList();

            Clientes = ClienteAlmacen.Clientes.Select(c => new Cliente(c.Numero, c.RazonSocial)).ToList();
            //Clientes = new List<Cliente>();
            foreach (var clienteEntidad in ClienteAlmacen.Clientes)
            {
                var cliente = new Cliente(clienteEntidad.Numero, clienteEntidad.RazonSocial);
                Clientes.Add(cliente);
            }

            //Ajustar las cantidades de los productos restando lo que esté reservado por ordenes de preparación pendientes
            foreach (var producto in Productos)
            {
                producto.Cantidad -= OrdenDePreparacionAlmacen.OrdenesDePreparacion
                                                              .Where(o => o.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual)
                                                              .Where(o => o.Estado == EstadoOrdenDePreparacionEnum.Pendiente || o.Estado == EstadoOrdenDePreparacionEnum.Procesamiento)                                                              
                                                              .SelectMany(o => o.Detalle)
                                                              .Where(o => o.SKU == producto.SKUProducto)
                                                              .Sum(o => o.Cantidad);
            }

            //Productos = ProductoAlmacen.Productos.Select(p => new Producto(p.SKU, p.Nombre, p.Cantidad, p.Posiciones, p.NumeroCliente)).tolist();
            ////productos = new list<producto>(listaproductos);
            //foreach (var productoentidad in ProductoAlmacen.Productos)
            //{
            //    var producto = new Producto(productoentidad.SKU, productoentidad.Nombre, productoentidad.Cantidad, productoentidad.Posiciones, productoentidad.numerocliente);
            //    Productos.Add(producto);


            //}

            Transportistas = TransportistaAlmacen.Transportistas.Select(t => new Transportista(t.DNI, t.Nombre)).ToList();
            //Transportistas = new List<Transportista>(ListaTransportistas);
            foreach (var transportistaEntidad in TransportistaAlmacen.Transportistas)
            {
                var transportista = new Transportista(transportistaEntidad.DNI, transportistaEntidad.Nombre);
                Transportistas.Add(transportista);

            }
        }


        //public void AgregarNuevaOrden(List<OrdenDePreparacionClase> nuevaOrden)
        //{
        //    //modelo.AgregarNuevaOrden(nuevaOrden);
        //}

        //FULL PRUEBA
        private static int numeroOrden = 0; // Contador de órdenes autonumérico

        public static int GenerarNumeroOrden()
        {
            return ++numeroOrden;
        }

        public int ObtenerProximoNumero()
        {
            return OrdenDePreparacionAlmacen.OrdenesDePreparacion.Max(o => o.Numero) + 1;
        }




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
                throw new Exception("Debe agregar productos a la Orden de Preparación antes de generarla.");




            // Variable interna para generar números de orden
            int numeroOrdenLocal = ObtenerProximoNumero();




            foreach (ListViewItem item in items)
            {
                string skuTexto = item.SubItems[0].Text;
                string nombreProducto = item.SubItems[1].Text;
                string cantidadTexto = item.SubItems[2].Text;
                int sku = int.Parse(item.SubItems[0].Text);
                int cantidad = int.Parse(item.SubItems[2].Text);

                // Verificar el stock disponible en ProductoAlmacen.Productos
                var productoStock = ProductoAlmacen.Productos.FirstOrDefault(p => p.SKU == sku);
                if (productoStock == null)
                {
                    MessageBox.Show($"Producto no encontrado (SKU: {sku}).");
                    continue; // O puedes lanzar una excepción
                }

                int cantidadEnDepositoActual = productoStock.CantidadEnDeposito(DepositoAlmacen.CodigoDepositoActual);
                if (cantidadEnDepositoActual < cantidad)
                {
                    MessageBox.Show($"Stock insuficiente para el producto {productoStock.Nombre}. Stock disponible: {cantidadEnDepositoActual}");
                    continue; // Se impide la creación de la orden para este producto
                }

                string codigoDeposito = string.Empty;
                if (productoStock.Posiciones != null && productoStock.Posiciones.Any())
                {
                    // Por ejemplo, usar el de la primera posición
                    codigoDeposito = productoStock.Posiciones.First().CodigoDeposito;
                }
                else
                {
                    // Manejar el caso en que no haya posiciones definidas.
                    MessageBox.Show($"No se encontró una posición para el producto {productoStock.Nombre}.");
                    continue;
                }

                //Crear una entidad.
                OrdenDePreparacionEntidad orden = new OrdenDePreparacionEntidad
                {
                    Numero = numeroOrdenLocal,
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
                    Detalle = new List<ProductosPorOrden>(),

                    /*
                    SKUProducto = sku,
                    NombreProducto = nombreProducto,
                    CantidadProducto = cantidadTexto,
                    FechaRetirar = fechaRetirar,
                    Prioridad = prioridadSeleccionada,
                    DNITransportista = dniTransportista,
                    NumeroCliente = numeroCliente,
                    Pallet = pallet,
                    RazonSocialCliente = razonSocialCliente,
                    Posicion = "" // Se asigna según la lógica de la aplicación*/
                };

                // Verificar si la lista Detalle es null y inicializarla si es necesario
                if (orden.Detalle == null)
                {
                    orden.Detalle = new List<ProductosPorOrden>();
                }

                // Agregar detalles de productos
                orden.Detalle.Add(new ProductosPorOrden { SKU = sku, Cantidad = cantidad });

                // Agregar el detalle de productos a la orden
                ProductosPorOrden detalle = new ProductosPorOrden
                {
                    SKU = sku,
                    Cantidad = cantidad
                };
                orden.Detalle.Add(detalle);

                OrdenDePreparacionAlmacen.Agregar(orden);

                //numeroOrdenLocal++; // Incrementa para cada producto si buscas que cada ítem genere una orden única

                MessageBox.Show($"Orden de Preparación Nº {numeroOrdenLocal} generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Simula obtener el último número de orden registrado en el almacén;
        // eventualmente se consultaría al almacén de órdenes.
        private int ObtenerUltimoNumeroOrden()
        {
            // Aquí podrías consultar Almacenes.OrdenPreparacionAlmacen, de momento devolvemos un número hardcodeado.
            return 0;
        }

        private string ConvertirPosicionesAString(List<PosicionesPorProducto> posiciones)
        {

            if (posiciones == null || posiciones.Count == 0)
                return string.Empty;

            return string.Join(",", posiciones.Select(pos => $"{pos.Codigo}:{pos.Stock}:{pos.CodigoDeposito}")); // O manejar según tu lógica


        }
        // Validación de DNI del transportista usando la lista hardcodeada

        public bool ValidarDNITransportista(int dni)
        {
            return Transportistas.Any(t => t.DNITransportista == dni);
        }

        private void GuardarProductos()
        {
            string ruta = @"Datos\Producto.json";
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string datosJson = JsonSerializer.Serialize(ProductoAlmacen.Productos, opciones);
            File.WriteAllText(ruta, datosJson);
        }



    }


}





