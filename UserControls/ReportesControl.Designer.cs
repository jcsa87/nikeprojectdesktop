namespace nikeproject.UserControls
{
    partial class ReportesControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.Panel panelSeparator;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            pictureBox1 = new PictureBox();
            lblTitulo = new Label();
            panelSeparator = new Panel();
            cbFiltro = new ComboBox();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnExportar = new Button();
            dgvReportes = new DataGridView();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
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
            lblTitulo.Location = new Point(93, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(233, 32);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Reportes de Ventas";
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
            // cbFiltro
            // 
            cbFiltro.BackColor = Color.WhiteSmoke;
            cbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFiltro.FlatStyle = FlatStyle.Flat;
            cbFiltro.ForeColor = Color.Black;
            cbFiltro.Items.AddRange(new object[] { "Todos", "Hoy", "Este mes", "Por usuario" });
            cbFiltro.Location = new Point(20, 105);
            cbFiltro.Name = "cbFiltro";
            cbFiltro.Size = new Size(150, 23);
            cbFiltro.TabIndex = 2;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(200, 105);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar...";
            txtBuscar.Size = new Size(200, 23);
            txtBuscar.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.DimGray;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(420, 105);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.Black;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(520, 105);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(80, 23);
            btnExportar.TabIndex = 5;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = false;
            // 
            // dgvReportes
            // 
            dgvReportes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReportes.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReportes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReportes.EnableHeadersVisualStyles = false;
            dgvReportes.GridColor = Color.DarkGray;
            dgvReportes.Location = new Point(20, 138);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.Size = new Size(833, 561);
            dgvReportes.TabIndex = 6;
            // 
            // ReportesControl
            // 
            Controls.Add(panelHeader);
            Controls.Add(panelSeparator);
            Controls.Add(cbFiltro);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(btnExportar);
            Controls.Add(dgvReportes);
            Name = "ReportesControl";
            Size = new Size(873, 702);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
