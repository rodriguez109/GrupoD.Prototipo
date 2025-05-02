

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoD.Prototipo._4.EmpaquetarProductos
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
            button1 = new Button();
            button2 = new Button();
            listView1 = new ListView();
            skuProductoCLM = new ColumnHeader();
            detalleProductoCLM = new ColumnHeader();
            cantidadProductoCLM = new ColumnHeader();
            listView2 = new ListView();
            numOrde = new ColumnHeader();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(149, 20);
            label1.TabIndex = 1;
            label1.Text = "Órdenes empaquetar";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(694, 409);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(514, 409);
            button2.Name = "button2";
            button2.Size = new Size(174, 29);
            button2.TabIndex = 3;
            button2.Text = "Orden empaquetada";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { skuProductoCLM, detalleProductoCLM, cantidadProductoCLM });
            listView1.Location = new Point(12, 193);
            listView1.Name = "listView1";
            listView1.Size = new Size(754, 181);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // skuProductoCLM
            // 
            skuProductoCLM.Text = "SKU Producto";
            skuProductoCLM.Width = 250;
            // 
            // detalleProductoCLM
            // 
            detalleProductoCLM.Text = "Nombre de producto";
            detalleProductoCLM.Width = 250;
            // 
            // cantidadProductoCLM
            // 
            cantidadProductoCLM.Text = "Cantidad";
            cantidadProductoCLM.Width = 250;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { numOrde });
            listView2.Location = new Point(12, 32);
            listView2.MultiSelect = false;
            listView2.Name = "listView2";
            listView2.Size = new Size(255, 112);
            listView2.TabIndex = 9;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            // 
            // numOrde
            // 
            numOrde.Text = "N Orden";
            numOrde.Width = 250;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 170);
            label2.Name = "label2";
            label2.Size = new Size(172, 20);
            label2.TabIndex = 10;
            label2.Text = "Productos a empaquetar";
            label2.Click += label2_Click;
            // 
            // GenerarOrdenPreparadaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "GenerarOrdenPreparadaForm";
            Text = "Confirmar Empaquetado";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button button1;
        private Button button2;
        private ListView listView1;
        private ColumnHeader skuProductoCLM;
        private ColumnHeader detalleProductoCLM;
        private ColumnHeader cantidadProductoCLM;
        private ListView listView2;
        private ColumnHeader numOrde;
        private Label label2;
    }

}
