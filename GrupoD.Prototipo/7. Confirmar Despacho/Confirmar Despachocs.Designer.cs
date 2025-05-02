namespace GrupoD.Prototipo._7._Confirmar_Despacho
{
    partial class Confirmar_Despachocs
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
            groupBox1 = new GroupBox();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            Fecha = new ColumnHeader();
            Transportista = new ColumnHeader();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ActiveCaptionText;
            groupBox1.Location = new Point(22, 29);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(297, 35);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordenes a Despachar";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, Fecha, Transportista });
            listView1.Location = new Point(22, 70);
            listView1.Name = "listView1";
            listView1.Size = new Size(757, 310);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Fecha de Entrega";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Razón Social Cliente";
            columnHeader2.Width = 200;
            // 
            // Fecha
            // 
            Fecha.Text = "Código Orden de entrega";
            Fecha.Width = 250;
            // 
            // Transportista
            // 
            Transportista.Text = "CUIL Transportista";
            Transportista.Width = 170;
            // 
            // button1
            // 
            button1.Location = new Point(431, 395);
            button1.Name = "button1";
            button1.Size = new Size(232, 29);
            button1.TabIndex = 3;
            button1.Text = "Confirmar Orden de Entrega";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(678, 395);
            button2.Name = "button2";
            button2.Size = new Size(101, 29);
            button2.TabIndex = 4;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // Confirmar_Despachocs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(groupBox1);
            Name = "Confirmar_Despachocs";
            Text = "Confirmar Despacho";
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader Fecha;
        private ColumnHeader Transportista;
        private Button button1;
        private Button button2;
    }
}