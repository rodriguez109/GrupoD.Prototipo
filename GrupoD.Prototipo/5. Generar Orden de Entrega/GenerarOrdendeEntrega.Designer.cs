namespace GrupoD.Prototipo
{
    partial class GenerarOrdendeEntrega
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
        /// 
        private void GenerarOrdendeEntrega_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Formulario cargado correctamente.");
        }

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            listView1LST = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            buttonBTN = new Button();
            button2BTN = new Button();
            Fecha = new ColumnHeader();
            Transportista = new ColumnHeader();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ActiveCaptionText;
            groupBox1.Location = new Point(18, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(287, 35);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Órdenes Preparadas hacia Despacho";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // listView1LST
            // 
            listView1LST.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, Fecha, Transportista });
            listView1LST.Location = new Point(18, 53);
            listView1LST.Name = "listView1LST";
            listView1LST.Size = new Size(757, 310);
            listView1LST.TabIndex = 1;
            listView1LST.UseCompatibleStateImageBehavior = false;
            listView1LST.View = View.Details;
            listView1LST.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Código de órden Preparada";
            columnHeader1.Width = 230;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Cliente";
            columnHeader2.Width = 200;
            // 
            // buttonBTN
            // 
            buttonBTN.Location = new Point(420, 390);
            buttonBTN.Name = "buttonBTN";
            buttonBTN.Size = new Size(232, 29);
            buttonBTN.TabIndex = 2;
            buttonBTN.Text = "Confirmar Orden de Entrega";
            buttonBTN.UseVisualStyleBackColor = true;
            // 
            // button2BTN
            // 
            button2BTN.Location = new Point(674, 390);
            button2BTN.Name = "button2BTN";
            button2BTN.Size = new Size(101, 29);
            button2BTN.TabIndex = 3;
            button2BTN.Text = "Cancelar";
            button2BTN.UseVisualStyleBackColor = true;
            // 
            // Fecha
            // 
            Fecha.Text = "Fecha de Entrega";
            Fecha.Width = 150;
            // 
            // Transportista
            // 
            Transportista.Text = "Transportista";
            Transportista.Width = 150;
            // 
            // GenerarOrdendeEntrega
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2BTN);
            Controls.Add(buttonBTN);
            Controls.Add(listView1LST);
            Controls.Add(groupBox1);
            Name = "GenerarOrdendeEntrega";
            Text = "Generar Orden de Entrega";
            Load += this.GenerarOrdendeEntrega_Load;
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView listView1LST;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button buttonBTN;
        private Button button2BTN;
        private ColumnHeader Fecha;
        private ColumnHeader Transportista;
    }
}