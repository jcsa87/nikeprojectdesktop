namespace nikeproject.UserControls
{
    partial class VentaControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentaControl));
            grpVenta = new GroupBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblTipoDoc = new Label();
            cbTipoDoc = new ComboBox();
            grpCliente = new GroupBox();
            pbCliente = new PictureBox();
            lblDocumento = new Label();
            txtDocumentoCliente = new TextBox();
            btnBuscarCliente = new Button();
            lblCorreo = new Label();
            lblTelefono = new Label();
            lblApellido = new Label();
            lblNombreCliente = new Label();
            txtCorreo = new TextBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            txtNombreCliente = new TextBox();
            grpProducto = new GroupBox();
            pbProducto = new PictureBox();
            lblCodProd = new Label();
            txtCodProducto = new TextBox();
            btnBuscarProducto = new Button();
            lblNombreProd = new Label();
            txtNombreProd = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblStock = new Label();
            txtStock = new TextBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            btnAgregar = new Button();
            dgvDetalle = new DataGridView();
            colIdProducto = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colSubTotal = new DataGridViewTextBoxColumn();
            colQuitar = new DataGridViewButtonColumn();
            pnlTotales = new Panel();
            lblTotal = new Label();
            txtTotal = new TextBox();
            lblPagaCon = new Label();
            cbFormaPago = new ComboBox();
            lblCambio = new Label();
            txtCambio = new TextBox();
            txtPagaCon = new TextBox();
            btnCrearVenta = new Button();
            btnHistorialVentas = new Button();

            grpVenta.SuspendLayout();
            grpCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCliente).BeginInit();
            grpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbProducto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            pnlTotales.SuspendLayout();
            SuspendLayout();

            // ====== GRUPO VENTA ======
            grpVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpVenta.Controls.Add(lblFecha);
            grpVenta.Controls.Add(dtpFecha);
            grpVenta.Controls.Add(lblTipoDoc);
            grpVenta.Controls.Add(cbTipoDoc);
            grpVenta.Location = new Point(50, 10);
            grpVenta.Name = "grpVenta";
            grpVenta.Size = new Size(1480, 60);
            grpVenta.Text = "Información Venta";

            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(15, 28);
            lblFecha.Text = "Fecha:";

            dtpFecha.Enabled = false;
            dtpFecha.Location = new Point(70, 24);
            dtpFecha.Size = new Size(200, 27);

            lblTipoDoc.AutoSize = true;
            lblTipoDoc.Location = new Point(300, 28);
            lblTipoDoc.Text = "Tipo Documento:";

            cbTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoDoc.Items.AddRange(new object[] { "Factura", "Boleta", "Ticket" });
            cbTipoDoc.Location = new Point(420, 24);
            cbTipoDoc.Size = new Size(160, 28);

            // ====== GRUPO CLIENTE ======
            grpCliente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpCliente.Controls.Add(pbCliente);
            grpCliente.Controls.Add(lblDocumento);
            grpCliente.Controls.Add(txtDocumentoCliente);
            grpCliente.Controls.Add(btnBuscarCliente);
            grpCliente.Controls.Add(lblCorreo);
            grpCliente.Controls.Add(lblTelefono);
            grpCliente.Controls.Add(lblApellido);
            grpCliente.Controls.Add(lblNombreCliente);
            grpCliente.Controls.Add(txtCorreo);
            grpCliente.Controls.Add(txtApellido);
            grpCliente.Controls.Add(txtTelefono);
            grpCliente.Controls.Add(txtNombreCliente);
            grpCliente.Location = new Point(50, 80);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(1480, 80);
            grpCliente.Text = "Información Cliente";

            pbCliente.Image = (Image)resources.GetObject("pbCliente.Image");
            pbCliente.Location = new Point(1360, 18);
            pbCliente.Size = new Size(88, 47);
            pbCliente.SizeMode = PictureBoxSizeMode.Zoom;

            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(15, 35);
            lblDocumento.Text = "Nro Documento:";

            txtDocumentoCliente.Location = new Point(130, 32);
            txtDocumentoCliente.Size = new Size(150, 27);

            btnBuscarCliente.Location = new Point(285, 32);
            btnBuscarCliente.Size = new Size(34, 27);
            btnBuscarCliente.Text = "🔍";
            btnBuscarCliente.Click += btnBuscarCliente_Click;

            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(340, 35);
            lblNombreCliente.Text = "Nombre:";

            txtNombreCliente.Location = new Point(410, 32);
            txtNombreCliente.ReadOnly = true;
            txtNombreCliente.Size = new Size(140, 27);

            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(560, 35);
            lblApellido.Text = "Apellido:";

            txtApellido.Location = new Point(620, 32);
            txtApellido.ReadOnly = true;
            txtApellido.Size = new Size(140, 27);

            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(770, 35);
            lblTelefono.Text = "Teléfono:";

            txtTelefono.Location = new Point(845, 32);
            txtTelefono.ReadOnly = true;
            txtTelefono.Size = new Size(140, 27);

            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(1000, 35);
            lblCorreo.Text = "Correo:";

            txtCorreo.Location = new Point(1060, 32);
            txtCorreo.ReadOnly = true;
            txtCorreo.Size = new Size(200, 27);

            // ====== GRUPO PRODUCTO ======
            grpProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpProducto.Controls.Add(pbProducto);
            grpProducto.Controls.Add(lblCodProd);
            grpProducto.Controls.Add(txtCodProducto);
            grpProducto.Controls.Add(btnBuscarProducto);
            grpProducto.Controls.Add(lblNombreProd);
            grpProducto.Controls.Add(txtNombreProd);
            grpProducto.Controls.Add(lblPrecio);
            grpProducto.Controls.Add(txtPrecio);
            grpProducto.Controls.Add(lblStock);
            grpProducto.Controls.Add(txtStock);
            grpProducto.Controls.Add(lblCantidad);
            grpProducto.Controls.Add(nudCantidad);
            grpProducto.Controls.Add(btnAgregar);
            grpProducto.Location = new Point(50, 170);
            grpProducto.Size = new Size(1480, 90);
            grpProducto.Text = "Información Producto";

            pbProducto.Image = (Image)resources.GetObject("pbProducto.Image");
            pbProducto.Location = new Point(1360, 15);
            pbProducto.Size = new Size(100, 70);
            pbProducto.SizeMode = PictureBoxSizeMode.Zoom;

            lblCodProd.AutoSize = true;
            lblCodProd.Location = new Point(15, 35);
            lblCodProd.Text = "Cod. Producto:";

            txtCodProducto.Location = new Point(120, 32);
            txtCodProducto.Size = new Size(150, 27);

            btnBuscarProducto.Location = new Point(275, 32);
            btnBuscarProducto.Size = new Size(34, 27);
            btnBuscarProducto.Text = "🔍";
            btnBuscarProducto.Click += btnBuscarProducto_Click;

            lblNombreProd.AutoSize = true;
            lblNombreProd.Location = new Point(330, 35);
            lblNombreProd.Text = "Producto:";

            txtNombreProd.Location = new Point(410, 32);
            txtNombreProd.ReadOnly = true;
            txtNombreProd.Size = new Size(140, 27);

            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(560, 35);
            lblPrecio.Text = "Precio:";

            txtPrecio.Location = new Point(615, 32);
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(90, 27);

            lblStock.AutoSize = true;
            lblStock.Location = new Point(720, 35);
            lblStock.Text = "Stock:";

            txtStock.Location = new Point(770, 32);
            txtStock.ReadOnly = true;
            txtStock.Size = new Size(60, 27);

            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(850, 35);
            lblCantidad.Text = "Cantidad:";

            nudCantidad.Location = new Point(925, 32);
            nudCantidad.Size = new Size(80, 27);

            btnAgregar.Location = new Point(1020, 32);
            btnAgregar.Size = new Size(90, 27);
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;

            // ====== DETALLE ======
            dgvDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.Location = new Point(50, 270);
            dgvDetalle.Size = new Size(1480, 450);
            dgvDetalle.RowHeadersWidth = 51;
            dgvDetalle.RowTemplate.Height = 28;
            dgvDetalle.Columns.AddRange(new DataGridViewColumn[] {
                colIdProducto, colProducto, colPrecio, colCantidad, colSubTotal, colQuitar });
            dgvDetalle.CellContentClick += dgvDetalle_CellContentClick;

            colIdProducto.HeaderText = "IdProducto";
            colIdProducto.Name = "colIdProducto";
            colIdProducto.Visible = false;

            colProducto.HeaderText = "Producto";
            colProducto.Name = "colProducto";

            colPrecio.HeaderText = "Precio";
            colPrecio.Name = "colPrecio";

            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";

            colSubTotal.HeaderText = "SubTotal";
            colSubTotal.Name = "colSubTotal";

            colQuitar.HeaderText = "";
            colQuitar.Name = "colQuitar";
            colQuitar.Text = "Quitar";
            colQuitar.UseColumnTextForButtonValue = true;

            // ====== PANELES DE TOTALES ======
            pnlTotales.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlTotales.Controls.Add(lblTotal);
            pnlTotales.Controls.Add(txtTotal);
            pnlTotales.Controls.Add(lblPagaCon);
            pnlTotales.Controls.Add(cbFormaPago);
            pnlTotales.Controls.Add(lblCambio);
            pnlTotales.Controls.Add(txtCambio);
            pnlTotales.Controls.Add(txtPagaCon);
            pnlTotales.Location = new Point(960, 735);
            pnlTotales.Size = new Size(400, 90);

            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(10, 15);
            lblTotal.Text = "Total a Pagar:";

            txtTotal.Location = new Point(110, 12);
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(100, 27);
            txtTotal.Text = "0.00";

            lblPagaCon.AutoSize = true;
            lblPagaCon.Location = new Point(225, 15);
            lblPagaCon.Text = "Forma Pago:";

            cbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFormaPago.Items.AddRange(new object[] { "Efectivo", "Débito", "Crédito", "Transferencia" });
            cbFormaPago.Location = new Point(310, 12);
            cbFormaPago.Size = new Size(85, 27);
            cbFormaPago.SelectedIndexChanged += cbFormaPago_SelectedIndexChanged;

            lblCambio.AutoSize = true;
            lblCambio.Location = new Point(10, 55);
            lblCambio.Text = "Cambio:";

            txtCambio.Location = new Point(110, 52);
            txtCambio.ReadOnly = true;
            txtCambio.Size = new Size(100, 27);
            txtCambio.Text = "0.00";

            txtPagaCon.Location = new Point(310, 52);
            txtPagaCon.Size = new Size(85, 27);
            txtPagaCon.TextChanged += txtPagaCon_TextChanged;
            txtPagaCon.KeyPress += txtPagaCon_KeyPress;

            // ====== BOTONES FINALES ======
            btnCrearVenta.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCrearVenta.BackColor = Color.SeaGreen;
            btnCrearVenta.FlatStyle = FlatStyle.Flat;
            btnCrearVenta.ForeColor = Color.White;
            btnCrearVenta.Location = new Point(1380, 760);
            btnCrearVenta.Size = new Size(150, 40);
            btnCrearVenta.Text = "Crear Venta";
            btnCrearVenta.Click += btnCrearVenta_Click;

            btnHistorialVentas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnHistorialVentas.BackColor = SystemColors.ActiveCaption;
            btnHistorialVentas.FlatStyle = FlatStyle.Flat;
            btnHistorialVentas.Location = new Point(50, 760);
            btnHistorialVentas.Size = new Size(150, 40);
            btnHistorialVentas.Text = "Historial de Ventas";
            btnHistorialVentas.Click += btnHistorialVentas_Click;

            // ====== CONTROL PRINCIPAL ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(btnHistorialVentas);
            Controls.Add(btnCrearVenta);
            Controls.Add(pnlTotales);
            Controls.Add(dgvDetalle);
            Controls.Add(grpProducto);
            Controls.Add(grpCliente);
            Controls.Add(grpVenta);
            Name = "VentaControl";
            Size = new Size(1583, 830);

            grpVenta.ResumeLayout(false);
            grpVenta.PerformLayout();
            grpCliente.ResumeLayout(false);
            grpCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCliente).EndInit();
            grpProducto.ResumeLayout(false);
            grpProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbProducto).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            pnlTotales.ResumeLayout(false);
            pnlTotales.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private GroupBox grpVenta;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblTipoDoc;
        private ComboBox cbTipoDoc;
        private GroupBox grpCliente;
        private Label lblDocumento;
        private TextBox txtDocumentoCliente;
        private Button btnBuscarCliente;
        private Label lblNombreCliente;
        private TextBox txtNombreCliente;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private PictureBox pbCliente;
        private GroupBox grpProducto;
        private PictureBox pbProducto;
        private Label lblCodProd;
        private TextBox txtCodProducto;
        private Button btnBuscarProducto;
        private Label lblNombreProd;
        private TextBox txtNombreProd;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblStock;
        private TextBox txtStock;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Button btnAgregar;
        private DataGridView dgvDetalle;
        private DataGridViewTextBoxColumn colIdProducto;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colSubTotal;
        private DataGridViewButtonColumn colQuitar;
        private Panel pnlTotales;
        private Label lblTotal;
        private TextBox txtTotal;
        private Label lblPagaCon;
        private ComboBox cbFormaPago;
        private Label lblCambio;
        private TextBox txtCambio;
        private TextBox txtPagaCon;
        private Button btnCrearVenta;
        private Button btnHistorialVentas;
    }
}
