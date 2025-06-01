using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrupoD.Prototipo._2._GenerarOrdenSeleccion;

namespace GrupoD.Prototipo._6._GenerarRemito
{

    public partial class GenerarRemitoForm : Form
    {
        private GenerarRemitoModelo? modelo;

        public GenerarRemitoForm()
        {
            InitializeComponent();
        }

        private void GenerarRemitoForm_Load(object sender, EventArgs e)
        {
            modelo = new GenerarRemitoModelo();
        }

        private void BuscarOrdenesBTN_Click(object sender, EventArgs e)
        {
            string dni = DniTransportistaTXT.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Debe ingresar un número de DNI para poder continuar.", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(dni, out _))
            {

                MessageBox.Show("Debe ingresar solo números", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
                   
            }

            if (dni.Length != 8)
            {
                MessageBox.Show("El DNI debe tener de 8 dígitos", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ordenes = modelo.ObtenerOrdenesPorDNI(dni);
            OrdenesDeSeleccionLST.Items.Clear();

            if (ordenes.Count == 0)
            {
                MessageBox.Show("No se encontraron órdenes de entrega para este DNI.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var orden in ordenes)
                {
                    bool yaAgregada = OrdenesAgregadasLST.Items.Cast<ListViewItem>()
                        .Any(i => ((OrdenDeSeleccion)i.Tag).NumeroOrden == orden.NumeroOrden);
                    if (yaAgregada)
                        continue;

                    var item = new ListViewItem(orden.NumeroOrden);
                    item.Tag = orden;
                    OrdenesDeSeleccionLST.Items.Add(item);
                }
            }
        }

        private void AgregarAlRemitoBTN_Click(object sender, EventArgs e)
        {
            if (OrdenesDeSeleccionLST.SelectedItems.Count == 0)  // Verificar si no hay ítems seleccionados
            {
                MessageBox.Show("Debe seleccionar al menos una orden de entrega para agregar al remito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ListViewItem item in OrdenesDeSeleccionLST.SelectedItems)
            {
                OrdenDeSeleccion orden = (OrdenDeSeleccion)item.Tag;
                var nuevoItem = new ListViewItem(orden.NumeroOrden);
                nuevoItem.Tag = orden;
                OrdenesAgregadasLST.Items.Add(nuevoItem);
                OrdenesDeSeleccionLST.Items.Remove(item);  // Eliminar de la lista de entrega
            }
        }

        private void QuitarDelRemitoBTN_Click(object sender, EventArgs e)
        {
            if (OrdenesAgregadasLST.SelectedItems.Count == 0)  // Verificar si no hay ítems seleccionados
            {
                MessageBox.Show("Debe seleccionar al menos una orden para quitar del remito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ListViewItem item in OrdenesAgregadasLST.SelectedItems)
            {
                OrdenDeSeleccion orden = (OrdenDeSeleccion)item.Tag;
                var nuevoItem = new ListViewItem(orden.NumeroOrden);
                nuevoItem.Tag = orden;
                OrdenesDeSeleccionLST.Items.Add(nuevoItem);  // Mover ítems de vuelta a la lista de entrega
                OrdenesAgregadasLST.Items.Remove(item);  // Eliminar de la lista agregada
            }
        }

        private void GenerarRemitoBTN_Click(object sender, EventArgs e)
        {
            if (OrdenesAgregadasLST.Items.Count == 0)  // Verificar si no hay ítems agregados al remito
            {
                MessageBox.Show("Debe agregar al menos una orden al remito antes de generarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> ordenes = OrdenesAgregadasLST.Items.Cast<ListViewItem>()
                .Select(i => ((OrdenDeSeleccion)i.Tag).NumeroOrden)
                .ToList();

            string ordenesTexto = string.Join(", ", ordenes);
            MessageBox.Show($"Remito generado con éxito.\nÓrdenes incluidas: {ordenesTexto}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar la lista de ordenes agregadas después de generar el remito
            OrdenesAgregadasLST.Items.Clear();
        }

        

        private void CancelarBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
    }



}
