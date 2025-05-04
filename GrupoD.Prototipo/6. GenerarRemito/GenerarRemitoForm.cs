using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;

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

        }
        private void BuscarOrdenesBTN_Click(object sender, EventArgs e)
        {
            string cuil = CuilTransportistaTXT.Text.Trim();

            if (!EsCUILValido(cuil))
            {
                MessageBox.Show("El CUIL debe tener 11 dígitos numéricos.", "CUIL inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ordenes = modelo.ObtenerOrdenesPorCUIL(cuil);
            OrdenesDeEntregaLST.Items.Clear();

            if (ordenes.Count == 0)
            {
                MessageBox.Show("No se encontraron órdenes para este CUIL.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var orden in ordenes)
                {
                    var item = new ListViewItem(orden.NumeroOrden);
                    item.Tag = orden;
                    OrdenesDeEntregaLST.Items.Add(item);
                }
            }
        }

        private void AgregarAlRemitoBTN_Click(object sender, EventArgs e)
        {
            if (OrdenesDeEntregaLST.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccioná al menos una orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var codigosAgregados = new List<string>();

            foreach (ListViewItem item in OrdenesDeEntregaLST.SelectedItems)
            {
                OrdenDeEntrega orden = (OrdenDeEntrega)item.Tag;
                codigosAgregados.Add(orden.NumeroOrden);
                // Podés usar la orden como quieras
            }

            string ordenesTexto = string.Join(", ", codigosAgregados);
            MessageBox.Show($"Órdenes agregadas al remito con éxito.\nSe agregaron las siguientes órdenes: {ordenesTexto}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private bool EsCUILValido(string cuil)
        {
            return cuil.Length == 11 && long.TryParse(cuil, out _);
        }

        private void CancelarBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
