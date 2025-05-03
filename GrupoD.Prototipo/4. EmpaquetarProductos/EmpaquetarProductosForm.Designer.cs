namespace GrupoD.Prototipo._4._EmpaquetarProductos;

partial class EmpaquetarProductosForm
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
        ordenEmpaquetadaBTN = new Button();
        cancelarBTN = new Button();
        listView2 = new ListView();
        skuProductoCLM = new ColumnHeader();
        nombreProductoCLM = new ColumnHeader();
        cantidadProductoCLM = new ColumnHeader();
        listView1 = new ListView();
        nOrdenCLM = new ColumnHeader();
        label2 = new Label();
        label1 = new Label();
        SuspendLayout();
        // 
        // ordenEmpaquetadaBTN
        // 
        ordenEmpaquetadaBTN.Location = new Point(425, 304);
        ordenEmpaquetadaBTN.Margin = new Padding(3, 2, 3, 2);
        ordenEmpaquetadaBTN.Name = "ordenEmpaquetadaBTN";
        ordenEmpaquetadaBTN.Size = new Size(174, 22);
        ordenEmpaquetadaBTN.TabIndex = 11;
        ordenEmpaquetadaBTN.Text = "Orden Empaquetada";
        ordenEmpaquetadaBTN.UseVisualStyleBackColor = true;
        // 
        // cancelarBTN
        // 
        cancelarBTN.Location = new Point(604, 304);
        cancelarBTN.Margin = new Padding(3, 2, 3, 2);
        cancelarBTN.Name = "cancelarBTN";
        cancelarBTN.Size = new Size(82, 22);
        cancelarBTN.TabIndex = 10;
        cancelarBTN.Text = "Cancelar";
        cancelarBTN.UseVisualStyleBackColor = true;
        // 
        // listView2
        // 
        listView2.Columns.AddRange(new ColumnHeader[] { skuProductoCLM, nombreProductoCLM, cantidadProductoCLM });
        listView2.Location = new Point(12, 156);
        listView2.Margin = new Padding(3, 2, 3, 2);
        listView2.Name = "listView2";
        listView2.Size = new Size(680, 114);
        listView2.TabIndex = 9;
        listView2.UseCompatibleStateImageBehavior = false;
        listView2.View = View.Details;
        // 
        // skuProductoCLM
        // 
        skuProductoCLM.Text = "SKU Producto";
        skuProductoCLM.Width = 200;
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
        // listView1
        // 
        listView1.Columns.AddRange(new ColumnHeader[] { nOrdenCLM });
        listView1.Location = new Point(12, 26);
        listView1.Margin = new Padding(3, 2, 3, 2);
        listView1.Name = "listView1";
        listView1.Size = new Size(302, 92);
        listView1.TabIndex = 8;
        listView1.UseCompatibleStateImageBehavior = false;
        listView1.View = View.Details;
        // 
        // nOrdenCLM
        // 
        nOrdenCLM.Text = "N Orden";
        nOrdenCLM.Width = 200;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 138);
        label2.Name = "label2";
        label2.Size = new Size(137, 15);
        label2.TabIndex = 7;
        label2.Text = "Productos a empaquetar";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(107, 15);
        label1.TabIndex = 6;
        label1.Text = "Ordenes a preparar";
        // 
        // EmpaquetarProductosForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(708, 344);
        Controls.Add(ordenEmpaquetadaBTN);
        Controls.Add(cancelarBTN);
        Controls.Add(listView2);
        Controls.Add(listView1);
        Controls.Add(label2);
        Controls.Add(label1);
        Name = "EmpaquetarProductosForm";
        Text = "EmpaquetarProductosForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button ordenEmpaquetadaBTN;
    private Button cancelarBTN;
    private ListView listView2;
    private ColumnHeader skuProductoCLM;
    private ColumnHeader nombreProductoCLM;
    private ColumnHeader cantidadProductoCLM;
    private ListView listView1;
    private ColumnHeader nOrdenCLM;
    private Label label2;
    private Label label1;
}