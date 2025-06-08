namespace GrupoD.Prototipo._0._Menu_Principal
{
    partial class MenuForm
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
            GenerarOPMenuBTN = new Button();
            GenerarOSMenuBTN = new Button();
            PrepararProductoMenuBTN = new Button();
            EmpaquetarMenuBTN = new Button();
            GenerarOEMenuBTN = new Button();
            GenerarDocMenuBTN = new Button();
            label1 = new Label();
            seleccionDepositoCMB = new ComboBox();
            depositoLBL = new Label();
            SuspendLayout();
            // 
            // GenerarOPMenuBTN
            // 
            GenerarOPMenuBTN.Location = new Point(103, 104);
            GenerarOPMenuBTN.Name = "GenerarOPMenuBTN";
            GenerarOPMenuBTN.Size = new Size(357, 45);
            GenerarOPMenuBTN.TabIndex = 0;
            GenerarOPMenuBTN.Text = "Generar orden de preparacion";
            GenerarOPMenuBTN.UseVisualStyleBackColor = true;
            GenerarOPMenuBTN.Click += GenerarOPMenuBTN_Click;
            // 
            // GenerarOSMenuBTN
            // 
            GenerarOSMenuBTN.Location = new Point(103, 169);
            GenerarOSMenuBTN.Name = "GenerarOSMenuBTN";
            GenerarOSMenuBTN.Size = new Size(357, 45);
            GenerarOSMenuBTN.TabIndex = 1;
            GenerarOSMenuBTN.Text = "Generar orden de selección";
            GenerarOSMenuBTN.UseVisualStyleBackColor = true;
            GenerarOSMenuBTN.Click += GenerarOSMenuBTN_Click;
            // 
            // PrepararProductoMenuBTN
            // 
            PrepararProductoMenuBTN.Location = new Point(103, 239);
            PrepararProductoMenuBTN.Name = "PrepararProductoMenuBTN";
            PrepararProductoMenuBTN.Size = new Size(357, 45);
            PrepararProductoMenuBTN.TabIndex = 2;
            PrepararProductoMenuBTN.Text = "Preparar los productos";
            PrepararProductoMenuBTN.UseVisualStyleBackColor = true;
            PrepararProductoMenuBTN.Click += PrepararProductoMenuBTN_Click;
            // 
            // EmpaquetarMenuBTN
            // 
            EmpaquetarMenuBTN.Location = new Point(103, 310);
            EmpaquetarMenuBTN.Name = "EmpaquetarMenuBTN";
            EmpaquetarMenuBTN.Size = new Size(357, 45);
            EmpaquetarMenuBTN.TabIndex = 3;
            EmpaquetarMenuBTN.Text = "Empaquetar los productos";
            EmpaquetarMenuBTN.UseVisualStyleBackColor = true;
            EmpaquetarMenuBTN.Click += EmpaquetarMenuBTN_Click;
            // 
            // GenerarOEMenuBTN
            // 
            GenerarOEMenuBTN.Location = new Point(103, 381);
            GenerarOEMenuBTN.Name = "GenerarOEMenuBTN";
            GenerarOEMenuBTN.Size = new Size(357, 45);
            GenerarOEMenuBTN.TabIndex = 4;
            GenerarOEMenuBTN.Text = "Generar orden de entrega";
            GenerarOEMenuBTN.UseVisualStyleBackColor = true;
            GenerarOEMenuBTN.Click += GenerarOEMenuBTN_Click;
            // 
            // GenerarDocMenuBTN
            // 
            GenerarDocMenuBTN.Location = new Point(103, 448);
            GenerarDocMenuBTN.Name = "GenerarDocMenuBTN";
            GenerarDocMenuBTN.Size = new Size(357, 45);
            GenerarDocMenuBTN.TabIndex = 5;
            GenerarDocMenuBTN.Text = "Generar remito";
            GenerarDocMenuBTN.UseVisualStyleBackColor = true;
            GenerarDocMenuBTN.Click += GenerarDocMenuBTN_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(228, 9);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 7;
            label1.Text = "Menu Inicio Empresa";
            // 
            // seleccionDepositoCMB
            // 
            seleccionDepositoCMB.FormattingEnabled = true;
            seleccionDepositoCMB.Location = new Point(103, 64);
            seleccionDepositoCMB.Margin = new Padding(3, 2, 3, 2);
            seleccionDepositoCMB.Name = "seleccionDepositoCMB";
            seleccionDepositoCMB.Size = new Size(357, 23);
            seleccionDepositoCMB.TabIndex = 8;
            seleccionDepositoCMB.SelectedIndexChanged += seleccionDepositoCMB_SelectedIndexChanged;
            // 
            // depositoLBL
            // 
            depositoLBL.AutoSize = true;
            depositoLBL.Location = new Point(103, 47);
            depositoLBL.Name = "depositoLBL";
            depositoLBL.Size = new Size(54, 15);
            depositoLBL.TabIndex = 9;
            depositoLBL.Text = "Depósito";
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 532);
            Controls.Add(depositoLBL);
            Controls.Add(seleccionDepositoCMB);
            Controls.Add(label1);
            Controls.Add(GenerarDocMenuBTN);
            Controls.Add(GenerarOEMenuBTN);
            Controls.Add(EmpaquetarMenuBTN);
            Controls.Add(PrepararProductoMenuBTN);
            Controls.Add(GenerarOSMenuBTN);
            Controls.Add(GenerarOPMenuBTN);
            Name = "MenuForm";
            Text = "Menu Empresa";
            Load += MenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GenerarOPMenuBTN;
        private Button GenerarOSMenuBTN;
        private Button PrepararProductoMenuBTN;
        private Button EmpaquetarMenuBTN;
        private Button GenerarOEMenuBTN;
        private Button GenerarDocMenuBTN;
        private Label label1;
        private ComboBox seleccionDepositoCMB;
        private Label depositoLBL;
    }
}