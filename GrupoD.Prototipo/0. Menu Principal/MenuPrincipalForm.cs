using GrupoD.Prototipo._4._EmpaquetarProductos;
using GrupoD.Prototipo._5._Generar_Orden_de_Entrega;
using GrupoD.Prototipo._6._GenerarRemito;
using GrupoD.Prototipo.Almacenes;
using GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion;
using GrupoD.Prototipo.CDU2._GenerarOrdenSeleccion;
using Prototipo.PrepararProductos;

namespace GrupoD.Prototipo._0._Menu_Principal;

public partial class MenuForm : Form
{
    public MenuForm() => InitializeComponent();

    private void MenuForm_Load(object sender, EventArgs e)
    {
        foreach (var deposito in DepositoAlmacen.Depositos)
        {
            seleccionDepositoCMB.Items.Add(deposito.Nombre);
        }
        seleccionDepositoCMB.SelectedItem = seleccionDepositoCMB.Items[0];
    }

    //codigo de paulo
    //private void seleccionDepositoCMB_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string nombreSeleccionado = seleccionDepositoCMB.SelectedItem?.ToString();

    //    // Buscar el código del depósito
    //    var deposito = DepositoAlmacen.Depositos.FirstOrDefault(d => d.Nombre == nombreSeleccionado);
    //    if (deposito != null)
    //    {
    //        DepositoAlmacen.CodigoDepositoActual = deposito.Codigo; // Se actualiza el depósito actual
    //        MessageBox.Show($"Depósito seleccionado: {deposito.Nombre} (Código: {deposito.Codigo})");
    //    }
    //}
    private void seleccionDepositoCMB_SelectedIndexChanged(object sender, EventArgs e)
    {
        string nombreSeleccionado = seleccionDepositoCMB.SelectedItem?.ToString();

        var deposito = DepositoAlmacen.Depositos.FirstOrDefault(d => d.Nombre == nombreSeleccionado);
        if (deposito != null)
        {
            DepositoAlmacen.CodigoDepositoActual = deposito.Codigo; // Se actualiza el depósito actual
            //MessageBox.Show($"Depósito seleccionado: {deposito.Nombre} (Código: {deposito.Codigo})");
        }
    }


    //Método para validar si se seleccionó un depósito antes de ejecutar una acción.
    private bool ValidarSeleccionDeposito()
    {
        if (string.IsNullOrEmpty(seleccionDepositoCMB.Text))
        {
            MessageBox.Show("Por favor, seleccione un depósito antes de continuar.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }

    private void GenerarOSMenuBTN_Click(object sender, EventArgs e)
    {
        if (!ValidarSeleccionDeposito()) return;

        var generarOrdenDeSeleccionForm = new GenerarOrdenDeSeleccionForm();
        generarOrdenDeSeleccionForm.Show();
    }

    private void GenerarOEMenuBTN_Click(object sender, EventArgs e)
    {
        if (!ValidarSeleccionDeposito()) return;

        var generarOrdendeEntregaForm = new GenerarOrdendeEntregaForm();
        generarOrdendeEntregaForm.Show();
    }

    private void GenerarOPMenuBTN_Click(object sender, EventArgs e)
    {
        if (!ValidarSeleccionDeposito()) return;

        var ordenDePreparacion = new OrdenDePreparacion();
        ordenDePreparacion.Show();
    }

    private void PrepararProductoMenuBTN_Click(object sender, EventArgs e)
    {
        if (!ValidarSeleccionDeposito()) return;

        var prepararProductosForm = new PrepararProductosForm();
        prepararProductosForm.Show();
    }

    private void EmpaquetarMenuBTN_Click(object sender, EventArgs e)
    {
        if (!ValidarSeleccionDeposito()) return;

        var empaquetarProductosForm = new EmpaquetarProductosForm();
        empaquetarProductosForm.Show();
    }

    private void GenerarDocMenuBTN_Click(object sender, EventArgs e)
    {
        if (!ValidarSeleccionDeposito()) return;

        var generarRemitoForm = new GenerarRemitoForm();
        generarRemitoForm.Show();
    }
}
