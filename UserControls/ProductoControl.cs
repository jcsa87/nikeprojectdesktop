using nikeproject.Data;
using nikeproject.DataAccess;
using nikeproject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using nikeproject.Helpers;

namespace nikeproject.UserControls
{
    public partial class ProductoControl : UserControl
    {
        private int idProductoSeleccionado = 0;
        private bool estadoProductoSeleccionado = true;

        public ProductoControl()
        {
            InitializeComponent();
            GridHelper.PintarInactivos(dgvProductos);
            dgvProductos.CellClick += dgvProductos_CellClick;
            btnBuscar.Click += btnBuscar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            CargarProductos();
            CargarCategorias();
            CargarOpcionesBusqueda();
        }

        // ================== CARGA INICIAL ==================
        private void CargarOpcionesBusqueda()
        {
            cbBusqueda.Items.Clear();
            cbBusqueda.Items.Add("Código");
            cbBusqueda.Items.Add("Nombre");
            cbBusqueda.Items.Add("Categoría");
            cbBusqueda.SelectedIndex = 0;
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = ProductoData.ListarProductos();

            if (dgvProductos.Columns.Contains("Estado"))
                dgvProductos.Columns["Estado"].Visible = false;
        }

        private void CargarCategorias()
        {
            cbCategoria.DataSource = CategoriaData.ListarCategorias();
            cbCategoria.DisplayMember = "Descripcion";
            cbCategoria.ValueMember = "IdCategoria";
        }

        // ================== GUARDAR ==================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposProducto(out int stock, out decimal precioCompra, out decimal precioVenta))
            {
                return; // Detiene el guardado si la validación falla
            }

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
                    Estado = true,
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

        // ================== EDITAR ==================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("⚠️ Seleccione un producto primero.");
                return;
            }

            if (!ValidarCamposProducto(out int stock, out decimal precioCompra, out decimal precioVenta))
            {
                return; // Detiene el guardado si la validación falla
            }

            try
            {
                Producto p = new Producto
                {
                    IdProducto = idProductoSeleccionado,
                    Codigo = txtCodigo.Text.Trim(),
                    Nombre = txtNombreProd.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Stock = int.Parse(txtStock.Text),
                    PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                    PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                    ImagenRuta = txtImagenRuta.Text.Trim(),
                    IdCategoria = (int)cbCategoria.SelectedValue,
                    Estado = estadoProductoSeleccionado // conserva el estado actual
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
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error al editar: " + ex.Message);
            }
        }

        // ================== FILTRO ==================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = cbBusqueda.SelectedItem?.ToString() ?? "";
            string valor = txtBusqueda.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(valor))
            {
                MessageBox.Show("⚠️ Ingrese un valor para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Producto> productos = ProductoData.ListarProductos();
            List<Producto> filtrados = new List<Producto>();

            switch (criterio)
            {
                case "Código":
                    filtrados = productos
                        .Where(p => p.Codigo != null && p.Codigo.ToLower().Contains(valor))
                        .ToList();
                    break;

                case "Nombre":
                    filtrados = productos
                        .Where(p => p.Nombre != null && p.Nombre.ToLower().Contains(valor))
                        .ToList();
                    break;

                case "Categoría":
                    filtrados = productos
                        .Where(p => p.CategoriaNombre != null && p.CategoriaNombre.ToLower().Contains(valor))
                        .ToList();
                    break;
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = filtrados;

            if (dgvProductos.Columns.Contains("Estado"))
                dgvProductos.Columns["Estado"].Visible = false;
        }

        // Para Stock (solo números enteros)
        private void txtNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        // Para Precios (números y una coma)
        private void txtDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite números y teclas de control (borrar)
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                return;
            }

            // Permite UNA coma (o punto, y la convierte en coma)
            TextBox textBox = (TextBox)sender;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && !textBox.Text.Contains(","))
            {
                e.KeyChar = ','; // Estandariza a coma
                return;
            }

            e.Handled = true; // Bloquea todo lo demás
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            cbBusqueda.SelectedIndex = 0;
            CargarProductos();
        }

        // ================== ELIMINAR / REACTIVAR ==================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado > 0)
            {
                ProductoData productoData = new ProductoData();
                bool reactivar = (btnEliminar.Text == "Reactivar Producto");

                string mensaje = reactivar
                    ? "¿Está seguro que desea reactivar este producto?"
                    : "¿Está seguro que desea dar de baja este producto?";

                if (MessageBox.Show(mensaje, "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool resultado = productoData.CambiarEstadoProducto(idProductoSeleccionado, reactivar);

                    if (resultado)
                    {
                        MessageBox.Show(reactivar ? "✅ Producto reactivado correctamente." : "✅ Producto dado de baja correctamente.");
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
                MessageBox.Show("⚠️ Seleccione un producto.");
            }
        }

        // ================== EVENTOS GRILLA ==================
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var prod = dgvProductos.Rows[e.RowIndex].DataBoundItem as Producto;
            if (prod == null) return;

            idProductoSeleccionado = prod.IdProducto;
            estadoProductoSeleccionado = prod.Estado; // guardamos el estado real

            txtCodigo.Text = prod.Codigo;
            txtNombreProd.Text = prod.Nombre;
            txtDescripcion.Text = prod.Descripcion;
            txtStock.Text = prod.Stock.ToString();
            txtPrecioCompra.Text = prod.PrecioCompra.ToString("0.##");
            txtPrecioVenta.Text = prod.PrecioVenta.ToString("0.##");
            cbCategoria.SelectedValue = prod.IdCategoria;

            if (prod.Estado)
            {
                btnEliminar.Text = "Dar de Baja Producto";
                btnEliminar.BackColor = Color.Firebrick;
            }
            else
            {
                btnEliminar.Text = "Reactivar Producto";
                btnEliminar.BackColor = Color.SeaGreen;
            }

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

            // --- INICIO DE LÓGICA DE ROLES ---
            RolUsuario rolActual = SesionUsuario.Rol; // (Ajusta 'SesionUsuario.Rol')

            if (rolActual == RolUsuario.Supervisor)
            {
                // El Supervisor solo puede editar el STOCK.
                txtCodigo.ReadOnly = true;
                txtNombreProd.ReadOnly = true;
                txtDescripcion.ReadOnly = true;
                txtPrecioCompra.ReadOnly = true;
                txtPrecioVenta.ReadOnly = true;
                cbCategoria.Enabled = false;

                txtStock.ReadOnly = false; // <-- ¡El único campo editable!
            }
            // (El Vendedor ya tiene todo bloqueado por el método ConfigurarVistaPorRol)
            // --- FIN DE LÓGICA DE ROLES ---
        }

        // ================== AUXILIARES ==================
        private void LimpiarCampos()
        {
            idProductoSeleccionado = 0;
            estadoProductoSeleccionado = true;
            txtCodigo.Text = "";
            txtNombreProd.Text = "";
            txtDescripcion.Text = "";
            txtStock.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtImagenRuta.Text = "";
            pBImagenProducto.Image = null;

            // Vuelve a aplicar la lógica de roles para resetear los ReadOnly
            ConfigurarVistaPorRol();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            // Si ya tenías lógica para cargar imagen, podés mantenerla.
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar imagen del producto";
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagenRuta.Text = ofd.FileName;
                    pBImagenProducto.Image = Image.FromFile(ofd.FileName);
                    pBImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void txtImagenRuta_TextChanged(object sender, EventArgs e)
        {
            // Este evento no es crítico, se puede dejar vacío o mostrar previsualización
        }

        private void lbCodigo_Click(object sender, EventArgs e)
        {
            // Evento decorativo, puede dejarse vacío
        }

        private void dgvProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Resalta productos inactivos en color
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.DataBoundItem is Producto p)
                {
                    if (!p.Estado)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void ProductoControl_Load(object sender, EventArgs e)
        {
            ConfigurarVistaPorRol();
        }

        private void ConfigurarVistaPorRol()
        {
            // (Ajusta 'SesionUsuario.Rol' al nombre real de tu propiedad)
            RolUsuario rolActual = SesionUsuario.Rol;

            if (rolActual == RolUsuario.Supervisor)
            {
                // Lógica del Supervisor:
                btnGuardar.Enabled = false;   // No puede crear
                btnEditar.Enabled = true;     // Sí puede editar (solo stock)
                btnEliminar.Enabled = false;  // No puede dar de baja/reactivar
                btnCargarImagen.Enabled = false;

                // Campos bloqueados por defecto (se desbloquea 'Stock' al hacer clic)
                txtCodigo.ReadOnly = true;
                txtNombreProd.ReadOnly = true;
                txtDescripcion.ReadOnly = true;
                txtPrecioCompra.ReadOnly = true;
                txtPrecioVenta.ReadOnly = true;
                txtStock.ReadOnly = true;
                cbCategoria.Enabled = false;
            }
            else if (rolActual == RolUsuario.Vendedor)
            {
                // Lógica del Vendedor (Modo "Solo Lectura"):
                btnGuardar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnCargarImagen.Enabled = false;

                // Todos los campos bloqueados
                txtCodigo.ReadOnly = true;
                txtNombreProd.ReadOnly = true;
                txtDescripcion.ReadOnly = true;
                txtPrecioCompra.ReadOnly = true;
                txtPrecioVenta.ReadOnly = true;
                txtStock.ReadOnly = true;
                cbCategoria.Enabled = false;
            }
            // No hay 'else' para Administrador, él puede hacer todo por defecto.
        }

        // --- PEGA ESTE MÉTODO NUEVO EN CUALQUIER LUGAR DE TU CLASE ---

        private bool ValidarCamposProducto(out int stock, out decimal precioCompra, out decimal precioVenta)
        {
            stock = 0;
            precioCompra = 0;
            precioVenta = 0;

            // 1. Validar campos de texto vacíos
            if (string.IsNullOrWhiteSpace(txtCodigo.Text)) // Reemplaza txtCodigo si se llama distinto
            {
                MessageBox.Show("El campo 'Código' no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNombreProd.Text)) // Reemplaza txtNombreProd si se llama distinto
            {
                MessageBox.Show("El campo 'Nombre' no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProd.Focus();
                return false;
            }

            // 2. Validar Stock (que no esté vacío, sea número, y no sea negativo)
            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                MessageBox.Show("El Stock debe ser un número entero válido y no puede ser negativo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            // 3. Validar Precio de Compra (que no esté vacío y sea mayor a 0)
            if (!decimal.TryParse(txtPrecioCompra.Text.Replace(".", ","), out precioCompra) || precioCompra <= 0)
            {
                MessageBox.Show("El Precio de Compra debe ser un número válido y mayor a cero.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioCompra.Focus();
                return false;
            }

            // 4. Validar Precio de Venta (que no esté vacío y sea mayor a 0)
            if (!decimal.TryParse(txtPrecioVenta.Text.Replace(".", ","), out precioVenta) || precioVenta <= 0)
            {
                MessageBox.Show("El Precio de Venta debe ser un número válido y mayor a cero.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioVenta.Focus();
                return false;
            }

            // 5. Lógica de negocio: Precio Venta > Precio Compra
            if (precioVenta <= precioCompra)
            {
                MessageBox.Show("El Precio de Venta debe ser mayor que el Precio de Compra.", "Error de Lógica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioVenta.Focus();
                return false;
            }

            return true; // Si todo está bien
        }

    }
}
