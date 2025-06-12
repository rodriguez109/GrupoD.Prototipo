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
            listView1LST.View = View.Details;
            listView1LST.FullRowSelect = true;
            listView1LST.MultiSelect = false;
            listView1LST.Columns.Clear();
            listView1LST.Columns.Add("Número de Orden", 150);
            listView1LST.Columns.Add("Razón Social Cliente", 230);
            listView1LST.Columns.Add("Fecha Entrega", 200);
            listView1LST.Columns.Add("DNI Transportista", 150);
            listView1LST.Columns.Add("Razón Social Transportista", 230);

            CargarOrdenesEnListView();
        }

        private void CargarOrdenesEnListView()
        {
            listView1LST.Items.Clear();
            var ordenes = modelo.ObtenerOrdenesPreparadas();

            foreach (var orden in ordenes)
            {
                var item = new ListViewItem(orden.NumeroOrden.ToString());
                item.SubItems.Add(orden.NombreCliente);
                item.SubItems.Add(orden.FechaEntrega.ToShortDateString());
                item.SubItems.Add(orden.DNITransportista.ToString());
                item.SubItems.Add(orden.NombreTransportista); 

                item.Tag = orden;

                listView1LST.Items.Add(item);
            }
        }

        private void buttonBTN_Click(object sender, EventArgs e)
        {
            if (listView1LST.SelectedItems.Count == 1)
            {
                var itemSeleccionado = listView1LST.SelectedItems[0];
                var ordenSeleccionada = itemSeleccionado.Tag as OrdenDePreparacionClase;

                if (ordenSeleccionada != null)
                {
                     MessageBox.Show("La orden de entrega ha sido generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarOrdenesEnListView();
                    
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos una orden para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2BTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}