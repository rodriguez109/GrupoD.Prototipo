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

            if (string.IsNullOrEmpty(cuil))
            {
                MessageBox.Show("Debe ingresar un número de CUIL para poder continuar.", "CUIL inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EsCUILValido(cuil))
            {
                MessageBox.Show("El CUIL debe tener 11 dígitos numéricos.", "CUIL inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ordenes = modelo.ObtenerOrdenesPorCUIL(cuil);
            OrdenesDeEntregaLST.Items.Clear();

            if (ordenes.Count == 0)
            {
                MessageBox.Show("No se encontraron órdenes de entrega para este CUIL.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (OrdenesDeEntregaLST.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una orden de entrega para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var codigosAgregados = new List<string>();

            foreach (ListViewItem item in OrdenesDeEntregaLST.CheckedItems)
            {
                OrdenDeEntrega orden = (OrdenDeEntrega)item.Tag;
                codigosAgregados.Add(orden.NumeroOrden);

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

        private void CuilTransportistaTXT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
