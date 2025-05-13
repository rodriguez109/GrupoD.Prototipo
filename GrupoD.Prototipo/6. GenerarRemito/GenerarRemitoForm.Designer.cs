namespace GrupoD.Prototipo._6._GenerarRemito
{
    partial class GenerarRemitoForm
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
            DniTransportistaTXT = new TextBox();
            OrdenesDeEntregaLST = new ListView();
            columnHeader1 = new ColumnHeader();
            AgregarAlRemitoBTN = new Button();
            CancelarBTN = new Button();
            BuscarOrdenesBTN = new Button();
            OrdenesAgregadasLST = new ListView();
            columnHeader2 = new ColumnHeader();
            QuitarDelRemitoBTN = new Button();
            GenerarRemitoBTN = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 33);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 0;
            label1.Text = "DNI Transportista";
            // 
            // DniTransportistaTXT
            // 
            DniTransportistaTXT.Location = new Point(11, 56);
            DniTransportistaTXT.Name = "DniTransportistaTXT";
            DniTransportistaTXT.Size = new Size(383, 27);
            DniTransportistaTXT.TabIndex = 1;
            // 
            // OrdenesDeEntregaLST
            // 
            OrdenesDeEntregaLST.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            OrdenesDeEntregaLST.FullRowSelect = true;
            OrdenesDeEntregaLST.Location = new Point(11, 112);
            OrdenesDeEntregaLST.Name = "OrdenesDeEntregaLST";
            OrdenesDeEntregaLST.Size = new Size(758, 229);
            OrdenesDeEntregaLST.TabIndex = 2;
            OrdenesDeEntregaLST.UseCompatibleStateImageBehavior = false;
            OrdenesDeEntregaLST.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nro Orden de entrega";
            columnHeader1.Width = 200;
            // 
            // AgregarAlRemitoBTN
            // 
            AgregarAlRemitoBTN.Location = new Point(571, 356);
            AgregarAlRemitoBTN.Name = "AgregarAlRemitoBTN";
            AgregarAlRemitoBTN.Size = new Size(157, 29);
            AgregarAlRemitoBTN.TabIndex = 3;
            AgregarAlRemitoBTN.Text = "Agregar al remito";
            AgregarAlRemitoBTN.UseVisualStyleBackColor = true;
            AgregarAlRemitoBTN.Click += AgregarAlRemitoBTN_Click;
            // 
            // CancelarBTN
            // 
            CancelarBTN.Location = new Point(614, 841);
            CancelarBTN.Name = "CancelarBTN";
            CancelarBTN.Size = new Size(155, 29);
            CancelarBTN.TabIndex = 4;
            CancelarBTN.Text = "Cancelar";
            CancelarBTN.UseVisualStyleBackColor = true;
            CancelarBTN.Click += CancelarBTN_Click;
            // 
            // BuscarOrdenesBTN
            // 
            BuscarOrdenesBTN.Location = new Point(447, 53);
            BuscarOrdenesBTN.Name = "BuscarOrdenesBTN";
            BuscarOrdenesBTN.Size = new Size(152, 29);
            BuscarOrdenesBTN.TabIndex = 5;
            BuscarOrdenesBTN.Text = "Buscar órdenes";
            BuscarOrdenesBTN.UseVisualStyleBackColor = true;
            BuscarOrdenesBTN.Click += BuscarOrdenesBTN_Click;
            // 
            // OrdenesAgregadasLST
            // 
            OrdenesAgregadasLST.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            OrdenesAgregadasLST.FullRowSelect = true;
            OrdenesAgregadasLST.Location = new Point(11, 457);
            OrdenesAgregadasLST.Name = "OrdenesAgregadasLST";
            OrdenesAgregadasLST.Size = new Size(758, 263);
            OrdenesAgregadasLST.TabIndex = 6;
            OrdenesAgregadasLST.UseCompatibleStateImageBehavior = false;
            OrdenesAgregadasLST.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Nro Orden de entrega";
            columnHeader2.Width = 200;
            // 
            // QuitarDelRemitoBTN
            // 
            QuitarDelRemitoBTN.Location = new Point(571, 739);
            QuitarDelRemitoBTN.Name = "QuitarDelRemitoBTN";
            QuitarDelRemitoBTN.Size = new Size(157, 29);
            QuitarDelRemitoBTN.TabIndex = 7;
            QuitarDelRemitoBTN.Text = "Quitar del remito";
            QuitarDelRemitoBTN.UseVisualStyleBackColor = true;
            QuitarDelRemitoBTN.Click += QuitarDelRemitoBTN_Click;
            // 
            // GenerarRemitoBTN
            // 
            GenerarRemitoBTN.Location = new Point(423, 841);
            GenerarRemitoBTN.Name = "GenerarRemitoBTN";
            GenerarRemitoBTN.Size = new Size(176, 29);
            GenerarRemitoBTN.TabIndex = 8;
            GenerarRemitoBTN.Text = "Generar remito";
            GenerarRemitoBTN.UseVisualStyleBackColor = true;
            GenerarRemitoBTN.Click += GenerarRemitoBTN_Click;
            // 
            // GenerarRemitoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 887);
            Controls.Add(GenerarRemitoBTN);
            Controls.Add(QuitarDelRemitoBTN);
            Controls.Add(OrdenesAgregadasLST);
            Controls.Add(BuscarOrdenesBTN);
            Controls.Add(CancelarBTN);
            Controls.Add(AgregarAlRemitoBTN);
            Controls.Add(OrdenesDeEntregaLST);
            Controls.Add(DniTransportistaTXT);
            Controls.Add(label1);
            Name = "GenerarRemitoForm";
            Text = "GenerarRemitoForm";
            Load += GenerarRemitoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox DniTransportistaTXT;
        private ListView OrdenesDeEntregaLST;
        private ColumnHeader columnHeader1;
        private Button AgregarAlRemitoBTN;
        private Button CancelarBTN;
        private Button BuscarOrdenesBTN;
        private ListView OrdenesAgregadasLST;
        private Button QuitarDelRemitoBTN;
        private Button GenerarRemitoBTN;
        private ColumnHeader columnHeader2;
    }
}