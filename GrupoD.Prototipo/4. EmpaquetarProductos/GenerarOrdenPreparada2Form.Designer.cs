namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    partial class GenerarOrdenPreparada2Form
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
            label2 = new Label();
            listView1 = new ListView();
            listView2 = new ListView();
            cancelarBTN = new Button();
            ordenEmpaquetadaBTN = new Button();
            nOrdenCLM = new ColumnHeader();
            nombreProductoCLM = new ColumnHeader();
            cantidadProductoCLM = new ColumnHeader();
            skuProductoCLM = new ColumnHeader();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 0;
            label1.Text = "Ordenes a preparar";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 182);
            label2.Name = "label2";
            label2.Size = new Size(172, 20);
            label2.TabIndex = 1;
            label2.Text = "Productos a empaquetar";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { nOrdenCLM });
            listView1.Location = new Point(12, 32);
            listView1.Name = "listView1";
            listView1.Size = new Size(345, 121);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { skuProductoCLM, nombreProductoCLM, cantidadProductoCLM });
            listView2.Location = new Point(12, 205);
            listView2.Name = "listView2";
            listView2.Size = new Size(776, 150);
            listView2.TabIndex = 3;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // cancelarBTN
            // 
            cancelarBTN.Location = new Point(688, 402);
            cancelarBTN.Name = "cancelarBTN";
            cancelarBTN.Size = new Size(94, 29);
            cancelarBTN.TabIndex = 4;
            cancelarBTN.Text = "Cancelar";
            cancelarBTN.UseVisualStyleBackColor = true;
            // 
            // ordenEmpaquetadaBTN
            // 
            ordenEmpaquetadaBTN.Location = new Point(483, 402);
            ordenEmpaquetadaBTN.Name = "ordenEmpaquetadaBTN";
            ordenEmpaquetadaBTN.Size = new Size(199, 29);
            ordenEmpaquetadaBTN.TabIndex = 5;
            ordenEmpaquetadaBTN.Text = "Orden Empaquetada";
            ordenEmpaquetadaBTN.UseVisualStyleBackColor = true;
            // 
            // nOrdenCLM
            // 
            nOrdenCLM.Text = "N Orden";
            nOrdenCLM.Width = 200;
            // 
            // nombreProductoCLM
            // 
            nombreProductoCLM.Text = "Nombre Producto";
            nombreProductoCLM.Width = 200;
            // 
            // cantidadProductoCLM
            // 
            cantidadProductoCLM.Text = "Cantidad";
            cantidadProductoCLM.Width = 200;
            // 
            // skuProductoCLM
            // 
            skuProductoCLM.Text = "SKU Producto";
            skuProductoCLM.Width = 200;
            // 
            // GenerarOrdenPreparada2Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ordenEmpaquetadaBTN);
            Controls.Add(cancelarBTN);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GenerarOrdenPreparada2Form";
            Text = "GenerarOrdenPreparada2Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ListView listView1;
        private ListView listView2;
        private Button cancelarBTN;
        private Button ordenEmpaquetadaBTN;
        private ColumnHeader nOrdenCLM;
        private ColumnHeader skuProductoCLM;
        private ColumnHeader nombreProductoCLM;
        private ColumnHeader cantidadProductoCLM;
    }
}