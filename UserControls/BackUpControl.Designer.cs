namespace nikeproject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackUpControl));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            label12 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(157, 101);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(261, 146);
            label1.Name = "label1";
            label1.Size = new Size(121, 37);
            label1.TabIndex = 1;
            label1.Text = "Back Up";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Font = new Font("Segoe Print", 9F);
            panel1.Location = new Point(157, 235);
            panel1.Name = "panel1";
            panel1.Size = new Size(596, 337);
            panel1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(pictureBox3);
            panel3.Location = new Point(331, 149);
            panel3.Name = "panel3";
            panel3.Size = new Size(208, 61);
            panel3.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label2.Location = new Point(85, 24);
            label2.Name = "label2";
            label2.Size = new Size(97, 13);
            label2.TabIndex = 7;
            label2.Text = "Exportar archivos";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(14, 6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(46, 50);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(label12);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(64, 149);
            panel2.Name = "panel2";
            panel2.Size = new Size(208, 61);
            panel2.TabIndex = 8;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label12.Location = new Point(66, 24);
            label12.Name = "label12";
            label12.Size = new Size(138, 13);
            label12.TabIndex = 7;
            label12.Text = "Hacer copia de seguridad";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(14, 6);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // BackUpControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "BackUpControl";
            Size = new Size(915, 670);
//            Load += this.BackUpControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel1;
        private Panel panel3;
        private Label label2;
        private PictureBox pictureBox3;
        private Panel panel2;
        private Label label12;
        private PictureBox pictureBox2;
    }
}
