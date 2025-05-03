namespace Prototipo.PrepararProductos
{
    partial class PrepararProductosForm
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
            comboOrdenSeleccion = new ComboBox();
            lViewOrdenSeleccion = new ListView();
            ubicacionCol = new ColumnHeader();
            productoCol = new ColumnHeader();
            cantidadCol = new ColumnHeader();
            btnSeleccion = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Orden de selección";
            // 
            // comboOrdenSeleccion
            // 
            comboOrdenSeleccion.FormattingEnabled = true;
            comboOrdenSeleccion.Location = new Point(12, 43);
            comboOrdenSeleccion.Name = "comboOrdenSeleccion";
            comboOrdenSeleccion.Size = new Size(277, 23);
            comboOrdenSeleccion.TabIndex = 1;
            // 
            // lViewOrdenSeleccion
            // 
            lViewOrdenSeleccion.Columns.AddRange(new ColumnHeader[] { ubicacionCol, productoCol, cantidadCol });
            lViewOrdenSeleccion.FullRowSelect = true;
            lViewOrdenSeleccion.Location = new Point(12, 72);
            lViewOrdenSeleccion.Name = "lViewOrdenSeleccion";
            lViewOrdenSeleccion.Size = new Size(776, 327);
            lViewOrdenSeleccion.TabIndex = 2;
            lViewOrdenSeleccion.UseCompatibleStateImageBehavior = false;
            lViewOrdenSeleccion.View = View.Details;
            // 
            // ubicacionCol
            // 
            ubicacionCol.Text = "Ubicación";
            ubicacionCol.Width = 180;
            // 
            // productoCol
            // 
            productoCol.Text = "SKU Producto";
            productoCol.Width = 180;
            // 
            // cantidadCol
            // 
            cantidadCol.Text = "Cantidad";
            cantidadCol.Width = 180;
            // 
            // btnSeleccion
            // 
            btnSeleccion.Location = new Point(520, 413);
            btnSeleccion.Name = "btnSeleccion";
            btnSeleccion.Size = new Size(187, 23);
            btnSeleccion.TabIndex = 3;
            btnSeleccion.Text = "Confirmar órden de selección";
            btnSeleccion.UseVisualStyleBackColor = true;
            btnSeleccion.Click += btnSeleccion_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(713, 413);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // PrepararProductosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnSeleccion);
            Controls.Add(lViewOrdenSeleccion);
            Controls.Add(comboOrdenSeleccion);
            Controls.Add(label1);
            Name = "PrepararProductosForm";
            Text = "Preparar Productos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboOrdenSeleccion;
        private ListView lViewOrdenSeleccion;
        private Button btnSeleccion;
        private Button btnCancelar;
        private ColumnHeader ubicacionCol;
        private ColumnHeader productoCol;
        private ColumnHeader cantidadCol;
    }
}