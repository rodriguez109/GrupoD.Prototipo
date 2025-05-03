using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoD.Prototipo
{
    public partial class GenerarOrdendeEntrega : Form
    {
        public GenerarOrdendeEntrega()
        {
            InitializeComponent();
        }

        private void buttonBTN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Orden generada con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Lógica opcional al entrar al groupBox
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lógica opcional al cambiar selección
        }

        private void GenerarOrdendeEntrega_Load(object sender, EventArgs e)
        {
            // Carga inicial del formulario
        }
    }
}