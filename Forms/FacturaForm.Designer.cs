namespace nikeproject.Forms
{
    partial class FacturaForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblTipoDocumento;
        private Label lblTipoDocumentoValor;
        private Label lblFecha;
        private Label lblFechaValor;
        private Label lblCliente;
        private Label lblClienteValor;
        private Label lblTelefono;
        private Label lblTelefonoValor;
        private Label lblCorreo;
        private Label lblCorreoValor;
        private Label lblVendedor;
        private Label lblVendedorValor;
        private DataGridView dgvDetalleFactura;
        private Label lblTotalTexto;
        private Label lblTotalValor;
        private Button btnImprimir;
        private Button btnCerrar;
        private PictureBox pbLogo;
        private System.Drawing.Printing.PrintDocument printDocument1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new Label();
            this.lblTipoDocumento = new Label();
            this.lblTipoDocumentoValor = new Label();
            this.lblFecha = new Label();
            this.lblFechaValor = new Label();
            this.lblCliente = new Label();
            this.lblClienteValor = new Label();
            this.lblTelefono = new Label();
            this.lblTelefonoValor = new Label();
            this.lblCorreo = new Label();
            this.lblCorreoValor = new Label();
            this.lblVendedor = new Label();
            this.lblVendedorValor = new Label();
            this.dgvDetalleFactura = new DataGridView();
            this.lblTotalTexto = new Label();
            this.lblTotalValor = new Label();
            this.btnImprimir = new Button();
            this.btnCerrar = new Button();
            this.pbLogo = new PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();

            // --- FORM ---
            this.Text = "Factura de Venta";
            this.ClientSize = new Size(720, 560);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.WhiteSmoke;

            // --- TITULO ---
            this.lblTitulo.Text = "Factura de Venta";
            this.lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitulo.Location = new Point(20, 15);

            // --- LOGO ---
            this.pbLogo.Image = Properties.Resources.nikelogo;
            this.pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbLogo.Location = new Point(580, 10);
            this.pbLogo.Size = new Size(100, 50);

            // --- Tipo Documento ---
            this.lblTipoDocumento.Text = "Tipo de Documento:";
            this.lblTipoDocumento.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblTipoDocumento.Location = new Point(20, 70);
            this.lblTipoDocumentoValor.Location = new Point(160, 70);
            this.lblTipoDocumentoValor.AutoSize = true;

            // --- Fecha ---
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblFecha.Location = new Point(20, 95);
            this.lblFechaValor.Location = new Point(160, 95);
            this.lblFechaValor.AutoSize = true;

            // --- Cliente ---
            this.lblCliente.Text = "Cliente:";
            this.lblCliente.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblCliente.Location = new Point(20, 125);
            this.lblClienteValor.Location = new Point(160, 125);
            this.lblClienteValor.AutoSize = true;

            // --- Teléfono ---
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Location = new Point(20, 145);
            this.lblTelefonoValor.Location = new Point(160, 145);
            this.lblTelefonoValor.AutoSize = true;

            // --- Correo ---
            this.lblCorreo.Text = "Correo:";
            this.lblCorreo.Location = new Point(20, 165);
            this.lblCorreoValor.Location = new Point(160, 165);
            this.lblCorreoValor.AutoSize = true;

            // --- Vendedor ---
            this.lblVendedor.Text = "Vendedor:";
            this.lblVendedor.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblVendedor.Location = new Point(20, 190);
            this.lblVendedorValor.Location = new Point(160, 190);
            this.lblVendedorValor.AutoSize = true;

            // --- Detalle ---
            this.dgvDetalleFactura.Location = new Point(20, 220);
            this.dgvDetalleFactura.Size = new Size(660, 240);
            this.dgvDetalleFactura.BackgroundColor = Color.White;
            this.dgvDetalleFactura.ReadOnly = true;
            this.dgvDetalleFactura.AllowUserToAddRows = false;
            this.dgvDetalleFactura.AllowUserToDeleteRows = false;
            this.dgvDetalleFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // --- TOTAL ---
            this.lblTotalTexto.Text = "TOTAL:";
            this.lblTotalTexto.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblTotalTexto.Location = new Point(450, 480);
            this.lblTotalValor.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblTotalValor.ForeColor = Color.SeaGreen;
            this.lblTotalValor.Location = new Point(520, 480);
            this.lblTotalValor.AutoSize = true;

            // --- Botones ---
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.BackColor = Color.SeaGreen;
            this.btnImprimir.ForeColor = Color.White;
            this.btnImprimir.FlatStyle = FlatStyle.Flat;
            this.btnImprimir.Location = new Point(20, 480);
            this.btnImprimir.Size = new Size(100, 32);
            this.btnImprimir.Click += btnImprimir_Click;

            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.BackColor = Color.DimGray;
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.Location = new Point(130, 480);
            this.btnCerrar.Size = new Size(100, 32);
            this.btnCerrar.Click += btnCerrar_Click;

            // --- Add controls ---
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblTipoDocumento);
            this.Controls.Add(this.lblTipoDocumentoValor);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblFechaValor);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblClienteValor);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblTelefonoValor);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblCorreoValor);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblVendedorValor);
            this.Controls.Add(this.dgvDetalleFactura);
            this.Controls.Add(this.lblTotalTexto);
            this.Controls.Add(this.lblTotalValor);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCerrar);

            this.Load += new EventHandler(this.FacturaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
