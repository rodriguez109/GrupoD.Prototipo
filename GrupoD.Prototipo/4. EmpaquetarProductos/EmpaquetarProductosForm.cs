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
using GrupoD.Prototipo.Almacenes;

namespace GrupoD.Prototipo._4._EmpaquetarProductos;
public partial class EmpaquetarProductosForm : Form
{
    private EmpaquetarProductosModelo modelo;
    //public OrdenPreparacion ordenActual;


    public EmpaquetarProductosForm()
    {
        InitializeComponent();

        modelo = new EmpaquetarProductosModelo();

        ordenEmpaquetadaBTN.Click += ordenEmpaquetadaBTN_Click;
        cancelarBTN.Click += cancelarBTN_Click;

        MostrarOrdenPantalla();

    }

    internal void MostrarOrdenPantalla() 
    {
        var ordenActual = modelo.BusquedaOrdenDisponible();

        if (ordenActual == null)
        {
            MessageBox.Show("No hay más órdenes pendientes.");
            listViewProductos.Items.Clear();
            labelNumeroOrden.Text = "Sin órdenes pendientes";
            this.Close();
        }
        else
        {
            labelNumeroOrden.Text = $"Orden #{ordenActual.Numero}";
            CargarProductosEnListView(ordenActual.Detalle);
        }
    }

    internal void CargarProductosEnListView(List<ProductosPorOrden> productos) // va aca o en modelo?
    {
        listViewProductos.Items.Clear();

        foreach (var producto in productos)
        {
            var productoA = ProductoAlmacen.Productos.FirstOrDefault(p=> p.SKU == producto.SKU);

            var item = new ListViewItem(producto.SKU.ToString());
            item.SubItems.Add(productoA.Nombre); //tengo q conseguir el nombre 
            item.SubItems.Add(producto.Cantidad.ToString());

            listViewProductos.Items.Add(item);
        }
    }

    private void ordenEmpaquetadaBTN_Click(object sender, EventArgs e)
    {
        var ordenActual = modelo.BusquedaOrdenDisponible();
        if (ordenActual != null)
        {
            modelo.CambioEstadoOP(ordenActual);
            modelo.ActualizarOrdenesDisponibles(); // Refresca la lista de órdenes disponibles
            MessageBox.Show("La orden fue marcada como 'Preparada'.");
            MostrarOrdenPantalla();

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


