using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using GrupoD.Prototipo._5._Generar_Orden_de_Entrega;
using GrupoD.Prototipo.Almacenes;



namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    public partial class GenerarOrdendeEntregaForm : Form
    {
        private GenerarOrdenEntregaModelo modelo = new GenerarOrdenEntregaModelo();

        public GenerarOrdendeEntregaForm()
        {
            InitializeComponent();
            this.Load += GenerarOrdendeEntregaForm_Load;
        }

        private void GenerarOrdendeEntregaForm_Load(object sender, EventArgs e)
        {
            OrdenesPreparacionEstadoPreparadasLST.View = View.Details;
            OrdenesPreparacionEstadoPreparadasLST.FullRowSelect = true;
            OrdenesPreparacionEstadoPreparadasLST.MultiSelect = false;
            OrdenesPreparacionEstadoPreparadasLST.Columns.Clear();
            OrdenesPreparacionEstadoPreparadasLST.Columns.Add("Número de Orden", 150);
            OrdenesPreparacionEstadoPreparadasLST.Columns.Add("Razón Social Cliente", 230);
            OrdenesPreparacionEstadoPreparadasLST.Columns.Add("Fecha Entrega", 200);
            OrdenesPreparacionEstadoPreparadasLST.Columns.Add("DNI Transportista", 150);
            OrdenesPreparacionEstadoPreparadasLST.Columns.Add("Razón Social Transportista", 230);

            CargarOrdenesEnListView();
        }

        private void CargarOrdenesEnListView()
        {
            OrdenesPreparacionEstadoPreparadasLST.Items.Clear();
            var ordenes = modelo.ObtenerOrdenesPreparadas();

            foreach (var orden in ordenes)
            {
                var item = new ListViewItem(orden.NumeroOrden.ToString());
                item.SubItems.Add(orden.NombreCliente);
                item.SubItems.Add(orden.FechaEntrega.ToShortDateString());
                item.SubItems.Add(orden.DNITransportista.ToString());
                item.SubItems.Add(orden.NombreTransportista);


                item.Tag = orden;

                OrdenesPreparacionEstadoPreparadasLST.Items.Add(item);
            }
        }



       

        private void GenerarOrdenEntregaBTN_Click(object sender, EventArgs e)
        {
            if (OrdenesPreparacionEstadoPreparadasLST.SelectedItems.Count == 1)
            {
                var itemSeleccionado = OrdenesPreparacionEstadoPreparadasLST.SelectedItems[0];
                var ordenSeleccionada = itemSeleccionado.Tag as OrdenDePreparacionClase;

                if (ordenSeleccionada != null)
                {
                    modelo.CrearYGuardarOrdenDeEntrega(new List<OrdenDePreparacionClase> { ordenSeleccionada });

                    MessageBox.Show("La orden de entrega ha sido generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarOrdenesEnListView();

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos una orden para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CancelarOrdenEntregaBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}