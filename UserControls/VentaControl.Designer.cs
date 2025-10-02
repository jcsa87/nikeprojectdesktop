namespace nikeproject.UserControls
{
    partial class VentaControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
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
            grpVenta.SuspendLayout();
            grpCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCliente).BeginInit();
            grpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbProducto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            pnlTotales.SuspendLayout();
            SuspendLayout();
            // 
            // grpVenta
            // 
            grpVenta.Controls.Add(lblFecha);
            grpVenta.Controls.Add(dtpFecha);
            grpVenta.Controls.Add(lblTipoDoc);
            grpVenta.Controls.Add(cbTipoDoc);
            grpVenta.Location = new Point(15, 10);
            grpVenta.Name = "grpVenta";
            grpVenta.Size = new Size(950, 60);
            grpVenta.TabIndex = 0;
            grpVenta.TabStop = false;
            grpVenta.Text = "Información Venta";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(15, 28);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(65, 24);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 1;
            // 
            // lblTipoDoc
            // 
            lblTipoDoc.AutoSize = true;
            lblTipoDoc.Location = new Point(290, 28);
            lblTipoDoc.Name = "lblTipoDoc";
            lblTipoDoc.Size = new Size(99, 15);
            lblTipoDoc.TabIndex = 2;
            lblTipoDoc.Text = "Tipo Documento:";
            // 
            // cbTipoDoc
            // 
            cbTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoDoc.Location = new Point(400, 24);
            cbTipoDoc.Name = "cbTipoDoc";
            cbTipoDoc.Size = new Size(160, 23);
            cbTipoDoc.TabIndex = 3;
            // 
            // grpCliente
            // 
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
            grpCliente.Location = new Point(15, 80);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(950, 70);
            grpCliente.TabIndex = 1;
            grpCliente.TabStop = false;
            grpCliente.Text = "Información Cliente";
            // 
            // pbCliente
            // 
            pbCliente.Image = (Image)resources.GetObject("pbCliente.Image");
            pbCliente.InitialImage = (Image)resources.GetObject("pbCliente.InitialImage");
            pbCliente.Location = new Point(844, 15);
            pbCliente.Name = "pbCliente";
            pbCliente.Size = new Size(88, 47);
            pbCliente.SizeMode = PictureBoxSizeMode.Zoom;
            pbCliente.TabIndex = 13;
            pbCliente.TabStop = false;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(15, 30);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(96, 15);
            lblDocumento.TabIndex = 0;
            lblDocumento.Text = "Nro Documento:";
            // 
            // txtDocumentoCliente
            // 
            txtDocumentoCliente.Location = new Point(120, 27);
            txtDocumentoCliente.Name = "txtDocumentoCliente";
            txtDocumentoCliente.Size = new Size(160, 23);
            txtDocumentoCliente.TabIndex = 1;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Location = new Point(285, 27);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(34, 23);
            btnBuscarCliente.TabIndex = 2;
            btnBuscarCliente.Text = "🔍";
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(608, 41);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(46, 15);
            lblCorreo.TabIndex = 3;
            lblCorreo.Text = "Correo:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(605, 16);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(55, 15);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "Telefono:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(407, 42);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido:";
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(407, 17);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(54, 15);
            lblNombreCliente.TabIndex = 3;
            lblNombreCliente.Text = "Nombre:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(677, 39);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.ReadOnly = true;
            txtCorreo.Size = new Size(124, 23);
            txtCorreo.TabIndex = 4;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(473, 38);
            txtApellido.Name = "txtApellido";
            txtApellido.ReadOnly = true;
            txtApellido.Size = new Size(124, 23);
            txtApellido.TabIndex = 4;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(677, 13);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.ReadOnly = true;
            txtTelefono.Size = new Size(124, 23);
            txtTelefono.TabIndex = 4;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(473, 13);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.ReadOnly = true;
            txtNombreCliente.Size = new Size(124, 23);
            txtNombreCliente.TabIndex = 4;
            // 
            // grpProducto
            // 
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
            grpProducto.Location = new Point(15, 160);
            grpProducto.Name = "grpProducto";
            grpProducto.Size = new Size(950, 90);
            grpProducto.TabIndex = 2;
            grpProducto.TabStop = false;
            grpProducto.Text = "Información Producto";
            // 
            // pbProducto
            // 
            pbProducto.Image = (Image)resources.GetObject("pbProducto.Image");
            pbProducto.InitialImage = (Image)resources.GetObject("pbProducto.InitialImage");
            pbProducto.Location = new Point(829, 12);
            pbProducto.Name = "pbProducto";
            pbProducto.Size = new Size(115, 72);
            pbProducto.SizeMode = PictureBoxSizeMode.Zoom;
            pbProducto.TabIndex = 12;
            pbProducto.TabStop = false;
            // 
            // lblCodProd
            // 
            lblCodProd.AutoSize = true;
            lblCodProd.Location = new Point(15, 30);
            lblCodProd.Name = "lblCodProd";
            lblCodProd.Size = new Size(87, 15);
            lblCodProd.TabIndex = 0;
            lblCodProd.Text = "Cod. Producto:";
            // 
            // txtCodProducto
            // 
            txtCodProducto.Location = new Point(110, 27);
            txtCodProducto.Name = "txtCodProducto";
            txtCodProducto.Size = new Size(160, 23);
            txtCodProducto.TabIndex = 1;
            // 
            // btnBuscarProducto
            // 
            btnBuscarProducto.Location = new Point(275, 27);
            btnBuscarProducto.Name = "btnBuscarProducto";
            btnBuscarProducto.Size = new Size(34, 23);
            btnBuscarProducto.TabIndex = 2;
            btnBuscarProducto.Text = "🔍";
            btnBuscarProducto.Click += btnBuscarProducto_Click;
            // 
            // lblNombreProd
            // 
            lblNombreProd.AutoSize = true;
            lblNombreProd.Location = new Point(330, 30);
            lblNombreProd.Name = "lblNombreProd";
            lblNombreProd.Size = new Size(59, 15);
            lblNombreProd.TabIndex = 3;
            lblNombreProd.Text = "Producto:";
            // 
            // txtNombreProd
            // 
            txtNombreProd.Location = new Point(395, 27);
            txtNombreProd.Name = "txtNombreProd";
            txtNombreProd.ReadOnly = true;
            txtNombreProd.Size = new Size(129, 23);
            txtNombreProd.TabIndex = 4;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(545, 30);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(43, 15);
            lblPrecio.TabIndex = 5;
            lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(605, 28);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(80, 23);
            txtPrecio.TabIndex = 6;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(696, 31);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 7;
            lblStock.Text = "Stock:";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(741, 28);
            txtStock.Name = "txtStock";
            txtStock.ReadOnly = true;
            txtStock.Size = new Size(60, 23);
            txtStock.TabIndex = 8;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(15, 58);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 9;
            lblCantidad.Text = "Cantidad:";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(110, 55);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(80, 23);
            nudCantidad.TabIndex = 10;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(205, 55);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(95, 23);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvDetalle
            // 
            dgvDetalle.Columns.AddRange(new DataGridViewColumn[] { colIdProducto, colProducto, colPrecio, colCantidad, colSubTotal, colQuitar });
            dgvDetalle.Location = new Point(15, 260);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.RowTemplate.Height = 26;
            dgvDetalle.Size = new Size(950, 250);
            dgvDetalle.TabIndex = 3;
            // 
            // colIdProducto
            // 
            colIdProducto.HeaderText = "IdProducto";
            colIdProducto.Name = "colIdProducto";
            colIdProducto.Visible = false;
            // 
            // colProducto
            // 
            colProducto.HeaderText = "Producto";
            colProducto.Name = "colProducto";
            // 
            // colPrecio
            // 
            colPrecio.HeaderText = "Precio";
            colPrecio.Name = "colPrecio";
            // 
            // colCantidad
            // 
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            // 
            // colSubTotal
            // 
            colSubTotal.HeaderText = "Sub Total";
            colSubTotal.Name = "colSubTotal";
            // 
            // colQuitar
            // 
            colQuitar.HeaderText = "";
            colQuitar.Name = "colQuitar";
            colQuitar.Text = "Quitar";
            colQuitar.UseColumnTextForButtonValue = true;
            dgvDetalle.CellContentClick += dgvDetalle_CellContentClick;
            // 
            // pnlTotales
            // 
            pnlTotales.Controls.Add(lblTotal);
            pnlTotales.Controls.Add(txtTotal);
            pnlTotales.Controls.Add(lblPagaCon);
            pnlTotales.Controls.Add(cbFormaPago);
            pnlTotales.Controls.Add(lblCambio);
            pnlTotales.Controls.Add(txtCambio);
            pnlTotales.Controls.Add(txtPagaCon);
            pnlTotales.Location = new Point(437, 516);
            pnlTotales.Name = "pnlTotales";
            pnlTotales.Size = new Size(415, 80);
            pnlTotales.TabIndex = 4;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(10, 15);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(77, 15);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total a Pagar:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(100, 12);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(100, 23);
            txtTotal.TabIndex = 1;
            txtTotal.Text = "0.00";
            // 
            // lblPagaCon
            // 
            lblPagaCon.AutoSize = true;
            lblPagaCon.Location = new Point(207, 15);
            lblPagaCon.Name = "lblPagaCon";
            lblPagaCon.Size = new Size(59, 15);
            lblPagaCon.TabIndex = 2;
            lblPagaCon.Text = "Paga con:";
            lblPagaCon.Click += lblPagaCon_Click;
            // 
            // cbFormaPago
            // 
            cbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFormaPago.Location = new Point(272, 15);
            cbFormaPago.Name = "cbFormaPago";
            cbFormaPago.Size = new Size(88, 23);
            cbFormaPago.TabIndex = 3;
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.Location = new Point(10, 45);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(52, 15);
            lblCambio.TabIndex = 4;
            lblCambio.Text = "Cambio:";
            // 
            // txtCambio
            // 
            txtCambio.Location = new Point(100, 42);
            txtCambio.Name = "txtCambio";
            txtCambio.ReadOnly = true;
            txtCambio.Size = new Size(100, 23);
            txtCambio.TabIndex = 5;
            txtCambio.Text = "0.00";
            // 
            // txtPagaCon
            // 
            txtPagaCon.Location = new Point(272, 42);
            txtPagaCon.Name = "txtPagaCon";
            txtPagaCon.Size = new Size(100, 23);
            txtPagaCon.TabIndex = 7;
            // 
            // btnCrearVenta
            // 
            btnCrearVenta.BackColor = Color.SeaGreen;
            btnCrearVenta.FlatAppearance.BorderSize = 0;
            btnCrearVenta.FlatStyle = FlatStyle.Flat;
            btnCrearVenta.ForeColor = Color.White;
            btnCrearVenta.Location = new Point(872, 527);
            btnCrearVenta.Name = "btnCrearVenta";
            btnCrearVenta.Size = new Size(75, 23);
            btnCrearVenta.TabIndex = 0;
            btnCrearVenta.Text = "Crear Venta";
            btnCrearVenta.UseVisualStyleBackColor = false;
            btnCrearVenta.Click += btnCrearVenta_Click;
            // 
            // VentaControl
            // 
            Controls.Add(btnCrearVenta);
            Controls.Add(grpVenta);
            Controls.Add(grpCliente);
            Controls.Add(grpProducto);
            Controls.Add(dgvDetalle);
            Controls.Add(pnlTotales);
            Name = "VentaControl";
            Size = new Size(980, 620);
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
            // grpHistorial
            GroupBox grpHistorial = new GroupBox();
            grpHistorial.Text = "Historial de Ventas";
            grpHistorial.Location = new Point(980, 10); // al lado derecho
            grpHistorial.Size = new Size(500, 590);     // ajusta según el form
            grpHistorial.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // dgvVentas
            dgvVentas = new DataGridView();
            dgvVentas.Dock = DockStyle.Fill;
            dgvVentas.ReadOnly = true;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grpHistorial.Controls.Add(dgvVentas);
            Controls.Add(grpHistorial);


        }


        #endregion
        public DataGridView dgvVentas;

        public System.Windows.Forms.GroupBox grpVenta;
        public System.Windows.Forms.Label lblFecha;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        public System.Windows.Forms.Label lblTipoDoc;
        public System.Windows.Forms.ComboBox cbTipoDoc;


        public System.Windows.Forms.GroupBox grpCliente;
        public System.Windows.Forms.Label lblDocumento;
        public System.Windows.Forms.TextBox txtDocumentoCliente;
        public System.Windows.Forms.Button btnBuscarCliente;
        public System.Windows.Forms.Label lblNombreCliente;
        public System.Windows.Forms.TextBox txtNombreCliente;

        public System.Windows.Forms.GroupBox grpProducto;
        public System.Windows.Forms.Label lblCodProd;
        public System.Windows.Forms.TextBox txtCodProducto;
        public System.Windows.Forms.Button btnBuscarProducto;
        public System.Windows.Forms.Label lblNombreProd;
        public System.Windows.Forms.TextBox txtNombreProd;
        public System.Windows.Forms.Label lblPrecio;
        public System.Windows.Forms.TextBox txtPrecio;
        public System.Windows.Forms.Label lblStock;
        public System.Windows.Forms.TextBox txtStock;
        public System.Windows.Forms.Label lblCantidad;
        public System.Windows.Forms.NumericUpDown nudCantidad;
        public System.Windows.Forms.Button btnAgregar;

        public System.Windows.Forms.DataGridView dgvDetalle;
        public System.Windows.Forms.DataGridViewTextBoxColumn colIdProducto;
        public System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        public System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        public System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        public System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;
        public System.Windows.Forms.DataGridViewButtonColumn colQuitar;

        public System.Windows.Forms.Panel pnlTotales;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.Label lblPagaCon;
        public System.Windows.Forms.Label lblCambio;
        public System.Windows.Forms.TextBox txtCambio;
        public System.Windows.Forms.Button btnCrearVenta;
        public PictureBox pbProducto;
        public Label lblCorreo;
        public Label lblTelefono;
        public Label lblApellido;
        public TextBox txtCorreo;
        public TextBox txtApellido;
        public TextBox txtTelefono;
        public ComboBox cbFormaPago;
        public TextBox txtPagaCon;
        public PictureBox pbCliente;
    }
}
