namespace nikeproject.Forms
{
    partial class VentaControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtCliente;
        private TextBox txtUsuario;
        private NumericUpDown numMontoTotal;
        private DataGridView dgvVentas;

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
            txtCliente = new TextBox();
            txtUsuario = new TextBox();
            numMontoTotal = new NumericUpDown();
            dgvVentas = new DataGridView();

            // label1
            label1.Text = "Cliente:";
            label1.Location = new System.Drawing.Point(20, 20);

            // txtCliente
            txtCliente.Location = new System.Drawing.Point(120, 20);
            txtCliente.Width = 150;

            // label2
            label2.Text = "Usuario:";
            label2.Location = new System.Drawing.Point(20, 60);

            // txtUsuario
            txtUsuario.Location = new System.Drawing.Point(120, 60);
            txtUsuario.Width = 150;

            // label3
            label3.Text = "Monto Total:";
            label3.Location = new System.Drawing.Point(20, 100);

            // numMontoTotal
            numMontoTotal.Location = new System.Drawing.Point(120, 100);
            numMontoTotal.DecimalPlaces = 2;
            numMontoTotal.Maximum = 1000000;

            // dgvVentas
            dgvVentas.Location = new System.Drawing.Point(20, 140);
            dgvVentas.Size = new System.Drawing.Size(400, 200);

            Controls.Add(label1);
            Controls.Add(txtCliente);
            Controls.Add(label2);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(numMontoTotal);
            Controls.Add(dgvVentas);

            Size = new System.Drawing.Size(450, 370);
        }
    }
}
