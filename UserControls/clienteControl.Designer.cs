namespace nikeproject
{
    partial class ClienteControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lbApellido = new Label();
            txtApellido = new TextBox();
            dgvCliente = new DataGridView();
            IdCliente = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Documento = new DataGridViewTextBoxColumn();
            Correo = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            btnSeleccionar = new DataGridViewButtonColumn();
            clienteBindingSource3 = new BindingSource(components);
            clienteBindingSource = new BindingSource(components);
            btnLimpiar = new FontAwesome.Sharp.IconButton();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            cbBusqueda = new ComboBox();
            txtBusqueda = new TextBox();
            lbBusqueda = new Label();
            btnBaja = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            cbEstado = new ComboBox();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            txtNroDocumento = new TextBox();
            txtNombre = new TextBox();
            lbEstado = new Label();
            lbCorreo = new Label();
            lbTelefono = new Label();
            lbTitulo = new Label();
            lbNombre = new Label();
            lbDocumentoUsu = new Label();
            label1 = new Label();
            lbListaUsuario = new Label();
            clienteBindingSource2 = new BindingSource(components);
            clienteBindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dgvCliente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // lbApellido
            // 
            lbApellido.AutoSize = true;
            lbApellido.BackColor = Color.White;
            lbApellido.Location = new Point(27, 119);
            lbApellido.Name = "lbApellido";
            lbApellido.Size = new Size(54, 15);
            lbApellido.TabIndex = 45;
            lbApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Location = new Point(23, 137);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(182, 23);
            txtApellido.TabIndex = 44;
            // 
            // dgvCliente
            // 
            dgvCliente.AllowUserToAddRows = false;
            dgvCliente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCliente.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCliente.Location = new Point(247, 127);
            dgvCliente.MultiSelect = false;
            dgvCliente.Name = "dgvCliente";
            dgvCliente.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvCliente.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvCliente.RowTemplate.Height = 28;
            dgvCliente.Size = new Size(773, 424);
            dgvCliente.TabIndex = 43;
            dgvCliente.CellClick += dgvCliente_CellClick;
            dgvCliente.DataBindingComplete += dgvCliente_DataBindingComplete;
            // 
            // IdCliente
            // 
            IdCliente.DataPropertyName = "IdCliente";
            IdCliente.HeaderText = "IdCliente";
            IdCliente.Name = "IdCliente";
            IdCliente.ReadOnly = true;
            IdCliente.Visible = false;
            // 
            // Nombre
            // 
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 180;
            // 
            // Apellido
            // 
            Apellido.DataPropertyName = "Apellido";
            Apellido.HeaderText = "Apellido";
            Apellido.Name = "Apellido";
            Apellido.ReadOnly = true;
            // 
            // Documento
            // 
            Documento.DataPropertyName = "Documento";
            Documento.HeaderText = "Nro Documento";
            Documento.Name = "Documento";
            Documento.ReadOnly = true;
            Documento.Width = 150;
            // 
            // Correo
            // 
            Correo.DataPropertyName = "Correo";
            Correo.HeaderText = "Correo";
            Correo.Name = "Correo";
            Correo.ReadOnly = true;
            // 
            // Telefono
            // 
            Telefono.DataPropertyName = "Telefono";
            Telefono.HeaderText = "Telefono";
            Telefono.Name = "Telefono";
            Telefono.ReadOnly = true;
            // 
            // Estado
            // 
            Estado.DataPropertyName = "Estado";
            Estado.HeaderText = "Estado";
            Estado.Name = "Estado";
            Estado.ReadOnly = true;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.DataPropertyName = "idCliente";
            btnSeleccionar.HeaderText = "";
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.ReadOnly = true;
            btnSeleccionar.Visible = false;
            btnSeleccionar.Width = 30;
            // 
            // clienteBindingSource3
            // 
            clienteBindingSource3.DataSource = typeof(Models.Cliente);
            // 
            // clienteBindingSource
            // 
            clienteBindingSource.DataSource = typeof(Models.Cliente);
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
            btnLimpiar.Location = new Point(945, 49);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(39, 25);
            btnLimpiar.TabIndex = 41;
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
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
            btnBuscar.Location = new Point(887, 49);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(41, 24);
            btnBuscar.TabIndex = 40;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cbBusqueda
            // 
            cbBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBusqueda.FormattingEnabled = true;
            cbBusqueda.Location = new Point(546, 47);
            cbBusqueda.Name = "cbBusqueda";
            cbBusqueda.Size = new Size(139, 23);
            cbBusqueda.TabIndex = 35;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BorderStyle = BorderStyle.FixedSingle;
            txtBusqueda.Location = new Point(700, 48);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(141, 23);
            txtBusqueda.TabIndex = 29;
            // 
            // lbBusqueda
            // 
            lbBusqueda.AutoSize = true;
            lbBusqueda.BackColor = Color.DimGray;
            lbBusqueda.Font = new Font("Segoe UI", 10F);
            lbBusqueda.Location = new Point(458, 49);
            lbBusqueda.Name = "lbBusqueda";
            lbBusqueda.Size = new Size(77, 19);
            lbBusqueda.TabIndex = 27;
            lbBusqueda.Text = "Buscar por:";
            // 
            // btnBaja
            // 
            btnBaja.BackColor = Color.Firebrick;
            btnBaja.Cursor = Cursors.Hand;
            btnBaja.FlatAppearance.BorderColor = Color.Black;
            btnBaja.FlatStyle = FlatStyle.Flat;
            btnBaja.ForeColor = Color.White;
            btnBaja.Location = new Point(23, 466);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(182, 26);
            btnBaja.TabIndex = 38;
            btnBaja.Text = "Dar de Baja";
            btnBaja.UseVisualStyleBackColor = false;
            btnBaja.Click += btnBaja_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.ForestGreen;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderColor = Color.Black;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(23, 408);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(182, 23);
            btnGuardar.TabIndex = 37;
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
            btnEditar.Location = new Point(23, 437);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(182, 23);
            btnEditar.TabIndex = 39;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // cbEstado
            // 
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(23, 355);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(180, 23);
            cbEstado.TabIndex = 36;
            cbEstado.Visible = false;
            // 
            // txtCorreo
            // 
            txtCorreo.BorderStyle = BorderStyle.FixedSingle;
            txtCorreo.Location = new Point(23, 247);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(182, 23);
            txtCorreo.TabIndex = 33;
            // 
            // txtTelefono
            // 
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Location = new Point(23, 302);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(182, 23);
            txtTelefono.TabIndex = 32;
            txtTelefono.TextChanged += txtDocumento_TextChanged;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtNroDocumento
            // 
            txtNroDocumento.BorderStyle = BorderStyle.FixedSingle;
            txtNroDocumento.Location = new Point(23, 191);
            txtNroDocumento.Name = "txtNroDocumento";
            txtNroDocumento.Size = new Size(182, 23);
            txtNroDocumento.TabIndex = 31;
            txtNroDocumento.TextChanged += txtDocumento_TextChanged;
            txtNroDocumento.KeyPress += txtNroDocumento_KeyPress;
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Location = new Point(23, 83);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(182, 23);
            txtNombre.TabIndex = 30;
            // 
            // lbEstado
            // 
            lbEstado.AutoSize = true;
            lbEstado.BackColor = Color.White;
            lbEstado.Location = new Point(23, 337);
            lbEstado.Name = "lbEstado";
            lbEstado.Size = new Size(45, 15);
            lbEstado.TabIndex = 26;
            lbEstado.Text = "Estado:";
            lbEstado.Visible = false;
            // 
            // lbCorreo
            // 
            lbCorreo.AutoSize = true;
            lbCorreo.BackColor = Color.White;
            lbCorreo.Location = new Point(21, 229);
            lbCorreo.Name = "lbCorreo";
            lbCorreo.Size = new Size(46, 15);
            lbCorreo.TabIndex = 23;
            lbCorreo.Text = "Correo:";
            // 
            // lbTelefono
            // 
            lbTelefono.AutoSize = true;
            lbTelefono.BackColor = Color.White;
            lbTelefono.Location = new Point(23, 284);
            lbTelefono.Name = "lbTelefono";
            lbTelefono.Size = new Size(55, 15);
            lbTelefono.TabIndex = 28;
            lbTelefono.Text = "Telefono:";
            // 
            // lbTitulo
            // 
            lbTitulo.AutoSize = true;
            lbTitulo.BackColor = Color.White;
            lbTitulo.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lbTitulo.Location = new Point(23, 18);
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(153, 25);
            lbTitulo.TabIndex = 20;
            lbTitulo.Text = "Detalle Cliente";
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.BackColor = Color.White;
            lbNombre.Location = new Point(27, 65);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(54, 15);
            lbNombre.TabIndex = 22;
            lbNombre.Text = "Nombre:";
            // 
            // lbDocumentoUsu
            // 
            lbDocumentoUsu.AutoSize = true;
            lbDocumentoUsu.BackColor = Color.White;
            lbDocumentoUsu.Location = new Point(23, 173);
            lbDocumentoUsu.Name = "lbDocumentoUsu";
            lbDocumentoUsu.Size = new Size(96, 15);
            lbDocumentoUsu.TabIndex = 21;
            lbDocumentoUsu.Text = "Nro Documento:";
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(233, 622);
            label1.TabIndex = 19;
            // 
            // lbListaUsuario
            // 
            lbListaUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbListaUsuario.BackColor = Color.DimGray;
            lbListaUsuario.Font = new Font("Segoe UI", 15F);
            lbListaUsuario.Location = new Point(247, 16);
            lbListaUsuario.Name = "lbListaUsuario";
            lbListaUsuario.Size = new Size(773, 76);
            lbListaUsuario.TabIndex = 42;
            lbListaUsuario.Text = "Lista de Clientes";
            lbListaUsuario.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // clienteBindingSource2
            // 
            clienteBindingSource2.DataSource = typeof(Models.Cliente);
            // 
            // clienteBindingSource1
            // 
            clienteBindingSource1.DataSource = typeof(Models.Cliente);
            // 
            // ClienteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbApellido);
            Controls.Add(txtApellido);
            Controls.Add(dgvCliente);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(cbBusqueda);
            Controls.Add(txtBusqueda);
            Controls.Add(lbBusqueda);
            Controls.Add(btnBaja);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(cbEstado);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtNroDocumento);
            Controls.Add(txtNombre);
            Controls.Add(lbEstado);
            Controls.Add(lbCorreo);
            Controls.Add(lbTelefono);
            Controls.Add(lbTitulo);
            Controls.Add(lbNombre);
            Controls.Add(lbDocumentoUsu);
            Controls.Add(label1);
            Controls.Add(lbListaUsuario);
            Name = "ClienteControl";
            Size = new Size(1045, 622);
            ((System.ComponentModel.ISupportInitialize)dgvCliente).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource3).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();





        }

        #endregion

        private Label lbApellido;
        private TextBox txtApellido;
        private DataGridView dgvCliente;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private ComboBox cbBusqueda;
        private TextBox txtBusqueda;
        private Label lbBusqueda;
        private Button btnBaja;
        private Button btnGuardar;
        private Button btnEditar;
        private ComboBox cbEstado;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private TextBox txtNroDocumento;
        private TextBox txtNombre;
        private Label lbEstado;
        private Label lbCorreo;
        private Label lbTelefono;
        private Label lbTitulo;
        private Label lbNombre;
        private Label lbDocumentoUsu;
        private Label label1;
        private Label lbListaUsuario;
        private BindingSource clienteBindingSource;
        private BindingSource clienteBindingSource1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private BindingSource clienteBindingSource2;
        private BindingSource clienteBindingSource3;
        private DataGridViewButtonColumn btnSeleccionar;
        private DataGridViewTextBoxColumn IdCliente;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Documento;
        private DataGridViewTextBoxColumn Correo;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewTextBoxColumn Estado;
    }
}