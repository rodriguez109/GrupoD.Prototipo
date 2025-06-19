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
        productosPorOrdenLST = new ListView();
        skuProductoCLM = new ColumnHeader();
        nombreProductoCLM = new ColumnHeader();
        cantidadProductoCLM = new ColumnHeader();
        label2 = new Label();
        labelNumeroOrden = new Label();
        SuspendLayout();
        // 
        // ordenEmpaquetadaBTN
        // 
        ordenEmpaquetadaBTN.Location = new Point(572, 405);
        ordenEmpaquetadaBTN.Name = "ordenEmpaquetadaBTN";
        ordenEmpaquetadaBTN.Size = new Size(113, 29);
        ordenEmpaquetadaBTN.TabIndex = 11;
        ordenEmpaquetadaBTN.Text = "Empaquetar";
        ordenEmpaquetadaBTN.UseVisualStyleBackColor = true;
        // 
        // cancelarBTN
        // 
        cancelarBTN.Location = new Point(690, 405);
        cancelarBTN.Name = "cancelarBTN";
        cancelarBTN.Size = new Size(94, 29);
        cancelarBTN.TabIndex = 10;
        cancelarBTN.Text = "Cancelar";
        cancelarBTN.UseVisualStyleBackColor = true;
        // 
        // productosPorOrdenLST
        // 
        productosPorOrdenLST.Columns.AddRange(new ColumnHeader[] { skuProductoCLM, nombreProductoCLM, cantidadProductoCLM });
        productosPorOrdenLST.HideSelection = true;
        productosPorOrdenLST.Location = new Point(14, 75);
        productosPorOrdenLST.Name = "productosPorOrdenLST";
        productosPorOrdenLST.Size = new Size(777, 280);
        productosPorOrdenLST.TabIndex = 9;
        productosPorOrdenLST.UseCompatibleStateImageBehavior = false;
        productosPorOrdenLST.View = View.Details;
        productosPorOrdenLST.SelectedIndexChanged += listView2_SelectedIndexChanged;
        // 
        // skuProductoCLM
        // 
        skuProductoCLM.Text = "SKU Producto";
        skuProductoCLM.Width = 255;
        // 
        // nombreProductoCLM
        // 
        nombreProductoCLM.Text = "Nombre Producto";
        nombreProductoCLM.Width = 270;
        // 
        // cantidadProductoCLM
        // 
        cantidadProductoCLM.Text = "Cantidad";
        cantidadProductoCLM.Width = 250;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(14, 52);
        label2.Name = "label2";
        label2.Size = new Size(172, 20);
        label2.TabIndex = 7;
        label2.Text = "Productos a empaquetar";
        // 
        // labelNumeroOrden
        // 
        labelNumeroOrden.AutoSize = true;
        labelNumeroOrden.Location = new Point(14, 9);
        labelNumeroOrden.Name = "labelNumeroOrden";
        labelNumeroOrden.Size = new Size(54, 20);
        labelNumeroOrden.TabIndex = 13;
        labelNumeroOrden.Text = "Orden ";
        // 
        // EmpaquetarProductosForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(809, 459);
        Controls.Add(labelNumeroOrden);
        Controls.Add(ordenEmpaquetadaBTN);
        Controls.Add(cancelarBTN);
        Controls.Add(productosPorOrdenLST);
        Controls.Add(label2);
        Margin = new Padding(3, 4, 3, 4);
        Name = "EmpaquetarProductosForm";
        Text = "EmpaquetarProductosForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button ordenEmpaquetadaBTN;
    private Button cancelarBTN;
    private ListView productosPorOrdenLST;
    private ColumnHeader skuProductoCLM;
    private ColumnHeader nombreProductoCLM;
    private ColumnHeader cantidadProductoCLM;
    private Label label2;
    private Label labelNumeroOrden;
}