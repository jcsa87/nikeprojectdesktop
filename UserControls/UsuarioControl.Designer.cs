namespace nikeproject
{
    partial class UsuariosControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            lbDocumentoUsu = new Label();
            lbNombre = new Label();
            lbClave = new Label();
            txtNombre = new TextBox();
            txtNroDocumento = new TextBox();
            txtClave = new TextBox();
            lbConfirmarClave = new Label();
            txtConfirmarClave = new TextBox();
            lbRol = new Label();
            cbRol = new ComboBox();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            lbTitulo = new Label();
            lbListaUsuarios = new Label();
            cbBusqueda = new ComboBox();
            txtBusqueda = new TextBox();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            btnLimpiar = new FontAwesome.Sharp.IconButton();
            lbBusqueda = new Label();
            lbListaUsuario = new Label();
            dgvUsuario = new DataGridView();
            btnSeleccionar = new DataGridViewButtonColumn();
            idUsuario = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Documento = new DataGridViewTextBoxColumn();
            Clave = new DataGridViewTextBoxColumn();
            Rol = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            EstadoValor = new DataGridViewTextBoxColumn();
            txtApellido = new TextBox();
            lbApellido = new Label();
            lbEstado = new Label();
            cbEstado = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(258, 556);
            label1.TabIndex = 8;
            // 
            // lbDocumentoUsu
            // 
            lbDocumentoUsu.AutoSize = true;
            lbDocumentoUsu.BackColor = Color.White;
            lbDocumentoUsu.Location = new Point(20, 143);
            lbDocumentoUsu.Name = "lbDocumentoUsu";
            lbDocumentoUsu.Size = new Size(96, 15);
            lbDocumentoUsu.TabIndex = 9;
            lbDocumentoUsu.Text = "Nro Documento:";
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.BackColor = Color.White;
            lbNombre.Location = new Point(20, 45);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(54, 15);
            lbNombre.TabIndex = 9;
            lbNombre.Text = "Nombre:";
            // 
            // lbClave
            // 
            lbClave.AutoSize = true;
            lbClave.BackColor = Color.White;
            lbClave.Location = new Point(20, 198);
            lbClave.Name = "lbClave";
            lbClave.Size = new Size(39, 15);
            lbClave.TabIndex = 9;
            lbClave.Text = "Clave:";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Location = new Point(20, 63);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(207, 23);
            txtNombre.TabIndex = 10;
            // 
            // txtNroDocumento
            // 
            txtNroDocumento.BorderStyle = BorderStyle.FixedSingle;
            txtNroDocumento.Location = new Point(20, 161);
            txtNroDocumento.Name = "txtNroDocumento";
            txtNroDocumento.Size = new Size(207, 23);
            txtNroDocumento.TabIndex = 10;
            txtNroDocumento.KeyPress += txtNroDocumento_KeyPress;
            // 
            // txtClave
            // 
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Location = new Point(20, 216);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(207, 23);
            txtClave.TabIndex = 10;
            // 
            // lbConfirmarClave
            // 
            lbConfirmarClave.AutoSize = true;
            lbConfirmarClave.BackColor = Color.White;
            lbConfirmarClave.Location = new Point(20, 260);
            lbConfirmarClave.Name = "lbConfirmarClave";
            lbConfirmarClave.Size = new Size(96, 15);
            lbConfirmarClave.TabIndex = 9;
            lbConfirmarClave.Text = "Confirmar Clave:";
            // 
            // txtConfirmarClave
            // 
            txtConfirmarClave.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmarClave.Location = new Point(20, 278);
            txtConfirmarClave.Name = "txtConfirmarClave";
            txtConfirmarClave.PasswordChar = '*';
            txtConfirmarClave.Size = new Size(207, 23);
            txtConfirmarClave.TabIndex = 10;
            // 
            // lbRol
            // 
            lbRol.AutoSize = true;
            lbRol.BackColor = Color.White;
            lbRol.Location = new Point(20, 316);
            lbRol.Name = "lbRol";
            lbRol.Size = new Size(27, 15);
            lbRol.TabIndex = 9;
            lbRol.Text = "Rol:";
            // 
            // cbRol
            // 
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(20, 334);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(205, 23);
            cbRol.TabIndex = 11;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.RoyalBlue;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderColor = Color.Black;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(20, 456);
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
            btnEliminar.Location = new Point(20, 485);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(207, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Dar de Baja";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.ForestGreen;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderColor = Color.Black;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(20, 427);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(207, 23);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lbTitulo
            // 
            lbTitulo.AutoSize = true;
            lbTitulo.BackColor = Color.White;
            lbTitulo.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lbTitulo.Location = new Point(20, 10);
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(159, 25);
            lbTitulo.TabIndex = 9;
            lbTitulo.Text = "Detalle Usuario";
            // 
            // lbListaUsuarios
            // 
            lbListaUsuarios.BackColor = Color.White;
            lbListaUsuarios.Font = new Font("Segoe UI", 15F);
            lbListaUsuarios.Location = new Point(293, 20);
            lbListaUsuarios.Name = "lbListaUsuarios";
            lbListaUsuarios.Size = new Size(736, 66);
            lbListaUsuarios.TabIndex = 9;
            lbListaUsuarios.Text = "Lista de Usuarios:";
            lbListaUsuarios.TextAlign = ContentAlignment.MiddleLeft;
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
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
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
            btnBuscar.Click += btnBuscar_Click;
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
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lbBusqueda
            // 
            lbBusqueda.AutoSize = true;
            lbBusqueda.BackColor = Color.White;
            lbBusqueda.Location = new Point(475, 36);
            lbBusqueda.Name = "lbBusqueda";
            lbBusqueda.Size = new Size(66, 15);
            lbBusqueda.TabIndex = 9;
            lbBusqueda.Text = "Buscar por:";
            // 
            // lbListaUsuario
            // 
            lbListaUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbListaUsuario.BackColor = Color.White;
            lbListaUsuario.Font = new Font("Segoe UI", 15F);
            lbListaUsuario.Location = new Point(257, 0);
            lbListaUsuario.Name = "lbListaUsuario";
            lbListaUsuario.Size = new Size(798, 86);
            lbListaUsuario.TabIndex = 15;
            lbListaUsuario.Text = "Lista de Usuarios:";
            lbListaUsuario.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvUsuario
            // 
            dgvUsuario.AllowUserToAddRows = false;
            dgvUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuario.Columns.AddRange(new DataGridViewColumn[] { btnSeleccionar, idUsuario, Nombre, Apellido, Documento, Clave, Rol, Estado, EstadoValor });
            dgvUsuario.Location = new Point(257, 78);
            dgvUsuario.MultiSelect = false;
            dgvUsuario.Name = "dgvUsuario";
            dgvUsuario.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvUsuario.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsuario.RowTemplate.Height = 28;
            dgvUsuario.Size = new Size(798, 478);
            dgvUsuario.TabIndex = 16;
            dgvUsuario.CellClick += dgvUsuario_CellClick;
            dgvUsuario.CellContentClick += dgvUsuario_CellContentClick;
            dgvUsuario.CellFormatting += dgvUsuario_CellFormatting;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.DataPropertyName = "idUsuario";
            btnSeleccionar.HeaderText = "";
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.ReadOnly = true;
            btnSeleccionar.Width = 30;
            // 
            // idUsuario
            // 
            idUsuario.DataPropertyName = "idUsuario";
            idUsuario.HeaderText = "idUsuario";
            idUsuario.Name = "idUsuario";
            idUsuario.ReadOnly = true;
            idUsuario.Visible = false;
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
            // Clave
            // 
            Clave.DataPropertyName = "Clave";
            Clave.HeaderText = "Clave";
            Clave.Name = "Clave";
            Clave.ReadOnly = true;
            Clave.Visible = false;
            // 
            // Rol
            // 
            Rol.DataPropertyName = "Rol";
            Rol.HeaderText = "Rol";
            Rol.Name = "Rol";
            Rol.ReadOnly = true;
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
            // txtApellido
            // 
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Location = new Point(20, 107);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(207, 23);
            txtApellido.TabIndex = 17;
            // 
            // lbApellido
            // 
            lbApellido.AutoSize = true;
            lbApellido.BackColor = Color.White;
            lbApellido.Location = new Point(20, 89);
            lbApellido.Name = "lbApellido";
            lbApellido.Size = new Size(54, 15);
            lbApellido.TabIndex = 18;
            lbApellido.Text = "Apellido:";
            // 
            // lbEstado
            // 
            lbEstado.AutoSize = true;
            lbEstado.BackColor = Color.White;
            lbEstado.Location = new Point(20, 369);
            lbEstado.Name = "lbEstado";
            lbEstado.Size = new Size(45, 15);
            lbEstado.TabIndex = 9;
            lbEstado.Text = "Estado:";
            lbEstado.Visible = false;
            // 
            // cbEstado
            // 
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(20, 387);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(205, 23);
            cbEstado.TabIndex = 11;
            cbEstado.Visible = false;
            cbEstado.SelectedIndexChanged += cbEstado_SelectedIndexChanged;
            // 
            // UsuariosControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lbApellido);
            Controls.Add(txtApellido);
            Controls.Add(dgvUsuario);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(cbBusqueda);
            Controls.Add(txtBusqueda);
            Controls.Add(lbBusqueda);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(cbEstado);
            Controls.Add(cbRol);
            Controls.Add(txtConfirmarClave);
            Controls.Add(txtClave);
            Controls.Add(txtNroDocumento);
            Controls.Add(txtNombre);
            Controls.Add(lbEstado);
            Controls.Add(lbRol);
            Controls.Add(lbConfirmarClave);
            Controls.Add(lbClave);
            Controls.Add(lbTitulo);
            Controls.Add(lbNombre);
            Controls.Add(lbDocumentoUsu);
            Controls.Add(label1);
            Controls.Add(lbListaUsuario);
            Name = "UsuariosControl";
            Size = new Size(1058, 556);
            Load += UsuariosControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label lbDocumentoUsu;
        private Label lbNombre;
        private Label lbClave;
        private TextBox txtNombre;
        private TextBox txtNroDocumento;
        private TextBox txtClave;
        private Label lbConfirmarClave;
        private TextBox txtConfirmarClave;
        private Label lbRol;
        private ComboBox cbRol;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Label lbTitulo;
        private Label lbListaUsuarios;
        private ComboBox cbBusqueda;
        private TextBox txtBusqueda;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private Label lbBusqueda;
        private Label lbListaUsuario;
        private DataGridView dgvUsuario;
        private TextBox txtApellido;
        private Label lbApellido;
        private Label lbEstado;
        private ComboBox cbEstado;
        private DataGridViewButtonColumn btnSeleccionar;
        private DataGridViewTextBoxColumn idUsuario;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Documento;
        private DataGridViewTextBoxColumn Clave;
        private DataGridViewTextBoxColumn Rol;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn EstadoValor;
    }

}
