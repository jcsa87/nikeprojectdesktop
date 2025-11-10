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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductoControl));
            label1 = new Label();
            lblTituloDetalle = new Label();
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
            idProducto = new DataGridViewTextBoxColumn();
            Codigo = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            EstadoValor = new DataGridViewTextBoxColumn();
            lbCargarImagen = new Label();
            btnCargarImagen = new Button();
            pBImagenProducto = new PictureBox();
            txtImagenRuta = new TextBox();
            lbCodigo = new Label();
            txtCodigo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBImagenProducto).BeginInit();
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
            lblTituloDetalle.Location = new Point(30, 8);
            lblTituloDetalle.Name = "lblTituloDetalle";
            lblTituloDetalle.Size = new Size(171, 25);
            lblTituloDetalle.TabIndex = 9;
            lblTituloDetalle.Text = "Detalle Producto";
            // 
            // lblNombreProd
            // 
            lblNombreProd.AutoSize = true;
            lblNombreProd.BackColor = Color.White;
            lblNombreProd.Location = new Point(13, 175);
            lblNombreProd.Name = "lblNombreProd";
            lblNombreProd.Size = new Size(54, 15);
            lblNombreProd.TabIndex = 9;
            lblNombreProd.Text = "Nombre:";
            // 
            // txtNombreProd
            // 
            txtNombreProd.BorderStyle = BorderStyle.FixedSingle;
            txtNombreProd.Location = new Point(13, 193);
            txtNombreProd.Name = "txtNombreProd";
            txtNombreProd.Size = new Size(207, 23);
            txtNombreProd.TabIndex = 10;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.BackColor = Color.White;
            lblDescripcion.Location = new Point(13, 230);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 9;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Location = new Point(13, 248);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(207, 50);
            txtDescripcion.TabIndex = 10;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.BackColor = Color.White;
            lblCategoria.Location = new Point(13, 312);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(61, 15);
            lblCategoria.TabIndex = 9;
            lblCategoria.Text = "Categoría:";
            // 
            // cbCategoria
            // 
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(15, 330);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(205, 23);
            cbCategoria.TabIndex = 11;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.BackColor = Color.White;
            lblStock.Location = new Point(13, 365);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 9;
            lblStock.Text = "Stock:";
            // 
            // txtStock
            // 
            txtStock.BorderStyle = BorderStyle.FixedSingle;
            txtStock.Location = new Point(13, 383);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(207, 23);
            txtStock.TabIndex = 10;
            txtStock.KeyPress += txtNumerico_KeyPress;
            // 
            // lblPrecioCompra
            // 
            lblPrecioCompra.AutoSize = true;
            lblPrecioCompra.BackColor = Color.White;
            lblPrecioCompra.Location = new Point(13, 423);
            lblPrecioCompra.Name = "lblPrecioCompra";
            lblPrecioCompra.Size = new Size(89, 15);
            lblPrecioCompra.TabIndex = 9;
            lblPrecioCompra.Text = "Precio Compra:";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioCompra.Location = new Point(13, 441);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(207, 23);
            txtPrecioCompra.TabIndex = 10;
            txtPrecioCompra.KeyPress += txtDecimal_KeyPress;
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.BackColor = Color.White;
            lblPrecioVenta.Location = new Point(13, 479);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.Size = new Size(75, 15);
            lblPrecioVenta.TabIndex = 9;
            lblPrecioVenta.Text = "Precio Venta:";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioVenta.Location = new Point(13, 497);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(207, 23);
            txtPrecioVenta.TabIndex = 10;
            txtPrecioVenta.KeyPress += txtDecimal_KeyPress;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.ForestGreen;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderColor = Color.Black;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(17, 600);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(207, 23);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.RoyalBlue;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderColor = Color.Black;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(17, 629);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(207, 23);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Firebrick;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderColor = Color.Black;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(17, 659);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(207, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Dar de Baja";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblListaProductos
            // 
            lblListaProductos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblListaProductos.BackColor = Color.White;
            lblListaProductos.Font = new Font("Segoe UI", 15F);
            lblListaProductos.Location = new Point(257, 0);
            lblListaProductos.Name = "lblListaProductos";
            lblListaProductos.Size = new Size(822, 86);
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
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { idProducto, Codigo, Nombre, Categoria, Descripcion, Stock, PrecioCompra, PrecioVenta, Estado, EstadoValor });
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
            dgvProductos.DataBindingComplete += dgvProductos_DataBindingComplete;
            // 
            // idProducto
            // 
            idProducto.DataPropertyName = "idProducto";
            idProducto.HeaderText = "Id";
            idProducto.Name = "idProducto";
            idProducto.ReadOnly = true;
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
            // Categoria
            // 
            Categoria.DataPropertyName = "CategoriaNombre";
            Categoria.HeaderText = "Categoría";
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // Descripcion
            // 
            Descripcion.DataPropertyName = "Descripcion";
            Descripcion.HeaderText = "Descripción";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            Descripcion.Width = 180;
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
            // lbCargarImagen
            // 
            lbCargarImagen.AutoSize = true;
            lbCargarImagen.BackColor = Color.White;
            lbCargarImagen.Location = new Point(15, 524);
            lbCargarImagen.Name = "lbCargarImagen";
            lbCargarImagen.Size = new Size(50, 15);
            lbCargarImagen.TabIndex = 17;
            lbCargarImagen.Text = "Imagen:";
            // 
            // btnCargarImagen
            // 
            btnCargarImagen.Location = new Point(13, 542);
            btnCargarImagen.Name = "btnCargarImagen";
            btnCargarImagen.Size = new Size(114, 23);
            btnCargarImagen.TabIndex = 18;
            btnCargarImagen.Text = "Cargar Imagen";
            btnCargarImagen.UseVisualStyleBackColor = true;
            btnCargarImagen.Click += btnCargarImagen_Click;
            // 
            // pBImagenProducto
            // 
            pBImagenProducto.BackColor = SystemColors.ButtonFace;
            pBImagenProducto.Image = (Image)resources.GetObject("pBImagenProducto.Image");
            pBImagenProducto.Location = new Point(52, 36);
            pBImagenProducto.Name = "pBImagenProducto";
            pBImagenProducto.Size = new Size(130, 73);
            pBImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
            pBImagenProducto.TabIndex = 19;
            pBImagenProducto.TabStop = false;
            // 
            // txtImagenRuta
            // 
            txtImagenRuta.BorderStyle = BorderStyle.None;
            txtImagenRuta.Location = new Point(17, 571);
            txtImagenRuta.Name = "txtImagenRuta";
            txtImagenRuta.Size = new Size(207, 16);
            txtImagenRuta.TabIndex = 0;
            txtImagenRuta.TextChanged += txtImagenRuta_TextChanged;
            // 
            // lbCodigo
            // 
            lbCodigo.AutoSize = true;
            lbCodigo.BackColor = Color.White;
            lbCodigo.Location = new Point(13, 131);
            lbCodigo.Name = "lbCodigo";
            lbCodigo.Size = new Size(46, 15);
            lbCodigo.TabIndex = 9;
            lbCodigo.Text = "Código";
            lbCodigo.Click += lbCodigo_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Location = new Point(13, 149);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(207, 23);
            txtCodigo.TabIndex = 10;
            // 
            // ProductoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            Controls.Add(txtImagenRuta);
            Controls.Add(pBImagenProducto);
            Controls.Add(btnCargarImagen);
            Controls.Add(lbCargarImagen);
            Controls.Add(dgvProductos);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(cbBusqueda);
            Controls.Add(txtBusqueda);
            Controls.Add(lblBusqueda);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(cbCategoria);
            Controls.Add(txtPrecioVenta);
            Controls.Add(txtPrecioCompra);
            Controls.Add(txtCodigo);
            Controls.Add(txtStock);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombreProd);
            Controls.Add(lblPrecioVenta);
            Controls.Add(lblPrecioCompra);
            Controls.Add(lblStock);
            Controls.Add(lbCodigo);
            Controls.Add(lblCategoria);
            Controls.Add(lblDescripcion);
            Controls.Add(lblNombreProd);
            Controls.Add(lblTituloDetalle);
            Controls.Add(label1);
            Controls.Add(lblListaProductos);
            Name = "ProductoControl";
            Size = new Size(1082, 702);
            Load += ProductoControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBImagenProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label label1;
        public Label lblTituloDetalle;
        public Label lblNombreProd;
        public TextBox txtNombreProd;
        public Label lblDescripcion;
        public TextBox txtDescripcion;
        public Label lblCategoria;
        public ComboBox cbCategoria;
        public Label lblStock;
        public TextBox txtStock;
        public Label lblPrecioCompra;
        public TextBox txtPrecioCompra;
        public Label lblPrecioVenta;
        public TextBox txtPrecioVenta;
        public Button btnGuardar;
        public Button btnEditar;
        public Button btnEliminar;
        public Label lblListaProductos;
        public ComboBox cbBusqueda;
        public TextBox txtBusqueda;
        public FontAwesome.Sharp.IconButton btnBuscar;
        public FontAwesome.Sharp.IconButton btnLimpiar;
        public Label lblBusqueda;
        public DataGridView dgvProductos;

        public Label lblImagen;
        public TextBox txtImagenRuta;
        public Button btnCargarImagen;
        public PictureBox pBImagenProducto;
        public PictureBox pbPreview;
        public Label lbCargarImagen;
        public Label lbCodigo;
        public TextBox txtCodigo;
        public DataGridViewTextBoxColumn idProducto;
        public DataGridViewTextBoxColumn Codigo;
        public DataGridViewTextBoxColumn Nombre;
        public DataGridViewTextBoxColumn Categoria;
        public DataGridViewTextBoxColumn Descripcion;
        public DataGridViewTextBoxColumn Stock;
        public DataGridViewTextBoxColumn PrecioCompra;
        public DataGridViewTextBoxColumn PrecioVenta;
        public DataGridViewTextBoxColumn Estado;
        public DataGridViewTextBoxColumn EstadoValor;
    }
}