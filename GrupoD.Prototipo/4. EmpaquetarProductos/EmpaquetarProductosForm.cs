using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrupoD.Prototipo._4._Empaquetar_Productos;

//namespace GrupoD.Prototipo._4._EmpaquetarProductos;
//public partial class EmpaquetarProductosForm : Form
//{
//    public EmpaquetarProductosForm()
//    {
//        InitializeComponent();
//    }

//    private void label1_Click(object sender, EventArgs e)
//    {

//    }
//}


namespace GrupoD.Prototipo._4._EmpaquetarProductos;
public partial class EmpaquetarProductosForm : Form
{
    private EmpaquetarProductosModelo modelo;
    private OrdenPreparacion ordenActual;


    public EmpaquetarProductosForm()
    {
        InitializeComponent();

        modelo = new EmpaquetarProductosModelo();

        ordenEmpaquetadaBTN.Click += ordenEmpaquetadaBTN_Click;
        cancelarBTN.Click += cancelarBTN_Click;

        MostrarProximaOrden();

    }

    private void MostrarProximaOrden() //EXP
    {
        // Buscar próxima orden "En Preparacion"
        ordenActual = modelo.OrdenesEnPreparacionDisponibles.FirstOrDefault(o => o.EstadoOrden == "En Preparacion");

        if (ordenActual == null)
        {
            MessageBox.Show("No hay más órdenes pendientes.");
            listViewProductos.Items.Clear();
            labelNumeroOrden.Text = "Sin órdenes pendientes";
            this.Close();
            return;
        }

        labelNumeroOrden.Text = $"Orden #{ordenActual.NumeroOrden}";

        CargarProductosEnListView(ordenActual.Productos);
    }

    private void CargarProductosEnListView(List<Producto> productos) //EXP
    {
        listViewProductos.Items.Clear();

        foreach (var producto in productos)
        {
            var item = new ListViewItem(producto.SKUProducto.ToString());
            item.SubItems.Add(producto.NombreProducto);
            item.SubItems.Add(producto.CantidadProducto.ToString());

            listViewProductos.Items.Add(item);
        }
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click_1(object sender, EventArgs e)
    {

    }

    private void ordenEmpaquetadaBTN_Click(object sender, EventArgs e)
    {
        if (ordenActual != null)
        {
            ordenActual.EstadoOrden = "Preparada";
            MessageBox.Show("La orden fue marcada como empaquetada.");
            MostrarProximaOrden();
            //this.Close();
        }
    }

    private void cancelarBTN_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void listView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


