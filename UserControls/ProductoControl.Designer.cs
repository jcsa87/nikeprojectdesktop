namespace nikeproject.UserControls
{
    partial class ProductoControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Panel panelSeparator;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductoControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            pictureBox1 = new PictureBox();
            lblTitulo = new Label();
            panelSeparator = new Panel();
            cbEstado = new ComboBox();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnNuevo = new Button();
            dgvProductos = new DataGridView();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
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
            lblTitulo.Location = new Point(97, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(260, 32);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Gestión de Productos";
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
            // cbEstado
            // 
            cbEstado.BackColor = Color.WhiteSmoke;
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.FlatStyle = FlatStyle.Flat;
            cbEstado.ForeColor = Color.Black;
            cbEstado.Items.AddRange(new object[] { "Todos", "Activos", "Inactivos" });
            cbEstado.Location = new Point(30, 105);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(120, 23);
            cbEstado.TabIndex = 2;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(170, 105);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar producto...";
            txtBuscar.Size = new Size(200, 23);
            txtBuscar.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.DimGray;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(390, 105);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.Black;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(490, 105);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(80, 23);
            btnNuevo.TabIndex = 5;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // dgvProductos
            // 
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.DarkGray;
            dgvProductos.Location = new Point(30, 134);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(822, 550);
            dgvProductos.TabIndex = 6;
            // 
            // ProductoControl
            // 
            Controls.Add(panelHeader);
            Controls.Add(panelSeparator);
            Controls.Add(cbEstado);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvProductos);
            Name = "ProductoControl";
            Size = new Size(873, 702);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
