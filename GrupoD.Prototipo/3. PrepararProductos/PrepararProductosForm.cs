using Prototipo.PrepararProductos.PrepararProductos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo.PrepararProductos
{
    public partial class PrepararProductosForm : Form //PRESENTADOR -> Recibe los datos del formulario y los coordina
    {
        private List<OrdenSeleccion> listaOrdenes;

        public PrepararProductosForm()
        {
            InitializeComponent();

            // Simular carga de datos desde NuevaOrdenModelo
            listaOrdenes = new List<OrdenSeleccion>
    {
             new OrdenSeleccion { Ubicacion = "12-25-3", SKUProducto = "SKU123", Cantidad = 10 },
             new OrdenSeleccion { Ubicacion = "08-11-2", SKUProducto = "SKU456", Cantidad = 5 },
             new OrdenSeleccion { Ubicacion = "21-04-7", SKUProducto = "SKU789", Cantidad = 12 }
    };

            comboOrdenSeleccion.DataSource = listaOrdenes;
            comboOrdenSeleccion.DisplayMember = "ToString";
            comboOrdenSeleccion.SelectedIndexChanged += comboordenseleccion_SelectedIndexChanged;

            ConfigurarListView();
        }
        private void ConfigurarListView()
        {
            lViewOrdenSeleccion.View = View.Details;
            lViewOrdenSeleccion.Columns.Clear();
            lViewOrdenSeleccion.Columns.Add("Ubicación", 100);
            lViewOrdenSeleccion.Columns.Add("SKU Producto", 120);
            lViewOrdenSeleccion.Columns.Add("Cantidad", 80);
        }
        private void comboordenseleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboOrdenSeleccion.SelectedItem is OrdenSeleccion orden)
            {
                lViewOrdenSeleccion.Items.Clear();

                var item = new ListViewItem(orden.Ubicacion);
                item.SubItems.Add(orden.SKUProducto);
                item.SubItems.Add(orden.Cantidad.ToString());

                lViewOrdenSeleccion.Items.Add(item);
            }
        }
        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            if (lViewOrdenSeleccion.SelectedItems.Count > 0)
            {
                MessageBox.Show("Orden de selección confirmada!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una orden en la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
