namespace nikeproject
{
    partial class VendedorUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendedorUserControl));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            ID = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            pictureBox3 = new PictureBox();
            panel3 = new Panel();
            textBox6 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            textBox5 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            textBox9 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(54, 60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(74, 74);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(134, 74);
            label1.Name = "label1";
            label1.Size = new Size(138, 37);
            label1.TabIndex = 1;
            label1.Text = "Vendedor";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(ID);
            panel1.Location = new Point(27, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(402, 253);
            panel1.TabIndex = 2;
            // 
            // ID
            // 
            ID.AutoSize = true;
            ID.Font = new Font("Segoe UI", 13F);
            ID.Location = new Point(27, 139);
            ID.Name = "ID";
            ID.Size = new Size(30, 25);
            ID.TabIndex = 3;
            ID.Text = "ID";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(27, 167);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(142, 23);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(215, 139);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            label2.Click += this.label2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(215, 167);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(142, 23);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += this.textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Italic);
            label3.Location = new Point(570, 74);
            label3.Name = "label3";
            label3.Size = new Size(106, 37);
            label3.TabIndex = 4;
            label3.Text = "Cliente";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(490, 60);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(74, 74);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(463, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(402, 253);
            panel2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(226, 167);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(142, 23);
            textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(27, 167);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(142, 23);
            textBox4.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.Location = new Point(226, 139);
            label4.Name = "label4";
            label4.Size = new Size(43, 25);
            label4.TabIndex = 3;
            label4.Text = "DNI";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(27, 139);
            label5.Name = "label5";
            label5.Size = new Size(162, 25);
            label5.TabIndex = 3;
            label5.Text = "Nombre del cliente";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Italic);
            label6.Location = new Point(82, 13);
            label6.Name = "label6";
            label6.Size = new Size(143, 37);
            label6.TabIndex = 7;
            label6.Text = "Productos";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(17, 13);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(59, 61);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(button1);
            panel3.Controls.Add(textBox9);
            panel3.Controls.Add(textBox7);
            panel3.Controls.Add(textBox8);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(textBox5);
            panel3.Controls.Add(textBox6);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label8);
            panel3.Location = new Point(27, 285);
            panel3.Name = "panel3";
            panel3.Size = new Size(605, 211);
            panel3.TabIndex = 8;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(17, 106);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(142, 23);
            textBox6.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(17, 86);
            label8.Name = "label8";
            label8.Size = new Size(61, 17);
            label8.TabIndex = 3;
            label8.Text = "Producto";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(195, 86);
            label7.Name = "label7";
            label7.Size = new Size(76, 17);
            label7.TabIndex = 3;
            label7.Text = "Descripción";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(195, 106);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(142, 23);
            textBox5.TabIndex = 4;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(195, 163);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(142, 23);
            textBox7.TabIndex = 10;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(17, 163);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(142, 23);
            textBox8.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(195, 143);
            label9.Name = "label9";
            label9.Size = new Size(98, 17);
            label9.TabIndex = 8;
            label9.Text = "Precio de venta";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(17, 143);
            label10.Name = "label10";
            label10.Size = new Size(39, 17);
            label10.TabIndex = 9;
            label10.Text = "Stock";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(366, 143);
            label11.Name = "label11";
            label11.Size = new Size(60, 17);
            label11.TabIndex = 8;
            label11.Text = "Cantidad";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(370, 163);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(55, 23);
            textBox9.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(446, 162);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(27, 517);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(864, 150);
            dataGridView1.TabIndex = 9;
            // 
            // VendedorUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(panel3);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "VendedorUserControl";
            Size = new Size(910, 670);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label ID;
        private Label label3;
        private PictureBox pictureBox2;
        private Panel panel2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label4;
        private Label label5;
        private Label label6;
        private PictureBox pictureBox3;
        private Panel panel3;
        private TextBox textBox6;
        private Label label8;
        private Button button1;
        private TextBox textBox9;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label11;
        private Label label9;
        private Label label10;
        private TextBox textBox5;
        private Label label7;
        private DataGridView dataGridView1;
    }
}
