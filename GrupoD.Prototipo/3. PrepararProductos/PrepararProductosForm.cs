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
    public interface IPrepararProductosView
    {
        void MostrarOrdenes(List<OrdenSeleccion> ordenes);
        void MostrarProductosEnListView(List<OrdenDeSeleccion> productos);
        void MostrarMensaje(string mensaje, string titulo);
        void MostrarAdvertencia(string mensaje, string titulo);
        OrdenSeleccion ObtenerOrdenSeleccionada();
    }
    public partial class PrepararProductosForm : Form, IPrepararProductosView
    {
        private PrepararProductosPresenter _presenter;

        public PrepararProductosForm()
        {
            InitializeComponent();
            _presenter = new PrepararProductosPresenter(this);

            this.Load += (s, e) => _presenter.CargarOrdenes();
            comboOrdenSeleccion.SelectedIndexChanged += (s, e) => _presenter.OrdenSeleccionadaCambiada();
            btnSeleccion.Click += (s, e) => _presenter.ConfirmarSeleccion();
            btnCancelar.Click += (s, e) => this.Close();
        }

        public void MostrarOrdenes(List<OrdenSeleccion> ordenes)
        {
            comboOrdenSeleccion.DataSource = ordenes;
            comboOrdenSeleccion.DisplayMember = "NombreOrden";
        }

        public OrdenSeleccion ObtenerOrdenSeleccionada()
        {
            return comboOrdenSeleccion.SelectedItem as OrdenSeleccion;
        }

        public void MostrarProductosEnListView(List<OrdenDeSeleccion> productos)
        {
            lViewOrdenSeleccion.Items.Clear();
            foreach (var prod in productos)
            {
                var item = new ListViewItem(prod.Posicion);
                item.SubItems.Add(prod.SKUProducto);
                item.SubItems.Add(prod.Cantidad.ToString());
                lViewOrdenSeleccion.Items.Add(item);
            }
        }

        public void MostrarMensaje(string mensaje, string titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MostrarAdvertencia(string mensaje, string titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
