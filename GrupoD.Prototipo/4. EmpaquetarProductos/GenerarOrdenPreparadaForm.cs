using GrupoD.Prototipo._4._EmpaquetarProductos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prototipo.PrepararProductos.PrepararProductos;

namespace GrupoD.Prototipo._4._Empaquetar_Productos
{
    public partial class GenerarOrdenPreparadaForm : Form
    {
        private List<OrdenPreparacion> listaOrdenesPreparacion;

        public GenerarOrdenPreparadaForm()
        {
            InitializeComponent();

            // Simular carga de datos desde NuevaOrdenModelo
            listaOrdenesPreparacion = new List<OrdenPreparacion>
            {
            //new OrdenPreparacion { NumeroOrden = 1, SKUProducto = "A123", NombreProducto = "Art1", CantidadProducto = 10 },
            //new OrdenPreparacion { NumeroOrden = 2, SKUProducto = "A124", NombreProducto = "Art2", CantidadProducto = 4 },
            };

            //comboOrdenSeleccion.DataSource = listaOrdenes;
            //comboOrdenSeleccion.DisplayMember = "ToString";
            //comboOrdenSeleccion.SelectedIndexChanged += comboordenseleccion_SelectedIndexChanged;

            //ConfigurarListView();
        }

        //private void ConfigurarListView()
        //{
        //    listView2.View = View.Details;
        //    listView2.Columns.Clear();
        //    listView2.Columns.Add("Ubicación", 100);
        //    listView2.Columns.Add("SKU Producto", 120);
        //    listView2.Columns.Add("Cantidad", 80);
        //}




        private void GenerarOrdenPreparadaForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ordenEmpaquetadaBtn_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 1 )
            {
                MessageBox.Show("Orden empaquetada!");
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una orden de la lista.");
            }
            
        }
        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
