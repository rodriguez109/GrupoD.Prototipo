namespace GrupoD.Prototipo.CDU1_GenerarOrdenDePreparacion.sln.OrdenDePreparacion
{
    partial class OrdenDePreparacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            numeroClienteLBL = new Label();
            numeroClienteTXT = new TextBox();
            razonSocialClienteTXT = new TextBox();
            label3 = new Label();
            limpiarFiltrosBTN = new Button();
            depositoPorClienteLBL = new Label();
            productosClienteLST = new ListView();
            skuProductoCLM = new ColumnHeader();
            nombreProductoCLM = new ColumnHeader();
            cantidadProductoCLM = new ColumnHeader();
            productoSeleccionadoLBL = new Label();
            cantidadDisponibleLBL = new Label();
            cantidadSeleccionadaTXT = new TextBox();
            cantidadSeleccionadaLBL = new Label();
            agregarProductoBTN = new Button();
            opLBL = new Label();
            ordenPreparacionLST = new ListView();
            skuProductoLBL = new ColumnHeader();
            nombreProductoLBL = new ColumnHeader();
            cantidadSeleccionadaCLM = new ColumnHeader();
            fechaRetirarLBL = new Label();
            prioridadLBL = new Label();
            prioridadCMB = new ComboBox();
            cuilTransportistaLBL = new Label();
            cancelarBTN = new Button();
            generarOPBTN = new Button();
            cuilTransportistaTXT = new TextBox();
            quitarProductoBTN = new Button();
            fechaRetirarDTP = new DateTimePicker();
            productoSeleccionadoLABEL = new Label();
            cantidadDisponibleLABEL = new Label();
            buscarProductosBTN = new Button();
            palletCBX = new CheckBox();
            SuspendLayout();
            // 
            // numeroClienteLBL
            // 
            numeroClienteLBL.AutoSize = true;
            numeroClienteLBL.Location = new Point(13, 6);
            numeroClienteLBL.Name = "numeroClienteLBL";
            numeroClienteLBL.Size = new Size(113, 20);
            numeroClienteLBL.TabIndex = 1;
            numeroClienteLBL.Text = "Número Cliente";
            // 
            // numeroClienteTXT
            // 
            numeroClienteTXT.Location = new Point(13, 29);
            numeroClienteTXT.Name = "numeroClienteTXT";
            numeroClienteTXT.Size = new Size(321, 27);
            numeroClienteTXT.TabIndex = 2;
            // 
            // razonSocialClienteTXT
            // 
            razonSocialClienteTXT.Location = new Point(408, 29);
            razonSocialClienteTXT.Name = "razonSocialClienteTXT";
            razonSocialClienteTXT.Size = new Size(329, 27);
            razonSocialClienteTXT.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(408, 6);
            label3.Name = "label3";
            label3.Size = new Size(144, 20);
            label3.TabIndex = 3;
            label3.Text = "Razón Social Cliente";
            // 
            // limpiarFiltrosBTN
            // 
            limpiarFiltrosBTN.Location = new Point(601, 62);
            limpiarFiltrosBTN.Name = "limpiarFiltrosBTN";
            limpiarFiltrosBTN.Size = new Size(136, 29);
            limpiarFiltrosBTN.TabIndex = 6;
            limpiarFiltrosBTN.Text = "Limpiar Filtros";
            limpiarFiltrosBTN.UseVisualStyleBackColor = true;
            limpiarFiltrosBTN.Click += limpiarFiltrosBTN_Click;
            // 
            // depositoPorClienteLBL
            // 
            depositoPorClienteLBL.AutoSize = true;
            depositoPorClienteLBL.Location = new Point(13, 107);
            depositoPorClienteLBL.Name = "depositoPorClienteLBL";
            depositoPorClienteLBL.Size = new Size(233, 20);
            depositoPorClienteLBL.TabIndex = 7;
            depositoPorClienteLBL.Text = "Productos en depósito por cliente";
            // 
            // productosClienteLST
            // 
            productosClienteLST.Columns.AddRange(new ColumnHeader[] { skuProductoCLM, nombreProductoCLM, cantidadProductoCLM });
            productosClienteLST.FullRowSelect = true;
            productosClienteLST.Location = new Point(13, 137);
            productosClienteLST.Name = "productosClienteLST";
            productosClienteLST.Size = new Size(441, 192);
            productosClienteLST.TabIndex = 11;
            productosClienteLST.UseCompatibleStateImageBehavior = false;
            productosClienteLST.View = View.Details;
            // 
            // skuProductoCLM
            // 
            skuProductoCLM.Text = "SKU Producto";
            skuProductoCLM.Width = 120;
            // 
            // nombreProductoCLM
            // 
            nombreProductoCLM.Text = "Nombre Producto";
            nombreProductoCLM.Width = 150;
            // 
            // cantidadProductoCLM
            // 
            cantidadProductoCLM.Text = "Cantidad";
            cantidadProductoCLM.Width = 80;
            // 
            // productoSeleccionadoLBL
            // 
            productoSeleccionadoLBL.AutoSize = true;
            productoSeleccionadoLBL.Location = new Point(491, 137);
            productoSeleccionadoLBL.Name = "productoSeleccionadoLBL";
            productoSeleccionadoLBL.Size = new Size(162, 20);
            productoSeleccionadoLBL.TabIndex = 12;
            productoSeleccionadoLBL.Text = "Producto Seleccionado";
            // 
            // cantidadDisponibleLBL
            // 
            cantidadDisponibleLBL.AutoSize = true;
            cantidadDisponibleLBL.Location = new Point(491, 199);
            cantidadDisponibleLBL.Name = "cantidadDisponibleLBL";
            cantidadDisponibleLBL.Size = new Size(145, 20);
            cantidadDisponibleLBL.TabIndex = 14;
            cantidadDisponibleLBL.Text = "Cantidad Disponible";
            // 
            // cantidadSeleccionadaTXT
            // 
            cantidadSeleccionadaTXT.Location = new Point(491, 284);
            cantidadSeleccionadaTXT.Name = "cantidadSeleccionadaTXT";
            cantidadSeleccionadaTXT.Size = new Size(246, 27);
            cantidadSeleccionadaTXT.TabIndex = 17;
            // 
            // cantidadSeleccionadaLBL
            // 
            cantidadSeleccionadaLBL.AutoSize = true;
            cantidadSeleccionadaLBL.Location = new Point(491, 261);
            cantidadSeleccionadaLBL.Name = "cantidadSeleccionadaLBL";
            cantidadSeleccionadaLBL.Size = new Size(161, 20);
            cantidadSeleccionadaLBL.TabIndex = 16;
            cantidadSeleccionadaLBL.Text = "Cantidad Seleccionada";
            // 
            // agregarProductoBTN
            // 
            agregarProductoBTN.Location = new Point(491, 335);
            agregarProductoBTN.Name = "agregarProductoBTN";
            agregarProductoBTN.Size = new Size(246, 29);
            agregarProductoBTN.TabIndex = 18;
            agregarProductoBTN.Text = "Agregar Producto a la Orden";
            agregarProductoBTN.UseVisualStyleBackColor = true;
            agregarProductoBTN.Click += agregarProductoBTN_Click;
            // 
            // opLBL
            // 
            opLBL.AutoSize = true;
            opLBL.Location = new Point(13, 379);
            opLBL.Name = "opLBL";
            opLBL.Size = new Size(154, 20);
            opLBL.TabIndex = 19;
            opLBL.Text = "Orden de Preparación";
            // 
            // ordenPreparacionLST
            // 
            ordenPreparacionLST.Columns.AddRange(new ColumnHeader[] { skuProductoLBL, nombreProductoLBL, cantidadSeleccionadaCLM });
            ordenPreparacionLST.FullRowSelect = true;
            ordenPreparacionLST.Location = new Point(13, 420);
            ordenPreparacionLST.Name = "ordenPreparacionLST";
            ordenPreparacionLST.Size = new Size(472, 161);
            ordenPreparacionLST.TabIndex = 23;
            ordenPreparacionLST.UseCompatibleStateImageBehavior = false;
            ordenPreparacionLST.View = View.Details;
            // 
            // skuProductoLBL
            // 
            skuProductoLBL.Text = "SKU Producto";
            skuProductoLBL.Width = 150;
            // 
            // nombreProductoLBL
            // 
            nombreProductoLBL.Text = "Nombre Producto";
            nombreProductoLBL.Width = 150;
            // 
            // cantidadSeleccionadaCLM
            // 
            cantidadSeleccionadaCLM.Text = "Cantidad Seleccionada";
            cantidadSeleccionadaCLM.Width = 205;
            // 
            // fechaRetirarLBL
            // 
            fechaRetirarLBL.AutoSize = true;
            fechaRetirarLBL.Location = new Point(598, 420);
            fechaRetirarLBL.Name = "fechaRetirarLBL";
            fechaRetirarLBL.Size = new Size(107, 20);
            fechaRetirarLBL.TabIndex = 26;
            fechaRetirarLBL.Text = "Fecha a Retirar";
            // 
            // prioridadLBL
            // 
            prioridadLBL.AutoSize = true;
            prioridadLBL.Location = new Point(491, 481);
            prioridadLBL.Name = "prioridadLBL";
            prioridadLBL.Size = new Size(70, 20);
            prioridadLBL.TabIndex = 30;
            prioridadLBL.Text = "Prioridad";
            // 
            // prioridadCMB
            // 
            prioridadCMB.DropDownStyle = ComboBoxStyle.DropDownList;
            prioridadCMB.FormattingEnabled = true;
            prioridadCMB.Location = new Point(491, 504);
            prioridadCMB.Name = "prioridadCMB";
            prioridadCMB.Size = new Size(246, 28);
            prioridadCMB.TabIndex = 31;
            // 
            // cuilTransportistaLBL
            // 
            cuilTransportistaLBL.AutoSize = true;
            cuilTransportistaLBL.Location = new Point(491, 554);
            cuilTransportistaLBL.Name = "cuilTransportistaLBL";
            cuilTransportistaLBL.Size = new Size(128, 20);
            cuilTransportistaLBL.TabIndex = 32;
            cuilTransportistaLBL.Text = "CUIL Transportista";
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(615, 658);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(122, 29);
            cancelarBTN.TabIndex = 36;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.UseVisualStyleBackColor = true;
            cancelarBTN.Click += cancelarBTN_Click;
            // 
            // generarOPBTN
            // 
            generarOPBTN.Location = new Point(375, 635);
            generarOPBTN.Name = "generarOPBTN";
            generarOPBTN.Size = new Size(223, 52);
            generarOPBTN.TabIndex = 37;
            generarOPBTN.Text = "Generar Orden de Preparación";
            generarOPBTN.UseVisualStyleBackColor = true;
            generarOPBTN.Click += generarOPBTN_Click;
            // 
            // cuilTransportistaTXT
            // 
            cuilTransportistaTXT.Location = new Point(491, 577);
            cuilTransportistaTXT.Name = "cuilTransportistaTXT";
            cuilTransportistaTXT.Size = new Size(246, 27);
            cuilTransportistaTXT.TabIndex = 38;
            // 
            // quitarProductoBTN
            // 
            quitarProductoBTN.Location = new Point(12, 587);
            quitarProductoBTN.Name = "quitarProductoBTN";
            quitarProductoBTN.Size = new Size(130, 29);
            quitarProductoBTN.TabIndex = 39;
            quitarProductoBTN.Text = "Quitar Producto";
            quitarProductoBTN.UseVisualStyleBackColor = true;
            quitarProductoBTN.Click += quitarProductoBTN_Click;
            // 
            // fechaRetirarDTP
            // 
            fechaRetirarDTP.Format = DateTimePickerFormat.Short;
            fechaRetirarDTP.Location = new Point(601, 443);
            fechaRetirarDTP.MinDate = new DateTime(2025, 5, 15, 15, 55, 33, 0);
            fechaRetirarDTP.Name = "fechaRetirarDTP";
            fechaRetirarDTP.Size = new Size(140, 27);
            fechaRetirarDTP.TabIndex = 40;
            fechaRetirarDTP.Value = new DateTime(2025, 5, 15, 15, 55, 33, 0);
            // 
            // productoSeleccionadoLABEL
            // 
            productoSeleccionadoLABEL.AutoSize = true;
            productoSeleccionadoLABEL.Location = new Point(491, 168);
            productoSeleccionadoLABEL.Name = "productoSeleccionadoLABEL";
            productoSeleccionadoLABEL.Size = new Size(50, 20);
            productoSeleccionadoLABEL.TabIndex = 41;
            productoSeleccionadoLABEL.Text = "label1";
            // 
            // cantidadDisponibleLABEL
            // 
            cantidadDisponibleLABEL.AutoSize = true;
            cantidadDisponibleLABEL.Location = new Point(491, 230);
            cantidadDisponibleLABEL.Name = "cantidadDisponibleLABEL";
            cantidadDisponibleLABEL.Size = new Size(50, 20);
            cantidadDisponibleLABEL.TabIndex = 42;
            cantidadDisponibleLABEL.Text = "label2";
            // 
            // buscarProductosBTN
            // 
            buscarProductosBTN.Location = new Point(444, 62);
            buscarProductosBTN.Name = "buscarProductosBTN";
            buscarProductosBTN.Size = new Size(141, 29);
            buscarProductosBTN.TabIndex = 43;
            buscarProductosBTN.Text = "Buscar Productos";
            buscarProductosBTN.UseVisualStyleBackColor = true;
            buscarProductosBTN.Click += buscarProductosBTN_Click;
            // 
            // palletCBX
            // 
            palletCBX.AutoSize = true;
            palletCBX.Location = new Point(494, 433);
            palletCBX.Name = "palletCBX";
            palletCBX.Size = new Size(67, 24);
            palletCBX.TabIndex = 44;
            palletCBX.Text = "Pallet";
            palletCBX.UseVisualStyleBackColor = true;
            // 
            // OrdenDePreparacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 712);
            Controls.Add(palletCBX);
            Controls.Add(buscarProductosBTN);
            Controls.Add(cantidadDisponibleLABEL);
            Controls.Add(productoSeleccionadoLABEL);
            Controls.Add(fechaRetirarDTP);
            Controls.Add(quitarProductoBTN);
            Controls.Add(cuilTransportistaTXT);
            Controls.Add(generarOPBTN);
            Controls.Add(cancelarBTN);
            Controls.Add(cuilTransportistaLBL);
            Controls.Add(prioridadCMB);
            Controls.Add(prioridadLBL);
            Controls.Add(fechaRetirarLBL);
            Controls.Add(ordenPreparacionLST);
            Controls.Add(opLBL);
            Controls.Add(agregarProductoBTN);
            Controls.Add(cantidadSeleccionadaTXT);
            Controls.Add(cantidadSeleccionadaLBL);
            Controls.Add(cantidadDisponibleLBL);
            Controls.Add(productoSeleccionadoLBL);
            Controls.Add(productosClienteLST);
            Controls.Add(depositoPorClienteLBL);
            Controls.Add(limpiarFiltrosBTN);
            Controls.Add(razonSocialClienteTXT);
            Controls.Add(label3);
            Controls.Add(numeroClienteTXT);
            Controls.Add(numeroClienteLBL);
            Name = "OrdenDePreparacion";
            Text = "OrdenDePreparacion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label numeroClienteLBL;
        private TextBox numeroClienteTXT;
        private TextBox razonSocialClienteTXT;
        private Label label3;
        private Button limpiarFiltrosBTN;
        private Label depositoPorClienteLBL;
        private ListView productosClienteLST;
        private Label productoSeleccionadoLBL;
        private Label cantidadDisponibleLBL;
        private TextBox cantidadSeleccionadaTXT;
        private Label cantidadSeleccionadaLBL;
        private Button agregarProductoBTN;
        private Label opLBL;
        private Label label12;
        private ListView ordenPreparacionLST;
        private Label label14;
        private Label fechaRetirarLBL;
        private Label prioridadLBL;
        private ComboBox prioridadCMB;
        private Label cuilTransportistaLBL;
        private Button cancelarBTN;
        private Button generarOPBTN;
        private ColumnHeader skuProductoCLM;
        private ColumnHeader nombreProductoCLM;
        private ColumnHeader cantidadProductoCLM;
        private ColumnHeader nombreProductoLBL;
        private ColumnHeader cantidadSeleccionadaCLM;
        private TextBox cuilTransportistaTXT;
        private Button quitarProductoBTN;
        private DateTimePicker fechaRetirarDTP;
        private Label productoSeleccionadoLABEL;
        private Label cantidadDisponibleLABEL;
        private Button buscarProductosBTN;
        private CheckBox palletCBX;
        private ColumnHeader skuProductoLBL;
    }
}