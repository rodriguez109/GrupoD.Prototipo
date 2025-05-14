using GrupoD.Prototipo._4._EmpaquetarProductos;
using GrupoD.Prototipo._5._Generar_Orden_de_Entrega;
using GrupoD.Prototipo._6._GenerarRemito;
using GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion;
using GrupoD.Prototipo.CDU2._GenerarOrdenSeleccion;
using Prototipo.PrepararProductos;

namespace GrupoD.Prototipo._0._Menu_Principal;

public partial class MenuForm : Form
{
    public MenuForm() => InitializeComponent();

    private void MenuForm_Load(object sender, EventArgs e)
    {

    }

    private void GenerarOSMenuBTN_Click(object sender, EventArgs e)
    {
        var generarOrdenDeSeleccionForm = new GenerarOrdenDeSeleccionForm();
        generarOrdenDeSeleccionForm.Show();
    }

    private void GenerarOEMenuBTN_Click(object sender, EventArgs e)
    {
        var generarOrdendeEntregaForm = new GenerarOrdendeEntregaForm();
        generarOrdendeEntregaForm.Show();
    }


    private void GenerarOPMenuBTN_Click(object sender, EventArgs e)
    {
        var ordenDePreparacion = new OrdenDePreparacion();
        ordenDePreparacion.Show();
    }

    private void PrepararProductoMenuBTN_Click(object sender, EventArgs e)
    {
        var prepararProductosForm = new PrepararProductosForm();
        prepararProductosForm.Show();
    }

    private void EmpaquetarMenuBTN_Click(object sender, EventArgs e)
    {
        var empaquetarProductosForm = new EmpaquetarProductosForm();
        empaquetarProductosForm.Show();
    }

    private void GenerarDocMenuBTN_Click(object sender, EventArgs e)
    {
        var generarRemitoForm = new GenerarRemitoForm();
        generarRemitoForm.Show();
    }
}

