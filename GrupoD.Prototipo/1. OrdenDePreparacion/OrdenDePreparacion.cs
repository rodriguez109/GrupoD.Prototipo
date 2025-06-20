﻿using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo._4._EmpaquetarProductos;
using GrupoD.Prototipo.Almacenes;
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
           
        }

  

        private void OrdenDePreparacion_Load(object sender, EventArgs e)
        {
            modelo = new OrdenDePreparacionModelo();
       

        
            numeroClienteTXT.Enabled = true;
            razonSocialClienteTXT.Enabled = true;
            

            
            fechaRetirarDTP.ValueChanged += FechaRetirarDTP_ValueChanged;

            fechaRetirarDTP.MinDate = DateTime.Today;

            ConfigurarAutoCompletar();
            ConfigurarAutoCompletarDNITransportista();


            prioridadCMB.Items.Clear(); 
            prioridadCMB.Items.Add("Alta");
            prioridadCMB.Items.Add("Media");
            prioridadCMB.Items.Add("Baja");

            prioridadCMB.SelectedIndex = 1; 



           
            productosClienteLST.SelectedIndexChanged += productosClienteLST_SelectedIndexChanged;




        }



        private void ConfigurarAutoCompletar()
        {
            
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

            
            foreach (var cliente in modelo.Clientes)
            {
                listaAutocompletar.Add(cliente.RazonSocialCliente);
            }

            
            razonSocialClienteTXT.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            razonSocialClienteTXT.AutoCompleteSource = AutoCompleteSource.CustomSource;
            razonSocialClienteTXT.AutoCompleteCustomSource = listaAutocompletar;
        }


        
        private void ConfigurarAutoCompletarDNITransportista()
        {
            
            AutoCompleteStringCollection listaAutocompletar = new AutoCompleteStringCollection();

            
            foreach (var transportista in modelo.Transportistas)
            {
                listaAutocompletar.Add(transportista.DNITransportista.ToString());
            }

            
            dniTransportistaTXT.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dniTransportistaTXT.AutoCompleteSource = AutoCompleteSource.CustomSource;
            dniTransportistaTXT.AutoCompleteCustomSource = listaAutocompletar;
        }
        
        private void FechaRetirarDTP_ValueChanged(object sender, EventArgs e)
        {
            fechaRetirarDTP.CustomFormat = "dd/MM/yyyy"; 
        }

        private Cliente BuscarCliente(int numeroCliente, string razonSocial)    
        {
            
            if (modelo == null || modelo.Clientes == null || !modelo.Clientes.Any())
                return null;

            
            Cliente clienteEncontrado = modelo.Clientes
                .FirstOrDefault(c => c.NumeroCliente == numeroCliente);

            if (clienteEncontrado == null && !string.IsNullOrEmpty(razonSocial))
            {
                clienteEncontrado = modelo.Clientes
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
                

                int cantidadBase = producto.Cantidad;

               
                int cantidadReservada = OrdenDePreparacionAlmacen.OrdenesDePreparacion
                    .Where(o => o.CodigoDeposito == DepositoAlmacen.CodigoDepositoActual &&
                                (o.Estado == EstadoOrdenDePreparacionEnum.Pendiente ||
                                 o.Estado == EstadoOrdenDePreparacionEnum.Procesamiento))
                    .SelectMany(o => o.Detalle)
                    .Where(det => det.SKU == producto.SKUProducto)
                    .Sum(det => det.Cantidad);

                int cantidadDisponible = cantidadBase - cantidadReservada;

                
                var item = new ListViewItem(producto.SKUProducto.ToString());
                item.SubItems.Add(producto.NombreProducto);
                item.SubItems.Add(cantidadDisponible.ToString());


                productosClienteLST.Items.Add(item);
            }
        }

        private List<Producto> ObtenerProductosPorCliente(int numeroCliente)
        {
            List<Producto> productosCliente = new List<Producto>();

            foreach (var producto in modelo.Productos) 
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
            
            
            numeroClienteTXT.Text = "";
            razonSocialClienteTXT.Text = "";
        }

        
        private void productosClienteLST_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (productosClienteLST.SelectedItems.Count > 0)
            {
                
                ListViewItem itemSeleccionado = productosClienteLST.SelectedItems[0];

                
                if (itemSeleccionado.SubItems.Count >= 3)
                {
                   
                    productoSeleccionadoLABEL.Text = itemSeleccionado.SubItems[1].Text; 
                    cantidadDisponibleLABEL.Text = itemSeleccionado.SubItems[2].Text; 
                }
                else
                {
                    MessageBox.Show("Error: El producto seleccionado no tiene suficientes datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
               
                productoSeleccionadoLABEL.Text = "Seleccione un producto";
                cantidadDisponibleLABEL.Text = "0";
            }
        }



        private void cantidadSeleccionadaTXT_TextChanged(object sender, EventArgs e)
        {
            
            cantidadSeleccionadaTXT.Clear();
           
            if (!int.TryParse(cantidadSeleccionadaTXT.Text, out int cantidadSeleccionada))
            {
                MessageBox.Show("La cantidad seleccionada no es válida.");
                return;
            }
            
            if (cantidadSeleccionada > int.Parse(cantidadDisponibleLABEL.Text))
            {
                MessageBox.Show("La cantidad seleccionada excede la cantidad disponible.");
                return;
            }
        }

        private int clienteFijo = -1;  
       
        private void agregarProductoBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(productoSeleccionadoLABEL.Text) || string.IsNullOrEmpty(cantidadDisponibleLABEL.Text) || string.IsNullOrEmpty(cantidadSeleccionadaTXT.Text))
            {
                MessageBox.Show("Seleccione un producto y especifique una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!int.TryParse(cantidadSeleccionadaTXT.Text, out int cantidadSeleccionada) || !int.TryParse(cantidadDisponibleLABEL.Text, out int cantidadDisponible))
            {
                MessageBox.Show("Ingrese una cantidad numérica válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (cantidadSeleccionada <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (cantidadSeleccionada > cantidadDisponible)
            {
                MessageBox.Show($"La cantidad seleccionada ({cantidadSeleccionada}) es mayor a la disponible ({cantidadDisponible}).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int numeroCliente = 0;
            if (string.IsNullOrWhiteSpace(numeroClienteTXT.Text))
            {
                
                if (!string.IsNullOrWhiteSpace(razonSocialClienteTXT.Text))
                {
                    string razonSocial = razonSocialClienteTXT.Text.Trim();
                    var clienteEncontrado = modelo.Clientes
                    .FirstOrDefault(c => c.RazonSocialCliente.Equals(razonSocial, StringComparison.OrdinalIgnoreCase));

                    if (clienteEncontrado != null)
                    {
                        numeroCliente = clienteEncontrado.NumeroCliente;
                        
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
                clienteFijo = numeroCliente; 
            }


            
            string skuProducto = productosClienteLST.SelectedItems[0].SubItems[0].Text; 
            string nombreProducto = productoSeleccionadoLABEL.Text; 
            string cantidadSeleccionadaTexto = cantidadSeleccionadaTXT.Text; 

           
            ListViewItem nuevoItem = new ListViewItem(skuProducto); 
            nuevoItem.SubItems.Add(nombreProducto); 
            nuevoItem.SubItems.Add(cantidadSeleccionadaTexto); 


            
            ordenPreparacionLST.Items.Add(nuevoItem);
        }


       

        
        

        private void generarOPBTN_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (ordenPreparacionLST.Items.Count == 0)
                {
                    MessageBox.Show("Debe agregar productos a la Orden de Preparación antes de generarla.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


               
                if (string.IsNullOrEmpty(dniTransportistaTXT.Text) || dniTransportistaTXT.Text.Length != 8 ||
                    !int.TryParse(dniTransportistaTXT.Text, out int dniTransportista))
                {
                    MessageBox.Show("Ingrese un DNI válido de 8 dígitos.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (!modelo.ValidarDNITransportista(dniTransportista))
                {
                    MessageBox.Show("Transportista no encontrado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                if (!int.TryParse(numeroClienteTXT.Text, out int numeroCliente))
                {
                    MessageBox.Show("El número de cliente debe ser un valor numérico válido.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               
                DateTime fechaRetirar = fechaRetirarDTP.Value;
                string prioridadSeleccionada = prioridadCMB.Text;
                string razonSocialCliente = razonSocialClienteTXT.Text;
                bool pallet = palletCBX.Checked;

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
                    clienteFijo = numeroCliente; 
                }

                
                
                modelo.CrearOrdenesDesdeItems(
                    ordenPreparacionLST.Items.Cast<ListViewItem>(),
                    numeroCliente,
                    razonSocialCliente,
                    fechaRetirar,
                    prioridadSeleccionada,
                    dniTransportista,
                    pallet
                );

               
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

            
            if (numeroCliente == 0 && string.IsNullOrEmpty(razonSocialTexto))
            {
                MessageBox.Show("Debe ingresar un número de cliente o una razón social.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            Cliente clienteEncontrado = BuscarCliente(numeroCliente, razonSocialTexto);

            if (clienteEncontrado != null)
            {
                
                if (numeroCliente > 0 && !string.IsNullOrEmpty(razonSocialTexto) &&
                    !clienteEncontrado.RazonSocialCliente.Equals(razonSocialTexto, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El número de cliente ingresado no coincide con la razón social.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
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
