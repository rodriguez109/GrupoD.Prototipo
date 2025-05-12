using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    public partial class GenerarOrdendeEntregaForm : Form
    {
        private GenerarOrdendeEntregaModelo modelo;

        public GenerarOrdendeEntregaForm()
        {
            InitializeComponent();
            buttonBTN.Click += buttonBTN_Click;
            button2BTN.Click += button2BTN_Click;
        }

        private void GenerarOrdendeEntrega_Load(object sender, EventArgs e)
        {
          

            // Cargar datos en el ListView
            listView1LST.Items.Clear();
            foreach (var orden in modelo.Ordenes)
            {
                ListViewItem item = new ListViewItem(orden.NumeroOrden.ToString());
                item.SubItems.Add(orden.Cliente);
                item.SubItems.Add(orden.FechaEntrega.ToString("dd/MM/yyyy"));
                item.SubItems.Add(orden.CUIL.ToString());
                listView1LST.Items.Add(item);
            }
        }

        private void buttonBTN_Click(object sender, EventArgs e)
        {
            if (listView1LST.SelectedItems.Count > 0)
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
            // Evento disponible si lo necesitás usar después
        }


        //min 46 sumar validaciones!!! 
    }
}
