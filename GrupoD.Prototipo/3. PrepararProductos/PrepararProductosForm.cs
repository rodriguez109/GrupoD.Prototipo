using Prototipo.PrepararProductos.PrepararProductos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prototipo.PrepararProductos
{
    public partial class PrepararProductosForm : Form
    {
        private List<OrdenSeleccion> listaOrdenes;

        public PrepararProductosForm()
        {
            InitializeComponent();
            this.Load += PrepararProductosForm_Load;
            comboOrdenSeleccion.SelectedIndexChanged += Comboordenseleccion_SelectedIndexChanged;

            btnSeleccion.Click += BtnSeleccion_Click;

            btnCancelar.Click += BtnCancelar_Click;

        }

        private void BtnSeleccion_Click(object sender, EventArgs e)
        {
            // Verifica si hay una orden seleccionada
            var ordenSeleccionada = comboOrdenSeleccion.SelectedItem as OrdenSeleccion;

            // Verifica también que el ListView tenga productos cargados
            if (ordenSeleccionada == null || ordenSeleccionada.Productos == null || ordenSeleccionada.Productos.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una orden válida antes de confirmar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si todo está bien, se confirma la orden
            MessageBox.Show("¡Orden de selección confirmada!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario (cerrar el programa)
            this.Close();
        }

        private void PrepararProductosForm_Load(object sender, EventArgs e)
        {
            listaOrdenes = new List<OrdenSeleccion>
            {

                new OrdenSeleccion
                {
                    NombreOrden = "1",
                    Productos = new List<ProductoOrdenado>
                    {
                        new ProductoOrdenado { Ubicacion = "01-01-1", SKUProducto = "SKU001", Cantidad = 10 },
                        new ProductoOrdenado { Ubicacion = "01-01-2", SKUProducto = "SKU002", Cantidad = 5 },
                        new ProductoOrdenado { Ubicacion = "01-01-3", SKUProducto = "SKU003", Cantidad = 8 },
                        new ProductoOrdenado { Ubicacion = "01-01-4", SKUProducto = "SKU004", Cantidad = 12 },
                        new ProductoOrdenado { Ubicacion = "01-01-5", SKUProducto = "SKU005", Cantidad = 7 },
                        new ProductoOrdenado { Ubicacion = "01-01-6", SKUProducto = "SKU006", Cantidad = 3 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "2",
                    Productos = new List<ProductoOrdenado>
                    {
                        new ProductoOrdenado { Ubicacion = "02-01-1", SKUProducto = "SKU007", Cantidad = 15 },
                        new ProductoOrdenado { Ubicacion = "02-01-2", SKUProducto = "SKU008", Cantidad = 9 },
                        new ProductoOrdenado { Ubicacion = "02-01-3", SKUProducto = "SKU009", Cantidad = 4 },
                        new ProductoOrdenado { Ubicacion = "02-01-4", SKUProducto = "SKU010", Cantidad = 6 },
                        new ProductoOrdenado { Ubicacion = "02-01-5", SKUProducto = "SKU011", Cantidad = 11 },
                        new ProductoOrdenado { Ubicacion = "02-01-6", SKUProducto = "SKU012", Cantidad = 2 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "3",
                    Productos = new List<ProductoOrdenado>
                    {
                        new ProductoOrdenado { Ubicacion = "03-01-1", SKUProducto = "SKU013", Cantidad = 20 },
                        new ProductoOrdenado { Ubicacion = "03-01-2", SKUProducto = "SKU014", Cantidad = 5 },
                        new ProductoOrdenado { Ubicacion = "03-01-3", SKUProducto = "SKU015", Cantidad = 3 },
                        new ProductoOrdenado { Ubicacion = "03-01-4", SKUProducto = "SKU016", Cantidad = 7 },
                        new ProductoOrdenado { Ubicacion = "03-01-5", SKUProducto = "SKU017", Cantidad = 9 },
                        new ProductoOrdenado { Ubicacion = "03-01-6", SKUProducto = "SKU018", Cantidad = 14 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "4",
                    Productos = new List<ProductoOrdenado>
                    {
                        new ProductoOrdenado { Ubicacion = "04-01-1", SKUProducto = "SKU019", Cantidad = 6 },
                        new ProductoOrdenado { Ubicacion = "04-01-2", SKUProducto = "SKU020", Cantidad = 13 },
                        new ProductoOrdenado { Ubicacion = "04-01-3", SKUProducto = "SKU021", Cantidad = 11 },
                        new ProductoOrdenado { Ubicacion = "04-01-4", SKUProducto = "SKU022", Cantidad = 4 },
                        new ProductoOrdenado { Ubicacion = "04-01-5", SKUProducto = "SKU023", Cantidad = 8 },
                        new ProductoOrdenado { Ubicacion = "04-01-6", SKUProducto = "SKU024", Cantidad = 3 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "5",
                    Productos = new List<ProductoOrdenado>
                    {
                        new ProductoOrdenado { Ubicacion = "05-01-1", SKUProducto = "SKU025", Cantidad = 10 },
                        new ProductoOrdenado { Ubicacion = "05-01-2", SKUProducto = "SKU026", Cantidad = 2 },
                        new ProductoOrdenado { Ubicacion = "05-01-3", SKUProducto = "SKU027", Cantidad = 7 },
                        new ProductoOrdenado { Ubicacion = "05-01-4", SKUProducto = "SKU028", Cantidad = 9 },
                        new ProductoOrdenado { Ubicacion = "05-01-5", SKUProducto = "SKU029", Cantidad = 1 },
                        new ProductoOrdenado { Ubicacion = "05-01-6", SKUProducto = "SKU030", Cantidad = 6 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "6",
                    Productos = new List<ProductoOrdenado>
                    {
                        new ProductoOrdenado { Ubicacion = "06-01-1", SKUProducto = "SKU031", Cantidad = 3 },
                        new ProductoOrdenado { Ubicacion = "06-01-2", SKUProducto = "SKU032", Cantidad = 8 },
                        new ProductoOrdenado { Ubicacion = "06-01-3", SKUProducto = "SKU033", Cantidad = 5 },
                        new ProductoOrdenado { Ubicacion = "06-01-4", SKUProducto = "SKU034", Cantidad = 12 },
                        new ProductoOrdenado { Ubicacion = "06-01-5", SKUProducto = "SKU035", Cantidad = 9 },
                        new ProductoOrdenado { Ubicacion = "06-01-6", SKUProducto = "SKU036", Cantidad = 2 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "7",
                    Productos = new List<ProductoOrdenado>
                    {
                        new ProductoOrdenado { Ubicacion = "07-01-1", SKUProducto = "SKU037", Cantidad = 10 },
                        new ProductoOrdenado { Ubicacion = "07-01-2", SKUProducto = "SKU038", Cantidad = 4 },
                        new ProductoOrdenado { Ubicacion = "07-01-3", SKUProducto = "SKU039", Cantidad = 6 },
                        new ProductoOrdenado { Ubicacion = "07-01-4", SKUProducto = "SKU040", Cantidad = 11 },
                        new ProductoOrdenado { Ubicacion = "07-01-5", SKUProducto = "SKU041", Cantidad = 5 },
                        new ProductoOrdenado { Ubicacion = "07-01-6", SKUProducto = "SKU042", Cantidad = 7 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "8",
                    Productos = new List<ProductoOrdenado>
                    {
                        new ProductoOrdenado { Ubicacion = "08-01-1", SKUProducto = "SKU043", Cantidad = 9 },
                        new ProductoOrdenado { Ubicacion = "08-01-2", SKUProducto = "SKU044", Cantidad = 3 },
                        new ProductoOrdenado { Ubicacion = "08-01-3", SKUProducto = "SKU045", Cantidad = 4 },
                        new ProductoOrdenado { Ubicacion = "08-01-4", SKUProducto = "SKU046", Cantidad = 6 },
                        new ProductoOrdenado { Ubicacion = "08-01-5", SKUProducto = "SKU047", Cantidad = 13 },
                        new ProductoOrdenado { Ubicacion = "08-01-6", SKUProducto = "SKU048", Cantidad = 2 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "9",
                    Productos = new List<ProductoOrdenado>
                    {
                        new ProductoOrdenado { Ubicacion = "09-01-1", SKUProducto = "SKU049", Cantidad = 8 },
                        new ProductoOrdenado { Ubicacion = "09-01-2", SKUProducto = "SKU050", Cantidad = 5 },
                        new ProductoOrdenado { Ubicacion = "09-01-3", SKUProducto = "SKU051", Cantidad = 3 },
                        new ProductoOrdenado { Ubicacion = "09-01-4", SKUProducto = "SKU052", Cantidad = 7 },
                        new ProductoOrdenado { Ubicacion = "09-01-5", SKUProducto = "SKU053", Cantidad = 4 },
                        new ProductoOrdenado { Ubicacion = "09-01-6", SKUProducto = "SKU054", Cantidad = 6 }
                    }
                },
                new OrdenSeleccion
                {
                    NombreOrden = "10",
                    Productos = new List<ProductoOrdenado>
                    {
                        new ProductoOrdenado { Ubicacion = "10-01-1", SKUProducto = "SKU055", Cantidad = 10 },
                        new ProductoOrdenado { Ubicacion = "10-01-2", SKUProducto = "SKU056", Cantidad = 9 },
                        new ProductoOrdenado { Ubicacion = "10-01-3", SKUProducto = "SKU057", Cantidad = 6 },
                        new ProductoOrdenado { Ubicacion = "10-01-4", SKUProducto = "SKU058", Cantidad = 4 },
                        new ProductoOrdenado { Ubicacion = "10-01-5", SKUProducto = "SKU059", Cantidad = 8 },
                        new ProductoOrdenado { Ubicacion = "10-01-6", SKUProducto = "SKU060", Cantidad = 1 }
                    }
                }
            };

                comboOrdenSeleccion.DataSource = listaOrdenes;
                comboOrdenSeleccion.DisplayMember = "NombreOrden";
        }

        private void Comboordenseleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ordenSeleccionada = comboOrdenSeleccion.SelectedItem as OrdenSeleccion;
            if (ordenSeleccionada == null) return;

            lViewOrdenSeleccion.Items.Clear();

            foreach (var prod in ordenSeleccionada.Productos)
            {
                var item = new ListViewItem(prod.Ubicacion);
                item.SubItems.Add(prod.SKUProducto);
                item.SubItems.Add(prod.Cantidad.ToString());
                lViewOrdenSeleccion.Items.Add(item);
            }
        }
    }
}
