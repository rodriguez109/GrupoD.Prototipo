using GrupoD.Prototipo._1._OrdenDePreparacion;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
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
        }

        //El formulario tiene una referencia al modelo
        private OrdenDePreparacionModelo modelo2;
        private List<OrdenesDePreparacion> OrdenesPreparacionDisponibles = new List<OrdenesDePreparacion>();
        private List<OrdenesDePreparacion> OrdenesAgregadas = new List<OrdenesDePreparacion>();

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
        private Cliente BuscarCliente(string numeroCliente, string razonSocial, List<Cliente> listaClientes)
        {
            if (int.TryParse(numeroCliente, out int numeroClienteInt))
            {
                // Buscar por número de cliente
                //return listaClientes.FirstOrDefault(c => c.NumeroCliente == numeroClienteInt);
                return listaClientes.FirstOrDefault(c =>
                    c.NumeroCliente == numeroClienteInt ||
                    c.RazonSocialCliente.Equals(razonSocial, StringComparison.OrdinalIgnoreCase));
            }
            return listaClientes.FirstOrDefault(c =>
                c.RazonSocialCliente.Equals(razonSocial, StringComparison.OrdinalIgnoreCase));
        }

        //Agrega clientes al ListView
        private void CargarProductosCliente(Cliente cliente)
        {
            productosClienteLST.Items.Clear(); // Limpia los datos previos

            if (cliente == null)
            {
                MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var producto in cliente.Producto)
            {
                var item = new ListViewItem(producto.SkuProducto);
                item.SubItems.Add(producto.NombreProducto);
                item.SubItems.Add(producto.CantidadProducto.ToString());
                item.SubItems.Add(producto.PosicionProducto);

                productosClienteLST.Items.Add(item);
            }
        }
        //EVENTOS DEL FORMULARIO---------------------------------------------------------------------------------------

        private void cancelarBTN_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario sin guardar cambios
            this.Close();
        }

        private void buscarProductosBTN_Click(object sender, EventArgs e)
        {
            string numeroCliente = numeroClienteTXT.Text;
            string razonSocialCliente = razonSocialClienteTXT.Text;

            if (string.IsNullOrEmpty(numeroCliente) || string.IsNullOrEmpty(razonSocialCliente))
            {
                MessageBox.Show("Por favor, complete alguno de los campos.");
                return;
            }
            // Validar que solo uno de los dos campos esté lleno
            if (!string.IsNullOrEmpty(numeroClienteTXT.Text) && !string.IsNullOrEmpty(razonSocialClienteTXT.Text))
            {
                MessageBox.Show("Debe ingresar solo uno de los dos campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            //Validar que número es un numero
            if (!string.IsNullOrEmpty(numeroCliente) && !int.TryParse(numeroCliente, out int numeroClienteInt))
            {
                MessageBox.Show("El número de cliente no es válido.");
                return;
            }
            //Validar que razón social es un texto y no tiene más de 50 caracteres
            if (razonSocialClienteTXT.TextLength > 150)
            {
                MessageBox.Show("Razón Social no puede exceder los 50 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica que solo contenga letras y espacios (expresión regular)
            if (!Regex.IsMatch(razonSocialCliente, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("Razón Social solo puede contener letras y espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Muestra los datos en el listview
            Cliente clienteEncontrado = BuscarCliente(numeroCliente, razonSocialCliente, listaClientes);

            CargarProductosCliente(clienteEncontrado);




        }

        private void generarOPBTN_Click(object sender, EventArgs e)
        {
            var NumeroOrdenPreparacion = numeroOrdenPreparacionTextBox.Text;
            var nombreProducto = productoSeleccionadoTXT.Text;
            var cantidadProducto = cantidadSeleccionadaTXT.Text;
            if (!int.TryParse(cantidadProducto, out int cantidad))
            {
                MessageBox.Show("La cantidad no es válida.");
                return;
            }

            var fechaRetirar = fechaRetirarTXT.Text;
            if (!DateTime.TryParse(fechaRetirar, out DateTime fechaRetirarDate))
            {
                MessageBox.Show("La fecha de retiro no es válida.");
                return;
            }
            var prioridad = prioridadCMB.SelectedValue.ToString();
            var cuilTransportista = cuilTransportistaTXT.Text;
            if (!int.TryParse(cuilTransportista, out int cuil))
            {

                MessageBox.Show("El CUIL del transportista no es válido.");
                return;
            }

        }

       
    }
}
