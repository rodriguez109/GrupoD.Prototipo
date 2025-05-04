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
            label1.Location = new Point(18, 25);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "CUIL Transportista";
            // 
            // CuilTransportistaTXT
            // 
            CuilTransportistaTXT.Location = new Point(10, 42);
            CuilTransportistaTXT.Margin = new Padding(3, 2, 3, 2);
            CuilTransportistaTXT.Name = "CuilTransportistaTXT";
            CuilTransportistaTXT.Size = new Size(336, 23);
            CuilTransportistaTXT.TabIndex = 1;
            CuilTransportistaTXT.TextChanged += CuilTransportistaTXT_TextChanged;
            // 
            // OrdenesDeEntregaLST
            // 
            OrdenesDeEntregaLST.CheckBoxes = true;
            OrdenesDeEntregaLST.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            OrdenesDeEntregaLST.Location = new Point(10, 84);
            OrdenesDeEntregaLST.Margin = new Padding(3, 2, 3, 2);
            OrdenesDeEntregaLST.Name = "OrdenesDeEntregaLST";
            OrdenesDeEntregaLST.Size = new Size(664, 173);
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
            AgregarAlRemitoBTN.Location = new Point(349, 274);
            AgregarAlRemitoBTN.Margin = new Padding(3, 2, 3, 2);
            AgregarAlRemitoBTN.Name = "AgregarAlRemitoBTN";
            AgregarAlRemitoBTN.Size = new Size(137, 22);
            AgregarAlRemitoBTN.TabIndex = 3;
            AgregarAlRemitoBTN.Text = "Agregar al remito";
            AgregarAlRemitoBTN.UseVisualStyleBackColor = true;
            AgregarAlRemitoBTN.Click += AgregarAlRemitoBTN_Click;
            // 
            // CancelarBTN
            // 
            CancelarBTN.Location = new Point(504, 274);
            CancelarBTN.Margin = new Padding(3, 2, 3, 2);
            CancelarBTN.Name = "CancelarBTN";
            CancelarBTN.Size = new Size(136, 22);
            CancelarBTN.TabIndex = 4;
            CancelarBTN.Text = "Cancelar";
            CancelarBTN.UseVisualStyleBackColor = true;
            CancelarBTN.Click += CancelarBTN_Click;
            // 
            // BuscarOrdenesBTN
            // 
            BuscarOrdenesBTN.Location = new Point(391, 40);
            BuscarOrdenesBTN.Margin = new Padding(3, 2, 3, 2);
            BuscarOrdenesBTN.Name = "BuscarOrdenesBTN";
            BuscarOrdenesBTN.Size = new Size(133, 22);
            BuscarOrdenesBTN.TabIndex = 5;
            BuscarOrdenesBTN.Text = "Buscar Ordenes";
            BuscarOrdenesBTN.UseVisualStyleBackColor = true;
            BuscarOrdenesBTN.Click += BuscarOrdenesBTN_Click;
            // 
            // GenerarRemitoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 313);
            Controls.Add(BuscarOrdenesBTN);
            Controls.Add(CancelarBTN);
            Controls.Add(AgregarAlRemitoBTN);
            Controls.Add(OrdenesDeEntregaLST);
            Controls.Add(CuilTransportistaTXT);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
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