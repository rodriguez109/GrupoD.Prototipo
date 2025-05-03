namespace GrupoD.Prototipo._4._Empaquetar_Productos
{
    partial class GenerarOrdenPreparadaForm
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
            cancelarBtn = new Button();
            ordenEmpaquetadaBtn = new Button();
            listView2 = new ListView();
            numeroOrdenCLM = new ColumnHeader();
            skuProductoCLM = new ColumnHeader();
            nombreProductoCLM = new ColumnHeader();
            cantidadProductoCLM = new ColumnHeader();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(161, 20);
            label1.TabIndex = 0;
            label1.Text = "Órdenes a empaquetar";
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
            label2.Click += label2_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { skuProductoCLM, nombreProductoCLM, cantidadProductoCLM });
            listView1.Location = new Point(12, 205);
            listView1.Name = "listView1";
            listView1.Size = new Size(776, 161);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // cancelarBtn
            // 
            cancelarBtn.Location = new Point(694, 409);
            cancelarBtn.Name = "cancelarBtn";
            cancelarBtn.Size = new Size(94, 29);
            cancelarBtn.TabIndex = 4;
            cancelarBtn.Text = "Cancelar";
            cancelarBtn.UseVisualStyleBackColor = true;
            cancelarBtn.Click += button1_Click;
            // 
            // ordenEmpaquetadaBtn
            // 
            ordenEmpaquetadaBtn.Location = new Point(530, 409);
            ordenEmpaquetadaBtn.Name = "ordenEmpaquetadaBtn";
            ordenEmpaquetadaBtn.Size = new Size(158, 29);
            ordenEmpaquetadaBtn.TabIndex = 5;
            ordenEmpaquetadaBtn.Text = "Orden empaquetada";
            ordenEmpaquetadaBtn.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { numeroOrdenCLM });
            listView2.Location = new Point(12, 32);
            listView2.MultiSelect = false;
            listView2.Name = "listView2";
            listView2.Size = new Size(431, 121);
            listView2.TabIndex = 6;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // numeroOrdenCLM
            // 
            numeroOrdenCLM.Text = "N Orden";
            numeroOrdenCLM.Width = 200;
            // 
            // skuProductoCLM
            // 
            skuProductoCLM.Text = "SKU Producto";
            skuProductoCLM.Width = 250;
            // 
            // nombreProductoCLM
            // 
            nombreProductoCLM.Text = "Nombre de producto";
            nombreProductoCLM.Width = 250;
            // 
            // cantidadProductoCLM
            // 
            cantidadProductoCLM.Text = "Cantidad";
            cantidadProductoCLM.Width = 250;
            // 
            // GenerarOrdenPreparadaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView2);
            Controls.Add(ordenEmpaquetadaBtn);
            Controls.Add(cancelarBtn);
            Controls.Add(listView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GenerarOrdenPreparadaForm";
            Text = "Confirmar empaquetado";
            Load += GenerarOrdenPreparadaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ListView listView1;
        private Button cancelarBtn;
        private Button ordenEmpaquetadaBtn;
        private ListView listView2;
        private ColumnHeader numeroOrdenCLM;
        private ColumnHeader skuProductoCLM;
        private ColumnHeader nombreProductoCLM;
        private ColumnHeader cantidadProductoCLM;
    }
}