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
    public class OrdenEntrega
    {
        public string Codigo { get; set; }
        public string Cliente { get; set; }
        public string FechaEntrega { get; set; }
        public string Transportista { get; set; }
    }

    public partial class GenerarOrdendeEntrega : Form
    {
        public GenerarOrdendeEntrega()
        {
            InitializeComponent();
        }
        private void CargarListaOrdenes()
        {
            var ordenes = new List<OrdenEntrega>
        {
            new OrdenEntrega { Codigo = "ORD011", Cliente = "Juan Pérez", FechaEntrega = "03/05/2025", Transportista = "TransLogix" },
            new OrdenEntrega { Codigo = "ORD02", Cliente = "María Gómez", FechaEntrega = "04/05/2025", Transportista = "EnvíaYA" }
        };

            listView1LST.Items.Clear();

            foreach (var orden in ordenes)
            {
                var item = new ListViewItem(orden.Codigo);
                item.SubItems.Add(orden.Cliente);
                item.SubItems.Add(orden.FechaEntrega);
                item.SubItems.Add(orden.Transportista);
                listView1LST.Items.Add(item);
            }
        }
        

        private void buttonBTN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Orden generada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            CargarListaOrdenes();
        }
    }
}