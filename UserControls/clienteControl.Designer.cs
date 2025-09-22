namespace nikeproject
{
    partial class ClienteControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblTituloClientes = new Label();
            textBox1 = new TextBox();
            lblBuscador = new Label();
            btnBuscar = new Button();
            gbInformacion = new GroupBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            gbInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblTituloClientes
            // 
            lblTituloClientes.AutoSize = true;
            lblTituloClientes.Font = new Font("Segoe UI", 22F, FontStyle.Bold | FontStyle.Underline);
            lblTituloClientes.Location = new Point(15, 15);
            lblTituloClientes.Name = "lblTituloClientes";
            lblTituloClientes.Size = new Size(288, 41);
            lblTituloClientes.TabIndex = 0;
            lblTituloClientes.Text = "Gestion de Clientes\r\n";
            lblTituloClientes.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 90);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Buscar por Nombre, Apellido o DNI";
            textBox1.Size = new Size(281, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // lblBuscador
            // 
            lblBuscador.AutoSize = true;
            lblBuscador.Font = new Font("Malgun Gothic Semilight", 9F, FontStyle.Bold);
            lblBuscador.Location = new Point(22, 71);
            lblBuscador.Name = "lblBuscador";
            lblBuscador.Size = new Size(131, 15);
            lblBuscador.TabIndex = 2;
            lblBuscador.Text = "Buscar cliente por...";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(309, 90);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // gbInformacion
            // 
            gbInformacion.BackColor = SystemColors.ButtonFace;
            gbInformacion.Controls.Add(textBox5);
            gbInformacion.Controls.Add(textBox4);
            gbInformacion.Controls.Add(textBox3);
            gbInformacion.Controls.Add(textBox2);
            gbInformacion.Controls.Add(label4);
            gbInformacion.Controls.Add(label3);
            gbInformacion.Controls.Add(label2);
            gbInformacion.Controls.Add(label1);
            gbInformacion.Location = new Point(22, 131);
            gbInformacion.Name = "gbInformacion";
            gbInformacion.Size = new Size(767, 252);
            gbInformacion.TabIndex = 4;
            gbInformacion.TabStop = false;
            gbInformacion.Text = "Información del Cliente";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 38);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(407, 23);
            textBox5.TabIndex = 1;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 83);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(407, 23);
            textBox4.TabIndex = 1;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 128);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(407, 23);
            textBox3.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 173);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(407, 23);
            textBox2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Mongolian Baiti", 12F, FontStyle.Bold);
            label4.Location = new Point(6, 154);
            label4.Name = "label4";
            label4.Size = new Size(44, 16);
            label4.TabIndex = 0;
            label4.Text = "DNI:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Mongolian Baiti", 12F, FontStyle.Bold);
            label3.Location = new Point(6, 109);
            label3.Name = "label3";
            label3.Size = new Size(54, 16);
            label3.TabIndex = 0;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Mongolian Baiti", 12F, FontStyle.Bold);
            label2.Location = new Point(6, 64);
            label2.Name = "label2";
            label2.Size = new Size(75, 16);
            label2.TabIndex = 0;
            label2.Text = "Apellido:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Mongolian Baiti", 12F, FontStyle.Bold);
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(70, 16);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 389);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(767, 211);
            dataGridView1.TabIndex = 5;
            // 
            // ClienteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(gbInformacion);
            Controls.Add(btnBuscar);
            Controls.Add(lblBuscador);
            Controls.Add(textBox1);
            Controls.Add(lblTituloClientes);
            Name = "ClienteControl";
            Size = new Size(833, 622);
            gbInformacion.ResumeLayout(false);
            gbInformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();





        }

        #endregion

        private Label lblTituloClientes;
        private TextBox textBox1;
        private Label lblBuscador;
        private Button btnBuscar;
        private GroupBox gbInformacion;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private DataGridView dataGridView1;
    }
}