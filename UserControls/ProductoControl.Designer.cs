namespace nikeproject.UserControls
{
    partial class ProductoControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private NumericUpDown numPrecioVenta;
        private DataGridView dgvProductos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            numPrecioVenta = new NumericUpDown();
            dgvProductos = new DataGridView();

            // label1
            label1.Text = "Código:";
            label1.Location = new System.Drawing.Point(20, 20);

            // txtCodigo
            txtCodigo.Location = new System.Drawing.Point(120, 20);
            txtCodigo.Width = 150;

            // label2
            label2.Text = "Nombre:";
            label2.Location = new System.Drawing.Point(20, 60);

            // txtNombre
            txtNombre.Location = new System.Drawing.Point(120, 60);
            txtNombre.Width = 150;

            // label3
            label3.Text = "Descripción:";
            label3.Location = new System.Drawing.Point(20, 100);

            // txtDescripcion
            txtDescripcion.Location = new System.Drawing.Point(120, 100);
            txtDescripcion.Width = 150;

            // label4
            label4.Text = "Precio Venta:";
            label4.Location = new System.Drawing.Point(20, 140);

            // numPrecioVenta
            numPrecioVenta.Location = new System.Drawing.Point(120, 140);
            numPrecioVenta.DecimalPlaces = 2;
            numPrecioVenta.Maximum = 1000000;

            // dgvProductos
            dgvProductos.Location = new System.Drawing.Point(20, 180);
            dgvProductos.Size = new System.Drawing.Size(400, 200);

            Controls.Add(label1);
            Controls.Add(txtCodigo);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(txtDescripcion);
            Controls.Add(label4);
            Controls.Add(numPrecioVenta);
            Controls.Add(dgvProductos);

            Size = new System.Drawing.Size(450, 400);
        }
    }
}
