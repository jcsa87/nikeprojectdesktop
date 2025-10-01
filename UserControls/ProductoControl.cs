using nikeproject.Data;
using nikeproject.DataAccess;
using nikeproject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using nikeproject.Helpers;

namespace nikeproject.UserControls
{
    public partial class ProductoControl : UserControl
    {
        private int idProductoSeleccionado = 0;

        public ProductoControl()
        {
            InitializeComponent();
            GridHelper.PintarInactivos(dgvProductos);
            dgvProductos.CellClick += dgvProductos_CellClick;
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

            if (ProductoData.ExisteCodigo(txtCodigo.Text.Trim()))
            {
                MessageBox.Show("⚠️ Ya existe un producto con este código. Ingrese uno distinto.",
                                "Código duplicado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
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

        private void dgvProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.Cells["Estado"].Value != null && row.Cells["Estado"].Value != DBNull.Value)
                {
                    bool activo = Convert.ToBoolean(row.Cells["Estado"].Value);
                    row.DefaultCellStyle.BackColor = activo ? Color.White : Color.LightCoral;
                    row.DefaultCellStyle.ForeColor = activo ? Color.Black : Color.White;
                }
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
            if (idProductoSeleccionado > 0)
            {
                ProductoData productoData = new ProductoData();

                bool reactivar = (btnEliminar.Text == "Reactivar Producto");

                string mensajeConfirmacion = reactivar
    ? "¿Está seguro que desea reactivar este producto?"
    : "¿Está seguro que desea dar de baja este producto?";


                if (MessageBox.Show(mensajeConfirmacion, "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool resultado;

                    if (reactivar)
                    {
                        resultado = productoData.CambiarEstadoProducto(idProductoSeleccionado, true); // activo
                    }
                    else
                    {
                        resultado = productoData.CambiarEstadoProducto(idProductoSeleccionado, false); // inactivo
                    }

                    if (resultado)
                    {
                        MessageBox.Show(reactivar
                            ? "✅ Producto reactivado correctamente."
                            : "✅ Producto dado de baja correctamente.");

                        CargarProductos();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("⚠️ No se pudo actualizar el producto.");
                    }
                }
            }
            else
            {
                MessageBox.Show("⚠️ Seleccione un usuario.");
            }
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "Estado") // columna Estado
            {
                var estado = dgvProductos.Rows[e.RowIndex].Cells["Estado"].Value;
                if (estado != null && estado != DBNull.Value && !Convert.ToBoolean(estado))
                {
                    // Fila inactiva → rojo suave
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    // Reset a valores por defecto (por si se reusa fila)
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }


        // Autocompletar campos al seleccionar de la grilla
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Toma el objeto Producto que está enlazado a la fila
            var prod = dgvProductos.Rows[e.RowIndex].DataBoundItem as Producto;
            if (prod == null) return;

            idProductoSeleccionado = prod.IdProducto;

            // Autocompleta campos
            txtCodigo.Text = prod.Codigo;
            txtNombreProd.Text = prod.Nombre;
            txtDescripcion.Text = prod.Descripcion;
            txtStock.Text = prod.Stock.ToString();
            txtPrecioCompra.Text = prod.PrecioCompra.ToString("0.##");
            txtPrecioVenta.Text = prod.PrecioVenta.ToString("0.##");

            // Estado
            if (prod.Estado)
            {
                btnEliminar.Text = "Dar de Baja Producto";
                btnEliminar.BackColor = Color.Firebrick; // rojo
            }
            else
            {
                btnEliminar.Text = "Reactivar Producto";
                btnEliminar.BackColor = Color.SeaGreen; // verde
            }



            // Categoría (usa el Id)
            cbCategoria.SelectedValue = prod.IdCategoria;

            // Imagen
            txtImagenRuta.Text = prod.ImagenRuta ?? "";
            if (!string.IsNullOrWhiteSpace(prod.ImagenRuta) && File.Exists(prod.ImagenRuta))
            {
                pBImagenProducto.Image = Image.FromFile(prod.ImagenRuta);
                pBImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pBImagenProducto.Image = null;
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
