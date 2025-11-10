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
            panelMenu = new Panel();
            pbSalir = new PictureBox();
            pBotones = new Panel();
            flowMenu = new FlowLayoutPanel();
            pbUsuario = new PictureBox();
            lbUsuario = new Label();
            pbBackUp = new PictureBox();
            lbBackup = new Label();
            pbVentas = new PictureBox();
            lbVentas = new Label();
            pbClientes = new PictureBox();
            lbCliente = new Label();
            pbProductos = new PictureBox();
            lbProductos = new Label();
            pbReportes = new PictureBox();
            lbReportes = new Label();
            pSuperior = new Panel();
            lRol = new Label();
            lbMenu = new Label();
            pbMenu = new PictureBox();
            panelContenedor = new Panel();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSalir).BeginInit();
            pBotones.SuspendLayout();
            flowMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUsuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBackUp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbReportes).BeginInit();
            pSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMenu).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.ControlLight;
            panelMenu.Controls.Add(pbSalir);
            panelMenu.Controls.Add(pBotones);
            panelMenu.Controls.Add(pSuperior);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(0);
            panelMenu.MaximumSize = new Size(125, 702);
            panelMenu.MinimumSize = new Size(125, 702);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(125, 702);
            panelMenu.TabIndex = 0;
            // 
            // pbSalir
            // 
            pbSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pbSalir.Cursor = Cursors.Hand;
            pbSalir.Image = Properties.Resources.botonSalir;
            pbSalir.Location = new Point(0, 648);
            pbSalir.Margin = new Padding(3, 3, 3, 0);
            pbSalir.Name = "pbSalir";
            pbSalir.Size = new Size(125, 54);
            pbSalir.SizeMode = PictureBoxSizeMode.Zoom;
            pbSalir.TabIndex = 0;
            pbSalir.TabStop = false;
            pbSalir.Click += pbSalir_Click;
            // 
            // pBotones
            // 
            pBotones.BackColor = SystemColors.ControlLight;
            pBotones.Controls.Add(flowMenu);
            pBotones.Dock = DockStyle.Fill;
            pBotones.Location = new Point(0, 84);
            pBotones.Name = "pBotones";
            pBotones.Padding = new Padding(15, 15, 0, 0);
            pBotones.Size = new Size(125, 618);
            pBotones.TabIndex = 2;
            // 
            // flowMenu
            // 
            flowMenu.BackColor = Color.Transparent;
            flowMenu.Controls.Add(pbUsuario);
            flowMenu.Controls.Add(lbUsuario);
            flowMenu.Controls.Add(pbBackUp);
            flowMenu.Controls.Add(lbBackup);
            flowMenu.Controls.Add(pbVentas);
            flowMenu.Controls.Add(lbVentas);
            flowMenu.Controls.Add(pbClientes);
            flowMenu.Controls.Add(lbCliente);
            flowMenu.Controls.Add(pbProductos);
            flowMenu.Controls.Add(lbProductos);
            flowMenu.Controls.Add(pbReportes);
            flowMenu.Controls.Add(lbReportes);
            flowMenu.Dock = DockStyle.Fill;
            flowMenu.FlowDirection = FlowDirection.TopDown;
            flowMenu.Location = new Point(15, 15);
            flowMenu.Margin = new Padding(0);
            flowMenu.Name = "flowMenu";
            flowMenu.Padding = new Padding(7, 20, 0, 0);
            flowMenu.Size = new Size(110, 603);
            flowMenu.TabIndex = 0;
            flowMenu.WrapContents = false;

            // 
            // pbUsuario
            // 
            pbUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbUsuario.BorderStyle = BorderStyle.Fixed3D;
            pbUsuario.Cursor = Cursors.Hand;
            pbUsuario.Image = Properties.Resources.botonUsuario2;
            pbUsuario.Location = new Point(10, 23);
            pbUsuario.Name = "pbUsuario";
            pbUsuario.Size = new Size(100, 52);
            pbUsuario.SizeMode = PictureBoxSizeMode.Zoom;
            pbUsuario.TabIndex = 0;
            pbUsuario.TabStop = false;
            pbUsuario.Click += pbUsuario_Click;
            // 
            // lbUsuario
            // 
            lbUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbUsuario.AutoSize = true;
            lbUsuario.BackColor = SystemColors.ControlLight;
            lbUsuario.Cursor = Cursors.Hand;
            lbUsuario.FlatStyle = FlatStyle.System;
            lbUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbUsuario.Location = new Point(10, 78);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Padding = new Padding(10, 0, 0, 0);
            lbUsuario.Size = new Size(100, 19);
            lbUsuario.TabIndex = 0;
            lbUsuario.Text = "Usuarios";
            lbUsuario.TextAlign = ContentAlignment.MiddleCenter;
            lbUsuario.Click += pbUsuario_Click;
            // 
            // pbBackUp
            // 
            pbBackUp.BorderStyle = BorderStyle.Fixed3D;
            pbBackUp.Cursor = Cursors.Hand;
            pbBackUp.Image = Properties.Resources.botonBackUp;
            pbBackUp.Location = new Point(10, 100);
            pbBackUp.Name = "pbBackUp";
            pbBackUp.Size = new Size(100, 50);
            pbBackUp.SizeMode = PictureBoxSizeMode.Zoom;
            pbBackUp.TabIndex = 0;
            pbBackUp.TabStop = false;
            pbBackUp.Click += pbBackUp_Click;
            // 
            // lbBackup
            // 
            lbBackup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbBackup.AutoSize = true;
            lbBackup.Cursor = Cursors.Hand;
            lbBackup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbBackup.Location = new Point(10, 153);
            lbBackup.Name = "lbBackup";
            lbBackup.Padding = new Padding(10, 0, 0, 0);
            lbBackup.Size = new Size(100, 19);
            lbBackup.TabIndex = 0;
            lbBackup.Text = "BuckUp";
            lbBackup.TextAlign = ContentAlignment.TopCenter;
            lbBackup.Click += pbBackUp_Click;
            // 
            // pbVentas
            // 
            pbVentas.BorderStyle = BorderStyle.Fixed3D;
            pbVentas.Cursor = Cursors.Hand;
            pbVentas.Image = Properties.Resources.botonVentas;
            pbVentas.Location = new Point(10, 175);
            pbVentas.Name = "pbVentas";
            pbVentas.Size = new Size(100, 50);
            pbVentas.SizeMode = PictureBoxSizeMode.Zoom;
            pbVentas.TabIndex = 0;
            pbVentas.TabStop = false;
            pbVentas.Click += pbVentas_Click;
            // 
            // lbVentas
            // 
            lbVentas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbVentas.AutoSize = true;
            lbVentas.Cursor = Cursors.Hand;
            lbVentas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbVentas.Location = new Point(10, 228);
            lbVentas.Name = "lbVentas";
            lbVentas.Padding = new Padding(10, 0, 0, 0);
            lbVentas.Size = new Size(100, 19);
            lbVentas.TabIndex = 0;
            lbVentas.Text = "Ventas";
            lbVentas.TextAlign = ContentAlignment.MiddleCenter;
            lbVentas.Click += pbVentas_Click;
            // 
            // pbClientes
            // 
            pbClientes.BorderStyle = BorderStyle.Fixed3D;
            pbClientes.Cursor = Cursors.Hand;
            pbClientes.Image = Properties.Resources.botonClientes;
            pbClientes.Location = new Point(10, 250);
            pbClientes.Name = "pbClientes";
            pbClientes.Size = new Size(100, 47);
            pbClientes.SizeMode = PictureBoxSizeMode.Zoom;
            pbClientes.TabIndex = 0;
            pbClientes.TabStop = false;
            pbClientes.Click += pbClientes_Click;
            // 
            // lbCliente
            // 
            lbCliente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbCliente.AutoSize = true;
            lbCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbCliente.Location = new Point(10, 300);
            lbCliente.Name = "lbCliente";
            lbCliente.Padding = new Padding(10, 0, 0, 0);
            lbCliente.Size = new Size(100, 19);
            lbCliente.TabIndex = 0;
            lbCliente.Text = "Clientes";
            lbCliente.TextAlign = ContentAlignment.MiddleCenter;
            lbCliente.Click += pbVentas_Click;
            // 
            // pbProductos
            // 
            pbProductos.BorderStyle = BorderStyle.Fixed3D;
            pbProductos.Cursor = Cursors.Hand;
            pbProductos.Image = Properties.Resources.botonProductoa;
            pbProductos.Location = new Point(10, 322);
            pbProductos.Name = "pbProductos";
            pbProductos.Size = new Size(100, 47);
            pbProductos.SizeMode = PictureBoxSizeMode.Zoom;
            pbProductos.TabIndex = 0;
            pbProductos.TabStop = false;
            pbProductos.Click += pbProductos_Click;
            // 
            // lbProductos
            // 
            lbProductos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbProductos.AutoSize = true;
            lbProductos.Cursor = Cursors.Hand;
            lbProductos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbProductos.Location = new Point(10, 372);
            lbProductos.Name = "lbProductos";
            lbProductos.Padding = new Padding(10, 0, 0, 0);
            lbProductos.Size = new Size(100, 19);
            lbProductos.TabIndex = 0;
            lbProductos.Text = "Productos";
            lbProductos.TextAlign = ContentAlignment.MiddleCenter;
            lbProductos.Click += pbProductos_Click;
            // 
            // pbReportes
            // 
            pbReportes.BorderStyle = BorderStyle.Fixed3D;
            pbReportes.Cursor = Cursors.Hand;
            pbReportes.Image = Properties.Resources.botonReportes;
            pbReportes.Location = new Point(10, 394);
            pbReportes.Name = "pbReportes";
            pbReportes.Size = new Size(100, 50);
            pbReportes.SizeMode = PictureBoxSizeMode.Zoom;
            pbReportes.TabIndex = 0;
            pbReportes.TabStop = false;
            pbReportes.Click += pbReportes_Click;
            // 
            // lbReportes
            // 
            lbReportes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbReportes.AutoSize = true;
            lbReportes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbReportes.Location = new Point(10, 447);
            lbReportes.Name = "lbReportes";
            lbReportes.Padding = new Padding(10, 0, 0, 0);
            lbReportes.Size = new Size(100, 19);
            lbReportes.TabIndex = 0;
            lbReportes.Text = "Reportes";
            lbReportes.TextAlign = ContentAlignment.MiddleCenter;
            lbReportes.Click += pbReportes_Click;
            // 
            // pSuperior
            // 
            pSuperior.Controls.Add(lRol);
            pSuperior.Controls.Add(lbMenu);
            pSuperior.Controls.Add(pbMenu);
            pSuperior.Dock = DockStyle.Top;
            pSuperior.Location = new Point(0, 0);
            pSuperior.Name = "pSuperior";
            pSuperior.Size = new Size(125, 84);
            pSuperior.TabIndex = 2;
            // 
            // lRol
            // 
            lRol.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lRol.AutoSize = true;
            lRol.BackColor = Color.Transparent;
            lRol.Cursor = Cursors.Hand;
            lRol.FlatStyle = FlatStyle.Popup;
            lRol.Font = new Font("Corbel", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lRol.Location = new Point(25, 70);
            lRol.Name = "lRol";
            lRol.Size = new Size(23, 14);
            lRol.TabIndex = 0;
            lRol.Text = "Rol";
            lRol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbMenu
            // 
            lbMenu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbMenu.AutoSize = true;
            lbMenu.BackColor = Color.Transparent;
            lbMenu.Cursor = Cursors.Hand;
            lbMenu.FlatStyle = FlatStyle.Popup;
            lbMenu.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbMenu.Location = new Point(25, 53);
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
            pbMenu.Location = new Point(25, 0);
            pbMenu.Name = "pbMenu";
            pbMenu.Size = new Size(74, 74);
            pbMenu.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMenu.TabIndex = 1;
            pbMenu.TabStop = false;
            // 
            // panelContenedor
            // 
            panelContenedor.BackgroundImage = (Image)resources.GetObject("panelContenedor.BackgroundImage");
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(125, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(862, 702);
            panelContenedor.TabIndex = 1;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 702);
            Controls.Add(panelContenedor);
            Controls.Add(panelMenu);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbSalir).EndInit();
            pBotones.ResumeLayout(false);
            flowMenu.ResumeLayout(false);
            flowMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbUsuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBackUp).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbReportes).EndInit();
            pSuperior.ResumeLayout(false);
            pSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbMenu).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private Panel panelMenu;
        private Label lbMenu;
        private PictureBox pbMenu;
        private Panel pBotones;
        private Panel panelContenedor;
        private Label lRol;
        private FlowLayoutPanel flowMenu;
        private PictureBox pbUsuario;
        private Label lbUsuario;
        private PictureBox pbBackUp;
        private Label lbBackup;
        private PictureBox pbVentas;
        private Label lbVentas;
        private PictureBox pbClientes;
        private Label lbCliente;
        private PictureBox pbProductos;
        private Label lbProductos;
        private PictureBox pbReportes;
        private Label lbReportes;
        private PictureBox pbSalir;
        private Panel pSuperior;
    }
}
