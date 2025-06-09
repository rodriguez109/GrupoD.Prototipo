using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GrupoD.Prototipo._3._PrepararProductos;
using GrupoD.Prototipo.Almacenes;

namespace Prototipo.PrepararProductos
{
    public partial class PrepararProductosForm : Form
    {
        private PrepararProductosModelo modelo;
        private List<Producto> productosInfo;
        public PrepararProductosForm()
        {
            InitializeComponent();
            modelo = new PrepararProductosModelo();
            productosInfo = new List<Producto>();
        }
        private void PrepararProductosForm_Load(object sender, EventArgs e)
        {
            // Cargar las órdenes de selección en el ComboBox  
            CargarOrdenesSeleccionEnComboBox(comboOrdenSeleccion);

            // Establecer el estilo del ComboBox para que solo permita selección y no ASIGNAR un valor manualmente
            comboOrdenSeleccion.DropDownStyle = ComboBoxStyle.DropDownList;

            // Seleccionar la primera orden de selección si hay alguna  
            if (comboOrdenSeleccion.Items.Count > 0)
            {
                comboOrdenSeleccion.SelectedIndex = 0; // Selecciona automáticamente la primera orden de selección  
            }
        }

        public void CargarOrdenesSeleccionEnComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            List<int> ordenes = modelo.ObtenerOrdenesDeSeleccion();

            foreach (var orden in ordenes)
            {
                comboBox.Items.Add(orden);
            }

            // Seleccionar la primera orden de selección si hay alguna  
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0; // Selecciona automáticamente la primera  
            }
        }

        private List<OrdenesDeSeleccion> listaOrdenesDeSeleccion; // Agregar esta lista para almacenar las órdenes de selección

        private List<Producto> ObtenerProductosPorOrdenDeSeleccion(int idOrdenSeleccion) //VER CON ANDRES --> COPILOT ME CORRIGIO Y SE PUSO ASÍ OSCURO !!
                                                                                         //No me carga el listview
                                                                                         //Ver botón cancelar
        {
            var orden = listaOrdenesDeSeleccion.FirstOrDefault(o => o.NumeroOrdenSeleccion == idOrdenSeleccion);
            if (orden == null)
            {
                throw new InvalidOperationException($"No se encontró la orden de selección con ID {idOrdenSeleccion}");
            }

            var ordenesPreparacion = orden.OrdenesPreparacion
                .Select(op => OrdenDePreparacionAlmacen.OrdenesDePreparacion.FirstOrDefault(entidad => entidad.Numero == op.Id))
                .Where(entidad => entidad != null)
                .ToList();

            var cantReqXProducto = new Dictionary<int, int>();
            foreach (var ordenPrep in ordenesPreparacion)
            {
                foreach (var detalleOrdenPrep in ordenPrep.Detalle)
                {
                    if (cantReqXProducto.ContainsKey(detalleOrdenPrep.SKU))
                    {
                        cantReqXProducto[detalleOrdenPrep.SKU] += detalleOrdenPrep.Cantidad;
                    }
                    else
                    {
                        cantReqXProducto.Add(detalleOrdenPrep.SKU, detalleOrdenPrep.Cantidad);
                    }
                }
            }

            var resultado = new List<Producto>();

            foreach (int sku in cantReqXProducto.Keys)
            {
                var productoEntidad = ProductoAlmacen.Productos.FirstOrDefault(p => p.SKU == sku);
                if (productoEntidad == null)
                {
                    throw new InvalidOperationException($"No se encontró el producto con SKU {sku}");
                }

                var productoResultado = new Producto(sku.ToString(), productoEntidad.NumeroCliente.ToString(), productoEntidad.Nombre, new List<UbicacionProdEnDepositoBuscar>());

                foreach (var ubicacionEnStock in productoEntidad.Posiciones)
                {
                    var resultadoUbicacion = new UbicacionProdEnDepositoBuscar
                    {
                        IdUbicacion = ubicacionEnStock.CodigoDeposito,
                        Stock = Math.Min(cantReqXProducto[sku], ubicacionEnStock.Stock)
                    };

                    cantReqXProducto[sku] -= resultadoUbicacion.Stock;
                    productoResultado.Detalle.Add(resultadoUbicacion);

                    if (cantReqXProducto[sku] == 0)
                    {
                        break;
                    }
                }

                resultado.Add(productoResultado);
            }
            return resultado;
        }
        // Botón “Confirmar”
        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            if (comboOrdenSeleccion.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná primero una orden.", "Atención");
                return;
            }

            int id = Convert.ToInt32(comboOrdenSeleccion.SelectedItem);
            try
            {
                modelo.ConfirmarOrdenSeleccion(id);
                MessageBox.Show("Orden confirmada correctamente.", "Éxito");
                CargarOrdenesSeleccionEnComboBox(comboOrdenSeleccion);
                lViewOrdenSeleccion.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // Botón “Cancelar”
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lViewOrdenSeleccion.Items.Clear();
            comboOrdenSeleccion.SelectedIndex = -1;
        }
    }
}
