using GrupoD.Prototipo._2._GenerarOrdenSeleccion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GrupoD.Prototipo.CDU2._GenerarOrdenSeleccion
{
    public partial class GenerarOrdenDeSeleccionForm : Form
    {
        public GenerarOrdenDeSeleccionForm()
        {
            InitializeComponent();
        }
        //El formulario tiene una referencia al modelo
        private GenerarOrdenSeleccionModelo modelo;
        private List<OrdenesDePreparacion> OrdenesPreparacionDisponibles = new List<OrdenesDePreparacion>();
        private List<OrdenesDePreparacion> OrdenesAgregadas = new List<OrdenesDePreparacion>();

        //Esto es lo primero que se ejecuta de la funcionalidad -------------------------------------------------------------------------------------------
        private void GenerarOrdenDeSeleccionForm_Load(object sender, EventArgs e)
        {
            // Inicializar modelo
            modelo = new GenerarOrdenSeleccionModelo();

            // Habilitar las partes superiores del formulario.
            NombreClienteTXT.Enabled = true;
            NumeroOrdenPreparacionTXT.Enabled = true;
            FechaEntregaDTP.Enabled = true;
            PrioridadCMB.Enabled = true;

            // Llenar el ComboBox con los valores de Prioridad
            PrioridadCMB.Items.Clear();
            PrioridadCMB.Items.AddRange(new string[] { "Alta", "Media", "Baja" });
            PrioridadCMB.SelectedIndex = -1;

            // Aplicar limpieza de filtros y actualizar lista de órdenes
            BorrarFiltros();
            ActualizarListaOrdenDePreparacion();

            // Vincular evento para el DateTimePicker
            FechaEntregaDTP.ValueChanged += FechaEntregaDTP_ValueChanged;
        }

        // Evento para establecer el formato correcto cuando el usuario selecciona una fecha
        private void FechaEntregaDTP_ValueChanged(object sender, EventArgs e)
        {
            FechaEntregaDTP.CustomFormat = "dd/MM/yyyy"; // Mostrar la fecha correctamente al seleccionarla
        }


        // EVENTOS DEL FORMULARIO ----------------------------------------------------------------------------------------------------------------------

        private void CancelarOrdenSeleccionBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarOrdenesPendientesBTN_Click(object sender, EventArgs e)
        {
            // Limpiar la lista actual
            OrdenesPreparacionPendientesLST.Items.Clear();

            // Obtener los valores de los filtros
            string clienteAFiltrar = NombreClienteTXT.Text.Trim();
            string idOrdenAFiltrar = NumeroOrdenPreparacionTXT.Text.Trim();
            string prioridadAFiltrar = PrioridadCMB.SelectedItem?.ToString();
            DateTime? fechaAFiltrar = string.IsNullOrWhiteSpace(FechaEntregaDTP.CustomFormat.Trim()) ? null : FechaEntregaDTP.Value.Date;

            // Si no hay filtros ingresados, mostrar error pero recargar la lista completa
            if (string.IsNullOrWhiteSpace(clienteAFiltrar) &&
                string.IsNullOrWhiteSpace(idOrdenAFiltrar) &&
                string.IsNullOrWhiteSpace(prioridadAFiltrar) &&
                fechaAFiltrar == null)
            {
                MessageBox.Show("Por favor, ingrese al menos un criterio de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reutilizar método para recargar la lista completa
                ActualizarListaOrdenDePreparacion();
                return;
            }

            // Obtener las órdenes disponibles, excluyendo las ya agregadas
            var ordenesFiltradas = modelo.OrdenesPreparacionDisponibles
                .Where(o => !modelo.OrdenesAgregadas.Any(ag => ag.NumeroOrden == o.NumeroOrden))
                .ToList();

            // Aplicar filtros
            if (!string.IsNullOrWhiteSpace(clienteAFiltrar))
            {
                ordenesFiltradas = ordenesFiltradas
                    .Where(o => o.NombreCliente.IndexOf(clienteAFiltrar, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(idOrdenAFiltrar))
            {
                if (int.TryParse(idOrdenAFiltrar, out int numeroOrden))
                {
                    ordenesFiltradas = ordenesFiltradas
                        .Where(o => o.NumeroOrden == numeroOrden)
                        .ToList();
                }
                else
                {
                    MessageBox.Show("El número de orden debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(prioridadAFiltrar))
            {
                ordenesFiltradas = ordenesFiltradas
                    .Where(o => o.Prioridad.Equals(prioridadAFiltrar, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (fechaAFiltrar.HasValue)
            {
                ordenesFiltradas = ordenesFiltradas
                    .Where(o => o.FechaEntrega.Date == fechaAFiltrar.Value)
                    .ToList();
            }

            // Verificar si hay resultados
            if (!ordenesFiltradas.Any())
            {
                MessageBox.Show("No se encontraron órdenes de preparación que coincidan con los criterios de búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Si no hay resultados, recargar la lista completa en lugar de dejarla vacía
                ActualizarListaOrdenDePreparacion();
                return;
            }

            // Mostrar los resultados filtrados en el ListView
            foreach (var orden in ordenesFiltradas)
            {
                var item = new ListViewItem(orden.NumeroOrden.ToString());
                item.SubItems.Add(orden.NombreCliente);
                item.SubItems.Add(orden.FechaEntrega.ToShortDateString());
                item.SubItems.Add(orden.Transportista);
                item.SubItems.Add(orden.Prioridad);
                OrdenesPreparacionPendientesLST.Items.Add(item);
            }
        }

        private void ReiniciarBusquedaBTN_Click(object sender, EventArgs e)
        {
            // Llamar a BorrarFiltros para limpiar todos los criterios de búsqueda
            BorrarFiltros();

            // Llamar a ActualizarListaOrdenDePreparacion para recargar la lista completa
            ActualizarListaOrdenDePreparacion();
        }


        private void AgregarOrdenesSeleccionadasBTN_Click(object sender, EventArgs e)
        {
            // Verificar si hay elementos seleccionados en la lista de pendientes
            if (OrdenesPreparacionPendientesLST.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos una orden de preparación para continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lista para almacenar las órdenes que vamos a mover
            List<OrdenesDePreparacion> ordenesParaMover = new List<OrdenesDePreparacion>();

            // Recorrer las órdenes seleccionadas
            foreach (ListViewItem item in OrdenesPreparacionPendientesLST.SelectedItems)
            {
                int numeroOrden = int.Parse(item.Text);

                var orden = modelo.OrdenesPreparacionDisponibles
                    .FirstOrDefault(o => o.NumeroOrden == numeroOrden);

                if (orden != null && !modelo.OrdenesAgregadas.Any(a => a.NumeroOrden == orden.NumeroOrden))
                {
                    // Agregar la orden a la lista de órdenes seleccionadas
                    ordenesParaMover.Add(orden);

                    // Marcar como agregada
                    modelo.OrdenesAgregadas.Add(orden);
                }
            }

            // Si no hay órdenes para mover, mostrar mensaje
            if (ordenesParaMover.Count == 0)
            {
                MessageBox.Show("Las órdenes seleccionadas ya fueron agregadas previamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Mover las órdenes seleccionadas de la lista de pendientes a la lista de seleccionadas
            foreach (var orden in ordenesParaMover)
            {
                var item = new ListViewItem(orden.NumeroOrden.ToString());
                item.SubItems.Add(orden.NombreCliente);
                item.SubItems.Add(orden.FechaEntrega.ToShortDateString());
                item.SubItems.Add(orden.Transportista);
                item.SubItems.Add(orden.Prioridad);

                OrdenesPreparacionPendientesSeleccionadasLST.Items.Add(item);
            }

            // Refrescar la lista de pendientes reutilizando `ActualizarListaOrdenDePreparacion()`
            ActualizarListaOrdenDePreparacion();

            MessageBox.Show("Orden de preparación pendiente agregada al detalle de órdenes a seleccionar", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void QuitarOrdenesSeleccionadasBTN_Click(object sender, EventArgs e)
        {
            // Verificar si hay elementos seleccionados en la lista de seleccionadas
            if (OrdenesPreparacionPendientesSeleccionadasLST.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos una orden de preparación para quitar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lista para almacenar las órdenes que vamos a mover de vuelta a pendientes
            List<OrdenesDePreparacion> ordenesParaMover = new List<OrdenesDePreparacion>();

            // Recorrer las órdenes seleccionadas en la lista de seleccionadas
            foreach (ListViewItem item in OrdenesPreparacionPendientesSeleccionadasLST.SelectedItems)
            {
                int numeroOrden = int.Parse(item.Text);

                var orden = modelo.OrdenesAgregadas
                    .FirstOrDefault(o => o.NumeroOrden == numeroOrden);

                if (orden != null)
                {
                    // Agregar la orden a la lista de pendientes
                    ordenesParaMover.Add(orden);

                    // Eliminar de la lista de agregadas
                    modelo.OrdenesAgregadas.Remove(orden);
                }
            }

            // Eliminar de la lista de seleccionadas
            foreach (ListViewItem item in OrdenesPreparacionPendientesSeleccionadasLST.SelectedItems.Cast<ListViewItem>().ToList())
            {
                OrdenesPreparacionPendientesSeleccionadasLST.Items.Remove(item);
            }

            // Refrescar la lista de pendientes reutilizando `ActualizarListaOrdenDePreparacion()`
            ActualizarListaOrdenDePreparacion();

            MessageBox.Show("Orden de preparación pendiente removida del listado de órdenes a seleccionar", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //private void GenerarOrdenSeleccionBTN_Click(object sender, EventArgs e)
        //{
        // Verificar si hay elementos en la lista OrdenesPreparacionPendientesSeleccionadasLST

        //if (OrdenesPreparacionPendientesSeleccionadasLST.Items.Count == 0)
        //{
        //MessageBox.Show("No hay órdenes de preparación pendientes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //return;
        //}

        // Agregar las órdenes de preparación a la orden de selección

        // Eliminar las órdenes de preparación que se han agregado a la orden de selección de la lista OrdenesPreparacionPendientesLST

        // Le pido al modelo que cree una nueva orden de seleccion con esas ordenes de preparacion seleccionadas

        // Vaciar la lista OrdenesPreparacionPendientesSeleccionadasLST

        // Mostrar mensaje de confirmación

        //}

        private void GenerarOrdenSeleccionBTN_Click(object sender, EventArgs e)
        {
            // Verificar si hay órdenes agregadas
            if (!modelo.OrdenesAgregadas.Any())
            {
                MessageBox.Show("No hay ordenes de preparacion pendientes para crear una orden de selección", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Definir número correlativo de orden
            int nuevoNumeroOrdenSeleccion = modelo.OrdenesDeSeleccion.Count + 1;

            // Crear nueva orden de selección con las órdenes agregadas
            var nuevaOrdenSeleccion = new OrdenesDeSeleccion(
                nuevoNumeroOrdenSeleccion,
                modelo.OrdenesAgregadas.ToList(),
                DateTime.Now,
                "Pendiente"
            );

            // Agregar la nueva orden a la lista
            modelo.OrdenesDeSeleccion.Add(nuevaOrdenSeleccion);

            // Eliminar las órdenes agregadas de la lista de disponibles
            modelo.OrdenesPreparacionDisponibles.RemoveAll(o => modelo.OrdenesAgregadas.Any(ag => ag.NumeroOrden == o.NumeroOrden));

            // Limpiar listas después de generar la orden
            modelo.OrdenesAgregadas.Clear();
            OrdenesPreparacionPendientesSeleccionadasLST.Items.Clear();

            // Recargar la lista de órdenes disponibles
            ActualizarListaOrdenDePreparacion();

            MessageBox.Show($"Orden de selección número {nuevoNumeroOrdenSeleccion} generada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        // DEFINICION DE METODOS AUXILIARES  ------------------------------------------------------------------------------------------------------------

        private void ActualizarListaOrdenDePreparacion()
        {
            // Limpiar la lista actual
            OrdenesPreparacionPendientesLST.Items.Clear();

            // Verificar si hay órdenes disponibles
            if (modelo.OrdenesPreparacionDisponibles == null || !modelo.OrdenesPreparacionDisponibles.Any())
            {
                MessageBox.Show("No hay órdenes de preparación disponibles para seleccionar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Mostrar órdenes de preparación pendientes (no agregadas)
            var ordenesNoAgregadas = modelo.OrdenesPreparacionDisponibles
                .Where(o => !modelo.OrdenesAgregadas.Any(ag => ag.NumeroOrden == o.NumeroOrden))
                .ToList();

            foreach (var orden in ordenesNoAgregadas)
            {
                var item = new ListViewItem(orden.NumeroOrden.ToString());
                item.SubItems.Add(orden.NombreCliente);
                item.SubItems.Add(orden.FechaEntrega.ToShortDateString());
                item.SubItems.Add(orden.Transportista);
                item.SubItems.Add(orden.Prioridad);
                OrdenesPreparacionPendientesLST.Items.Add(item);
            }
        }


        private void BorrarFiltros()
        {
            // Limpiar los campos de búsqueda
            NombreClienteTXT.Clear();
            NumeroOrdenPreparacionTXT.Clear();
            PrioridadCMB.SelectedIndex = -1;

            // Configurar DateTimePicker para que se muestre vacío sin checkbox
            FechaEntregaDTP.Format = DateTimePickerFormat.Custom;
            FechaEntregaDTP.CustomFormat = " "; // Sin fecha inicial
        }





        //aca es donde vienen las validaciones (validamos los datos minimos para pasarle los datos al modelo -- esto es por evento click

        //validar lo minimo necesario para pasarle los datos al modelo
        //tomar los valores de los controles y realizar validaciones minimas

        //var fechanacimiento = textbox XXX

        //para poder hacer esto construir un objeto X

        //Pasar al modelo quien realiza el resto de las validaciones y devuelve mensaje de error si hace falta

        //aca van todos los if else
        //try parse y return como por ejemplo 1) el numero de dni no es un numero / facha de nacimiento no es fecha valida / el telefono no es un numero

        //por ejemplo evento borrar debe decir "No hay ninguna persona para borrar"
    }
}
