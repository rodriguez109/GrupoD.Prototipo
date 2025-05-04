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
            CuilTransportistaTXT = new TextBox();
            OrdenesDeEntregaLST = new ListView();
            columnHeader1 = new ColumnHeader();
            AgregarAlRemitoBTN = new Button();
            CancelarBTN = new Button();
            BuscarOrdenesBTN = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 33);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 0;
            label1.Text = "CUIL Transportista";
            // 
            // CuilTransportistaTXT
            // 
            CuilTransportistaTXT.Location = new Point(12, 56);
            CuilTransportistaTXT.Name = "CuilTransportistaTXT";
            CuilTransportistaTXT.Size = new Size(384, 27);
            CuilTransportistaTXT.TabIndex = 1;
            // 
            // OrdenesDeEntregaLST
            // 
            OrdenesDeEntregaLST.CheckBoxes = true;
            OrdenesDeEntregaLST.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            OrdenesDeEntregaLST.Location = new Point(12, 112);
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
            AgregarAlRemitoBTN.Location = new Point(399, 366);
            AgregarAlRemitoBTN.Name = "AgregarAlRemitoBTN";
            AgregarAlRemitoBTN.Size = new Size(157, 29);
            AgregarAlRemitoBTN.TabIndex = 3;
            AgregarAlRemitoBTN.Text = "Agregar al remito";
            AgregarAlRemitoBTN.UseVisualStyleBackColor = true;
            AgregarAlRemitoBTN.Click += AgregarAlRemitoBTN_Click;
            // 
            // CancelarBTN
            // 
            CancelarBTN.Location = new Point(576, 366);
            CancelarBTN.Name = "CancelarBTN";
            CancelarBTN.Size = new Size(155, 29);
            CancelarBTN.TabIndex = 4;
            CancelarBTN.Text = "Cancelar";
            CancelarBTN.UseVisualStyleBackColor = true;
            CancelarBTN.Click += CancelarBTN_Click;
            // 
            // BuscarOrdenesBTN
            // 
            BuscarOrdenesBTN.Location = new Point(447, 54);
            BuscarOrdenesBTN.Name = "BuscarOrdenesBTN";
            BuscarOrdenesBTN.Size = new Size(152, 29);
            BuscarOrdenesBTN.TabIndex = 5;
            BuscarOrdenesBTN.Text = "Buscar Ordenes";
            BuscarOrdenesBTN.UseVisualStyleBackColor = true;
            BuscarOrdenesBTN.Click += BuscarOrdenesBTN_Click;
            // 
            // GenerarRemitoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 417);
            Controls.Add(BuscarOrdenesBTN);
            Controls.Add(CancelarBTN);
            Controls.Add(AgregarAlRemitoBTN);
            Controls.Add(OrdenesDeEntregaLST);
            Controls.Add(CuilTransportistaTXT);
            Controls.Add(label1);
            Name = "GenerarRemitoForm";
            Text = "GenerarRemitoForm";
            Load += GenerarRemitoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox CuilTransportistaTXT;
        private ListView OrdenesDeEntregaLST;
        private ColumnHeader columnHeader1;
        private Button AgregarAlRemitoBTN;
        private Button CancelarBTN;
        private Button BuscarOrdenesBTN;
    }
}