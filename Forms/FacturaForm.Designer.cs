namespace nikeproject.Forms
{
    partial class FacturaForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTituloFactura;
        private Label lblEmpresa;
        private Label lblLema;
        private Label lblNumeroFacturaValor;
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
        private Button btnGuardarPdf;
        private Button btnVistaPrevia;
        private PictureBox pbLogo;
        private Panel panelHeader;
        private Panel panelInferior;
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
            this.lblTituloFactura = new Label();
            this.lblEmpresa = new Label();
            this.lblLema = new Label();
            this.lblNumeroFacturaValor = new Label();
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
            this.btnGuardarPdf = new Button();
            this.btnVistaPrevia = new Button();
            this.pbLogo = new PictureBox();
            this.panelHeader = new Panel();
            this.panelInferior = new Panel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();

            // =============== PANEL HEADER ===============
            this.panelHeader.BackColor = Color.White;
            this.panelHeader.BorderStyle = BorderStyle.FixedSingle;
            this.panelHeader.Location = new Point(20, 20);
            this.panelHeader.Size = new Size(680, 120);

            // --- Título principal ---
            this.lblTituloFactura.Text = "FACTURA";
            this.lblTituloFactura.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTituloFactura.ForeColor = Color.Black;
            this.lblTituloFactura.Location = new Point(20, 10);
            this.lblTituloFactura.AutoSize = true;

            // --- Empresa ---
            this.lblEmpresa.Text = "Nike Corrientes";
            this.lblEmpresa.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblEmpresa.Location = new Point(20, 50);
            this.lblEmpresa.AutoSize = true;

            // --- Lema ---
            this.lblLema.Text = "Calzado y ropa deportiva";
            this.lblLema.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            this.lblLema.ForeColor = Color.Gray;
            this.lblLema.Location = new Point(20, 70);
            this.lblLema.AutoSize = true;

            // --- Logo ---
            this.pbLogo.Image = Properties.Resources.nikelogo;
            this.pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbLogo.Location = new Point(560, 10);
            this.pbLogo.Size = new Size(100, 80);

            // --- Número de factura ---
            Label lblNumeroFactura = new Label();
            lblNumeroFactura.Text = "N° Factura:";
            lblNumeroFactura.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblNumeroFactura.Location = new Point(20, 95);
            lblNumeroFactura.AutoSize = true;

            this.lblNumeroFacturaValor.Font = new Font("Segoe UI", 9);
            this.lblNumeroFacturaValor.Location = new Point(110, 95);
            this.lblNumeroFacturaValor.AutoSize = true;

            this.panelHeader.Controls.Add(this.lblTituloFactura);
            this.panelHeader.Controls.Add(this.lblEmpresa);
            this.panelHeader.Controls.Add(this.lblLema);
            this.panelHeader.Controls.Add(this.pbLogo);
            this.panelHeader.Controls.Add(lblNumeroFactura);
            this.panelHeader.Controls.Add(this.lblNumeroFacturaValor);
            this.Controls.Add(this.panelHeader);

            // =============== FORM GENERAL ===============
            this.Text = "Factura de Venta";
            this.ClientSize = new Size(720, 560);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.WhiteSmoke;

            int inicioDatosY = 160;

            // --- Tipo documento ---
            this.lblTipoDocumento.Text = "Tipo de Documento:";
            this.lblTipoDocumento.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblTipoDocumento.Location = new Point(30, inicioDatosY);
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumentoValor.Location = new Point(180, inicioDatosY);
            this.lblTipoDocumentoValor.AutoSize = true;

            // --- Fecha ---
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblFecha.Location = new Point(30, inicioDatosY + 25);
            this.lblFecha.AutoSize = true;
            this.lblFechaValor.Location = new Point(180, inicioDatosY + 25);
            this.lblFechaValor.AutoSize = true;

            // --- Cliente ---
            this.lblCliente.Text = "Cliente:";
            this.lblCliente.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblCliente.Location = new Point(30, inicioDatosY + 55);
            this.lblCliente.AutoSize = true;
            this.lblClienteValor.Location = new Point(180, inicioDatosY + 55);
            this.lblClienteValor.AutoSize = true;

            // --- Teléfono ---
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblTelefono.Location = new Point(30, inicioDatosY + 80);
            this.lblTelefono.AutoSize = true;
            this.lblTelefonoValor.Location = new Point(180, inicioDatosY + 80);
            this.lblTelefonoValor.AutoSize = true;

            // --- Correo ---
            this.lblCorreo.Text = "Correo:";
            this.lblCorreo.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblCorreo.Location = new Point(30, inicioDatosY + 105);
            this.lblCorreo.AutoSize = true;
            this.lblCorreoValor.Location = new Point(180, inicioDatosY + 105);
            this.lblCorreoValor.AutoSize = true;

            // --- Vendedor ---
            this.lblVendedor.Text = "Vendedor:";
            this.lblVendedor.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblVendedor.Location = new Point(30, inicioDatosY + 130);
            this.lblVendedor.AutoSize = true;
            this.lblVendedorValor.Location = new Point(180, inicioDatosY + 130);
            this.lblVendedorValor.AutoSize = true;

            // =============== DATAGRID DETALLE ===============
            this.dgvDetalleFactura.Location = new Point(20, inicioDatosY + 170);
            this.dgvDetalleFactura.Size = new Size(660, 210);
            this.dgvDetalleFactura.BackgroundColor = Color.White;
            this.dgvDetalleFactura.ReadOnly = true;
            this.dgvDetalleFactura.AllowUserToAddRows = false;
            this.dgvDetalleFactura.AllowUserToDeleteRows = false;
            this.dgvDetalleFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleFactura.RowHeadersVisible = false;

            // =============== PANEL INFERIOR ===============
            this.panelInferior.BackColor = Color.WhiteSmoke;
            this.panelInferior.Dock = DockStyle.Bottom;
            this.panelInferior.Height = 60;
            this.Controls.Add(this.panelInferior);

            // --- Botones ---
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.BackColor = Color.SeaGreen;
            this.btnImprimir.ForeColor = Color.White;
            this.btnImprimir.FlatStyle = FlatStyle.Flat;
            this.btnImprimir.Location = new Point(20, 14);
            this.btnImprimir.Size = new Size(100, 32);
            this.btnImprimir.Click += btnImprimir_Click;
            this.panelInferior.Controls.Add(this.btnImprimir);

            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.BackColor = Color.DimGray;
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.Location = new Point(130, 14);
            this.btnCerrar.Size = new Size(100, 32);
            this.btnCerrar.Click += btnCerrar_Click;
            this.panelInferior.Controls.Add(this.btnCerrar);

            this.btnGuardarPdf.Text = "Guardar PDF";
            this.btnGuardarPdf.BackColor = Color.SteelBlue;
            this.btnGuardarPdf.ForeColor = Color.White;
            this.btnGuardarPdf.FlatStyle = FlatStyle.Flat;
            this.btnGuardarPdf.Location = new Point(240, 14);
            this.btnGuardarPdf.Size = new Size(120, 32);
            this.btnGuardarPdf.Click += btnGuardarPdf_Click;
            this.panelInferior.Controls.Add(this.btnGuardarPdf);

            this.btnVistaPrevia.Text = "Vista Previa";
            this.btnVistaPrevia.BackColor = Color.DarkOrange;
            this.btnVistaPrevia.ForeColor = Color.White;
            this.btnVistaPrevia.FlatStyle = FlatStyle.Flat;
            this.btnVistaPrevia.Location = new Point(370, 14);
            this.btnVistaPrevia.Size = new Size(120, 32);
            this.btnVistaPrevia.Click += btnVistaPrevia_Click;
            this.panelInferior.Controls.Add(this.btnVistaPrevia);

            // --- Total ---
            this.lblTotalTexto.Text = "TOTAL:";
            this.lblTotalTexto.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblTotalTexto.ForeColor = Color.Black;
            this.lblTotalTexto.AutoSize = true;
            this.lblTotalTexto.Location = new Point(540, 20);

            this.lblTotalValor.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblTotalValor.ForeColor = Color.SeaGreen;
            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Location = new Point(610, 20);

            this.panelInferior.Controls.Add(this.lblTotalTexto);
            this.panelInferior.Controls.Add(this.lblTotalValor);

            // --- Añadir controles al form ---
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

            this.Load += new EventHandler(this.FacturaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
