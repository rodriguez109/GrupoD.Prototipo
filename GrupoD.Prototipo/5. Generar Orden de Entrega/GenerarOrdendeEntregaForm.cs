using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo._5._Generar_Orden_de_Entrega;
using GrupoD.Prototipo.Almacenes;
using Prototipo.PrepararProductos.PrepararProductos;



namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    public partial class GenerarOrdendeEntregaForm : Form
    {
        private GenerarOrdenEntregaModelo modelo = new GenerarOrdenEntregaModelo();


        public GenerarOrdendeEntregaForm()
        {
            InitializeComponent();
            this.Load += GenerarOrdendeEntregaForm_Load;
        }

        private void GenerarOrdendeEntregaForm_Load(object sender, EventArgs e)
        {
            // Configuración del ListView
            listView1LST.View = View.Details;
            listView1LST.FullRowSelect = true;
            listView1LST.MultiSelect = false; // por ahora solo 1 a la vez
            listView1LST.Columns.Clear();
            listView1LST.Columns.Add("Número de Orden", 150);
            listView1LST.Columns.Add("Razón Social Cliente", 230);
            listView1LST.Columns.Add("Fecha Entrega", 200);
            listView1LST.Columns.Add("DNI Transportista", 150);
            listView1LST.Columns.Add("Razón Social Transportista", 230);

            // Cargar datos
            CargarOrdenesEnListView();
        }

        private void CargarOrdenesEnListView()
        {
            listView1LST.Items.Clear();
            var ordenes = modelo.ObtenerOrdenesPreparadas();

            foreach (var orden in ordenes)
            {
                var cliente = ClienteAlmacen.Buscar(orden.NumeroCliente);
                var transportista = TransportistaAlmacen.Buscar(orden.DNITransportista);

                var razonSocialCliente = cliente != null ? cliente.RazonSocial : "Cliente no encontrado";
                var razonSocialTransportista = transportista != null ? transportista.Nombre : "Transportista no encontrado";

                var item = new ListViewItem(orden.Numero.ToString());
                item.SubItems.Add(razonSocialCliente);
                item.SubItems.Add(orden.FechaRetirar.ToShortDateString());
                item.SubItems.Add(orden.DNITransportista.ToString());
                item.SubItems.Add(razonSocialTransportista);

                // Guardamos una referencia directa a la entidad
                item.Tag = orden;

                listView1LST.Items.Add(item);
            }
        }

        private void buttonBTN_Click(object sender, EventArgs e)
        {
            if (listView1LST.SelectedItems.Count == 1)
            {
                var itemSeleccionado = listView1LST.SelectedItems[0];
                var ordenSeleccionada = itemSeleccionado.Tag as OrdenDePreparacionEntidad;

                if (ordenSeleccionada != null)
                {
                    try
                    {
                        modelo.CrearYGuardarOrdenDeEntrega(new List<OrdenDePreparacionEntidad> { ordenSeleccionada });

                        MessageBox.Show("La orden de entrega ha sido generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar el ListView para reflejar cambios
                        CargarOrdenesEnListView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al generar la orden de entrega: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar exactamente una orden para confirmar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2BTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

