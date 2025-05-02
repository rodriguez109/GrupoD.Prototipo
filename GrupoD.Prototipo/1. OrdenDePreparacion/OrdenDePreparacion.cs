using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion
{
    public partial class OrdenDePreparacion : Form
    {
        private OrdenDePreparacionModelo modelo;

        public OrdenDePreparacion()
        {
            InitializeComponent();
        }

        private void OrdenDePreparacion_Load(object sender, EventArgs e)
        {
            modelo = new OrdenDePreparacionModelo();
            // Aquí puedes inicializar el modelo o cargar datos si es necesario
        }

        private void generarOPBTN_Click(object sender, EventArgs e)
        {
            var NumeroOrdenPreparacion = numeroOrdenPreparacionTextBox.Text;
            var nombreProducto = productoSeleccionadoTXT.Text;
            var cantidadProducto = cantidadSeleccionadaTXT.Text;
            if (!int.TryParse(cantidadProducto, out int cantidad))
            {
                MessageBox.Show("La cantidad no es válida.");
                return;
            }

            var fechaRetirar = fechaRetirarTXT.Text;
            if (!DateTime.TryParse(fechaRetirar, out DateTime fechaRetirarDate))
            {
                MessageBox.Show("La fecha de retiro no es válida.");
                return;
            }
            var prioridad = prioridadCMB.SelectedValue.ToString();
            var cuilTransportista = cuilTransportistaTXT.Text;
            if (!int.TryParse(cuilTransportista, out int cuil))
            {

                MessageBox.Show("El CUIL del transportista no es válido.");
                return;
            }

        }

       
    }
}
