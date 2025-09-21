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
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(281, 499);
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
            lbDocumentoUsu.Click += lbDocumentoUsu_Click;
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
            lbNombreCompleto.Click += label3_Click;
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
            lbClave.Click += lbClave_Click;
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(20, 63);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(207, 23);
            txtNombreCompleto.TabIndex = 10;
            // 
            // txtNroDocumento
            // 
            txtNroDocumento.Location = new Point(20, 118);
            txtNroDocumento.Name = "txtNroDocumento";
            txtNroDocumento.Size = new Size(207, 23);
            txtNroDocumento.TabIndex = 10;
            txtNroDocumento.TextChanged += txtNroDocumento_TextChanged;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(20, 177);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(207, 23);
            txtClave.TabIndex = 10;
            txtClave.TextChanged += textBox3_TextChanged;
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
            lbConfirmarClave.Click += label2_Click;
            // 
            // txtConfirmarClave
            // 
            txtConfirmarClave.Location = new Point(20, 239);
            txtConfirmarClave.Name = "txtConfirmarClave";
            txtConfirmarClave.Size = new Size(207, 23);
            txtConfirmarClave.TabIndex = 10;
            txtConfirmarClave.TextChanged += textBox3_TextChanged;
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
            lbRol.Click += label2_Click;
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
            cbEstado.Location = new Point(20, 349);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(207, 23);
            cbEstado.TabIndex = 11;
            // 
            // lbEstado
            // 
            lbEstado.AutoSize = true;
            lbEstado.BackColor = Color.White;
            lbEstado.Location = new Point(22, 331);
            lbEstado.Name = "lbEstado";
            lbEstado.Size = new Size(45, 15);
            lbEstado.TabIndex = 9;
            lbEstado.Text = "Estado:";
            lbEstado.Click += label2_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.RoyalBlue;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderColor = Color.Black;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(20, 417);
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
            btnEliminar.Location = new Point(20, 446);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(207, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.ForestGreen;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderColor = Color.Black;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(20, 388);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(207, 23);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += button3_Click;
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
            lbTitulo.Click += label3_Click;
            // 
            // UsuariosControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(cbEstado);
            Controls.Add(cbRol);
            Controls.Add(txtConfirmarClave);
            Controls.Add(txtClave);
            Controls.Add(txtNroDocumento);
            Controls.Add(txtNombreCompleto);
            Controls.Add(lbEstado);
            Controls.Add(lbRol);
            Controls.Add(lbConfirmarClave);
            Controls.Add(lbClave);
            Controls.Add(lbTitulo);
            Controls.Add(lbNombreCompleto);
            Controls.Add(lbDocumentoUsu);
            Controls.Add(label1);
            Name = "UsuariosControl";
            Size = new Size(745, 499);
            Load += UserControl1_Load;
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
    }
}
