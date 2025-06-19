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
        {   // columnas que quiero mostrar en la lista
            OrdenesPreparacionEstadoPreparadasLST.View = View.Details;
            OrdenesPreparacionEstadoPreparadasLST.FullRowSelect = true;
            OrdenesPreparacionEstadoPreparadasLST.MultiSelect = false;
            OrdenesPreparacionEstadoPreparadasLST.Columns.Clear();
            OrdenesPreparacionEstadoPreparadasLST.Columns.Add("Número de Orden", 150);
            OrdenesPreparacionEstadoPreparadasLST.Columns.Add("Razón Social Cliente", 200);
            OrdenesPreparacionEstadoPreparadasLST.Columns.Add("Fecha Entrega", 200);
            OrdenesPreparacionEstadoPreparadasLST.Columns.Add("DNI Transportista", 200);
            OrdenesPreparacionEstadoPreparadasLST.Columns.Add("Razón Social Transportista", 200);

            CargarOrdenesEnListView();
        }

        private void CargarOrdenesEnListView()
        {   // limpio la lista antes de cargar
            OrdenesPreparacionEstadoPreparadasLST.Items.Clear();
            // Le pido al modelo las ordenes en estado "Preparada"
            var ordenes = modelo.ObtenerOrdenesPreparadas();

            foreach (var orden in ordenes)
            {   // Creo un ítem nuevo con los datos de la orden
                var item = new ListViewItem(orden.NumeroOrden.ToString());
                item.SubItems.Add(orden.NombreCliente);
                item.SubItems.Add(orden.FechaEntrega.ToShortDateString());
                item.SubItems.Add(orden.DNITransportista.ToString());
                item.SubItems.Add(orden.NombreTransportista);

                // Guardo la orden completa en el ítem (para usarla después)
                item.Tag = orden;
                // Agrego la orden a la lista
                OrdenesPreparacionEstadoPreparadasLST.Items.Add(item);
            }
        }
        private void GenerarOrdenEntregaBTN_Click(object sender, EventArgs e)
        {   //valido que se seleccionó una orden
            if (OrdenesPreparacionEstadoPreparadasLST.SelectedItems.Count == 1)
            {
                var itemSeleccionado = OrdenesPreparacionEstadoPreparadasLST.SelectedItems[0];
                var ordenSeleccionada = itemSeleccionado.Tag as OrdenDePreparacionClase;

                if (ordenSeleccionada != null)
                {   // paso la orden al modelo para que la genere y la guarde
                    modelo.CrearYGuardarOrdenDeEntrega(new List<OrdenDePreparacionClase> { ordenSeleccionada });

                    MessageBox.Show("La orden de entrega ha sido generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Vuelvo a cargar la lista de órdenes
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