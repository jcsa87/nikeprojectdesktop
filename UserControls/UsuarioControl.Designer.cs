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
            lbNombreCompleto = new Label();
            lbClave = new Label();
            txtNombreCompleto = new TextBox();
            txtNroDocumento = new TextBox();
            txtClave = new TextBox();
            lbConfirmarClave = new Label();
            txtConfirmarClave = new TextBox();
            lbRol = new Label();
            cbRol = new ComboBox();
            cbEstado = new ComboBox();
            lbEstado = new Label();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            lbTitulo = new Label();
            dgvUsuarios = new DataGridView();
            btnSeleccionar = new DataGridViewButtonColumn();
            idUsuario = new DataGridViewTextBoxColumn();
            NombreCompleto = new DataGridViewTextBoxColumn();
            Documento = new DataGridViewTextBoxColumn();
            Clave = new DataGridViewTextBoxColumn();
            Rol = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            EstadoValor = new DataGridViewTextBoxColumn();
            label2 = new Label();
            lbBusqueda = new Label();
            cbBusqueda = new ComboBox();
            txtBusqueda = new TextBox();
            ibBusqueda = new FontAwesome.Sharp.IconButton();
            ibFiltro = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(261, 561);
            label1.TabIndex = 8;
            // 
            // lbDocumentoUsu
            // 
            lbDocumentoUsu.AutoSize = true;
            lbDocumentoUsu.BackColor = Color.White;
            lbDocumentoUsu.Location = new Point(20, 100);
            lbDocumentoUsu.Name = "lbDocumentoUsu";
            lbDocumentoUsu.Size = new Size(96, 15);
            lbDocumentoUsu.TabIndex = 9;
            lbDocumentoUsu.Text = "Nro Documento:";
            // 
            // lbNombreCompleto
            // 
            lbNombreCompleto.AutoSize = true;
            lbNombreCompleto.BackColor = Color.White;
            lbNombreCompleto.Location = new Point(20, 45);
            lbNombreCompleto.Name = "lbNombreCompleto";
            lbNombreCompleto.Size = new Size(110, 15);
            lbNombreCompleto.TabIndex = 9;
            lbNombreCompleto.Text = "Nombre Completo:";
            // 
            // lbClave
            // 
            lbClave.AutoSize = true;
            lbClave.BackColor = Color.White;
            lbClave.Location = new Point(20, 159);
            lbClave.Name = "lbClave";
            lbClave.Size = new Size(39, 15);
            lbClave.TabIndex = 9;
            lbClave.Text = "Clave:";
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.BorderStyle = BorderStyle.FixedSingle;
            txtNombreCompleto.Location = new Point(20, 63);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(207, 23);
            txtNombreCompleto.TabIndex = 10;
            // 
            // txtNroDocumento
            // 
            txtNroDocumento.BorderStyle = BorderStyle.FixedSingle;
            txtNroDocumento.Location = new Point(20, 118);
            txtNroDocumento.Name = "txtNroDocumento";
            txtNroDocumento.Size = new Size(207, 23);
            txtNroDocumento.TabIndex = 10;
            // 
            // txtClave
            // 
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Location = new Point(20, 177);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(207, 23);
            txtClave.TabIndex = 10;
            // 
            // lbConfirmarClave
            // 
            lbConfirmarClave.AutoSize = true;
            lbConfirmarClave.BackColor = Color.White;
            lbConfirmarClave.Location = new Point(20, 221);
            lbConfirmarClave.Name = "lbConfirmarClave";
            lbConfirmarClave.Size = new Size(96, 15);
            lbConfirmarClave.TabIndex = 9;
            lbConfirmarClave.Text = "Confirmar Clave:";
            // 
            // txtConfirmarClave
            // 
            txtConfirmarClave.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmarClave.Location = new Point(20, 239);
            txtConfirmarClave.Name = "txtConfirmarClave";
            txtConfirmarClave.PasswordChar = '*';
            txtConfirmarClave.Size = new Size(207, 23);
            txtConfirmarClave.TabIndex = 10;
            txtConfirmarClave.KeyPress += txtConfirmarClave_KeyPress;
            // 
            // lbRol
            // 
            lbRol.AutoSize = true;
            lbRol.BackColor = Color.White;
            lbRol.Location = new Point(20, 277);
            lbRol.Name = "lbRol";
            lbRol.Size = new Size(27, 15);
            lbRol.TabIndex = 9;
            lbRol.Text = "Rol:";
            // 
            // cbRol
            // 
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(20, 295);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(205, 23);
            cbRol.TabIndex = 11;
            // 
            // cbEstado
            // 
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(20, 359);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(207, 23);
            cbEstado.TabIndex = 11;
            // 
            // lbEstado
            // 
            lbEstado.AutoSize = true;
            lbEstado.BackColor = Color.White;
            lbEstado.Location = new Point(20, 341);
            lbEstado.Name = "lbEstado";
            lbEstado.Size = new Size(45, 15);
            lbEstado.TabIndex = 9;
            lbEstado.Text = "Estado:";
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.RoyalBlue;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderColor = Color.Black;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(20, 449);
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
            btnEliminar.Location = new Point(20, 478);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(207, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
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
            btnGuardar.Location = new Point(20, 420);
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
            lbTitulo.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitulo.Location = new Point(20, 10);
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(159, 25);
            lbTitulo.TabIndex = 9;
            lbTitulo.Text = "Detalle Usuario";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { btnSeleccionar, idUsuario, NombreCompleto, Documento, Clave, Rol, Estado, EstadoValor });
            dgvUsuarios.Location = new Point(267, 79);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsuarios.RowTemplate.Height = 28;
            dgvUsuarios.Size = new Size(736, 431);
            dgvUsuarios.TabIndex = 13;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            dgvUsuarios.CellFormatting += dgvUsuarios_CellFormatting;
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
            // NombreCompleto
            // 
            NombreCompleto.DataPropertyName = "NombreCompleto";
            NombreCompleto.HeaderText = "Nombre Completo";
            NombreCompleto.Name = "NombreCompleto";
            NombreCompleto.ReadOnly = true;
            NombreCompleto.Width = 180;
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
            // 
            // EstadoValor
            // 
            EstadoValor.HeaderText = "EstadoValor";
            EstadoValor.Name = "EstadoValor";
            EstadoValor.ReadOnly = true;
            EstadoValor.Visible = false;
            // 
            // label2
            // 
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(267, 10);
            label2.Name = "label2";
            label2.Size = new Size(736, 66);
            label2.TabIndex = 9;
            label2.Text = "Lista de Usuarios:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbBusqueda
            // 
            lbBusqueda.AutoSize = true;
            lbBusqueda.BackColor = Color.White;
            lbBusqueda.Location = new Point(475, 45);
            lbBusqueda.Name = "lbBusqueda";
            lbBusqueda.Size = new Size(66, 15);
            lbBusqueda.TabIndex = 9;
            lbBusqueda.Text = "Buscar por:";
            // 
            // cbBusqueda
            // 
            cbBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBusqueda.FormattingEnabled = true;
            cbBusqueda.Location = new Point(547, 42);
            cbBusqueda.Name = "cbBusqueda";
            cbBusqueda.Size = new Size(164, 23);
            cbBusqueda.TabIndex = 11;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BorderStyle = BorderStyle.FixedSingle;
            txtBusqueda.Location = new Point(717, 42);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.PasswordChar = '*';
            txtBusqueda.Size = new Size(166, 23);
            txtBusqueda.TabIndex = 10;
            // 
            // ibBusqueda
            // 
            ibBusqueda.BackColor = Color.DarkGray;
            ibBusqueda.Cursor = Cursors.Hand;
            ibBusqueda.FlatAppearance.BorderColor = Color.Black;
            ibBusqueda.FlatStyle = FlatStyle.Flat;
            ibBusqueda.IconChar = FontAwesome.Sharp.IconChar.Search;
            ibBusqueda.IconColor = Color.Black;
            ibBusqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibBusqueda.IconSize = 16;
            ibBusqueda.Location = new Point(889, 42);
            ibBusqueda.Name = "ibBusqueda";
            ibBusqueda.Size = new Size(33, 23);
            ibBusqueda.TabIndex = 14;
            ibBusqueda.UseVisualStyleBackColor = false;
            // 
            // ibFiltro
            // 
            ibFiltro.BackColor = Color.DarkGray;
            ibFiltro.Cursor = Cursors.Hand;
            ibFiltro.FlatAppearance.BorderColor = Color.Black;
            ibFiltro.FlatStyle = FlatStyle.Flat;
            ibFiltro.IconChar = FontAwesome.Sharp.IconChar.Broom;
            ibFiltro.IconColor = Color.Black;
            ibFiltro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibFiltro.IconSize = 18;
            ibFiltro.Location = new Point(928, 42);
            ibFiltro.Name = "ibFiltro";
            ibFiltro.Size = new Size(33, 23);
            ibFiltro.TabIndex = 14;
            ibFiltro.UseVisualStyleBackColor = false;
            // 
            // UsuariosControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(ibFiltro);
            Controls.Add(ibBusqueda);
            Controls.Add(dgvUsuarios);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(cbEstado);
            Controls.Add(cbBusqueda);
            Controls.Add(cbRol);
            Controls.Add(txtConfirmarClave);
            Controls.Add(txtBusqueda);
            Controls.Add(txtClave);
            Controls.Add(txtNroDocumento);
            Controls.Add(txtNombreCompleto);
            Controls.Add(lbEstado);
            Controls.Add(lbRol);
            Controls.Add(lbBusqueda);
            Controls.Add(lbConfirmarClave);
            Controls.Add(lbClave);
            Controls.Add(lbTitulo);
            Controls.Add(label2);
            Controls.Add(lbNombreCompleto);
            Controls.Add(lbDocumentoUsu);
            Controls.Add(label1);
            Name = "UsuariosControl";
            Size = new Size(1046, 561);
            Load += UsuariosControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label lbDocumentoUsu;
        private Label lbNombreCompleto;
        private Label lbClave;
        private TextBox txtNombreCompleto;
        private TextBox txtNroDocumento;
        private TextBox txtClave;
        private Label lbConfirmarClave;
        private TextBox txtConfirmarClave;
        private Label lbRol;
        private ComboBox cbRol;
        private ComboBox cbEstado;
        private Label lbEstado;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Label lbTitulo;
        private DataGridView dgvUsuarios;
        private Label label2;
        private DataGridViewButtonColumn btnSeleccionar;
        private DataGridViewTextBoxColumn idUsuario;
        private DataGridViewTextBoxColumn NombreCompleto;
        private DataGridViewTextBoxColumn Documento;
        private DataGridViewTextBoxColumn Clave;
        private DataGridViewTextBoxColumn Rol;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn EstadoValor;
        private Label lbBusqueda;
        private ComboBox cbBusqueda;
        private TextBox txtBusqueda;
        private FontAwesome.Sharp.IconButton ibBusqueda;
        private FontAwesome.Sharp.IconButton ibFiltro;
    }
}
