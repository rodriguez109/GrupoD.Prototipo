using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoD.Prototipo._6._GenerarRemito
{
    public partial class GenerarRemitoForm : Form
    {
        private GenerarRemitoModelo modelo;
        public GenerarRemitoForm()
        {
            InitializeComponent();
        }

        private void GenerarRemitoForm_Load(object sender, EventArgs e)
        {
            modelo = new GenerarRemitoModelo();
            foreach (var OrdenDeEntrega in modelo OrdenesDeEntrega )
            {
                OrdenesDeEntregaLST.Items.Add();

            }
            

        }

        private void BuscarOrdenesBTN_Click(object sender, EventArgs e)
        {
            var cuilTransportista = CuilTransportistaTXT.Text.Trim();

            var OrdenDeEntrega = new OrdenEntrega
            {



            };
        }
    }
}
