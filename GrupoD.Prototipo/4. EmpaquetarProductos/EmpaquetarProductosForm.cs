using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrupoD.Prototipo.Almacenes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GrupoD.Prototipo._4._EmpaquetarProductos;
public partial class EmpaquetarProductosForm : Form
{
    private EmpaquetarProductosModelo modelo;

    //inicializa el formulario, crea el modelo y muestra la primera orden disponible.
    public EmpaquetarProductosForm()
    {
        InitializeComponent();

        modelo = new EmpaquetarProductosModelo();

        ordenEmpaquetadaBTN.Click += ordenEmpaquetadaBTN_Click;
        cancelarBTN.Click += cancelarBTN_Click;

        modelo.CambiarEstadoOPsConPallet();
        MostrarOrdenPantalla();
    }

    //busca la próxima orden en preparación y la carga visualmente o avisa si ya no hay más.
    internal void MostrarOrdenPantalla() 
    {
        var ordenActual = modelo.BusquedaOrdenDisponible();

        if (ordenActual == null)
        {
            MessageBox.Show("No hay más órdenes en estado 'En Preparacion' para empaquetar.");
            productosPorOrdenLST.Items.Clear();
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

    //llena el ListView con los productos de la orden actual usando sus datos reales del almacén.
    internal void CargarProductosEnListView(List<ProductoOP> productos)
    {
        productosPorOrdenLST.Items.Clear();

        foreach (var producto in productos) // se repite por cada producto en la lista productos
        {
            var productoConsultar = modelo.ObtenerProductoPorSKU(producto.SKU, producto.CantidadSolicitada);

            if (productoConsultar == null)
            {
                // Evita añadir productos no encontrados
                MessageBox.Show($"El producto con SKU {producto.SKU} no existe en el almacén."); 
                continue; 
            }

            var item = new ListViewItem(producto.SKU.ToString());
            item.SubItems.Add(productoConsultar.Nombre);
            item.SubItems.Add(producto.CantidadSolicitada.ToString());

            productosPorOrdenLST.Items.Add(item);
        }
    }

    //marca la orden como preparada y muestra la siguiente orden pendiente.
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

    //cierra el formulario cuando se cancela o finaliza el flujo.
    private void cancelarBTN_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void listView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


