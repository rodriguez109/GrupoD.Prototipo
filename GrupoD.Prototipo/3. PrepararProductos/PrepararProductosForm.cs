using Prototipo.PrepararProductos.PrepararProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GrupoD.Prototipo._3._PrepararProductos; 

namespace Prototipo.PrepararProductos
{
    public interface IPrepararProductosView
    {
        void MostrarOrdenes(List<OrdenesDeSeleccion> ordenes);
        OrdenesDeSeleccion ObtenerOrdenSeleccionada();
        void MostrarProductosEnListView(List<OrdenesDePreparacion> productos);
        void MostrarMensaje(string mensaje, string titulo);
        void MostrarAdvertencia(string mensaje, string titulo);
        void CerrarAplicacion();
        void HabilitarBotonConfirmar(bool habilitar);
    }

    public partial class PrepararProductosForm : Form, IPrepararProductosView
    {
        private PrepararProductosPresenter _presenter;

        public PrepararProductosForm()
        {
            InitializeComponent();
            _presenter = new PrepararProductosPresenter(this);

            // 1) Al cargar el formulario, cargamos las OS pendientes
            this.Load += (s, e) => _presenter.CargarOrdenes();

            // 2) Cuando cambia la selección en el combo, pedimos al Presenter que muestre las OP
            comboOrdenSeleccion.SelectedIndexChanged += (s, e) => _presenter.OrdenSeleccionadaCambiada();

            // 3) Al hacer clic en “Confirmar”, pedimos confirmar la OS
            btnSeleccion.Click += (s, e) => _presenter.ConfirmarSeleccion();

            // 4) “Cancelar” cierra el formulario
            btnCancelar.Click += (s, e) => this.Close();

            // 5) Inicialmente, deshabilitamos el botón Confirmar
            btnSeleccion.Enabled = false;
        }

        public void MostrarOrdenes(List<OrdenesDeSeleccion> ordenes)
        {
            // Ordenamos por número de orden para que aparezcan en orden ascendente
            var ordenesOrdenadas = ordenes.OrderBy(o => o.NumeroOrdenSeleccion).ToList();

            comboOrdenSeleccion.DataSource = null;
            comboOrdenSeleccion.DataSource = ordenesOrdenadas;
            comboOrdenSeleccion.DisplayMember = nameof(OrdenesDeSeleccion.NumeroOrdenSeleccion);
        }

        public OrdenesDeSeleccion ObtenerOrdenSeleccionada()
        {
            return comboOrdenSeleccion.SelectedItem as OrdenesDeSeleccion;
        }

        public void MostrarProductosEnListView(List<OrdenesDePreparacion> productos)
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

        public void CerrarAplicacion()
        {
            this.Close();
        }

        public void HabilitarBotonConfirmar(bool habilitar)
        {
            btnSeleccion.Enabled = habilitar;
        }
    }
}
