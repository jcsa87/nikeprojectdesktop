namespace nikeproject.Forms
{
    partial class LoginForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lbTitulo = new Label();
            pbLogo = new PictureBox();
            txtDocumento = new TextBox();
            txtClave = new TextBox();
            lbNroDocumento = new Label();
            lbContraseña = new Label();
            btnIngresar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Dock = DockStyle.Left;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(182, 241);
            label1.TabIndex = 0;
            label1.Click += label1_Click;
            // 
            // lbTitulo
            // 
            lbTitulo.AutoSize = true;
            lbTitulo.BackColor = SystemColors.ActiveCaptionText;
            lbTitulo.Font = new Font("Myanmar Text", 15F);
            lbTitulo.ForeColor = Color.White;
            lbTitulo.Location = new Point(29, 177);
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(134, 36);
            lbTitulo.TabIndex = 1;
            lbTitulo.Text = "NIKEPROJECT";
            // 
            // pbLogo
            // 
            pbLogo.BackColor = SystemColors.ActiveCaptionText;
            pbLogo.Image = Properties.Resources.logo;
            pbLogo.Location = new Point(28, 24);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(135, 93);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 2;
            pbLogo.TabStop = false;
            pbLogo.Click += pictureBox1_Click;
            // 
            // txtDocumento
            // 
            txtDocumento.BackColor = SystemColors.WindowFrame;
            txtDocumento.ForeColor = Color.White;
            txtDocumento.Location = new Point(204, 49);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(234, 23);
            txtDocumento.TabIndex = 3;
            txtDocumento.TextChanged += textBox1_TextChanged;
            // 
            // txtClave
            // 
            txtClave.BackColor = SystemColors.WindowFrame;
            txtClave.ForeColor = Color.White;
            txtClave.Location = new Point(204, 128);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(234, 23);
            txtClave.TabIndex = 3;
            // 
            // lbNroDocumento
            // 
            lbNroDocumento.AutoSize = true;
            lbNroDocumento.Font = new Font("Myanmar Text", 9F);
            lbNroDocumento.Location = new Point(204, 25);
            lbNroDocumento.Name = "lbNroDocumento";
            lbNroDocumento.Size = new Size(96, 21);
            lbNroDocumento.TabIndex = 4;
            lbNroDocumento.Text = "Nro Documento";
            // 
            // lbContraseña
            // 
            lbContraseña.AutoSize = true;
            lbContraseña.Font = new Font("Myanmar Text", 9F);
            lbContraseña.Location = new Point(204, 104);
            lbContraseña.Name = "lbContraseña";
            lbContraseña.Size = new Size(70, 21);
            lbContraseña.TabIndex = 4;
            lbContraseña.Text = "Contraseña";
            lbContraseña.Click += label4_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.Black;
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderColor = Color.DimGray;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Myanmar Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.ImageAlign = ContentAlignment.MiddleRight;
            btnIngresar.Location = new Point(204, 187);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(96, 26);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += button1_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Firebrick;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Myanmar Text", 9F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(345, 187);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(93, 26);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(484, 241);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            Controls.Add(lbContraseña);
            Controls.Add(lbNroDocumento);
            Controls.Add(txtClave);
            Controls.Add(txtDocumento);
            Controls.Add(pbLogo);
            Controls.Add(lbTitulo);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lbTitulo;
        private PictureBox pbLogo;
        private TextBox txtDocumento;
        private TextBox txtClave;
        private Label lbNroDocumento;
        private Label lbContraseña;
        private Button btnIngresar;
        private Button btnCancelar;
    }
}