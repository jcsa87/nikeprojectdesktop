namespace nikeproject.UserControls
{
    partial class ReportesControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private DataGridView dgvReportes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            dgvReportes = new DataGridView();

            // lblTitulo
            lblTitulo.Text = "Reportes de Ventas";
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(20, 20);
            lblTitulo.AutoSize = true;

            // dgvReportes
            dgvReportes.Location = new System.Drawing.Point(20, 60);
            dgvReportes.Size = new System.Drawing.Size(500, 300);

            Controls.Add(lblTitulo);
            Controls.Add(dgvReportes);

            Size = new System.Drawing.Size(550, 400);
        }
    }
}
