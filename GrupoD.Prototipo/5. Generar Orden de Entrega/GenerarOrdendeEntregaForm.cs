using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GrupoD.Prototipo._5._Generar_Orden_de_Entrega;

namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    public partial class GenerarOrdendeEntregaForm : Form
    {
        private GenerarOrdendeEntregaModelo modelo = new GenerarOrdendeEntregaModelo();

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
            listView1LST.Columns.Clear();
            listView1LST.Columns.Add("Número de Orden", 120);
            listView1LST.Columns.Add("Cliente", 150);
            listView1LST.Columns.Add("Fecha Entrega", 120);
            listView1LST.Columns.Add("DNI Transportista", 130);
            listView1LST.Columns.Add("Transportista", 150);

            // Cargar datos
            CargarOrdenesEnListView();

        }

        private void CargarOrdenesEnListView()
        {
            listView1LST.Items.Clear();

            foreach (var orden in modelo.Ordenes)
            {
                var item = new ListViewItem(orden.NumeroOrden.ToString());
                item.SubItems.Add(orden.NombreCliente);
                item.SubItems.Add(orden.FechaEntrega.ToShortDateString());
                item.SubItems.Add(orden.DniTransportista.ToString());
                item.SubItems.Add(orden.NombreTransportista);

                listView1LST.Items.Add(item);
            }
        }



        private void buttonBTN_Click(object sender, EventArgs e)
        {
            if (listView1LST.SelectedItems.Count >= 1)
            {
                MessageBox.Show("La orden seleccionada ha sido confirmada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos una orden para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2BTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenerarOrdendeEntregaForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}