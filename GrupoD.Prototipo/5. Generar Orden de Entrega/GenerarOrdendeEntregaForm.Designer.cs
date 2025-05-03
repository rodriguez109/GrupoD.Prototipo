namespace GrupoD.Prototipo._5._Generar_Orden_de_Entrega
{
    partial class GenerarOrdendeEntregaForm
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
            button2 = new Button();
            button1 = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            Fecha = new ColumnHeader();
            Transportista = new ColumnHeader();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(678, 373);
            button2.Name = "button2";
            button2.Size = new Size(101, 29);
            button2.TabIndex = 7;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(431, 373);
            button1.Name = "button1";
            button1.Size = new Size(232, 29);
            button1.TabIndex = 6;
            button1.Text = "Confirmar Orden de Entrega";
            button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, Fecha, Transportista });
            listView1.Location = new Point(22, 48);
            listView1.Name = "listView1";
            listView1.Size = new Size(757, 310);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
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
            // GenerarOrdendeEntregaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Name = "GenerarOrdendeEntregaForm";
            Text = "GenerarOrdendeEntregaForm";
            ResumeLayout(false);
        }

        #endregion

        private Button button2;
        private Button button1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader Fecha;
        private ColumnHeader Transportista;
    }
}