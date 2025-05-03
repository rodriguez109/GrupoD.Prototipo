using GrupoD.Prototipo.CDU2._GenerarOrdenSeleccion;
using GrupoD.Prototipo;

//using GrupoD.Prototipo._4._Empaquetar_Productos;
//>>>>>>> b5605ac3bedbd13f710e58fc45e73dac3f630a1d
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoD.Prototipo._0._Menu_Principal
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void GenerarOSMenuBTN_Click(object sender, EventArgs e)
        {
            GenerarOrdenDeSeleccionForm generarOrdenDeSeleccionForm = new GenerarOrdenDeSeleccionForm();
            generarOrdenDeSeleccionForm.Show();
        }
//<<<<<<< HEAD
        private void GenerarOEMenuBTN_Click(object sender, EventArgs e)
        {
            GenerarOrdendeEntrega generarOrdenDeEntregaaForm = new GenerarOrdendeEntrega();
            generarOrdenDeEntregaaForm.Show();
        }
//=======
//=======

        private void EmpaquetarProductosMenuBTN_Click(object sender, EventArgs e)
        {
            //    GenerarOrdenPreparadaForm generarOrdenPreparadaForm = new GenerarOrdenPreparadaForm();
            //    generarOrdenPreparadaForm.Show();
        }

//>>>>>>> b5605ac3bedbd13f710e58fc45e73dac3f630a1d
        private void GenerarOPMenuBTN_Click(object sender, EventArgs e)
        {
//>>>>>>> c9680d6050ca24c1528df9bb3c468796010f5fc2

        }
    }
}

