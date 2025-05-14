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
            listView1LST = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            Fecha = new ColumnHeader();
            Transportista = new ColumnHeader();
            buttonBTN = new Button();
            button2BTN = new Button();
            columnHeader3 = new ColumnHeader();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listView1LST);
            groupBox1.Font = new Font("Segoe UI", 9F);
            groupBox1.ForeColor = SystemColors.ActiveCaptionText;
            groupBox1.Location = new Point(18, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1074, 470);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordenes Preparadas hacia Despacho";
            // 
            // listView1LST
            // 
            listView1LST.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, Fecha, Transportista, columnHeader3 });
            listView1LST.FullRowSelect = true;
            listView1LST.Location = new Point(10, 25);
            listView1LST.Name = "listView1LST";
            listView1LST.Size = new Size(1044, 426);
            listView1LST.TabIndex = 1;
            listView1LST.UseCompatibleStateImageBehavior = false;
            listView1LST.View = View.Details;
            listView1LST.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Fecha de Entrega";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "ID orden empaquetada";
            columnHeader2.Width = 200;
            // 
            // Fecha
            // 
            Fecha.Text = "Cliente Razón Social";
            Fecha.Width = 235;
            // 
            // Transportista
            // 
            Transportista.Text = "Transportista Razón Social";
            Transportista.Width = 230;
            // 
            // buttonBTN
            // 
            buttonBTN.Location = new Point(729, 508);
            buttonBTN.Name = "buttonBTN";
            buttonBTN.Size = new Size(232, 29);
            buttonBTN.TabIndex = 2;
            buttonBTN.Text = "Confirmar Orden de Entrega";
            buttonBTN.UseVisualStyleBackColor = true;
            buttonBTN.Click += buttonBTN_Click;
            // 
            // button2BTN
            // 
            button2BTN.Location = new Point(991, 508);
            button2BTN.Name = "button2BTN";
            button2BTN.Size = new Size(101, 29);
            button2BTN.TabIndex = 3;
            button2BTN.Text = "Cancelar";
            button2BTN.UseVisualStyleBackColor = true;
            button2BTN.Click += button2BTN_Click;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Transportista Cuil";
            columnHeader3.Width = 220;
            // 
            // GenerarOrdendeEntregaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 554);
            Controls.Add(button2BTN);
            Controls.Add(buttonBTN);
            Controls.Add(groupBox1);
            Name = "GenerarOrdendeEntregaForm";
            Text = "Generar Orden de Entrega";
            Load += GenerarOrdendeEntrega_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView listView1LST;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader Fecha;
        private ColumnHeader Transportista;
        private Button buttonBTN;
        private Button button2BTN;
        private ColumnHeader columnHeader3;
    }
}
