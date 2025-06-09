using GrupoD.Prototipo._3._PrepararProductos;

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

    private void comboOrdenSeleccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboOrdenSeleccion.SelectedItem == null)
        {
            lViewOrdenSeleccion.Items.Clear();
            return; // No hay orden seleccionada
        }

        var idOrdenSeleccion = Convert.ToInt32(comboOrdenSeleccion.SelectedItem);
        foreach (var posicion in modelo.ObtenerListaPosiciones(idOrdenSeleccion))
        {
            var lvItem = new ListViewItem
            {
                Text = posicion.Posicion
            };
            _ = lvItem.SubItems.Add(posicion.Sku);
            _ = lvItem.SubItems.Add(posicion.Cantidad.ToString());
        }
    }

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
