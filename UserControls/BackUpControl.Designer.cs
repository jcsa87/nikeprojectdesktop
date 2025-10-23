namespace nikeproject.UserControls
{
    partial class BackUpControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
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
            lblDestino = new Label();
            txtDestino = new TextBox();
            btnSeleccionarDestino = new Button();
            grpOpciones = new GroupBox();
            clbTablas = new CheckedListBox();
            rbBackupSelectivo = new RadioButton();
            rbBackupCompleto = new RadioButton();
            lblNombreBackup = new Label();
            txtNombreBackup = new TextBox();
            chkAgregarFecha = new CheckBox();
            btnBackup = new Button();
            lblResultado = new Label();
            grpOpciones.SuspendLayout();
            SuspendLayout();
            // 
            // lblDestino
            // 
            lblDestino.AutoSize = true;
            lblDestino.Location = new Point(40, 40);
            lblDestino.Name = "lblDestino";
            lblDestino.Size = new Size(109, 15);
            lblDestino.TabIndex = 0;
            lblDestino.Text = "Carpeta de destino:";
            // 
            // txtDestino
            // 
            txtDestino.BorderStyle = BorderStyle.FixedSingle;
            txtDestino.Location = new Point(40, 58);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(340, 23);
            txtDestino.TabIndex = 1;
            // 
            // btnSeleccionarDestino
            // 
            btnSeleccionarDestino.BackColor = Color.DarkGray;
            btnSeleccionarDestino.Cursor = Cursors.Hand;
            btnSeleccionarDestino.FlatStyle = FlatStyle.Flat;
            btnSeleccionarDestino.Location = new Point(400, 57);
            btnSeleccionarDestino.Name = "btnSeleccionarDestino";
            btnSeleccionarDestino.Size = new Size(100, 25);
            btnSeleccionarDestino.TabIndex = 2;
            btnSeleccionarDestino.Text = "Seleccionar...";
            btnSeleccionarDestino.UseVisualStyleBackColor = false;
            btnSeleccionarDestino.Click += btnSeleccionarDestino_Click;
            // 
            // grpOpciones
            // 
            grpOpciones.Controls.Add(clbTablas);
            grpOpciones.Controls.Add(rbBackupSelectivo);
            grpOpciones.Controls.Add(rbBackupCompleto);
            grpOpciones.Controls.Add(lblNombreBackup);
            grpOpciones.Controls.Add(txtNombreBackup);
            grpOpciones.Controls.Add(chkAgregarFecha);
            grpOpciones.Location = new Point(40, 100);
            grpOpciones.Name = "grpOpciones";
            grpOpciones.Size = new Size(460, 230);
            grpOpciones.TabIndex = 3;
            grpOpciones.TabStop = false;
            grpOpciones.Text = "Configuraciones";
            // 
            // clbTablas
            // 
            clbTablas.CheckOnClick = true;
            clbTablas.FormattingEnabled = true;
            clbTablas.Location = new Point(30, 80);
            clbTablas.Name = "clbTablas";
            clbTablas.Size = new Size(400, 94);
            clbTablas.TabIndex = 5;
            // 
            // rbBackupSelectivo
            // 
            rbBackupSelectivo.AutoSize = true;
            rbBackupSelectivo.Location = new Point(30, 50);
            rbBackupSelectivo.Name = "rbBackupSelectivo";
            rbBackupSelectivo.Size = new Size(160, 19);
            rbBackupSelectivo.TabIndex = 4;
            rbBackupSelectivo.Text = "Backup de tablas elegidas";
            rbBackupSelectivo.UseVisualStyleBackColor = true;
            // 
            // rbBackupCompleto
            // 
            rbBackupCompleto.AutoSize = true;
            rbBackupCompleto.Checked = true;
            rbBackupCompleto.Location = new Point(30, 25);
            rbBackupCompleto.Name = "rbBackupCompleto";
            rbBackupCompleto.Size = new Size(118, 19);
            rbBackupCompleto.TabIndex = 3;
            rbBackupCompleto.TabStop = true;
            rbBackupCompleto.Text = "Backup completo";
            rbBackupCompleto.UseVisualStyleBackColor = true;
            // 
            // lblNombreBackup
            // 
            lblNombreBackup.AutoSize = true;
            lblNombreBackup.Location = new Point(30, 185);
            lblNombreBackup.Name = "lblNombreBackup";
            lblNombreBackup.Size = new Size(96, 15);
            lblNombreBackup.TabIndex = 2;
            lblNombreBackup.Text = "Nombre backup:";
            // 
            // txtNombreBackup
            // 
            txtNombreBackup.BorderStyle = BorderStyle.FixedSingle;
            txtNombreBackup.Location = new Point(130, 182);
            txtNombreBackup.Name = "txtNombreBackup";
            txtNombreBackup.Size = new Size(200, 23);
            txtNombreBackup.TabIndex = 1;
            txtNombreBackup.Text = "Respaldo";
            // 
            // chkAgregarFecha
            // 
            chkAgregarFecha.AutoSize = true;
            chkAgregarFecha.Checked = true;
            chkAgregarFecha.CheckState = CheckState.Checked;
            chkAgregarFecha.Location = new Point(340, 184);
            chkAgregarFecha.Name = "chkAgregarFecha";
            chkAgregarFecha.Size = new Size(112, 19);
            chkAgregarFecha.TabIndex = 0;
            chkAgregarFecha.Text = "Agregar la fecha";
            chkAgregarFecha.UseVisualStyleBackColor = true;
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.RoyalBlue;
            btnBackup.Cursor = Cursors.Hand;
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.ForeColor = Color.White;
            btnBackup.Location = new Point(40, 350);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(460, 35);
            btnBackup.TabIndex = 4;
            btnBackup.Text = "Generar Backup";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblResultado.ForeColor = Color.ForestGreen;
            lblResultado.Location = new Point(40, 400);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(0, 15);
            lblResultado.TabIndex = 5;
            // 
            // BackUpControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblResultado);
            Controls.Add(btnBackup);
            Controls.Add(grpOpciones);
            Controls.Add(btnSeleccionarDestino);
            Controls.Add(txtDestino);
            Controls.Add(lblDestino);
            Name = "BackUpControl";
            Size = new Size(600, 450);
            grpOpciones.ResumeLayout(false);
            grpOpciones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button btnSeleccionarDestino;
        private System.Windows.Forms.GroupBox grpOpciones;
        private System.Windows.Forms.CheckedListBox clbTablas;
        private System.Windows.Forms.RadioButton rbBackupCompleto;
        private System.Windows.Forms.Label lblNombreBackup;
        private System.Windows.Forms.TextBox txtNombreBackup;
        private System.Windows.Forms.CheckBox chkAgregarFecha;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label lblResultado;
        private RadioButton rbBackupSelectivo;
    }
}
