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
            this.lblArchivos = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.btnSeleccionarOrigen = new System.Windows.Forms.Button();
            this.lblDestino = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.btnSeleccionarDestino = new System.Windows.Forms.Button();
            this.chkSobrescribir = new System.Windows.Forms.CheckBox();
            this.grpOpciones = new System.Windows.Forms.GroupBox();
            this.rbCopiaDirecta = new System.Windows.Forms.RadioButton();
            this.rbComprimirZip = new System.Windows.Forms.RadioButton();
            this.lblNombreBackup = new System.Windows.Forms.Label();
            this.txtNombreBackup = new System.Windows.Forms.TextBox();
            this.chkAgregarFecha = new System.Windows.Forms.CheckBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.grpOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblArchivos
            // 
            this.lblArchivos.AutoSize = true;
            this.lblArchivos.Location = new System.Drawing.Point(40, 40);
            this.lblArchivos.Name = "lblArchivos";
            this.lblArchivos.Size = new System.Drawing.Size(92, 15);
            this.lblArchivos.TabIndex = 0;
            this.lblArchivos.Text = "Carpeta origen:";
            // 
            // txtOrigen
            // 
            this.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrigen.Location = new System.Drawing.Point(40, 58);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(340, 23);
            this.txtOrigen.TabIndex = 1;
            // 
            // btnSeleccionarOrigen
            // 
            this.btnSeleccionarOrigen.BackColor = System.Drawing.Color.DarkGray;
            this.btnSeleccionarOrigen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarOrigen.Location = new System.Drawing.Point(400, 57);
            this.btnSeleccionarOrigen.Name = "btnSeleccionarOrigen";
            this.btnSeleccionarOrigen.Size = new System.Drawing.Size(100, 25);
            this.btnSeleccionarOrigen.TabIndex = 2;
            this.btnSeleccionarOrigen.Text = "Seleccionar...";
            this.btnSeleccionarOrigen.UseVisualStyleBackColor = false;
            this.btnSeleccionarOrigen.Click += new System.EventHandler(this.btnSeleccionarOrigen_Click);
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(40, 100);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(108, 15);
            this.lblDestino.TabIndex = 3;
            this.lblDestino.Text = "Carpeta de destino:";
            // 
            // txtDestino
            // 
            this.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDestino.Location = new System.Drawing.Point(40, 118);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(340, 23);
            this.txtDestino.TabIndex = 4;
            // 
            // btnSeleccionarDestino
            // 
            this.btnSeleccionarDestino.BackColor = System.Drawing.Color.DarkGray;
            this.btnSeleccionarDestino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarDestino.Location = new System.Drawing.Point(400, 117);
            this.btnSeleccionarDestino.Name = "btnSeleccionarDestino";
            this.btnSeleccionarDestino.Size = new System.Drawing.Size(100, 25);
            this.btnSeleccionarDestino.TabIndex = 5;
            this.btnSeleccionarDestino.Text = "Seleccionar...";
            this.btnSeleccionarDestino.UseVisualStyleBackColor = false;
            this.btnSeleccionarDestino.Click += new System.EventHandler(this.btnSeleccionarDestino_Click);
            // 
            // chkSobrescribir
            // 
            this.chkSobrescribir.AutoSize = true;
            this.chkSobrescribir.Location = new System.Drawing.Point(40, 150);
            this.chkSobrescribir.Name = "chkSobrescribir";
            this.chkSobrescribir.Size = new System.Drawing.Size(181, 19);
            this.chkSobrescribir.TabIndex = 6;
            this.chkSobrescribir.Text = "Sobrescribir archivos existentes";
            this.chkSobrescribir.UseVisualStyleBackColor = true;
            // 
            // grpOpciones
            // 
            this.grpOpciones.Controls.Add(this.rbCopiaDirecta);
            this.grpOpciones.Controls.Add(this.rbComprimirZip);
            this.grpOpciones.Controls.Add(this.lblNombreBackup);
            this.grpOpciones.Controls.Add(this.txtNombreBackup);
            this.grpOpciones.Controls.Add(this.chkAgregarFecha);
            this.grpOpciones.Location = new System.Drawing.Point(40, 190);
            this.grpOpciones.Name = "grpOpciones";
            this.grpOpciones.Size = new System.Drawing.Size(460, 130);
            this.grpOpciones.TabIndex = 7;
            this.grpOpciones.TabStop = false;
            this.grpOpciones.Text = "Configuraciones";
            // 
            // rbCopiaDirecta
            // 
            this.rbCopiaDirecta.AutoSize = true;
            this.rbCopiaDirecta.Checked = true;
            this.rbCopiaDirecta.Location = new System.Drawing.Point(20, 25);
            this.rbCopiaDirecta.Name = "rbCopiaDirecta";
            this.rbCopiaDirecta.Size = new System.Drawing.Size(144, 19);
            this.rbCopiaDirecta.TabIndex = 0;
            this.rbCopiaDirecta.TabStop = true;
            this.rbCopiaDirecta.Text = "Copiar archivos directo";
            this.rbCopiaDirecta.UseVisualStyleBackColor = true;
            // 
            // rbComprimirZip
            // 
            this.rbComprimirZip.AutoSize = true;
            this.rbComprimirZip.Location = new System.Drawing.Point(20, 50);
            this.rbComprimirZip.Name = "rbComprimirZip";
            this.rbComprimirZip.Size = new System.Drawing.Size(136, 19);
            this.rbComprimirZip.TabIndex = 1;
            this.rbComprimirZip.Text = "Comprimir como .ZIP";
            this.rbComprimirZip.UseVisualStyleBackColor = true;
            // 
            // lblNombreBackup
            // 
            this.lblNombreBackup.AutoSize = true;
            this.lblNombreBackup.Location = new System.Drawing.Point(20, 80);
            this.lblNombreBackup.Name = "lblNombreBackup";
            this.lblNombreBackup.Size = new System.Drawing.Size(92, 15);
            this.lblNombreBackup.TabIndex = 2;
            this.lblNombreBackup.Text = "Nombre backup:";
            // 
            // txtNombreBackup
            // 
            this.txtNombreBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreBackup.Location = new System.Drawing.Point(130, 78);
            this.txtNombreBackup.Name = "txtNombreBackup";
            this.txtNombreBackup.Size = new System.Drawing.Size(200, 23);
            this.txtNombreBackup.TabIndex = 3;
            this.txtNombreBackup.Text = "Respaldo";
            // 
            // chkAgregarFecha
            // 
            this.chkAgregarFecha.AutoSize = true;
            this.chkAgregarFecha.Location = new System.Drawing.Point(340, 80);
            this.chkAgregarFecha.Name = "chkAgregarFecha";
            this.chkAgregarFecha.Size = new System.Drawing.Size(113, 19);
            this.chkAgregarFecha.TabIndex = 4;
            this.chkAgregarFecha.Text = "Agregar la fecha";
            this.chkAgregarFecha.UseVisualStyleBackColor = true;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(40, 340);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(460, 35);
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "Generar Backup";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblResultado.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblResultado.Location = new System.Drawing.Point(40, 390);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 15);
            this.lblResultado.TabIndex = 9;
            // 
            // BackupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.grpOpciones);
            this.Controls.Add(this.chkSobrescribir);
            this.Controls.Add(this.btnSeleccionarDestino);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.btnSeleccionarOrigen);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.lblArchivos);
            this.Name = "BackupControl";
            this.Size = new System.Drawing.Size(600, 450);
            this.grpOpciones.ResumeLayout(false);
            this.grpOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblArchivos;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Button btnSeleccionarOrigen;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button btnSeleccionarDestino;
        private System.Windows.Forms.CheckBox chkSobrescribir;
        private System.Windows.Forms.GroupBox grpOpciones;
        private System.Windows.Forms.RadioButton rbCopiaDirecta;
        private System.Windows.Forms.RadioButton rbComprimirZip;
        private System.Windows.Forms.Label lblNombreBackup;
        private System.Windows.Forms.TextBox txtNombreBackup;
        private System.Windows.Forms.CheckBox chkAgregarFecha;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label lblResultado;
    }
}
