using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GrupoD.Prototipo
{
    public partial class GenerarOrdendeEntrega : Form
    {
        public GenerarOrdendeEntrega()
        {
            InitializeComponent();
            this.Load += GenerarOrdendeEntrega_Load;
            buttonBTN.Click += buttonBTN_Click;
            button2BTN.Click += button2BTN_Click; // <-- para cerrar con Cancelar
        }

        private void GenerarOrdendeEntrega_Load(object sender, EventArgs e)
        {
            // Lista de datos de ejemplo
            var datosEjemplo = new List<string[]>
            {
                new string[] { "2025-05-10", "Cliente S.A.", "1001", "20304050601" },
                new string[] { "2025-05-11", "Distribuciones Norte", "1002", "20405060702" },
                new string[] { "2025-05-12", "Comercial Oeste", "1003", "20506070803" },
                new string[] { "2025-05-13", "Proveedor Sur", "1004", "20607080904" }
            };

            // Carga al ListView
            listView1LST.Items.Clear();
            foreach (var fila in datosEjemplo)
            {
                ListViewItem item = new ListViewItem(fila);
                listView1LST.Items.Add(item);
            }
        }

        private void buttonBTN_Click(object sender, EventArgs e)
        {
            if (listView1LST.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una orden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ListViewItem item in listView1LST.SelectedItems)
            {
                string fechaStr = item.SubItems[0].Text;
                string cliente = item.SubItems[1].Text;
                string codigoStr = item.SubItems[2].Text;
                string cuilStr = item.SubItems[3].Text;

                if (!DateTime.TryParse(fechaStr, out _))
                {
                    MessageBox.Show($"La fecha '{fechaStr}' no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cliente))
                {
                    MessageBox.Show("La razón social del cliente no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(codigoStr, out _))
                {
                    MessageBox.Show($"El código de orden '{codigoStr}' debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(cuilStr, out _))
                {
                    MessageBox.Show($"El CUIL del transportista '{cuilStr}' debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Todas las órdenes seleccionadas han sido confirmadas correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2BTN_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Evento opcional
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento opcional
        }
    }
}
