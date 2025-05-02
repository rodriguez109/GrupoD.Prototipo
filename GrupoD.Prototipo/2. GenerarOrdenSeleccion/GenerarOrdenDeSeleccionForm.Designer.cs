namespace GrupoD.Prototipo.CDU2._GenerarOrdenSeleccion
{
    partial class GenerarOrdenDeSeleccionForm
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
            label1 = new Label();
            IDOrdenSeleccionTXT = new TextBox();
            groupBox1 = new GroupBox();
            FechaEntregaDTP = new DateTimePicker();
            ReiniciarBusquedaBTN = new Button();
            BuscarOrdenesPendientesBTN = new Button();
            PrioridadCMB = new ComboBox();
            label5 = new Label();
            NumeroOrdenPreparacionTXT = new TextBox();
            label4 = new Label();
            NombreClienteTXT = new TextBox();
            label3 = new Label();
            label2 = new Label();
            AgregarOrdenesSeleccionadasBTN = new Button();
            groupBox2 = new GroupBox();
            OrdenesPreparacionPendientesLST = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            groupBox3 = new GroupBox();
            OrdenesPreparacionPendientesSeleccionadasLST = new ListView();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            QuitarOrdenesSeleccionadasBTN = new Button();
            GenerarOrdenSeleccionBTN = new Button();
            CancelarOrdenSeleccionBTN = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 9);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 0;
            label1.Text = "Orden de Selección N°";
            // 
            // IDOrdenSeleccionTXT
            // 
            IDOrdenSeleccionTXT.Location = new Point(157, 6);
            IDOrdenSeleccionTXT.Name = "IDOrdenSeleccionTXT";
            IDOrdenSeleccionTXT.Size = new Size(100, 23);
            IDOrdenSeleccionTXT.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(FechaEntregaDTP);
            groupBox1.Controls.Add(ReiniciarBusquedaBTN);
            groupBox1.Controls.Add(BuscarOrdenesPendientesBTN);
            groupBox1.Controls.Add(PrioridadCMB);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(NumeroOrdenPreparacionTXT);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(NombreClienteTXT);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(25, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1169, 126);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtrar por:";
            // 
            // FechaEntregaDTP
            // 
            FechaEntregaDTP.Location = new Point(683, 28);
            FechaEntregaDTP.Name = "FechaEntregaDTP";
            FechaEntregaDTP.Size = new Size(200, 23);
            FechaEntregaDTP.TabIndex = 8;
            // 
            // ReiniciarBusquedaBTN
            // 
            ReiniciarBusquedaBTN.Location = new Point(928, 79);
            ReiniciarBusquedaBTN.Name = "ReiniciarBusquedaBTN";
            ReiniciarBusquedaBTN.Size = new Size(176, 41);
            ReiniciarBusquedaBTN.TabIndex = 7;
            ReiniciarBusquedaBTN.Text = "Reiniciar busqueda";
            ReiniciarBusquedaBTN.UseVisualStyleBackColor = true;
            ReiniciarBusquedaBTN.Click += ReiniciarBusquedaBTN_Click;
            // 
            // BuscarOrdenesPendientesBTN
            // 
            BuscarOrdenesPendientesBTN.Location = new Point(928, 13);
            BuscarOrdenesPendientesBTN.Name = "BuscarOrdenesPendientesBTN";
            BuscarOrdenesPendientesBTN.Size = new Size(176, 56);
            BuscarOrdenesPendientesBTN.TabIndex = 3;
            BuscarOrdenesPendientesBTN.Text = "Buscar ordenes de preparación pendientes";
            BuscarOrdenesPendientesBTN.UseVisualStyleBackColor = true;
            BuscarOrdenesPendientesBTN.Click += BuscarOrdenesPendientesBTN_Click;
            // 
            // PrioridadCMB
            // 
            PrioridadCMB.FormattingEnabled = true;
            PrioridadCMB.Location = new Point(683, 75);
            PrioridadCMB.Name = "PrioridadCMB";
            PrioridadCMB.Size = new Size(200, 23);
            PrioridadCMB.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(556, 75);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 4;
            label5.Text = "Prioridad";
            // 
            // NumeroOrdenPreparacionTXT
            // 
            NumeroOrdenPreparacionTXT.Location = new Point(310, 66);
            NumeroOrdenPreparacionTXT.Name = "NumeroOrdenPreparacionTXT";
            NumeroOrdenPreparacionTXT.Size = new Size(190, 23);
            NumeroOrdenPreparacionTXT.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(556, 34);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 3;
            label4.Text = "Fecha de entrega";
            // 
            // NombreClienteTXT
            // 
            NombreClienteTXT.Location = new Point(310, 22);
            NombreClienteTXT.Name = "NombreClienteTXT";
            NombreClienteTXT.Size = new Size(190, 23);
            NombreClienteTXT.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 69);
            label3.Name = "label3";
            label3.Size = new Size(183, 15);
            label3.TabIndex = 1;
            label3.Text = "Numero de orden de preparacion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 28);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 0;
            label2.Text = "Nombre de cliente";
            // 
            // AgregarOrdenesSeleccionadasBTN
            // 
            AgregarOrdenesSeleccionadasBTN.Location = new Point(445, 163);
            AgregarOrdenesSeleccionadasBTN.Name = "AgregarOrdenesSeleccionadasBTN";
            AgregarOrdenesSeleccionadasBTN.Size = new Size(278, 23);
            AgregarOrdenesSeleccionadasBTN.TabIndex = 6;
            AgregarOrdenesSeleccionadasBTN.Text = "Agregar las ordenes seleccionadas";
            AgregarOrdenesSeleccionadasBTN.UseVisualStyleBackColor = true;
            AgregarOrdenesSeleccionadasBTN.Click += AgregarOrdenesSeleccionadasBTN_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(OrdenesPreparacionPendientesLST);
            groupBox2.Controls.Add(AgregarOrdenesSeleccionadasBTN);
            groupBox2.Location = new Point(25, 171);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1189, 200);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lista de Órdenes de Preparación Pendientes:";
            // 
            // OrdenesPreparacionPendientesLST
            // 
            OrdenesPreparacionPendientesLST.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            OrdenesPreparacionPendientesLST.FullRowSelect = true;
            OrdenesPreparacionPendientesLST.Location = new Point(6, 22);
            OrdenesPreparacionPendientesLST.Name = "OrdenesPreparacionPendientesLST";
            OrdenesPreparacionPendientesLST.Size = new Size(1169, 135);
            OrdenesPreparacionPendientesLST.TabIndex = 8;
            OrdenesPreparacionPendientesLST.UseCompatibleStateImageBehavior = false;
            OrdenesPreparacionPendientesLST.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nº Orden";
            columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Cliente";
            columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Fecha de entrega";
            columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Transportista";
            columnHeader4.Width = 180;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Prioridad";
            columnHeader5.Width = 180;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(OrdenesPreparacionPendientesSeleccionadasLST);
            groupBox3.Controls.Add(QuitarOrdenesSeleccionadasBTN);
            groupBox3.Location = new Point(25, 377);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1189, 200);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Detalle de Ordenes a Seleccionar:";
            // 
            // OrdenesPreparacionPendientesSeleccionadasLST
            // 
            OrdenesPreparacionPendientesSeleccionadasLST.Columns.AddRange(new ColumnHeader[] { columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            OrdenesPreparacionPendientesSeleccionadasLST.FullRowSelect = true;
            OrdenesPreparacionPendientesSeleccionadasLST.Location = new Point(6, 22);
            OrdenesPreparacionPendientesSeleccionadasLST.Name = "OrdenesPreparacionPendientesSeleccionadasLST";
            OrdenesPreparacionPendientesSeleccionadasLST.Size = new Size(1169, 135);
            OrdenesPreparacionPendientesSeleccionadasLST.TabIndex = 14;
            OrdenesPreparacionPendientesSeleccionadasLST.UseCompatibleStateImageBehavior = false;
            OrdenesPreparacionPendientesSeleccionadasLST.View = View.Details;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Nº Orden";
            columnHeader6.Width = 180;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Cliente";
            columnHeader7.Width = 180;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Fecha de entrega";
            columnHeader8.Width = 180;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Transportista";
            columnHeader9.Width = 180;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Prioridad";
            columnHeader10.Width = 180;
            // 
            // QuitarOrdenesSeleccionadasBTN
            // 
            QuitarOrdenesSeleccionadasBTN.Location = new Point(445, 163);
            QuitarOrdenesSeleccionadasBTN.Name = "QuitarOrdenesSeleccionadasBTN";
            QuitarOrdenesSeleccionadasBTN.Size = new Size(278, 23);
            QuitarOrdenesSeleccionadasBTN.TabIndex = 6;
            QuitarOrdenesSeleccionadasBTN.Text = "Quitar las ordenes seleccionadas";
            QuitarOrdenesSeleccionadasBTN.UseVisualStyleBackColor = true;
            QuitarOrdenesSeleccionadasBTN.Click += QuitarOrdenesSeleccionadasBTN_Click;
            // 
            // GenerarOrdenSeleccionBTN
            // 
            GenerarOrdenSeleccionBTN.Location = new Point(282, 595);
            GenerarOrdenSeleccionBTN.Name = "GenerarOrdenSeleccionBTN";
            GenerarOrdenSeleccionBTN.Size = new Size(302, 23);
            GenerarOrdenSeleccionBTN.TabIndex = 12;
            GenerarOrdenSeleccionBTN.Text = "Generar orden de seleccion";
            GenerarOrdenSeleccionBTN.UseVisualStyleBackColor = true;
            GenerarOrdenSeleccionBTN.Click += GenerarOrdenSeleccionBTN_Click;
            // 
            // CancelarOrdenSeleccionBTN
            // 
            CancelarOrdenSeleccionBTN.Location = new Point(656, 595);
            CancelarOrdenSeleccionBTN.Name = "CancelarOrdenSeleccionBTN";
            CancelarOrdenSeleccionBTN.Size = new Size(278, 23);
            CancelarOrdenSeleccionBTN.TabIndex = 13;
            CancelarOrdenSeleccionBTN.Text = "Cancelar";
            CancelarOrdenSeleccionBTN.UseVisualStyleBackColor = true;
            CancelarOrdenSeleccionBTN.Click += CancelarOrdenSeleccionBTN_Click;
            // 
            // GenerarOrdenDeSeleccionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1226, 639);
            Controls.Add(CancelarOrdenSeleccionBTN);
            Controls.Add(GenerarOrdenSeleccionBTN);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(IDOrdenSeleccionTXT);
            Controls.Add(label1);
            Name = "GenerarOrdenDeSeleccionForm";
            Text = "Generar orden de selección";
            Load += GenerarOrdenDeSeleccionForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox IDOrdenSeleccionTXT;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Button ReiniciarBusquedaBTN;
        private Button BuscarOrdenesPendientesBTN;
        private ComboBox PrioridadCMB;
        private Label label5;
        private TextBox NumeroOrdenPreparacionTXT;
        private Label label4;
        private TextBox NombreClienteTXT;
        private Button AgregarOrdenesSeleccionadasBTN;
        private GroupBox groupBox2;
        private ListView OrdenesPreparacionPendientesLST;
        private GroupBox groupBox3;
        private Button QuitarOrdenesSeleccionadasBTN;
        private Button GenerarOrdenSeleccionBTN;
        private Button CancelarOrdenSeleccionBTN;
        private DateTimePicker FechaEntregaDTP;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ListView OrdenesPreparacionPendientesSeleccionadasLST;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
    }
}