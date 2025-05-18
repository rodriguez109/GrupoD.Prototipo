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

namespace GrupoD.Prototipo._4._EmpaquetarProductos;
public partial class EmpaquetarProductosForm : Form
{
    private EmpaquetarProductosModelo modelo;
    private OrdenPreparacion ordenActual;


    public EmpaquetarProductosForm()
    {
        InitializeComponent(); //Inicializa componentes.

        modelo = new EmpaquetarProductosModelo(); // Crea un nuevo modelo de datos.

        ordenEmpaquetadaBTN.Click += ordenEmpaquetadaBTN_Click;
        cancelarBTN.Click += cancelarBTN_Click; //Asocia los botones con sus respectivos eventos.

        MostrarProximaOrden(); //Llama a MostrarProximaOrden() para cargar la primera orden disponible.

    }

    private void MostrarProximaOrden() //MOSTRAR PROX ORDEN DISPONIBLE
    {
        //Busca la primera orden en estado "En Preparación".

        //modelo.OrdenesEnPreparacionDisponibles: es una lista de órdenes cargada desde el modelo.
        //.FirstOrDefault(...): busca la primera orden que tenga el estado "En Preparacion".Si no hay, devuelve null.

        ordenActual = modelo.OrdenesEnPreparacionDisponibles.FirstOrDefault(o => o.EstadoOrdenPreparacion == "En Preparacion");

        if (ordenActual == null) //Si no hay ninguna, avisa al usuario y cierra el formulario.
        {
            MessageBox.Show("No hay más órdenes pendientes.");
            listViewProductos.Items.Clear();
            labelNumeroOrden.Text = "Sin órdenes pendientes";
            this.Close();
            return;
        }
        //Si hay una, muestra el número de orden y carga sus productos en un ListView.
        labelNumeroOrden.Text = $"Orden #{ordenActual.NumeroOrdenPreparacion}";

        CargarProductosEnListView(ordenActual.Productos); //Llama al método que carga los productos de esa orden en la interfaz
    }

    private void CargarProductosEnListView(List<Producto> productos) //EXP
    {
        listViewProductos.Items.Clear(); //Limpia la lista de productos.

        foreach (var producto in productos) //Muestra los productos de la orden: SKU, nombre y cantidad seleccionada.
        {
            var item = new ListViewItem(producto.SKUProducto.ToString());
            item.SubItems.Add(producto.NombreProducto);
            item.SubItems.Add(producto.CantidadSeleccionada.ToString());

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
            ordenActual.EstadoOrdenPreparacion = "Preparada";
            MessageBox.Show("La orden fue marcada como 'Preparada'.");
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


