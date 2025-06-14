using GrupoD.Prototipo._3._PrepararProductos;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;
using System.IO.Pipelines;
using System.Reflection;

namespace Prototipo.PrepararProductos;

public partial class PrepararProductosForm : Form
{
    private readonly PrepararProductosModelo modelo;

    public PrepararProductosForm()
    {
        InitializeComponent();
        modelo = new PrepararProductosModelo();
    }

    private void PrepararProductosForm_Load(object sender, EventArgs e)
    {
        CargarOrdenesSeleccionEnComboBox();
    }

    // CM_OS: Lee ID(int) de la orden elegida. Llama a modelo.ObtenerListaPosiciones(id) → devuelve una lista de PosicionProducto con: Posicion, sku y cantidad
    // Por cada posición, crea un ListViewItem y lo añade a lViewOrdenSeleccion.
    //private void comboOrdenSeleccion_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (comboOrdenSeleccion.SelectedItem == null)
    //    {
    //        lViewOrdenSeleccion.Items.Clear();
    //        return; // No hay orden seleccionada
    //    }

    //    var idOrdenSeleccion = Convert.ToInt32(comboOrdenSeleccion.SelectedItem);
    //    foreach (var posicion in modelo.ObtenerListaPosiciones(idOrdenSeleccion))
    //    {
    //        var lvItem = new ListViewItem
    //        {
    //            Text = posicion.Posicion
    //        };
    //        _ = lvItem.SubItems.Add(posicion.Sku);
    //        _ = lvItem.SubItems.Add(posicion.Cantidad.ToString());
    //    }
    //}
    private void comboOrdenSeleccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboOrdenSeleccion.SelectedItem == null)
        {
            lViewOrdenSeleccion.Items.Clear();
            return; // No hay orden seleccionada
        }


        lViewOrdenSeleccion.Items.Clear();

        var idOrdenSeleccion = Convert.ToInt32(comboOrdenSeleccion.SelectedItem);

        foreach (var posicion in modelo.ObtenerListaPosiciones(idOrdenSeleccion))
        {
            var lvItem = new ListViewItem(posicion.Posicion);


            lvItem.SubItems.Add(posicion.Sku);
            lvItem.SubItems.Add(posicion.Cantidad.ToString());


            lViewOrdenSeleccion.Items.Add(lvItem);
        }
    }

    // Click en seleccionar: Llama a ConfirmarOrdenSeleccion(id), que:
    // Cambia el estado de la orden de selección a Confirmada. Cambia el estado de cada orden de preparación asociada a EnPreparación.
    // Debe descontar el stock según la lista que proporcione ObtenerListaPosiciones. Devuelve null si todo salió bien, o un mensaje de error si algo falló.
    private void btnSeleccion_Click(object sender, EventArgs e)
    {
        if (comboOrdenSeleccion.SelectedItem == null)
        {
            _ = MessageBox.Show("Seleccioná primero una orden.", "Atención");
            return;
        }

        var id = Convert.ToInt32(comboOrdenSeleccion.SelectedItem);
        var error = modelo.ConfirmarOrdenSeleccion(id);
        if (error == null)
        {
            _ = MessageBox.Show(error);
        }
        else
        {
            _ = MessageBox.Show("Orden confirmada correctamente.", "Éxito");
            CargarOrdenesSeleccionEnComboBox();
        }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Close();
    }

    //CargarOrdenesSeleccionEnComboBox: Pide al modelo la lista de IDs de órdenes Pendientes. Las añade al ComboBox.
    //Si hay al menos una, selecciona la primera (dispara el evento). Si no queda ninguna, avisa y cierra.
    private void CargarOrdenesSeleccionEnComboBox()
    {
        comboOrdenSeleccion.Items.Clear();
        foreach (var orden in modelo.ObtenerOrdenesDeSeleccion())
        {
            _ = comboOrdenSeleccion.Items.Add(orden);
        }
        if (comboOrdenSeleccion.Items.Count > 0)
        {
            comboOrdenSeleccion.SelectedIndex = 0;
        }
        else
        {
            _ = MessageBox.Show("Ya no hay órdenes para seleccionar.");
            Close();
        }
    }
}
