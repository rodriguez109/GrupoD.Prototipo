using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            MessageBox.Show("No hay más órdenes en estado 'En Preparacion' para empaquetar.");
            listViewProductos.Items.Clear();
            labelNumeroOrden.Text = "Sin órdenes pendientes";
            ordenEmpaquetadaBTN.Enabled = false;
            cancelarBTN.Text = "Cerrar";
        }
        else
        {
            labelNumeroOrden.Text = $"Orden #{ordenActual.NumeroOP}";
            CargarProductosEnListView(ordenActual.Productos);
        }    
    }

    internal void CargarProductosEnListView(List<ProductoOP> productos)
    {
        listViewProductos.Items.Clear();

        foreach (var producto in productos) // se repite por cada producto en la lista productos
        {
            var productoConsultar = modelo.ObtenerProductoPorSKU(producto.SKU, producto.CantidadSolicitada);

            if (productoConsultar == null)
            {
                MessageBox.Show($"El producto con SKU {producto.SKU} no existe en el almacén."); //ELSE 2 DDS
                //CASO DE PRUEBA DE ORDEN SIN PRODUCTOS###########################
                continue; // Evita añadir productos no encontrados
            }

            var item = new ListViewItem(producto.SKU.ToString());
            item.SubItems.Add(productoConsultar.Nombre);
            item.SubItems.Add(producto.CantidadSolicitada.ToString());

            listViewProductos.Items.Add(item);
        }
    }

    private void ordenEmpaquetadaBTN_Click(object sender, EventArgs e)
    {
        var ordenActual = modelo.BusquedaOrdenDisponible();
        if (ordenActual != null)
        {
            modelo.CambioEstadoOP(ordenActual);
            //modelo.ActualizarOrdenesDisponibles(); // Refresca la lista de órdenes disponibles
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


