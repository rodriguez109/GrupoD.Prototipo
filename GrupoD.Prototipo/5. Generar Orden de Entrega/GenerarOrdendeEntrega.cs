using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    public partial class GenerarOrdendeEntrega : Form
    {
        private List<OrdenEntrega> ordenes;

        public GenerarOrdendeEntrega()
        {
            InitializeComponent();
            buttonBTN.Click += buttonBTN_Click;
            button2BTN.Click += button2BTN_Click;
        }

        private void GenerarOrdendeEntrega_Load(object sender, EventArgs e)
        {
            // Datos completos de 20 órdenes con CUIL como long (L)
            ordenes = new List<OrdenEntrega>
            {
                new OrdenEntrega(1, "DecoHogar S.A.", new DateTime(2025, 5, 3), 20242093500L),
                new OrdenEntrega(2, "MaxiLuz Iluminación SRL", new DateTime(2025, 5, 4), 27242093513L),
                new OrdenEntrega(3, "MundoFOX S.A.", new DateTime(2025, 5, 5), 20242093527L),
                new OrdenEntrega(4, "FullColor Pinturerías SRL", new DateTime(2025, 5, 6), 27242093534L),
                new OrdenEntrega(5, "Hogar Urbano S.A.", new DateTime(2025, 5, 7), 20242093543L),
                new OrdenEntrega(6, "Todo Obra Ferretería SRL", new DateTime(2025, 5, 8), 27242093552L),
                new OrdenEntrega(7, "Casa Nova Equipamientos S.A.", new DateTime(2025, 5, 9), 20242093560L),
                new OrdenEntrega(8, "OfiMarket SRL", new DateTime(2025, 5, 10), 27242093577L),
                new OrdenEntrega(9, "Red Tools S.A.", new DateTime(2025, 5, 11), 20242093586L),
                new OrdenEntrega(10, "MegaMuebles SRL", new DateTime(2025, 5, 12), 27242093593L),
                new OrdenEntrega(11, "ElectroCity S.A.", new DateTime(2025, 5, 13), 20242093608L),
                new OrdenEntrega(12, "PlastiSur SRL", new DateTime(2025, 5, 14), 27242093615L),
                new OrdenEntrega(13, "Tecnoshop S.A.", new DateTime(2025, 5, 15), 20242093624L),
                new OrdenEntrega(14, "Urban Market SRL", new DateTime(2025, 5, 16), 27242093631L),
                new OrdenEntrega(15, "DecoCentro S.A.", new DateTime(2025, 5, 17), 20242093640L),
                new OrdenEntrega(16, "Centro Herramientas SRL", new DateTime(2025, 5, 18), 27242093658L),
                new OrdenEntrega(17, "FullOffice S.A.", new DateTime(2025, 5, 19), 20242093667L),
                new OrdenEntrega(18, "DecorArte SRL", new DateTime(2025, 5, 20), 27242093674L),
                new OrdenEntrega(19, "EasyTech Distribuciones S.A.", new DateTime(2025, 5, 21), 20242093683L),
                new OrdenEntrega(20, "FerreMarket SRL", new DateTime(2025, 5, 22), 27242093690L)
            };

            // Cargar datos en el ListView
            listView1LST.Items.Clear();
            foreach (var orden in ordenes)
            {
                ListViewItem item = new ListViewItem(orden.NumeroOrden.ToString());
                item.SubItems.Add(orden.Cliente);
                item.SubItems.Add(orden.FechaEntrega.ToString("dd/MM/yyyy"));
                item.SubItems.Add(orden.CUIL.ToString());
                listView1LST.Items.Add(item);
            }
        }

        private void buttonBTN_Click(object sender, EventArgs e)
        {
            if (listView1LST.SelectedItems.Count > 0)
            {
                MessageBox.Show("La orden seleccionada ha sido confirmada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento disponible si lo necesitás usar después
        }
    }
}
