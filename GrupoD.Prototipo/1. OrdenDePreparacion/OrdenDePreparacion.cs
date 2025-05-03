using GrupoD.Prototipo._1._OrdenDePreparacion;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo._4._EmpaquetarProductos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion
{
    public partial class OrdenDePreparacion : Form
    {

        public OrdenDePreparacion()
        {
            InitializeComponent();
        }

        //El formulario tiene una referencia al modelo
        private OrdenDePreparacionModelo modelo;
        //private List<OrdenesDePreparacion> OrdenesPreparacionDisponibles = new List<OrdenesDePreparacion>();
        //private List<OrdenesDePreparacion> OrdenesAgregadas = new List<OrdenesDePreparacion>();
        private List<Cliente> listaClientes = new List<Cliente>();
        private List<Producto> productos = new List<Producto>();

        private void OrdenDePreparacion_Load(object sender, EventArgs e)
        {
            modelo2 = new OrdenDePreparacionModelo();
            // Aquí puedes inicializar el modelo o cargar datos si es necesario

            //Habilitar las partes superiores del formulario
            numeroClienteTXT.Enabled = true;
            razonSocialClienteTXT.Enabled = true;
            buscarProductosBTN.Enabled = true;
            limpiarFiltrosBTN.Enabled = true;

            //Vincular evento para el DateTimePicker
            fechaRetirarDTP.ValueChanged += FechaRetirarDTP_ValueChanged;

        }
        // Evento para establecer el formato correcto cuando el usuario selecciona una fecha
        private void FechaRetirarDTP_ValueChanged(object sender, EventArgs e)
        {
            fechaRetirarDTP.CustomFormat = "dd/MM/yyyy"; // Mostrar la fecha correctamente al seleccionarla
        }
        // Buscar clientes por razon social/numero
        //private Cliente BuscarCliente(string numeroCliente, string razonSocial)
        //{
        //    if (int.TryParse(numeroCliente, out int numeroClienteInt))
        //    {
        //        return listaClientes.FirstOrDefault(c => c.NumeroCliente == numeroClienteInt ||
        //                                                 c.RazonSocialCliente.Equals(razonSocial, StringComparison.OrdinalIgnoreCase));
        //    }
        //    else
        //    {
        //        return listaClientes.FirstOrDefault(c => c.RazonSocialCliente.Equals(razonSocial, StringComparison.OrdinalIgnoreCase));
        //    }
        //}

        //Obtener productos del cliente
        //private List<Producto> ObtenerProductosPorCliente(int numeroCliente)
        //{
        //  return Producto.Where(p => p.NumeroCliente == numeroCliente).ToList();
        //}

        //Cargar productos
        // private void CargarProductosCliente(int numeroCliente)
        //{
        //   productosClienteLST.Items.Clear();

        //   List<Producto> productosCliente = ObtenerProductosPorCliente(numeroCliente);

        // if (productosCliente.Count == 0)
        //{
        //  MessageBox.Show("Este cliente no tiene productos registrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //return;
        //}

        //foreach (var producto in productosCliente)
        //{
        //  var item = new ListViewItem(producto.SKUProducto.ToString());
        //item.SubItems.Add(producto.NombreProducto);
        //item.SubItems.Add(producto.Cantidad.ToString());
        //item.SubItems.Add(producto.Posicion);

        //productosClienteLST.Items.Add(item);
        //}
        //}



        //Agrega clientes al ListView
        //private void CargarProductosCliente(Cliente cliente)
        //{
        //  productosClienteLST.Items.Clear(); // Limpia los datos previos

        //List<Producto> productosCliente = ObtenerProductosPorCliente(numeroCliente);
        //if (cliente == null)
        //            {
        //                MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                return;
        //            }

        //            foreach (var producto in productosCliente)
        //            {
        //                var item = new ListViewItem(producto.SkuProducto);
        //    item.SubItems.Add(producto.NombreProducto);
        //                item.SubItems.Add(producto.CantidadProducto.ToString());
        //                item.SubItems.Add(producto.PosicionProducto);

        //                productosClienteLST.Items.Add(item);
        //            }
        //        }
        //        //EVENTOS DEL FORMULARIO---------------------------------------------------------------------------------------

        //        private void cancelarBTN_Click(object sender, EventArgs e)
        //{
        //    // Cerrar el formulario sin guardar cambios
        //    this.Close();
        //}

        //private void buscarProductosBTN_Click(object sender, EventArgs e)
        //{
        //    //Limpiar filtros
        //    numeroClienteTXT.Clear();
        //    razonSocialClienteTXT.Clear();

        //    string numeroCliente = numeroClienteTXT.Text;
        //    string razonSocialCliente = razonSocialClienteTXT.Text;

        //    if (string.IsNullOrEmpty(numeroCliente) || string.IsNullOrEmpty(razonSocialCliente))
        //    {
        //        MessageBox.Show("Por favor, complete alguno de los campos.");
        //        return;
        //    }
        //    // Validar que solo uno de los dos campos esté lleno
        //    if (!string.IsNullOrEmpty(numeroClienteTXT.Text) && !string.IsNullOrEmpty(razonSocialClienteTXT.Text))
        //    {
        //        MessageBox.Show("Debe ingresar solo uno de los dos campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    //Validar que número es un numero
        //    if (!string.IsNullOrEmpty(numeroCliente) && !int.TryParse(numeroCliente, out int numeroClienteInt))
        //    {
        //        MessageBox.Show("El número de cliente no es válido.");
        //        return;
        //    }
        //    //Validar que razón social es un texto y no tiene más de 150 caracteres
        //    if (razonSocialClienteTXT.TextLength > 150)
        //    {
        //        MessageBox.Show("Razón Social no puede exceder los 50 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // Verifica que solo contenga letras y espacios (expresión regular)
        //    if (!Regex.IsMatch(razonSocialCliente, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
        //    {
        //        MessageBox.Show("Razón Social solo puede contener letras y espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    //Muestra los datos en el listview


        //    Cliente clienteEncontrado = BuscarCliente(numeroClienteTXT, razonSocialClienteTXT);

        //    if (clienteEncontrado != null)
        //    {
        //        CargarProductosCliente(clienteEncontrado.NumeroCliente);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            string numeroClienteTexto = numeroClienteTXT.Text;
            string razonSocialTexto = razonSocialClienteTXT.Text;

            Cliente clienteEncontrado = BuscarCliente(numeroClienteTexto, razonSocialTexto);

            if (clienteEncontrado != null)
            {
                CargarProductosCliente(clienteEncontrado.NumeroCliente);
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Cliente BuscarCliente(string numeroCliente, string razonSocial)
        {
            if (int.TryParse(numeroCliente, out int numeroClienteInt))
            {
                return listaClientes.FirstOrDefault(c => c.NumeroCliente == numeroClienteInt ||
                                                         c.RazonSocialCliente.Equals(razonSocial, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                return listaClientes.FirstOrDefault(c => c.RazonSocialCliente.Equals(razonSocial, StringComparison.OrdinalIgnoreCase));
            }
        }

        private void CargarProductosCliente(int numeroCliente)
        {
            productosClienteLST.Items.Clear();

            List<Producto> productosCliente = ObtenerProductosPorCliente(numeroCliente);

            if (productosCliente.Count == 0)
            {
                MessageBox.Show("Este cliente no tiene productos registrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var producto in productosCliente)
            {
                var item = new ListViewItem(producto.SKUProducto.ToString());
                item.SubItems.Add(producto.NombreProducto);
                item.SubItems.Add(producto.Cantidad.ToString());
                item.SubItems.Add(producto.Posicion);

                productosClienteLST.Items.Add(item);
            }
        }

        private List<Producto> ObtenerProductosPorCliente(int numeroCliente)
        {
            List<Producto> productosCliente = new List<Producto>();

            foreach (var producto in OrdenDePreparacionModelo.ListaProductos) // Usa la lista correcta
            {
                if (producto.NumeroCliente == numeroCliente)
                {
                    productosCliente.Add(producto);
                }
            }

            return productosCliente;
        }

        private void limpiarFiltrosBTN_Click(object sender, EventArgs e)
        {
            // Limpiar los campos de búsqueda
            numeroClienteTXT.Clear();
            razonSocialClienteTXT.Clear();
            productosClienteLST.Items.Clear();
        }

        private void productosClienteLST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productosClienteLST.SelectedItems.Count > 0) // Verifica que haya una selección
            {
                ListViewItem itemSeleccionado = productosClienteLST.SelectedItems[0];

                // Asignar datos a los TextBox
                productoSeleccionadoTXT.Text = itemSeleccionado.SubItems[1].Text; // Nombre del producto
                cantidadDisponibleTXT.Text = itemSeleccionado.SubItems[2].Text; // Cantidad disponible
            }
        }

        private void cantidadSeleccionadaTXT_TextChanged(object sender, EventArgs e)
        {
            //Limpiar la cantidad seleccionada
            cantidadSeleccionadaTXT.Clear();
            // Validar que la cantidad seleccionada sea un número entero
            if (!int.TryParse(cantidadSeleccionadaTXT.Text, out int cantidadSeleccionada))
            {
                MessageBox.Show("La cantidad seleccionada no es válida.");
                return;
            }
            // Validar que la cantidad seleccionada no exceda la cantidad disponible
            if (cantidadSeleccionada > int.Parse(cantidadDisponibleTXT.Text))
            {
                MessageBox.Show("La cantidad seleccionada excede la cantidad disponible.");
                return;
            }
        }

        private void agregarProductoBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(productoSeleccionadoTXT.Text) || string.IsNullOrEmpty(cantidadDisponibleTXT.Text))
            {
                MessageBox.Show("Seleccione un producto y una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener los valores de los TextBox
            string nombreProducto = productoSeleccionadoTXT.Text;
            string cantidadSeleccionada = cantidadDisponibleTXT.Text;
            string posicionProducto = productosClienteLST.SelectedItems[0].SubItems[3].Text; // Posición del producto

            // Crear un nuevo ítem para el ListView de la Orden de Preparación
            ListViewItem nuevoItem = new ListViewItem(nombreProducto);
            nuevoItem.SubItems.Add(cantidadSeleccionada);
            nuevoItem.SubItems.Add(posicionProducto);

            // Agregar el producto al ListView de la Orden de Preparación
            ordenPreparacionLST.Items.Add(nuevoItem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prioridadCMB.Items.Add("Alta");
            prioridadCMB.Items.Add("Media");
            prioridadCMB.Items.Add("Baja");

            prioridadCMB.SelectedIndex = 1; // Preselecciona "Media" por defecto
        }
        private int numeroOrden = 1; // Variable autonumérica para las órdenes

        private void generarOPBTN_Click(object sender, EventArgs e)
        {
            if (ordenPreparacionLST.Items.Count == 0)
            {
                MessageBox.Show("Debe agregar productos a la Orden de Preparación antes de generarla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(prioridadCMB.Text))
            {
                MessageBox.Show("Seleccione una prioridad para la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(cuilTransportistaTXT.Text) || cuilTransportistaTXT.Text.Length != 11)
            {
                MessageBox.Show("Ingrese un CUIL válido de 11 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaRetiro = fechaRetirarDTP.Value; // Obtener fecha como DateTime
            string prioridadSeleccionada = prioridadCMB.Text;
            string cuilTransportista = cuilTransportistaTXT.Text;

            List<OrdenDePreparacionClase> nuevaOrden = new List<OrdenDePreparacionClase>();

            foreach (ListViewItem item in ordenPreparacionLST.Items)
            {
                OrdenDePreparacionClase orden = new OrdenDePreparacionClase
                {
                    NumeroOrdenPreparacion = numeroOrden, // Número autonumérico
                    NombreProducto = item.SubItems[0].Text,
                    CantidadProducto = item.SubItems[1].Text,
                    Posicion = item.SubItems[2].Text,
                    FechaRetirar = fechaRetiro, // Obtiene la fecha correctamente
                    Prioridad = prioridadSeleccionada, // Obtiene la prioridad desde el ComboBox
                    CUILTransportista = cuilTransportista // Obtiene el CUIL desde el TextBox
                };

                nuevaOrden.Add(orden);
            }

            // Incrementar el número de orden para la próxima vez
            numeroOrden++;

            MessageBox.Show($"Orden de Preparación Nº {numeroOrden - 1} generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        //private void agregarProductoBTN_Click(object sender, EventArgs e)
        //{
        //    if (productosClienteLST.SelectedItems.Count == 0)
        //    {
        //        MessageBox.Show("Seleccione un producto antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (string.IsNullOrEmpty(cantidadDisponibleTXT.Text))
        //    {
        //        MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // Obtener valores de los controles
        //    string nombreProducto = productoSeleccionadoTXT.Text;
        //    string cantidadSeleccionada = cantidadDisponibleTXT.Text;
        //    string posicionProducto = productosClienteLST.SelectedItems[0].SubItems[3].Text; // Posición del producto
        //    string fechaRetiro = fechaRetirarDTP.Value.ToShortDateString(); // Convertir fecha a formato corto

        //    // Crear un nuevo ítem con la fecha incluida
        //    ListViewItem nuevoItem = new ListViewItem(nombreProducto);
        //    nuevoItem.SubItems.Add(cantidadSeleccionada);
        //    nuevoItem.SubItems.Add(posicionProducto);
        //    nuevoItem.SubItems.Add(fechaRetiro); // Agrega la fecha al ListView

        //    // Agregar el producto a la Orden de Preparación
        //    ordenPreparacionLST.Items.Add(nuevoItem);
        //}

        //private void generarOPBTN_Click(object sender, EventArgs e)
        //{
        //    var NumeroOrdenPreparacion = numeroOrdenPreparacionTextBox.Text;
        //    var nombreProducto = productoSeleccionadoTXT.Text;
        //    var cantidadProducto = cantidadSeleccionadaTXT.Text;
        //    if (!int.TryParse(cantidadProducto, out int cantidad))
        //    {
        //        MessageBox.Show("La cantidad no es válida.");
        //        return;
        //    }

        //    var fechaRetirar = fechaRetirarTXT.Text;
        //    if (!DateTime.TryParse(fechaRetirar, out DateTime fechaRetirarDate))
        //    {
        //        MessageBox.Show("La fecha de retiro no es válida.");
        //        return;
        //    }
        //    var prioridad = prioridadCMB.SelectedValue.ToString();
        //    var cuilTransportista = cuilTransportistaTXT.Text;
        //    if (!int.TryParse(cuilTransportista, out int cuil))
        //    {

        //        MessageBox.Show("El CUIL del transportista no es válido.");
        //        return;
        //    }

        //}


    }
}
