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
        private OrdenDePreparacionModelo modelo;
        public OrdenDePreparacion()
        {
            InitializeComponent();
            this.Load += new EventHandler(OrdenDePreparacion_Load);
            //ConfigurarAutoCompletar();
            //ConfigurarAutoCompletarDNITransportista();
        }

        //El formulario tiene una referencia al modelo
        //private OrdenDePreparacionModelo modelo;
        //private List<OrdenesDePreparacion> OrdenesPreparacionDisponibles = new List<OrdenesDePreparacion>();
        //private List<OrdenesDePreparacion> OrdenesAgregadas = new List<OrdenesDePreparacion>();
        //private List<Cliente> listaClientes = new List<Cliente>();
        //private List<Producto> productos = new List<Producto>();

        private void OrdenDePreparacion_Load(object sender, EventArgs e)
        {
            modelo = new OrdenDePreparacionModelo();
            // Aquí puedes inicializar el modelo o cargar datos si es necesario

            //Habilitar las partes superiores del formulario
            numeroClienteTXT.Enabled = true;
            razonSocialClienteTXT.Enabled = true;
            //buscarProductosBTN.Enabled = true;
            //limpiarFiltrosBTN.Enabled = true;

            //Vincular evento para el DateTimePicker
            fechaRetirarDTP.ValueChanged += FechaRetirarDTP_ValueChanged;

            //Configurar DateTimePicker para mostrar fecha actual como fecha mínima
            fechaRetirarDTP.MinDate = DateTime.Today;

            ConfigurarAutoCompletar();


            prioridadCMB.Items.Clear(); // Limpiar elementos previos
            prioridadCMB.Items.Add("Alta");
            prioridadCMB.Items.Add("Media");
            prioridadCMB.Items.Add("Baja");

            prioridadCMB.SelectedIndex = 1; // Preselecciona "Media" por defecto



            // Vincular el evento del ListView para actualizar los labels al seleccionar un producto
            productosClienteLST.SelectedIndexChanged += productosClienteLST_SelectedIndexChanged;




        }

        //Razón social: búsqueda por primeras letras

        private void ConfigurarAutoCompletar()
        {
            // Verifica que la instancia del modelo y la lista de clientes no sean nulas
            if (modelo == null)
            {
                MessageBox.Show("El modelo no está inicializado.");
                return;
            }

            if (modelo.Clientes == null)
            {
                MessageBox.Show("La lista de clientes no ha sido cargada.");
                return;
            }

            AutoCompleteStringCollection listaAutocompletar = new AutoCompleteStringCollection();

            // Agregar todas las razones sociales de los clientes a la lista de autocompletar
            foreach (var cliente in modelo.Clientes)
            {
                listaAutocompletar.Add(cliente.RazonSocialCliente);
            }

            // Configurar el campo de texto con la lista de autocompletar
            razonSocialClienteTXT.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            razonSocialClienteTXT.AutoCompleteSource = AutoCompleteSource.CustomSource;
            razonSocialClienteTXT.AutoCompleteCustomSource = listaAutocompletar;
        }


        //DNI Transportista: búsqueda por primeros números
        private void ConfigurarAutoCompletarDNITransportista()
        {
            // Se crea la colección de cadenas para el autocompletado
            AutoCompleteStringCollection listaAutocompletar = new AutoCompleteStringCollection();

            // Agregar todos los DNIs (convertidos a string) de los transportistas
            foreach (var transportista in modelo.Transportistas)
            {
                listaAutocompletar.Add(transportista.DNITransportista.ToString());
            }

            // Configurar el TextBox para usar el autocompletado con la lista personalizada
            dniTransportistaTXT.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dniTransportistaTXT.AutoCompleteSource = AutoCompleteSource.CustomSource;
            dniTransportistaTXT.AutoCompleteCustomSource = listaAutocompletar;
        }
        // Evento para establecer el formato correcto cuando el usuario selecciona una fecha
        private void FechaRetirarDTP_ValueChanged(object sender, EventArgs e)
        {
            fechaRetirarDTP.CustomFormat = "dd/MM/yyyy"; // Mostrar la fecha correctamente al seleccionarla
        }

        private Cliente BuscarCliente(int numeroCliente, string razonSocial)    //FIJARSE SI CLIENTE O CLIENTEALMACEN
        {
            // Verifica que se hayan cargado clientes en el modelo.
            if (modelo == null || modelo.Clientes == null || !modelo.Clientes.Any())
                return null;

            // Suponiendo que la clase Cliente tiene las propiedades 'Numero' y 'RazonSocial'
            Cliente clienteEncontrado = modelo.Clientes
                .FirstOrDefault(c => c.NumeroCliente == numeroCliente);

            if (clienteEncontrado == null && !string.IsNullOrEmpty(razonSocial))
            {
                clienteEncontrado = modelo.Clientes
                    .FirstOrDefault(c => c.RazonSocialCliente.Equals(razonSocial, StringComparison.OrdinalIgnoreCase));
            }

            return clienteEncontrado;
        }


        //public static Cliente BuscarCliente(int numeroCliente, string razonSocial)
        //{
        //    if (OrdenDePreparacionModelo.ListaCliente == null || !OrdenDePreparacionModelo.ListaCliente.Any())
        //        return null;

        //    Cliente clienteEncontrado = OrdenDePreparacionModelo.ListaCliente
        //        .FirstOrDefault(c => c.NumeroCliente == numeroCliente);

        //    if (clienteEncontrado == null && !string.IsNullOrEmpty(razonSocial))
        //    {
        //        clienteEncontrado = OrdenDePreparacionModelo.ListaCliente
        //            .FirstOrDefault(c => c.RazonSocialCliente.Equals(razonSocial, StringComparison.OrdinalIgnoreCase));
        //    }

        //    return clienteEncontrado;
        //}



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


                productosClienteLST.Items.Add(item);
            }
        }

        private List<Producto> ObtenerProductosPorCliente(int numeroCliente)
        {
            List<Producto> productosCliente = new List<Producto>();

            foreach (var producto in modelo.Productos) // Usa la lista correcta
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
            numeroClienteTXT.Text = "";
            razonSocialClienteTXT.Text = "";
        }

        
        private void productosClienteLST_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (productosClienteLST.SelectedItems.Count > 0)
            {
                // Captura el producto seleccionado
                ListViewItem itemSeleccionado = productosClienteLST.SelectedItems[0];

                // Verifica que el ListViewItem tenga suficientes subitems
                if (itemSeleccionado.SubItems.Count >= 3)
                {
                    // Actualizar los Labels con el nombre y la cantidad
                    productoSeleccionadoLABEL.Text = itemSeleccionado.SubItems[1].Text; // Nombre del producto
                    cantidadDisponibleLABEL.Text = itemSeleccionado.SubItems[2].Text; // Cantidad disponible
                }
                else
                {
                    MessageBox.Show("Error: El producto seleccionado no tiene suficientes datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Si no hay selección, los labels quedan vacíos
                productoSeleccionadoLABEL.Text = "Seleccione un producto";
                cantidadDisponibleLABEL.Text = "0";
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
            if (cantidadSeleccionada > int.Parse(cantidadDisponibleLABEL.Text))
            {
                MessageBox.Show("La cantidad seleccionada excede la cantidad disponible.");
                return;
            }
        }

        private int clienteFijo = -1; //Variable para almacenar el cliente seleccionado 
       
        private void agregarProductoBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(productoSeleccionadoLABEL.Text) || string.IsNullOrEmpty(cantidadDisponibleLABEL.Text) || string.IsNullOrEmpty(cantidadSeleccionadaTXT.Text))
            {
                MessageBox.Show("Seleccione un producto y especifique una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convertir los valores a números para comparación
            if (!int.TryParse(cantidadSeleccionadaTXT.Text, out int cantidadSeleccionada) || !int.TryParse(cantidadDisponibleLABEL.Text, out int cantidadDisponible))
            {
                MessageBox.Show("Ingrese una cantidad numérica válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que la cantidad seleccionada sea mayor a cero
            if (cantidadSeleccionada <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que la cantidad seleccionada no sea mayor a la disponible
            if (cantidadSeleccionada > cantidadDisponible)
            {
                MessageBox.Show($"La cantidad seleccionada ({cantidadSeleccionada}) es mayor a la disponible ({cantidadDisponible}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int numeroCliente = 0;
            if (string.IsNullOrWhiteSpace(numeroClienteTXT.Text))
            {
                // Si no se ingresó un número de cliente, se busca por razón social.
                if (!string.IsNullOrWhiteSpace(razonSocialClienteTXT.Text))
                {
                    string razonSocial = razonSocialClienteTXT.Text.Trim();
                    var clienteEncontrado = modelo.Clientes
                    .FirstOrDefault(c => c.RazonSocialCliente.Equals(razonSocial, StringComparison.OrdinalIgnoreCase));

                    if (clienteEncontrado != null)
                    {
                        numeroCliente = clienteEncontrado.NumeroCliente;
                        // Opcional: actualizar el TextBox para reflejar el número obtenido.
                        numeroClienteTXT.Text = numeroCliente.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un cliente con la razón social ingresada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un número de cliente o una razón social válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (!int.TryParse(numeroClienteTXT.Text, out numeroCliente))
            {
                MessageBox.Show("El número de cliente debe ser un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bloquear cambio de cliente después de agregar productos
            if (ordenPreparacionLST.Items.Count > 0)
            {
                if (clienteFijo != numeroCliente)
                {
                    MessageBox.Show("No puede agregar productos de un cliente diferente a la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                clienteFijo = numeroCliente; // Fijar el cliente en la primera adición
            }


            // Obtener los valores correctos en el orden adecuado
            string skuProducto = productosClienteLST.SelectedItems[0].SubItems[0].Text; // SKU del producto
            string nombreProducto = productoSeleccionadoLABEL.Text; // Nombre del producto
            string cantidadSeleccionadaTexto = cantidadSeleccionadaTXT.Text; // Cantidad seleccionada

            // Crear un nuevo ítem para el ListView con las columnas correctamente ordenadas
            ListViewItem nuevoItem = new ListViewItem(skuProducto); // Primera columna: SKU Producto
            nuevoItem.SubItems.Add(nombreProducto); // Segunda columna: Nombre Producto
            nuevoItem.SubItems.Add(cantidadSeleccionadaTexto); // Tercera columna: Cantidad Seleccionada


            // Agregar el producto al ListView de la Orden de Preparación
            ordenPreparacionLST.Items.Add(nuevoItem);
        }


       
        private static int numeroOrden = 0; // Variable autonumérica para las órdenes
        private static int GenerarNumeroOrden()
        {
            return ++numeroOrden;
        }

        //private void generarOPBTN_Click(object sender, EventArgs e)
        //{

        //    if (ordenPreparacionLST.Items.Count == 0)
        //    {
        //        MessageBox.Show("Debe agregar productos a la Orden de Preparación antes de generarla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (string.IsNullOrEmpty(prioridadCMB.Text))
        //    {
        //        MessageBox.Show("Seleccione una prioridad para la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    int dniTransportista = 0;

        //    if (string.IsNullOrEmpty(dniTransportistaTXT.Text) || dniTransportistaTXT.Text.Length != 8 || !int.TryParse(dniTransportistaTXT.Text, out dniTransportista))
        //    {
        //        MessageBox.Show("Ingrese un DNI válido de 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // Validar el DNI del transportista con la lista de transportistas
        //    if (!ValidarDNITransportista(dniTransportista))
        //    {
        //        MessageBox.Show("Transportista no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }


        //    // Convertir númeroCliente a int
        //    if (!int.TryParse(numeroClienteTXT.Text, out int numeroCliente))
        //    {
        //        MessageBox.Show("El número de cliente debe ser un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    DateTime fechaRetiro = fechaRetirarDTP.Value; // Obtener fecha como DateTime
        //    string prioridadSeleccionada = prioridadCMB.Text;
        //    //string cuilTransportista = cuilTransportistaTXT.Text;
        //    /*int dniTransportista = int.Parse(dniTransportistaTXT.Text);*/ // Convertir a int

        //    string razonSocialCliente = razonSocialClienteTXT.Text;




        //    List<OrdenDePreparacionClase> nuevaOrden = new List<OrdenDePreparacionClase>();

        //    foreach (ListViewItem item in ordenPreparacionLST.Items)
        //    {
        //        // Obtener valores desde el ListView
        //        string nombreProducto = item.SubItems[1].Text;
        //        string cantidadTexto = item.SubItems[2].Text;
        //        string skuTexto = item.SubItems[0].Text;

        //        // Validar cantidad seleccionada
        //        if (!int.TryParse(cantidadTexto, out int cantidadSeleccionada) || cantidadSeleccionada <= 0)
        //        {
        //            MessageBox.Show($"La cantidad del producto '{nombreProducto}' no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (!int.TryParse(skuTexto, out int skuProducto))
        //        {
        //            MessageBox.Show($"El SKU del producto '{nombreProducto}' no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //            OrdenDePreparacionClase orden = new OrdenDePreparacionClase
        //        {
        //            NumeroOrdenPreparacion = numeroOrden, // Número autonumérico
        //            NumeroCliente = numeroCliente, // Número de cliente
        //            RazonSocialCliente = razonSocialCliente, // Razón social del cliente
        //            NombreProducto = item.SubItems[1].Text,
        //            CantidadProducto = item.SubItems[2].Text,

        //            SKUProducto = int.Parse(item.SubItems[0].Text), // SKU del producto

        //            FechaRetirar = fechaRetiro, // Obtiene la fecha correctamente
        //            Prioridad = prioridadSeleccionada, // Obtiene la prioridad desde el ComboBox
        //            /*CUILTransportista = cuilTransportista*/ // Obtiene el CUIL desde el TextBox
        //            //DNITransportista = int.Parse(dniTransportista)
        //            Pallet = palletCBX.Checked, //Pallet si o no
        //            DNITransportista = dniTransportista // Obtiene el DNI desde el TextBox

        //            };

        //        nuevaOrden.Add(orden);
        //    }


        //    // Incrementar el número de orden para la próxima vez
        //    numeroOrden++;

        //    MessageBox.Show($"Orden de Preparación Nº {numeroOrden - 1} generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    //Limpia los controles
        //    numeroClienteTXT.Clear();
        //    razonSocialClienteTXT.Clear();
        //    productosClienteLST.Items.Clear();
        //    ordenPreparacionLST.Items.Clear();
        //    cantidadSeleccionadaTXT.Clear();
        //    dniTransportistaTXT.Clear();

        //    modelo.AgregarNuevaOrden(nuevaOrden);
        //}

        private void generarOPBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se hayan agregado productos a la orden
                if (ordenPreparacionLST.Items.Count == 0)
                {
                    MessageBox.Show("Debe agregar productos a la Orden de Preparación antes de generarla.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Validar y convertir DNI del transportista
                if (string.IsNullOrEmpty(dniTransportistaTXT.Text) || dniTransportistaTXT.Text.Length != 8 ||
                    !int.TryParse(dniTransportistaTXT.Text, out int dniTransportista))
                {
                    MessageBox.Show("Ingrese un DNI válido de 8 dígitos.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Usar la validación del modelo
                if (!modelo.ValidarDNITransportista(dniTransportista))
                {
                    MessageBox.Show("Transportista no encontrado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar y convertir el número de cliente
                if (!int.TryParse(numeroClienteTXT.Text, out int numeroCliente))
                {
                    MessageBox.Show("El número de cliente debe ser un valor numérico válido.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener datos adicionales de la UI
                DateTime fechaRetirar = fechaRetirarDTP.Value;
                string prioridadSeleccionada = prioridadCMB.Text;
                string razonSocialCliente = razonSocialClienteTXT.Text;
                bool pallet = palletCBX.Checked;

                // Bloquear cambio de cliente si ya se han agregado productos
                if (ordenPreparacionLST.Items.Count > 0)
                {
                    if (clienteFijo != numeroCliente)
                    {
                        MessageBox.Show("No puede agregar productos de un cliente diferente a la orden.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    clienteFijo = numeroCliente; // Fijar el cliente en la primera adición
                }

                // Llamar al método del modelo para crear la orden y agregarla al almacen
                modelo.CrearOrdenesDesdeItems(
                    ordenPreparacionLST.Items.Cast<ListViewItem>(),
                    numeroCliente,
                    razonSocialCliente,
                    fechaRetirar,
                    prioridadSeleccionada,
                    dniTransportista,
                    pallet
                    


                );

                // Limpiar controles
                numeroClienteTXT.Clear();
                razonSocialClienteTXT.Clear();
                productosClienteLST.Items.Clear();
                ordenPreparacionLST.Items.Clear();
                cantidadSeleccionadaTXT.Clear();
                dniTransportistaTXT.Clear();                                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la orden: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buscarProductosBTN_Click(object sender, EventArgs e)
        {
            int numeroCliente = 0;
            string razonSocialTexto = razonSocialClienteTXT.Text.Trim();

            // Validar número de cliente solo si se ingresó
            if (!string.IsNullOrEmpty(numeroClienteTXT.Text))
            {
                if (!int.TryParse(numeroClienteTXT.Text, out numeroCliente))
                {
                    MessageBox.Show("Número de cliente inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (numeroCliente <= 0)
                {
                    MessageBox.Show("Número de cliente inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Validar que al menos haya ingresado un número de cliente o una razón social
            if (numeroCliente == 0 && string.IsNullOrEmpty(razonSocialTexto))
            {
                MessageBox.Show("Debe ingresar un número de cliente o una razón social.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar cliente con el método correcto
            Cliente clienteEncontrado = BuscarCliente(numeroCliente, razonSocialTexto);

            if (clienteEncontrado != null)
            {
                // Si el usuario ingresó ambos datos, verificar que coincidan
                if (numeroCliente > 0 && !string.IsNullOrEmpty(razonSocialTexto) &&
                    !clienteEncontrado.RazonSocialCliente.Equals(razonSocialTexto, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El número de cliente ingresado no coincide con la razón social.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Si la validación es correcta, cargar los productos
                CargarProductosCliente(clienteEncontrado.NumeroCliente);
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void quitarProductoBTN_Click(object sender, EventArgs e)
        {
            if (ordenPreparacionLST.SelectedItems.Count > 0)
            {
                // Eliminar el producto seleccionado
                ordenPreparacionLST.Items.Remove(ordenPreparacionLST.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Seleccione un producto para quitar de la orden de preparación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Razón social: búsqueda por primeras letras

        //private void ConfigurarAutoCompletar()
        //{
        //    // Verifica que la instancia del modelo y la lista de clientes no sean nulas
        //    if (modelo == null)
        //    {
        //        MessageBox.Show("El modelo no está inicializado.");
        //        return;
        //    }

        //    if (modelo.Clientes == null)
        //    {
        //        MessageBox.Show("La lista de clientes no ha sido cargada.");
        //        return;
        //    }

        //    AutoCompleteStringCollection listaAutocompletar = new AutoCompleteStringCollection();

        //    // Agregar todas las razones sociales de los clientes a la lista de autocompletar
        //    foreach (var cliente in modelo.Clientes)
        //    {
        //        listaAutocompletar.Add(cliente.RazonSocialCliente);
        //    }

        //    // Configurar el campo de texto con la lista de autocompletar
        //    razonSocialClienteTXT.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    razonSocialClienteTXT.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    razonSocialClienteTXT.AutoCompleteCustomSource = listaAutocompletar;
        //}


        ////DNI Transportista: búsqueda por primeros números
        //private void ConfigurarAutoCompletarDNITransportista()
        //{
        //    // Se crea la colección de cadenas para el autocompletado
        //    AutoCompleteStringCollection listaAutocompletar = new AutoCompleteStringCollection();

        //    // Agregar todos los DNIs (convertidos a string) de los transportistas
        //    foreach (var transportista in modelo.Transportistas)
        //    {
        //        listaAutocompletar.Add(transportista.DNITransportista.ToString());
        //    }

        //    // Configurar el TextBox para usar el autocompletado con la lista personalizada
        //    dniTransportistaTXT.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    dniTransportistaTXT.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    dniTransportistaTXT.AutoCompleteCustomSource = listaAutocompletar;
        //}

        private bool ValidarDNITransportista(int dni)
        {
            return modelo.Transportistas.Any(t => t.DNITransportista == dni);
        }











    }
}
