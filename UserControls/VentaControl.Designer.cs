namespace nikeproject.Forms
{
    partial class VentaControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.lbTituloDetalle = new System.Windows.Forms.Label();
            this.lbCliente = new System.Windows.Forms.Label();
            this.txtClienteSeleccionado = new System.Windows.Forms.TextBox();
            this.lbDocumento = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.lbMontoTotal = new System.Windows.Forms.Label();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();

            this.lbListaVentas = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.colSeleccionarVenta = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.lbClientes = new System.Windows.Forms.Label();
            this.dgvClientesVenta = new System.Windows.Forms.DataGridView();

            this.lbProductos = new System.Windows.Forms.Label();
            this.dgvProductosVenta = new System.Windows.Forms.DataGridView();

            this.lbDetalle = new System.Windows.Forms.Label();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.colIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.SuspendLayout();

            // 🔹 Panel lateral
            this.pnlDetalle.BackColor = System.Drawing.Color.White;
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDetalle.Size = new System.Drawing.Size(258, 720);

            // 🔹 Título Detalle
            this.lbTituloDetalle.AutoSize = true;
            this.lbTituloDetalle.BackColor = System.Drawing.Color.White;
            this.lbTituloDetalle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lbTituloDetalle.Location = new System.Drawing.Point(20, 15);
            this.lbTituloDetalle.Text = "Detalle Venta";

            // 🔹 Cliente
            this.lbCliente.AutoSize = true;
            this.lbCliente.BackColor = System.Drawing.Color.White;
            this.lbCliente.Location = new System.Drawing.Point(20, 60);
            this.lbCliente.Text = "Cliente:";
            this.txtClienteSeleccionado.Location = new System.Drawing.Point(20, 78);
            this.txtClienteSeleccionado.Size = new System.Drawing.Size(207, 23);
            this.txtClienteSeleccionado.ReadOnly = true;

            // 🔹 Documento
            this.lbDocumento.AutoSize = true;
            this.lbDocumento.BackColor = System.Drawing.Color.White;
            this.lbDocumento.Location = new System.Drawing.Point(20, 110);
            this.lbDocumento.Text = "Nro Documento:";
            this.txtNumeroDocumento.Location = new System.Drawing.Point(20, 128);
            this.txtNumeroDocumento.Size = new System.Drawing.Size(207, 23);
            this.txtNumeroDocumento.ReadOnly = true;

            // 🔹 Monto Total
            this.lbMontoTotal.AutoSize = true;
            this.lbMontoTotal.BackColor = System.Drawing.Color.White;
            this.lbMontoTotal.Location = new System.Drawing.Point(20, 165);
            this.lbMontoTotal.Text = "Monto Total:";
            this.txtMontoTotal.Location = new System.Drawing.Point(20, 183);
            this.txtMontoTotal.Size = new System.Drawing.Size(207, 23);
            this.txtMontoTotal.ReadOnly = true;

            // 🔹 Botones CRUD
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(20, 230);
            this.btnGuardar.Size = new System.Drawing.Size(207, 23);

            this.btnEditar.Text = "Editar";
            this.btnEditar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(20, 260);
            this.btnEditar.Size = new System.Drawing.Size(207, 23);

            this.btnEliminar.Text = "Dar de Baja";
            this.btnEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(20, 290);
            this.btnEliminar.Size = new System.Drawing.Size(207, 23);

            // 🔹 Lista de Ventas
            this.lbListaVentas.BackColor = System.Drawing.Color.White;
            this.lbListaVentas.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lbListaVentas.Location = new System.Drawing.Point(258, 0);
            this.lbListaVentas.Size = new System.Drawing.Size(822, 40);
            this.lbListaVentas.Text = "Lista de Ventas";
            this.lbListaVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 🔹 dgvVentas
            this.dgvVentas.Location = new System.Drawing.Point(258, 40);
            this.dgvVentas.Size = new System.Drawing.Size(822, 160);
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.MultiSelect = false;
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colSeleccionarVenta,
                this.colIdVenta,
                this.colNumeroDocumento,
                this.colCliente,
                this.colFechaRegistro,
                this.colMontoTotal,
                this.colEstado
            });

            this.colSeleccionarVenta.HeaderText = "";
            this.colSeleccionarVenta.Text = "Sel.";
            this.colSeleccionarVenta.UseColumnTextForButtonValue = true;
            this.colSeleccionarVenta.Width = 40;

            this.colIdVenta.DataPropertyName = "IdVenta";
            this.colIdVenta.Visible = false;

            this.colNumeroDocumento.DataPropertyName = "NumeroDocumento";
            this.colNumeroDocumento.HeaderText = "Documento";

            this.colCliente.DataPropertyName = "ClienteNombre";
            this.colCliente.HeaderText = "Cliente";

            this.colFechaRegistro.DataPropertyName = "FechaRegistro";
            this.colFechaRegistro.HeaderText = "Fecha";

            this.colMontoTotal.DataPropertyName = "MontoTotal";
            this.colMontoTotal.HeaderText = "Monto Total";

            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";

            // 🔹 Clientes
            this.lbClientes.Text = "Clientes";
            this.lbClientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbClientes.Location = new System.Drawing.Point(258, 210);

            this.dgvClientesVenta.Location = new System.Drawing.Point(258, 240);
            this.dgvClientesVenta.Size = new System.Drawing.Size(400, 200);
            this.dgvClientesVenta.ReadOnly = true;
            this.dgvClientesVenta.MultiSelect = false;
            this.dgvClientesVenta.AllowUserToAddRows = false;
            this.dgvClientesVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // 🔹 Productos
            this.lbProductos.Text = "Productos";
            this.lbProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbProductos.Location = new System.Drawing.Point(680, 210);

            this.dgvProductosVenta.Location = new System.Drawing.Point(680, 240);
            this.dgvProductosVenta.Size = new System.Drawing.Size(400, 200);
            this.dgvProductosVenta.ReadOnly = true;
            this.dgvProductosVenta.MultiSelect = false;
            this.dgvProductosVenta.AllowUserToAddRows = false;
            this.dgvProductosVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // 🔹 Detalle Venta
            this.lbDetalle.Text = "Detalle de Venta";
            this.lbDetalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbDetalle.Location = new System.Drawing.Point(258, 450);

            this.dgvDetalleVenta.Location = new System.Drawing.Point(258, 480);
            this.dgvDetalleVenta.Size = new System.Drawing.Size(822, 200);
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleVenta.ReadOnly = true;
            this.dgvDetalleVenta.MultiSelect = false;
            this.dgvDetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colIdProducto,
                this.colProducto,
                this.colCantidad,
                this.colPrecioUnitario,
                this.colSubTotal
            });

            this.colIdProducto.DataPropertyName = "IdProducto";
            this.colIdProducto.HeaderText = "IdProducto";
            this.colIdProducto.Visible = false;

            this.colProducto.DataPropertyName = "ProductoNombre";
            this.colProducto.HeaderText = "Producto";

            this.colCantidad.DataPropertyName = "Cantidad";
            this.colCantidad.HeaderText = "Cantidad";

            this.colPrecioUnitario.DataPropertyName = "PrecioUnitario";
            this.colPrecioUnitario.HeaderText = "Precio Unitario";

            this.colSubTotal.DataPropertyName = "SubTotal";
            this.colSubTotal.HeaderText = "Subtotal";

            // 🔹 UserControl VentaControl
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.dgvDetalleVenta);
            this.Controls.Add(this.lbDetalle);
            this.Controls.Add(this.dgvProductosVenta);
            this.Controls.Add(this.lbProductos);
            this.Controls.Add(this.dgvClientesVenta);
            this.Controls.Add(this.lbClientes);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.lbListaVentas);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.lbMontoTotal);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.lbDocumento);
            this.Controls.Add(this.txtClienteSeleccionado);
            this.Controls.Add(this.lbCliente);
            this.Controls.Add(this.lbTituloDetalle);
            this.Controls.Add(this.pnlDetalle);
            this.Size = new System.Drawing.Size(1100, 720);

            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Label lbTituloDetalle;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.TextBox txtClienteSeleccionado;
        private System.Windows.Forms.Label lbDocumento;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label lbMontoTotal;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lbListaVentas;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DataGridViewButtonColumn colSeleccionarVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Label lbClientes;
        private System.Windows.Forms.DataGridView dgvClientesVenta;
        private System.Windows.Forms.Label lbProductos;
        private System.Windows.Forms.DataGridView dgvProductosVenta;
        private System.Windows.Forms.Label lbDetalle;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;
    }
}
