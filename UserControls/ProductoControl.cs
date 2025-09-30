using nikeproject.Data;
using nikeproject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace nikeproject.UserControls
{
    public partial class ProductoControl : UserControl
    {
        private int idProductoSeleccionado = 0;

        public ProductoControl()
        {
            InitializeComponent();
            CargarProductos();
            CargarCategorias();
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = ProductoData.ListarProductos();
        }

        private void CargarCategorias()
        {
            cbCategoria.DataSource = CategoriaData.ListarCategorias();
            cbCategoria.DisplayMember = "Descripcion";
            cbCategoria.ValueMember = "IdCategoria";
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto p = new Producto
                {
                    Codigo = txtCodigo.Text.Trim(),
                    Nombre = txtNombreProd.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Stock = int.Parse(txtStock.Text),
                    PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                    PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                   // Estado = cbEstadoDetalle.SelectedItem?.ToString() == "Activo",
                    ImagenRuta = txtImagenRuta.Text.Trim(),
                    IdCategoria = (int)cbCategoria.SelectedValue
                };


                if (ProductoData.AgregarProducto(p))
                {
                    MessageBox.Show("✅ Producto agregado correctamente");
                    CargarProductos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("❌ Error al agregar el producto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error: " + ex.Message);
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("⚠️ Seleccione un producto primero.");
                return;
            }

            Producto p = new Producto
            {
                IdProducto = idProductoSeleccionado,
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombreProd.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                // Estado = cbEstadoDetalle.SelectedItem?.ToString() == "Activo",
                ImagenRuta = txtImagenRuta.Text.Trim(),
                IdCategoria = (int)cbCategoria.SelectedValue
            };

            if (ProductoData.EditarProducto(p))
            {
                MessageBox.Show("✏️ Producto editado correctamente");
                CargarProductos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("❌ Error al editar producto");
            }
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar imagen del producto";
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Validar que sea realmente una imagen
                        using (Image img = Image.FromFile(ofd.FileName))
                        {
                            // Guardar ruta en el TextBox
                            txtImagenRuta.Text = ofd.FileName;

                            // Mostrar previsualización en pBImagenProducto
                            pBImagenProducto.Image = (Image)img.Clone();
                            pBImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("⚠️ El archivo seleccionado no es una imagen válida.",
                                        "Error de imagen",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
            }
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("⚠️ Seleccione un producto primero.");
                return;
            }

            if (ProductoData.EliminarProducto(idProductoSeleccionado))
            {
                MessageBox.Show("🗑️ Producto eliminado (baja lógica).");
                CargarProductos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("❌ Error al eliminar producto");
            }
        }

        // Autocompletar campos al seleccionar de la grilla
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

                idProductoSeleccionado = Convert.ToInt32(row.Cells["IdProducto"].Value);
                txtCodigo.Text = row.Cells["Codigo"].Value.ToString();
                txtNombreProd.Text = row.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                txtPrecioVenta.Text = row.Cells["PrecioVenta"].Value.ToString();
                cbCategoria.SelectedValue = Convert.ToInt32(row.Cells["IdCategoria"].Value);


                // Imagen
                txtImagenRuta.Text = row.Cells["ImagenRuta"].Value?.ToString();
                if (File.Exists(txtImagenRuta.Text))
                {
                    pBImagenProducto.Image = Image.FromFile(txtImagenRuta.Text);
                }
                else
                {
                    pBImagenProducto.Image = null;
                }
            }
        }

        private void LimpiarCampos()
        {
            idProductoSeleccionado = 0;
            txtCodigo.Text = "";
            txtNombreProd.Text = "";
            txtDescripcion.Text = "";
            txtPrecioVenta.Text = "";
            txtImagenRuta.Text = "";
            pBImagenProducto.Image = null;
        }

        private void lbCodigo_Click(object sender, EventArgs e)
        {

        }

        private void txtImagenRuta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
