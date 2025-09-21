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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            lbUsuario = new Label();
            pbSalir = new PictureBox();
            pbProductos = new PictureBox();
            pbClientes = new PictureBox();
            pbVentas = new PictureBox();
            pbReportes = new PictureBox();
            pbUsuario = new PictureBox();
            lbMenu = new Label();
            pbMenu = new PictureBox();
            panel3 = new Panel();
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
            panel1.Controls.Add(lbMenu);
            panel1.Controls.Add(pbMenu);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(121, 707);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lbUsuario);
            panel2.Controls.Add(pbSalir);
            panel2.Controls.Add(pbProductos);
            panel2.Controls.Add(pbClientes);
            panel2.Controls.Add(pbVentas);
            panel2.Controls.Add(pbReportes);
            panel2.Controls.Add(pbUsuario);
            panel2.Location = new Point(9, 88);
            panel2.Name = "panel2";
            panel2.Size = new Size(104, 593);
            panel2.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.Popup;
            label8.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            label8.Location = new Point(28, 558);
            label8.Name = "label8";
            label8.Size = new Size(43, 21);
            label8.TabIndex = 0;
            label8.Text = "Salir";
            label8.Click += lbMenu_Click_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.FlatStyle = FlatStyle.Popup;
            label6.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            label6.Location = new Point(13, 461);
            label6.Name = "label6";
            label6.Size = new Size(83, 21);
            label6.TabIndex = 0;
            label6.Text = "Productos";
            label6.Click += lbMenu_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Popup;
            label5.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            label5.Location = new Point(20, 365);
            label5.Name = "label5";
            label5.Size = new Size(68, 21);
            label5.TabIndex = 0;
            label5.Text = "Clientes";
            label5.Click += lbMenu_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Popup;
            label4.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            label4.Location = new Point(24, 272);
            label4.Name = "label4";
            label4.Size = new Size(60, 21);
            label4.TabIndex = 0;
            label4.Text = "Ventas";
            label4.Click += lbMenu_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Popup;
            label3.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            label3.Location = new Point(20, 177);
            label3.Name = "label3";
            label3.Size = new Size(76, 21);
            label3.TabIndex = 0;
            label3.Text = "Reportes";
            label3.Click += lbMenu_Click_1;
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.FlatStyle = FlatStyle.Popup;
            lbUsuario.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbUsuario.Location = new Point(15, 83);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(73, 21);
            lbUsuario.TabIndex = 0;
            lbUsuario.Text = "Usuarios";
            lbUsuario.Click += label2_Click;
            // 
            // pbSalir
            // 
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
            pbUsuario.Image = (Image)resources.GetObject("pbUsuario.Image");
            pbUsuario.Location = new Point(28, 30);
            pbUsuario.Name = "pbUsuario";
            pbUsuario.Size = new Size(51, 50);
            pbUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
            pbUsuario.TabIndex = 0;
            pbUsuario.TabStop = false;
            pbUsuario.Click += pbUsuario_Click;
            // 
            // lbMenu
            // 
            lbMenu.AutoSize = true;
            lbMenu.BackColor = Color.Transparent;
            lbMenu.FlatStyle = FlatStyle.Popup;
            lbMenu.Font = new Font("Corbel", 17F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbMenu.Location = new Point(37, 64);
            lbMenu.Name = "lbMenu";
            lbMenu.Size = new Size(51, 21);
            lbMenu.TabIndex = 0;
            lbMenu.Text = "Menú";
            lbMenu.Click += lbMenu_Click_1;
            // 
            // pbMenu
            // 
            pbMenu.BackColor = SystemColors.ControlLight;
            pbMenu.Image = (Image)resources.GetObject("pbMenu.Image");
            pbMenu.Location = new Point(23, 3);
            pbMenu.Name = "pbMenu";
            pbMenu.Size = new Size(74, 74);
            pbMenu.SizeMode = PictureBoxSizeMode.CenterImage;
            pbMenu.TabIndex = 1;
            pbMenu.TabStop = false;
            pbMenu.Click += pbMenu_Click_1;
            // 
            // panel3
            // 
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.Location = new Point(127, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(919, 689);
            panel3.TabIndex = 1;
            panel3.Paint += panel3_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 707);
            Controls.Add(panel3);
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
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private PictureBox pbSalir;
        private PictureBox pbProductos;
        private PictureBox pbClientes;
        private PictureBox pbVentas;
        private PictureBox pbReportes;
        private Panel panel3;
    }
}
