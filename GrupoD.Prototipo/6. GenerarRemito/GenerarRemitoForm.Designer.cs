namespace GrupoD.Prototipo._6._GenerarRemito
{
    partial class GenerarRemitoForm
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
            ListViewItem listViewItem1 = new ListViewItem("Nro orden ");
            ListViewItem listViewItem2 = new ListViewItem("Cuil transportista");
            ListViewItem listViewItem3 = new ListViewItem("");
            ListViewItem listViewItem4 = new ListViewItem("Nro de orden");
            ListViewItem listViewItem5 = new ListViewItem("cuil transportista");
            button1 = new Button();
            NroClienteLabel = new Label();
            NroClienteText = new TextBox();
            groupBox1 = new GroupBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            button2 = new Button();
            groupBox3 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            button5 = new Button();
            listView1 = new ListView();
            columnHeader4 = new ColumnHeader();
            listView2 = new ListView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(491, 63);
            button1.Name = "button1";
            button1.Size = new Size(124, 29);
            button1.TabIndex = 0;
            button1.Text = "Buscar cliente";
            button1.UseVisualStyleBackColor = true;
            // 
            // NroClienteLabel
            // 
            NroClienteLabel.AutoSize = true;
            NroClienteLabel.Location = new Point(6, 40);
            NroClienteLabel.Name = "NroClienteLabel";
            NroClienteLabel.Size = new Size(132, 20);
            NroClienteLabel.TabIndex = 1;
            NroClienteLabel.Text = "Número de cliente";
            // 
            // NroClienteText
            // 
            NroClienteText.Location = new Point(6, 63);
            NroClienteText.Name = "NroClienteText";
            NroClienteText.Size = new Size(443, 27);
            NroClienteText.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(NroClienteLabel);
            groupBox1.Controls.Add(NroClienteText);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(733, 210);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Búsqueda de Cliente";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(336, 136);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(279, 27);
            textBox2.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 136);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(298, 27);
            textBox1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(336, 113);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 6;
            label2.Text = "Cuit";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 113);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 5;
            label1.Text = "Nombre ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listView1);
            groupBox2.Controls.Add(button2);
            groupBox2.Location = new Point(12, 255);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(733, 301);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ordenes de entrega del cliente";
            // 
            // button2
            // 
            button2.Location = new Point(520, 266);
            button2.Name = "button2";
            button2.Size = new Size(179, 29);
            button2.TabIndex = 1;
            button2.Text = "Agregar al remito";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(listView2);
            groupBox3.Controls.Add(button4);
            groupBox3.Controls.Add(button3);
            groupBox3.Location = new Point(12, 585);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(730, 347);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ordenes de entrega selecionadas";
            // 
            // button4
            // 
            button4.Location = new Point(520, 302);
            button4.Name = "button4";
            button4.Size = new Size(162, 29);
            button4.TabIndex = 5;
            button4.Text = "Generar remito";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(347, 302);
            button3.Name = "button3";
            button3.Size = new Size(167, 29);
            button3.TabIndex = 4;
            button3.Text = "Quitar orden";
            button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(544, 959);
            button5.Name = "button5";
            button5.Size = new Size(139, 29);
            button5.TabIndex = 7;
            button5.Text = "Salir";
            button5.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader4 });
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3 });
            listView1.Location = new Point(22, 40);
            listView1.Name = "listView1";
            listView1.Size = new Size(677, 214);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.SmallIcon;
            // 
            // columnHeader4
            // 
            columnHeader4.Width = 200;
            // 
            // listView2
            // 
            listView2.Items.AddRange(new ListViewItem[] { listViewItem4, listViewItem5 });
            listView2.Location = new Point(22, 36);
            listView2.Name = "listView2";
            listView2.Size = new Size(677, 260);
            listView2.TabIndex = 6;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // GenerarRemitoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 1000);
            Controls.Add(button5);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "GenerarRemitoForm";
            Text = "GenerarRemitoForm";
            Load += GenerarRemitoForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label NroClienteLabel;
        private TextBox NroClienteText;
        private GroupBox groupBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Button button2;
        private GroupBox groupBox3;
        private Button button4;
        private Button button3;
        private Button button5;
        private ListView listView1;
        private ColumnHeader columnHeader4;
        private ListView listView2;
    }
}