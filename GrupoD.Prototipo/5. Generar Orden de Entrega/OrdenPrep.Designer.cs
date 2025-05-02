namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    partial class OrdenPrep
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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            Cantidad = new ColumnHeader();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, Cantidad });
            listView1.Location = new Point(12, 30);
            listView1.Name = "listView1";
            listView1.Size = new Size(757, 310);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "SKU";
            columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Detalle del Producto";
            columnHeader2.Width = 300;
            // 
            // Cantidad
            // 
            Cantidad.Text = "Cantidad";
            Cantidad.Width = 200;
            // 
            // button1
            // 
            button1.Location = new Point(441, 389);
            button1.Name = "button1";
            button1.Size = new Size(232, 29);
            button1.TabIndex = 3;
            button1.Text = "Confirmar Orden Empaquetada";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(668, 389);
            button2.Name = "button2";
            button2.Size = new Size(101, 29);
            button2.TabIndex = 4;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // OrdenPrep
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Name = "OrdenPrep";
            Text = "Empaquetar Productos";
            Load += OrdenPrep_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader Cantidad;
        private Button button1;
        private Button button2;
    }
}