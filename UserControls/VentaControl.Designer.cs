namespace nikeproject.Forms
{
    partial class VentaControl
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
            lblListaVentas = new Label();
            lblFechaFiltro = new Label();
            dtpFecha = new DateTimePicker();
            btnFiltrar = new FontAwesome.Sharp.IconButton();
            btnLimpiarFiltro = new FontAwesome.Sharp.IconButton();
            btnNuevaVenta = new Button();
            dgvVentas = new DataGridView();
            idVenta = new DataGridViewTextBoxColumn();
            FechaRegistro = new DataGridViewTextBoxColumn();
            TipoDocumento = new DataGridViewTextBoxColumn();
            NumeroDocumento = new DataGridViewTextBoxColumn();
            MontoTotal = new DataGridViewTextBoxColumn();
            btnDetalle = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // lblListaVentas
            // 
            lblListaVentas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblListaVentas.BackColor = Color.White;
            lblListaVentas.Font = new Font("Segoe UI", 15F);
            lblListaVentas.Location = new Point(0, 0);
            lblListaVentas.Name = "lblListaVentas";
            lblListaVentas.Padding = new Padding(15, 0, 0, 0);
            lblListaVentas.Size = new Size(873, 86);
            lblListaVentas.TabIndex = 15;
            lblListaVentas.Text = "Lista de Ventas";
            lblListaVentas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFechaFiltro
            // 
            lblFechaFiltro.AutoSize = true;
            lblFechaFiltro.BackColor = Color.White;
            lblFechaFiltro.Location = new Point(20, 36);
            lblFechaFiltro.Name = "lblFechaFiltro";
            lblFechaFiltro.Size = new Size(41, 15);
            lblFechaFiltro.TabIndex = 9;
            lblFechaFiltro.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(67, 34);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(120, 23);
            dtpFecha.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.DimGray;
            btnFiltrar.Cursor = Cursors.Hand;
            btnFiltrar.FlatAppearance.BorderColor = Color.Black;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.IconChar = FontAwesome.Sharp.IconChar.Filter;
            btnFiltrar.IconColor = Color.White;
            btnFiltrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFiltrar.IconSize = 16;
            btnFiltrar.Location = new Point(200, 33);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(43, 24);
            btnFiltrar.TabIndex = 4;
            btnFiltrar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarFiltro
            // 
            btnLimpiarFiltro.BackColor = Color.DarkGray;
            btnLimpiarFiltro.Cursor = Cursors.Hand;
            btnLimpiarFiltro.FlatAppearance.BorderColor = Color.Black;
            btnLimpiarFiltro.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltro.IconChar = FontAwesome.Sharp.IconChar.Broom;
            btnLimpiarFiltro.IconColor = Color.Black;
            btnLimpiarFiltro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLimpiarFiltro.IconSize = 16;
            btnLimpiarFiltro.Location = new Point(249, 34);
            btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            btnLimpiarFiltro.Size = new Size(43, 24);
            btnLimpiarFiltro.TabIndex = 14;
            btnLimpiarFiltro.UseVisualStyleBackColor = false;
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevaVenta.BackColor = Color.ForestGreen;
            btnNuevaVenta.Cursor = Cursors.Hand;
            btnNuevaVenta.FlatAppearance.BorderColor = Color.Black;
            btnNuevaVenta.FlatStyle = FlatStyle.Flat;
            btnNuevaVenta.ForeColor = Color.White;
            btnNuevaVenta.Location = new Point(768, 33);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(88, 24);
            btnNuevaVenta.TabIndex = 5;
            btnNuevaVenta.Text = "Nueva Venta";
            btnNuevaVenta.UseVisualStyleBackColor = false;
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVentas.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Columns.AddRange(new DataGridViewColumn[] { idVenta, FechaRegistro, TipoDocumento, NumeroDocumento, MontoTotal, btnDetalle });
            dgvVentas.Location = new Point(20, 95);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvVentas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvVentas.RowTemplate.Height = 28;
            dgvVentas.Size = new Size(836, 595);
            dgvVentas.TabIndex = 6;
            // 
            // idVenta
            // 
            idVenta.DataPropertyName = "idVenta";
            idVenta.HeaderText = "Id Venta";
            idVenta.Name = "idVenta";
            idVenta.ReadOnly = true;
            idVenta.Visible = false;
            // 
            // FechaRegistro
            // 
            FechaRegistro.DataPropertyName = "FechaRegistro";
            FechaRegistro.HeaderText = "Fecha";
            FechaRegistro.Name = "FechaRegistro";
            FechaRegistro.ReadOnly = true;
            FechaRegistro.Width = 150;
            // 
            // TipoDocumento
            // 
            TipoDocumento.DataPropertyName = "TipoDocumento";
            TipoDocumento.HeaderText = "Tipo Doc.";
            TipoDocumento.Name = "TipoDocumento";
            TipoDocumento.ReadOnly = true;
            TipoDocumento.Width = 150;
            // 
            // NumeroDocumento
            // 
            NumeroDocumento.DataPropertyName = "NumeroDocumento";
            NumeroDocumento.HeaderText = "Nro. Documento";
            NumeroDocumento.Name = "NumeroDocumento";
            NumeroDocumento.ReadOnly = true;
            NumeroDocumento.Width = 180;
            // 
            // MontoTotal
            // 
            MontoTotal.DataPropertyName = "MontoTotal";
            MontoTotal.HeaderText = "Monto Total";
            MontoTotal.Name = "MontoTotal";
            MontoTotal.ReadOnly = true;
            MontoTotal.Width = 150;
            // 
            // btnDetalle
            // 
            btnDetalle.HeaderText = "";
            btnDetalle.Name = "btnDetalle";
            btnDetalle.ReadOnly = true;
            btnDetalle.Text = "Ver Detalle";
            btnDetalle.UseColumnTextForButtonValue = true;
            btnDetalle.Width = 80;
            // 
            // VentaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            Controls.Add(btnNuevaVenta);
            Controls.Add(btnLimpiarFiltro);
            Controls.Add(btnFiltrar);
            Controls.Add(dtpFecha);
            Controls.Add(lblFechaFiltro);
            Controls.Add(dgvVentas);
            Controls.Add(lblListaVentas);
            Name = "VentaControl";
            Size = new Size(873, 702);
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblListaVentas;
        private Label lblFechaFiltro;
        private DateTimePicker dtpFecha;
        // Se removieron: cbCliente, lblClienteFiltro, cbUsuario, lblUsuarioFiltro
        private FontAwesome.Sharp.IconButton btnFiltrar;
        private FontAwesome.Sharp.IconButton btnLimpiarFiltro;
        private Button btnNuevaVenta;
        private DataGridView dgvVentas;
        private DataGridViewTextBoxColumn idVenta;
        private DataGridViewTextBoxColumn FechaRegistro;
        private DataGridViewTextBoxColumn TipoDocumento;
        private DataGridViewTextBoxColumn NumeroDocumento;
        private DataGridViewTextBoxColumn MontoTotal;
        private DataGridViewButtonColumn btnDetalle;
    }
}
