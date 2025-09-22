namespace nikeproject.Forms
{
    partial class VentaControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.Panel panelSeparator;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentaControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            pictureBox1 = new PictureBox();
            lblTitulo = new Label();
            panelSeparator = new Panel();
            cbCliente = new ComboBox();
            cbUsuario = new ComboBox();
            dtpFecha = new DateTimePicker();
            btnFiltrar = new Button();
            btnNuevaVenta = new Button();
            dgvVentas = new DataGridView();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelHeader.BackColor = Color.FromArgb(240, 240, 240);
            panelHeader.Controls.Add(pictureBox1);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1596, 90);
            panelHeader.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(30, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.Black;
            lblTitulo.Location = new Point(85, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(218, 32);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Gestión de Ventas";
            // 
            // panelSeparator
            // 
            panelSeparator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSeparator.BackColor = Color.DarkGray;
            panelSeparator.Location = new Point(0, 90);
            panelSeparator.Name = "panelSeparator";
            panelSeparator.Size = new Size(1596, 2);
            panelSeparator.TabIndex = 1;
            // 
            // cbCliente
            // 
            cbCliente.BackColor = Color.WhiteSmoke;
            cbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCliente.FlatStyle = FlatStyle.Flat;
            cbCliente.ForeColor = Color.Black;
            cbCliente.Items.AddRange(new object[] { "Todos los clientes" });
            cbCliente.Location = new Point(30, 105);
            cbCliente.Name = "cbCliente";
            cbCliente.Size = new Size(180, 23);
            cbCliente.TabIndex = 1;
            // 
            // cbUsuario
            // 
            cbUsuario.BackColor = Color.WhiteSmoke;
            cbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUsuario.FlatStyle = FlatStyle.Flat;
            cbUsuario.ForeColor = Color.Black;
            cbUsuario.Items.AddRange(new object[] { "Todos los usuarios" });
            cbUsuario.Location = new Point(230, 105);
            cbUsuario.Name = "cbUsuario";
            cbUsuario.Size = new Size(180, 23);
            cbUsuario.TabIndex = 2;
            // 
            // dtpFecha
            // 
            dtpFecha.CalendarMonthBackground = Color.WhiteSmoke;
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(430, 105);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(180, 23);
            dtpFecha.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.DimGray;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(630, 105);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(80, 23);
            btnFiltrar.TabIndex = 4;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.Location = new Point(0, 0);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(75, 23);
            btnNuevaVenta.TabIndex = 5;
            // 
            // dgvVentas
            // 
            dgvVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVentas.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVentas.EnableHeadersVisualStyles = false;
            dgvVentas.GridColor = Color.DarkGray;
            dgvVentas.Location = new Point(30, 145);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(800, 540);
            dgvVentas.TabIndex = 6;
            // 
            // VentaControl
            // 
            Controls.Add(panelHeader);
            Controls.Add(panelSeparator);
            Controls.Add(cbCliente);
            Controls.Add(cbUsuario);
            Controls.Add(dtpFecha);
            Controls.Add(btnFiltrar);
            Controls.Add(btnNuevaVenta);
            Controls.Add(dgvVentas);
            Name = "VentaControl";
            Size = new Size(873, 702);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
        }
    }
}
