using GrupoD.Prototipo._1._OrdenDePreparacion;
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
                item.SubItems.Add(orden.CUIT.ToString());
                listView1LST.Items.Add(item);
            }
        }

        // incluyo Validaciones de datos en campo Columnas
        private void buttonBTN_Click(object sender, EventArgs e)
        {
            

           



            // Fecha
            string fechaTexto = item.SubItems[0].Text.Trim();
            if (!DateTime.TryParseExact(fechaTexto, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("La fecha no tiene el formato válido (dd/MM/yyyy).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //numero de Orden
            var item = listView1LST.SelectedItems[1];
            if (listView1LST.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una orden para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Razón Social Cliente
            string razonSocial = item.SubItems[2].Text.Trim();
            if (string.IsNullOrEmpty(razonSocial))
            {
                MessageBox.Show("Razón social Cliente no puede quedar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (razonSocial.Length > 20)
            {
                MessageBox.Show("La razón social debe tener menos de 20 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Razon Social Transportista
            string razonSocialTransporte = item.SubItems[3].Text.Trim();

            if (string.IsNullOrEmpty(razonSocialTransporte))
            {
                MessageBox.Show("Razón social Transportista no puede quedar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (razonSocialTransporte.Length > 20)
            {
                MessageBox.Show("La razón social debe tener menos de 20 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CUIT
            string cuitTexto = item.SubItems[4].Text.Trim();
            if (!long.TryParse(cuitTexto, out _) || cuitTexto.Length != 11)
            {
                MessageBox.Show("El CUIT debe ser un número de 11 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si todas las validaciones pasan:
            MessageBox.Show("La orden seleccionada ha sido confirmada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void button2BTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

    }
}
