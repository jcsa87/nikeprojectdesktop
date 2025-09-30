using nikeproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nikeproject.UserControls
{
    public partial class ProductoControl : UserControl
    {
        public ProductoControl()
        {
            InitializeComponent();

            int stock = 0;
            decimal precioCompra = 0;
            decimal precioVenta = 0;


            // lblImagen
            lblImagen = new Label();
            lblImagen.AutoSize = true;
            lblImagen.BackColor = Color.White;
            lblImagen.Location = new Point(20, 480);
            lblImagen.Name = "lblImagen";
            lblImagen.Size = new Size(51, 15);
            lblImagen.Text = "Imagen:";

            // txtImagenRuta
            txtImagenRuta = new TextBox();
            txtImagenRuta.BorderStyle = BorderStyle.FixedSingle;
            txtImagenRuta.Location = new Point(20, 498);
            txtImagenRuta.Name = "txtImagenRuta";
            txtImagenRuta.Size = new Size(160, 23);

            // btnCargarImagen
            btnCargarImagen = new Button();
            btnCargarImagen.BackColor = Color.DarkGray;
            btnCargarImagen.FlatStyle = FlatStyle.Flat;
            btnCargarImagen.Location = new Point(185, 498);
            btnCargarImagen.Name = "btnCargarImagen";
            btnCargarImagen.Size = new Size(42, 23);
            btnCargarImagen.Text = "...";
            btnCargarImagen.UseVisualStyleBackColor = false;
            btnCargarImagen.Click += new EventHandler(this.btnCargarImagen_Click);

            // pbPreview
            pbPreview = new PictureBox();
            pbPreview.BorderStyle = BorderStyle.FixedSingle;
            pbPreview.Location = new Point(20, 530);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(207, 100);
            pbPreview.SizeMode = PictureBoxSizeMode.Zoom;



        }


        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar imagen del producto";
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagenRuta.Text = ofd.FileName;
                    pbPreview.Image = Image.FromFile(ofd.FileName);
                }
            }
        }



    }
}
