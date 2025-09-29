namespace nikeproject.UserControls
{
    partial class ProductoControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary 
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

        #region Component Designer generated code

        /// <summary 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            lblTituloDetalle = new Label();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblNombreProd = new Label();
            txtNombreProd = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblCategoria = new Label();
            cbCategoria = new ComboBox();
            lblStock = new Label();
            txtStock = new TextBox();
            lblPrecioCompra = new Label();
            txtPrecioCompra = new TextBox();
            lblPrecioVenta = new Label();
            txtPrecioVenta = new TextBox();
            lblEstado = new Label();
            cbEstadoDetalle = new ComboBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            lblListaProductos = new Label();
            cbBusqueda = new ComboBox();
            txtBusqueda = new TextBox();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            btnLimpiar = new FontAwesome.Sharp.IconButton();
            lblBusqueda = new Label();
            dgvProductos = new DataGridView();
            btnSeleccionar = new DataGridViewButtonColumn();
            idProducto = new DataGridViewTextBoxColumn();
            Codigo = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            EstadoValor = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(258, 702);
            label1.TabIndex = 8;
            // 
            // lblTituloDetalle
            // 
            lblTituloDetalle.AutoSize = true;
            lblTituloDetalle.BackColor = Color.White;
            lblTituloDetalle.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTituloDetalle.Location = new Point(20, 10);
            lblTituloDetalle.Name = "lblTituloDetalle";
            lblTituloDetalle.Size = new Size(183, 25);
            lblTituloDetalle.TabIndex = 9;
            lblTituloDetalle.Text = "Detalle Producto";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.BackColor = Color.White;
            lblCodigo.Location = new Point(20, 45);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(49, 15);
            lblCodigo.TabIndex = 9;
            lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Location = new Point(20, 63);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(207, 23);
            txtCodigo.TabIndex = 10;
            // 
            // lblNombreProd
            // 
            lblNombreProd.AutoSize = true;
            lblNombreProd.BackColor = Color.White;
            lblNombreProd.Location = new Point(20, 95);
            lblNombreProd.Name = "lblNombreProd";
            lblNombreProd.Size = new Size(54, 15);
            lblNombreProd.TabIndex = 9;
            lblNombreProd.Text = "Nombre:";
            // 
            // txtNombreProd
            // 
            txtNombreProd.BorderStyle = BorderStyle.FixedSingle;
            txtNombreProd.Location = new Point(20, 113);
            txtNombreProd.Name = "txtNombreProd";
            txtNombreProd.Size = new Size(207, 23);
            txtNombreProd.TabIndex = 10;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.BackColor = Color.White;
            lblDescripcion.Location = new Point(20, 143);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 9;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Location = new Point(20, 161);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(207, 50);
            txtDescripcion.TabIndex = 10;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.BackColor = Color.White;
            lblCategoria.Location = new Point(20, 220);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(61, 15);
            lblCategoria.TabIndex = 9;
            lblCategoria.Text = "Categoría:";
            // 
            // cbCategoria
            // 
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(20, 238);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(205, 23);
            cbCategoria.TabIndex = 11;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.BackColor = Color.White;
            lblStock.Location = new Point(20, 274);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 9;
            lblStock.Text = "Stock:";
            // 
            // txtStock
            // 
            txtStock.BorderStyle = BorderStyle.FixedSingle;
            txtStock.Location = new Point(20, 292);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(207, 23);
            txtStock.TabIndex = 10;
            // 
            // lblPrecioCompra
            // 
            lblPrecioCompra.AutoSize = true;
            lblPrecioCompra.BackColor = Color.White;
            lblPrecioCompra.Location = new Point(20, 326);
            lblPrecioCompra.Name = "lblPrecioCompra";
            lblPrecioCompra.Size = new Size(88, 15);
            lblPrecioCompra.TabIndex = 9;
            lblPrecioCompra.Text = "Precio Compra:";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioCompra.Location = new Point(20, 344);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(207, 23);
            txtPrecioCompra.TabIndex = 10;
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.BackColor = Color.White;
            lblPrecioVenta.Location = new Point(20, 378);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(74, 15);
            lblPrecioVenta.TabIndex = 9;
            lblPrecioVenta.Text = "Precio Venta:";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioVenta.Location = new Point(20, 396);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(207, 23);
            txtPrecioVenta.TabIndex = 10;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.BackColor = Color.White;
            lblEstado.Location = new Point(20, 430);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 9;
            lblEstado.Text = "Estado:";
            // 
            // cbEstadoDetalle
            // 
            cbEstadoDetalle.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstadoDetalle.FormattingEnabled = true;
            cbEstadoDetalle.Location = new Point(20, 448);
            cbEstadoDetalle.Name = "cbEstadoDetalle";
            cbEstadoDetalle.Size = new Size(205, 23);
            cbEstadoDetalle.TabIndex = 11;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.ForestGreen;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderColor = Color.Black;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(20, 507);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(207, 23);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.RoyalBlue;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderColor = Color.Black;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(20, 536);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(207, 23);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Firebrick;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderColor = Color.Black;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(20, 565);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(207, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Dar de Baja";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // lblListaProductos
            // 
            lblListaProductos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblListaProductos.BackColor = Color.White;
            lblListaProductos.Font = new Font("Segoe UI", 15F);
            lblListaProductos.Location = new Point(257, 0);
            lblListaProductos.Name = "lblListaProductos";
            lblListaProductos.Size = new Size(616, 86);
            lblListaProductos.TabIndex = 15;
            lblListaProductos.Text = "Lista de Productos:";
            lblListaProductos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbBusqueda
            // 
            cbBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBusqueda.FormattingEnabled = true;
            cbBusqueda.Location = new Point(547, 34);
            cbBusqueda.Name = "cbBusqueda";
            cbBusqueda.Size = new Size(164, 23);
            cbBusqueda.TabIndex = 11;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BorderStyle = BorderStyle.FixedSingle;
            txtBusqueda.Location = new Point(717, 33);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(166, 23);
            txtBusqueda.TabIndex = 10;
            // 
            // btnBuscar
            // 
            btnBuscar.AutoSize = true;
            btnBuscar.BackColor = Color.DarkGray;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderColor = Color.Black;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.Black;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 16;
            btnBuscar.Location = new Point(908, 33);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(45, 24);
            btnBuscar.TabIndex = 14;
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.DarkGray;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderColor = Color.Black;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            btnLimpiar.IconColor = Color.Black;
            btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLimpiar.IconSize = 16;
            btnLimpiar.Location = new Point(970, 33);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(43, 24);
            btnLimpiar.TabIndex = 14;
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.BackColor = Color.White;
            lblBusqueda.Location = new Point(475, 36);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(66, 15);
            lblBusqueda.TabIndex = 9;
            lblBusqueda.Text = "Buscar por:";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { btnSeleccionar, idProducto, Codigo, Nombre, Descripcion, Categoria, Stock, PrecioCompra, PrecioVenta, Estado, EstadoValor });
            dgvProductos.Location = new Point(257, 78);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.RowTemplate.Height = 28;
            dgvProductos.Size = new Size(822, 624);
            dgvProductos.TabIndex = 16;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.HeaderText = "";
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.ReadOnly = true;
            btnSeleccionar.Width = 30;
            // 
            // idProducto
            // 
            idProducto.DataPropertyName = "idProducto";
            idProducto.HeaderText = "Id";
            idProducto.Name = "idProducto";
            idProducto.ReadOnly = true;
            idProducto.Visible = false;
            // 
            // Codigo
            // 
            Codigo.DataPropertyName = "Codigo";
            Codigo.HeaderText = "Código";
            Codigo.Name = "Codigo";
            Codigo.ReadOnly = true;
            Codigo.Width = 120;
            // 
            // Nombre
            // 
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 150;
            // 
            // Descripcion
            // 
            Descripcion.DataPropertyName = "Descripcion";
            Descripcion.HeaderText = "Descripción";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            Descripcion.Width = 180;
            // 
            // Categoria
            // 
            Categoria.DataPropertyName = "Categoria";
            Categoria.HeaderText = "Categoría";
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // Stock
            // 
            Stock.DataPropertyName = "Stock";
            Stock.HeaderText = "Stock";
            Stock.Name = "Stock";
            Stock.ReadOnly = true;
            // 
            // PrecioCompra
            // 
            PrecioCompra.DataPropertyName = "PrecioCompra";
            PrecioCompra.HeaderText = "P. Compra";
            PrecioCompra.Name = "PrecioCompra";
            PrecioCompra.ReadOnly = true;
            // 
            // PrecioVenta
            // 
            PrecioVenta.DataPropertyName = "PrecioVenta";
            PrecioVenta.HeaderText = "P. Venta";
            PrecioVenta.Name = "PrecioVenta";
            PrecioVenta.ReadOnly = true;
            // 
            // Estado
            // 
            Estado.DataPropertyName = "Estado";
            Estado.HeaderText = "Estado";
            Estado.Name = "Estado";
            Estado.ReadOnly = true;
            Estado.Visible = false;
            // 
            // EstadoValor
            // 
            EstadoValor.HeaderText = "EstadoValor";
            EstadoValor.Name = "EstadoValor";
            EstadoValor.ReadOnly = true;
            EstadoValor.Visible = false;
            // 
            // ProductoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            Controls.Add(dgvProductos);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(cbBusqueda);
            Controls.Add(txtBusqueda);
            Controls.Add(lblBusqueda);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(cbEstadoDetalle);
            Controls.Add(cbCategoria);
            Controls.Add(txtPrecioVenta);
            Controls.Add(txtPrecioCompra);
            Controls.Add(txtStock);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombreProd);
            Controls.Add(txtCodigo);
            Controls.Add(lblEstado);
            Controls.Add(lblPrecioVenta);
            Controls.Add(lblPrecioCompra);
            Controls.Add(lblStock);
            Controls.Add(lblCategoria);
            Controls.Add(lblDescripcion);
            Controls.Add(lblNombreProd);
            Controls.Add(lblCodigo);
            Controls.Add(lblTituloDetalle);
            Controls.Add(label1);
            Controls.Add(lblListaProductos);
            Name = "ProductoControl";
            Size = new Size(1082, 702);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblTituloDetalle;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblNombreProd;
        private TextBox txtNombreProd;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblCategoria;
        private ComboBox cbCategoria;
        private Label lblStock;
        private TextBox txtStock;
        private Label lblPrecioCompra;
        private TextBox txtPrecioCompra;
        private Label lblPrecioVenta;
        private TextBox txtPrecioVenta;
        private Label lblEstado;
        private ComboBox cbEstadoDetalle;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Label lblListaProductos;
        private ComboBox cbBusqueda;
        private TextBox txtBusqueda;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private Label lblBusqueda;
        private DataGridView dgvProductos;
        private DataGridViewButtonColumn btnSeleccionar;
        private DataGridViewTextBoxColumn idProducto;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn Stock;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn EstadoValor;
    }
}