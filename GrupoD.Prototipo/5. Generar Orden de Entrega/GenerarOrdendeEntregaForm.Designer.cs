namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    partial class GenerarOrdendeEntregaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            OrdenesPreparacionEstadoPreparadasLST = new ListView();
            columnHeader0 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            GenerarOrdenEntregaBTN = new Button();
            CancelarOrdenEntregaBTN = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(OrdenesPreparacionEstadoPreparadasLST);
            groupBox1.Font = new Font("Segoe UI", 9F);
            groupBox1.ForeColor = SystemColors.ActiveCaptionText;
            groupBox1.Location = new Point(18, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(976, 470);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = " Ordenes Preparadas hacia Despacho";
            // 
            // OrdenesPreparacionEstadoPreparadasLST
            // 
            OrdenesPreparacionEstadoPreparadasLST.Columns.AddRange(new ColumnHeader[] { columnHeader0, columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            OrdenesPreparacionEstadoPreparadasLST.FullRowSelect = true;
            OrdenesPreparacionEstadoPreparadasLST.Location = new Point(10, 25);
            OrdenesPreparacionEstadoPreparadasLST.Name = "OrdenesPreparacionEstadoPreparadasLST";
            OrdenesPreparacionEstadoPreparadasLST.Size = new Size(958, 426);
            OrdenesPreparacionEstadoPreparadasLST.TabIndex = 1;
            OrdenesPreparacionEstadoPreparadasLST.UseCompatibleStateImageBehavior = false;
            OrdenesPreparacionEstadoPreparadasLST.View = View.Details;
            // 
            // columnHeader0
            // 
            columnHeader0.Text = "Numero de Orden";
            columnHeader0.Width = 150;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Razón Social Cliente";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Fecha de Entrega";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "DNI transportista";
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Razón Social Transportista";
            columnHeader4.Width = 200;
            // 
            // GenerarOrdenEntregaBTN
            // 
            GenerarOrdenEntregaBTN.Location = new Point(521, 482);
            GenerarOrdenEntregaBTN.Name = "GenerarOrdenEntregaBTN";
            GenerarOrdenEntregaBTN.Size = new Size(241, 30);
            GenerarOrdenEntregaBTN.TabIndex = 2;
            GenerarOrdenEntregaBTN.Text = "Generar orden de Entrega";
            GenerarOrdenEntregaBTN.UseVisualStyleBackColor = true;
            GenerarOrdenEntregaBTN.Click += GenerarOrdenEntregaBTN_Click;
            // 
            // CancelarOrdenEntregaBTN
            // 
            CancelarOrdenEntregaBTN.Location = new Point(768, 482);
            CancelarOrdenEntregaBTN.Name = "CancelarOrdenEntregaBTN";
            CancelarOrdenEntregaBTN.Size = new Size(220, 30);
            CancelarOrdenEntregaBTN.TabIndex = 3;
            CancelarOrdenEntregaBTN.Text = "Cancelar";
            CancelarOrdenEntregaBTN.UseVisualStyleBackColor = true;
            CancelarOrdenEntregaBTN.Click += CancelarOrdenEntregaBTN_Click;
            // 
            // GenerarOrdendeEntregaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1009, 533);
            Controls.Add(CancelarOrdenEntregaBTN);
            Controls.Add(GenerarOrdenEntregaBTN);
            Controls.Add(groupBox1);
            Name = "GenerarOrdendeEntregaForm";
            Text = "Generar Orden de Entrega";
            Load += GenerarOrdendeEntregaForm_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView OrdenesPreparacionEstadoPreparadasLST;
        private ColumnHeader columnHeader0;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button GenerarOrdenEntregaBTN;
        private Button CancelarOrdenEntregaBTN;
        private ColumnHeader columnHeader4;
    }
}
