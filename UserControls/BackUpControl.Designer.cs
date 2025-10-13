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
            this.lblDestino = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.btnSeleccionarDestino = new System.Windows.Forms.Button();
            this.grpOpciones = new System.Windows.Forms.GroupBox();
            this.clbTablas = new System.Windows.Forms.CheckedListBox();
            this.rbBackupSelectivo = new System.Windows.Forms.RadioButton();
            this.rbBackupCompleto = new System.Windows.Forms.RadioButton();
            this.lblNombreBackup = new System.Windows.Forms.Label();
            this.txtNombreBackup = new System.Windows.Forms.TextBox();
            this.chkAgregarFecha = new System.Windows.Forms.CheckBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.grpOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(40, 40);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(108, 15);
            this.lblDestino.TabIndex = 0;
            this.lblDestino.Text = "Carpeta de destino:";
            // 
            // txtDestino
            // 
            this.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDestino.Location = new System.Drawing.Point(40, 58);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(340, 23);
            this.txtDestino.TabIndex = 1;
            // 
            // btnSeleccionarDestino
            // 
            this.btnSeleccionarDestino.BackColor = System.Drawing.Color.DarkGray;
            this.btnSeleccionarDestino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarDestino.Location = new System.Drawing.Point(400, 57);
            this.btnSeleccionarDestino.Name = "btnSeleccionarDestino";
            this.btnSeleccionarDestino.Size = new System.Drawing.Size(100, 25);
            this.btnSeleccionarDestino.TabIndex = 2;
            this.btnSeleccionarDestino.Text = "Seleccionar...";
            this.btnSeleccionarDestino.UseVisualStyleBackColor = false;
            this.btnSeleccionarDestino.Click += new System.EventHandler(this.btnSeleccionarDestino_Click);
            // 
            // grpOpciones
            // 
            this.grpOpciones.Controls.Add(this.clbTablas);
            this.grpOpciones.Controls.Add(this.rbBackupSelectivo);
            this.grpOpciones.Controls.Add(this.rbBackupCompleto);
            this.grpOpciones.Controls.Add(this.lblNombreBackup);
            this.grpOpciones.Controls.Add(this.txtNombreBackup);
            this.grpOpciones.Controls.Add(this.chkAgregarFecha);
            this.grpOpciones.Location = new System.Drawing.Point(40, 100);
            this.grpOpciones.Name = "grpOpciones";
            this.grpOpciones.Size = new System.Drawing.Size(460, 230);
            this.grpOpciones.TabIndex = 3;
            this.grpOpciones.TabStop = false;
            this.grpOpciones.Text = "Configuraciones";
            // 
            // clbTablas
            // 
            this.clbTablas.CheckOnClick = true;
            this.clbTablas.FormattingEnabled = true;
            this.clbTablas.Location = new System.Drawing.Point(30, 80);
            this.clbTablas.Name = "clbTablas";
            this.clbTablas.Size = new System.Drawing.Size(400, 94);
            this.clbTablas.TabIndex = 5;
            // 
            // rbBackupSelectivo
            // 
            this.rbBackupSelectivo.AutoSize = true;
            this.rbBackupSelectivo.Location = new System.Drawing.Point(30, 50);
            this.rbBackupSelectivo.Name = "rbBackupSelectivo";
            this.rbBackupSelectivo.Size = new System.Drawing.Size(162, 19);
            this.rbBackupSelectivo.TabIndex = 4;
            this.rbBackupSelectivo.Text = "Backup de tablas elegidas";
            this.rbBackupSelectivo.UseVisualStyleBackColor = true;
            // 
            // rbBackupCompleto
            // 
            this.rbBackupCompleto.AutoSize = true;
            this.rbBackupCompleto.Checked = true;
            this.rbBackupCompleto.Location = new System.Drawing.Point(30, 25);
            this.rbBackupCompleto.Name = "rbBackupCompleto";
            this.rbBackupCompleto.Size = new System.Drawing.Size(115, 19);
            this.rbBackupCompleto.TabIndex = 3;
            this.rbBackupCompleto.TabStop = true;
            this.rbBackupCompleto.Text = "Backup completo";
            this.rbBackupCompleto.UseVisualStyleBackColor = true;
            // 
            // lblNombreBackup
            // 
            this.lblNombreBackup.AutoSize = true;
            this.lblNombreBackup.Location = new System.Drawing.Point(30, 185);
            this.lblNombreBackup.Name = "lblNombreBackup";
            this.lblNombreBackup.Size = new System.Drawing.Size(92, 15);
            this.lblNombreBackup.TabIndex = 2;
            this.lblNombreBackup.Text = "Nombre backup:";
            // 
            // txtNombreBackup
            // 
            this.txtNombreBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreBackup.Location = new System.Drawing.Point(130, 182);
            this.txtNombreBackup.Name = "txtNombreBackup";
            this.txtNombreBackup.Size = new System.Drawing.Size(200, 23);
            this.txtNombreBackup.TabIndex = 1;
            this.txtNombreBackup.Text = "Respaldo";
            // 
            // chkAgregarFecha
            // 
            this.chkAgregarFecha.AutoSize = true;
            this.chkAgregarFecha.Location = new System.Drawing.Point(340, 184);
            this.chkAgregarFecha.Name = "chkAgregarFecha";
            this.chkAgregarFecha.Size = new System.Drawing.Size(113, 19);
            this.chkAgregarFecha.TabIndex = 0;
            this.chkAgregarFecha.Text = "Agregar la fecha";
            this.chkAgregarFecha.UseVisualStyleBackColor = true;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(40, 350);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(460, 35);
            this.btnBackup.TabIndex = 4;
            this.btnBackup.Text = "Generar Backup";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblResultado.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblResultado.Location = new System.Drawing.Point(40, 400);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 15);
            this.lblResultado.TabIndex = 5;
            // 
            // BackUpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.grpOpciones);
            this.Controls.Add(this.btnSeleccionarDestino);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.lblDestino);
            this.Name = "BackUpControl";
            this.Size = new System.Drawing.Size(600, 450);
            this.grpOpciones.ResumeLayout(false);
            this.grpOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button btnSeleccionarDestino;
        private System.Windows.Forms.GroupBox grpOpciones;
        private System.Windows.Forms.CheckedListBox clbTablas;
        private System.Windows.Forms.RadioButton rbBackupSelectivo;
        private System.Windows.Forms.RadioButton rbBackupCompleto;
        private System.Windows.Forms.Label lblNombreBackup;
        private System.Windows.Forms.TextBox txtNombreBackup;
        private System.Windows.Forms.CheckBox chkAgregarFecha;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label lblResultado;
    }
}
