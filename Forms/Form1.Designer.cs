namespace nikeproject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            panel2 = new Panel();
            label8 = new Label();
            lbProductos = new Label();
            lbCliente = new Label();
            lbVentas = new Label();
            lbReporte = new Label();
            lbUsuario = new Label();
            pbSalir = new PictureBox();
            pbProductos = new PictureBox();
            pbClientes = new PictureBox();
            pbVentas = new PictureBox();
            pbReportes = new PictureBox();
            pbUsuario = new PictureBox();
            lRol = new Label();
            lbMenu = new Label();
            pbMenu = new PictureBox();
            panelContenedor = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSalir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbReportes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbUsuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMenu).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lRol);
            panel1.Controls.Add(lbMenu);
            panel1.Controls.Add(pbMenu);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(121, 702);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(lbProductos);
            panel2.Controls.Add(lbCliente);
            panel2.Controls.Add(lbVentas);
            panel2.Controls.Add(lbReporte);
            panel2.Controls.Add(lbUsuario);
            panel2.Controls.Add(pbSalir);
            panel2.Controls.Add(pbProductos);
            panel2.Controls.Add(pbClientes);
            panel2.Controls.Add(pbVentas);
            panel2.Controls.Add(pbReportes);
            panel2.Controls.Add(pbUsuario);
            panel2.Location = new Point(9, 102);
            panel2.Name = "panel2";
            panel2.Size = new Size(104, 588);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Cursor = Cursors.Hand;
            label8.FlatStyle = FlatStyle.Popup;
            label8.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            label8.Location = new Point(28, 558);
            label8.Name = "label8";
            label8.Size = new Size(43, 21);
            label8.TabIndex = 0;
            label8.Text = "Salir";
            // 
            // lbProductos
            // 
            lbProductos.AutoSize = true;
            lbProductos.Cursor = Cursors.Hand;
            lbProductos.FlatStyle = FlatStyle.Popup;
            lbProductos.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbProductos.Location = new Point(13, 461);
            lbProductos.Name = "lbProductos";
            lbProductos.Size = new Size(83, 21);
            lbProductos.TabIndex = 0;
            lbProductos.Text = "Productos";
            // 
            // lbCliente
            // 
            lbCliente.AutoSize = true;
            lbCliente.Cursor = Cursors.Hand;
            lbCliente.FlatStyle = FlatStyle.Popup;
            lbCliente.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbCliente.Location = new Point(20, 365);
            lbCliente.Name = "lbCliente";
            lbCliente.Size = new Size(68, 21);
            lbCliente.TabIndex = 0;
            lbCliente.Text = "Clientes";
            // 
            // lbVentas
            // 
            lbVentas.AutoSize = true;
            lbVentas.Cursor = Cursors.Hand;
            lbVentas.FlatStyle = FlatStyle.Popup;
            lbVentas.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbVentas.Location = new Point(24, 272);
            lbVentas.Name = "lbVentas";
            lbVentas.Size = new Size(60, 21);
            lbVentas.TabIndex = 0;
            lbVentas.Text = "Ventas";
            // 
            // lbReporte
            // 
            lbReporte.AutoSize = true;
            lbReporte.Cursor = Cursors.Hand;
            lbReporte.FlatStyle = FlatStyle.Popup;
            lbReporte.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbReporte.Location = new Point(20, 177);
            lbReporte.Name = "lbReporte";
            lbReporte.Size = new Size(76, 21);
            lbReporte.TabIndex = 0;
            lbReporte.Text = "Reportes";
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Cursor = Cursors.Hand;
            lbUsuario.FlatStyle = FlatStyle.Popup;
            lbUsuario.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbUsuario.Location = new Point(15, 83);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(73, 21);
            lbUsuario.TabIndex = 0;
            lbUsuario.Text = "Usuarios";
            lbUsuario.Click += lbUsuario_Click;
            // 
            // pbSalir
            // 
            pbSalir.Cursor = Cursors.Hand;
            pbSalir.Image = (Image)resources.GetObject("pbSalir.Image");
            pbSalir.Location = new Point(28, 505);
            pbSalir.Name = "pbSalir";
            pbSalir.Size = new Size(51, 50);
            pbSalir.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSalir.TabIndex = 0;
            pbSalir.TabStop = false;
            pbSalir.Click += pbSalir_Click;
            // 
            // pbProductos
            // 
            pbProductos.Cursor = Cursors.Hand;
            pbProductos.Image = (Image)resources.GetObject("pbProductos.Image");
            pbProductos.Location = new Point(28, 408);
            pbProductos.Name = "pbProductos";
            pbProductos.Size = new Size(51, 50);
            pbProductos.SizeMode = PictureBoxSizeMode.StretchImage;
            pbProductos.TabIndex = 0;
            pbProductos.TabStop = false;
            pbProductos.Click += pbProductos_Click;
            // 
            // pbClientes
            // 
            pbClientes.Cursor = Cursors.Hand;
            pbClientes.Image = (Image)resources.GetObject("pbClientes.Image");
            pbClientes.Location = new Point(28, 312);
            pbClientes.Name = "pbClientes";
            pbClientes.Size = new Size(51, 50);
            pbClientes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbClientes.TabIndex = 0;
            pbClientes.TabStop = false;
            pbClientes.Click += pbClientes_Click;
            // 
            // pbVentas
            // 
            pbVentas.Cursor = Cursors.Hand;
            pbVentas.Image = (Image)resources.GetObject("pbVentas.Image");
            pbVentas.Location = new Point(28, 219);
            pbVentas.Name = "pbVentas";
            pbVentas.Size = new Size(51, 50);
            pbVentas.SizeMode = PictureBoxSizeMode.StretchImage;
            pbVentas.TabIndex = 0;
            pbVentas.TabStop = false;
            pbVentas.Click += pbVentas_Click;
            // 
            // pbReportes
            // 
            pbReportes.Cursor = Cursors.Hand;
            pbReportes.Image = (Image)resources.GetObject("pbReportes.Image");
            pbReportes.Location = new Point(28, 124);
            pbReportes.Name = "pbReportes";
            pbReportes.Size = new Size(51, 50);
            pbReportes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbReportes.TabIndex = 0;
            pbReportes.TabStop = false;
            pbReportes.Click += pbReportes_Click;
            // 
            // pbUsuario
            // 
            pbUsuario.Cursor = Cursors.Hand;
            pbUsuario.Image = (Image)resources.GetObject("pbUsuario.Image");
            pbUsuario.Location = new Point(28, 30);
            pbUsuario.Name = "pbUsuario";
            pbUsuario.Size = new Size(51, 50);
            pbUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
            pbUsuario.TabIndex = 0;
            pbUsuario.TabStop = false;
            pbUsuario.Click += pbUsuario_Click;
            // 
            // lRol
            // 
            lRol.AutoSize = true;
            lRol.BackColor = Color.Transparent;
            lRol.Cursor = Cursors.Hand;
            lRol.FlatStyle = FlatStyle.Popup;
            lRol.Font = new Font("Corbel", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lRol.Location = new Point(36, 84);
            lRol.Name = "lRol";
            lRol.Size = new Size(23, 14);
            lRol.TabIndex = 0;
            lRol.Text = "Rol";
            lRol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbMenu
            // 
            lbMenu.AutoSize = true;
            lbMenu.BackColor = Color.Transparent;
            lbMenu.Cursor = Cursors.Hand;
            lbMenu.FlatStyle = FlatStyle.Popup;
            lbMenu.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbMenu.Location = new Point(37, 64);
            lbMenu.Name = "lbMenu";
            lbMenu.Size = new Size(51, 21);
            lbMenu.TabIndex = 0;
            lbMenu.Text = "Menú";
            // 
            // pbMenu
            // 
            pbMenu.BackColor = SystemColors.ControlLight;
            pbMenu.Cursor = Cursors.Hand;
            pbMenu.Image = (Image)resources.GetObject("pbMenu.Image");
            pbMenu.Location = new Point(23, 3);
            pbMenu.Name = "pbMenu";
            pbMenu.Size = new Size(74, 74);
            pbMenu.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMenu.TabIndex = 1;
            pbMenu.TabStop = false;
            pbMenu.Click += pbMenu_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.BackgroundImage = (Image)resources.GetObject("panelContenedor.BackgroundImage");
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(121, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(866, 702);
            panelContenedor.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 702);
            Controls.Add(panelContenedor);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSalir).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbReportes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbUsuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMenu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lbMenu;
        private PictureBox pbMenu;
        private Panel panel2;
        private PictureBox pbUsuario;
        private Label lbUsuario;
        private Label label8;
        private Label lbProductos;
        private Label lbCliente;
        private Label lbVentas;
        private Label lbReporte;
        private PictureBox pbSalir;
        private PictureBox pbProductos;
        private PictureBox pbClientes;
        private PictureBox pbVentas;
        private PictureBox pbReportes;
        private Panel panelContenedor;
        private Label lRol;
    }
}
