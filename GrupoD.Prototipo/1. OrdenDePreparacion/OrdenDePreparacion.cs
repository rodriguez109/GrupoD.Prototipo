﻿using GrupoD.Prototipo._1._OrdenDePreparacion;
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
            this.Load += new EventHandler(OrdenDePreparacion_Load);
        }

        //El formulario tiene una referencia al modelo
        private OrdenDePreparacionModelo modelo;
        //private List<OrdenesDePreparacion> OrdenesPreparacionDisponibles = new List<OrdenesDePreparacion>();
        //private List<OrdenesDePreparacion> OrdenesAgregadas = new List<OrdenesDePreparacion>();
        private List<Cliente> listaClientes = new List<Cliente>();
        private List<Producto> productos = new List<Producto>();

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


            prioridadCMB.Items.Clear(); // Limpiar elementos previos
            prioridadCMB.Items.Add("Alta");
            prioridadCMB.Items.Add("Media");
            prioridadCMB.Items.Add("Baja");

            prioridadCMB.SelectedIndex = 1; // Preselecciona "Media" por defecto

            // Vincular el evento del ListView para actualizar los labels al seleccionar un producto
            productosClienteLST.SelectedIndexChanged += productosClienteLST_SelectedIndexChanged;

        }
        // Evento para establecer el formato correcto cuando el usuario selecciona una fecha
        private void FechaRetirarDTP_ValueChanged(object sender, EventArgs e)
        {
            fechaRetirarDTP.CustomFormat = "dd/MM/yyyy"; // Mostrar la fecha correctamente al seleccionarla
        }
        

        public static Cliente BuscarCliente(int numeroCliente, string razonSocial)
        {
            if (OrdenDePreparacionModelo.ListaCliente == null || !OrdenDePreparacionModelo.ListaCliente.Any())
                return null;

            Cliente clienteEncontrado = OrdenDePreparacionModelo.ListaCliente
                .FirstOrDefault(c => c.NumeroCliente == numeroCliente);

            if (clienteEncontrado == null && !string.IsNullOrEmpty(razonSocial))
            {
                clienteEncontrado = OrdenDePreparacionModelo.ListaCliente
                    .FirstOrDefault(c => c.RazonSocialCliente.Equals(razonSocial, StringComparison.OrdinalIgnoreCase));
            }

            return clienteEncontrado;
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

            // Verificar que la cantidad seleccionada no sea mayor a la disponible
            if (cantidadSeleccionada > cantidadDisponible)
            {
                MessageBox.Show($"La cantidad seleccionada ({cantidadSeleccionada}) es mayor a la disponible ({cantidadDisponible}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener otros valores del producto
            string nombreProducto = productoSeleccionadoLABEL.Text;
            string posicionProducto = productosClienteLST.SelectedItems[0].SubItems[3].Text; // Posición del producto

            // Crear un nuevo ítem para el ListView de la Orden de Preparación
            ListViewItem nuevoItem = new ListViewItem(nombreProducto);
            nuevoItem.SubItems.Add(cantidadSeleccionadaTXT.Text); // Cantidad seleccionada
            nuevoItem.SubItems.Add(posicionProducto);

            // Agregar el producto al ListView de la Orden de Preparación
            ordenPreparacionLST.Items.Add(nuevoItem);
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

          
            //if (long.TryParse(cuilTransportista, out long cUILTransportista))
            //{
            //    // Conversion exitosa, podés usar "numero"
            //}
            //else
            //{
            //    // El string no era un número válido
            //}

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

            //Limpia los controles
            numeroClienteTXT.Clear();
            razonSocialClienteTXT.Clear();
            productosClienteLST.Items.Clear();
            ordenPreparacionLST.Items.Clear();
            cantidadSeleccionadaTXT.Clear();
            cuilTransportistaTXT.Clear();
        }

        

        private void buscarProductosBTN_Click(object sender, EventArgs e)
        {
            int numeroCliente = 0;

            // Se intenta obtener el número de cliente si es que el usuario ingresó el dato
            if (!string.IsNullOrEmpty(numeroClienteTXT.Text) && !int.TryParse(numeroClienteTXT.Text, out numeroCliente))
            {
                MessageBox.Show("Número de cliente inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string razonSocialTexto = razonSocialClienteTXT.Text;

            // Usamos el método BuscarCliente del modelo
            // Nota: si el número de cliente es 0, se buscará por razón social
            Cliente clienteEncontrado = BuscarCliente(numeroCliente, razonSocialTexto);

            if (clienteEncontrado != null)
            {
                // Suponiendo que tienes un método para cargar los productos basado en el número de cliente
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

 






        


    }
}
