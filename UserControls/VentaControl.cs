using nikeproject.Data;
using nikeproject.DataAccess;
using nikeproject.Forms;
using nikeproject.Models;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.SqlServer;
using System.Data.SqlClient;

namespace nikeproject.UserControls
{
    public partial class VentaControl : UserControl
    {
        private static VentaControl _instance;

        // Variables internas
        private int _idCliente = 0;
        private int _idProducto = 0;

        // Patrón Singleton
        public static VentaControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new VentaControl();
                return _instance;
            }
        }

        public VentaControl()
        {
            InitializeComponent();
            _instance = this;
            InicializarCombos();
        }

        // =====================================================
        // MÉTODOS DE CARGA INICIAL
        // =====================================================
        private void InicializarCombos()
        {
            cbTipoDoc.Items.Clear();
            cbTipoDoc.Items.Add("Boleta");
            cbTipoDoc.Items.Add("Factura");
            cbTipoDoc.Items.Add("Ticket");

            cbFormaPago.Items.Clear();
            cbFormaPago.Items.Add("Efectivo");
            cbFormaPago.Items.Add("Débito");
            cbFormaPago.Items.Add("Crédito");
            cbFormaPago.Items.Add("Transferencia");

            cbTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;

            cbTipoDoc.SelectedIndex = 0;
            cbFormaPago.SelectedIndex = 0;
        }

        // =====================================================
        // CLIENTE Y PRODUCTO SELECCIONADOS
        // =====================================================
        public void SetClienteSeleccionado(int idCliente, string documento, string nombreCompleto)
        {
            _idCliente = idCliente;
            txtDocumentoCliente.Text = documento;
            txtNombreCliente.Text = nombreCompleto;
        }

        public void SetProductoSeleccionado(Producto p)
        {
            _idProducto = p.IdProducto;
            txtCodProducto.Text = p.Codigo;
            txtNombreProd.Text = p.Nombre;
            txtPrecio.Text = p.PrecioVenta.ToString("0.00");
            txtStock.Text = p.Stock.ToString();

            nudCantidad.Minimum = 1;
            nudCantidad.Value = 1;

            // --- CAMBIO AQUÍ ---
            // Le ponemos un máximo muy alto.
            nudCantidad.Maximum = 9999;

            if (p.Stock <= 0)
            {
                txtStock.BackColor = Color.LightCoral;
                btnAgregar.Enabled = false;
            }
            else
            {
                txtStock.BackColor = Color.White;
                btnAgregar.Enabled = true;
            }

            if (!string.IsNullOrEmpty(p.ImagenRuta) && File.Exists(p.ImagenRuta))
            {
                pbProducto.Image = Image.FromFile(p.ImagenRuta);
                pbProducto.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pbProducto.Image = null;
            }
        }

        // =====================================================
        // AGREGAR PRODUCTO A LA GRILLA
        // =====================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_idProducto == 0)
            {
                MessageBox.Show("Seleccione un producto válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- LÓGICA DE VALIDACIÓN MEJORADA ---

            int stockReal = ProductoData.ObtenerStock(_idProducto);
            int cantidadDeseada = (int)nudCantidad.Value;

            if (cantidadDeseada <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el producto ya existe en la grilla
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;

                int idExistente = Convert.ToInt32(row.Cells["colIdProducto"].Value);
                if (idExistente == _idProducto)
                {
                    int cantidadActual = Convert.ToInt32(row.Cells["colCantidad"].Value);
                    int nuevaCantidadTotal = cantidadActual + cantidadDeseada;

                    // Validamos si la SUMA supera el stock real
                    if (nuevaCantidadTotal > stockReal)
                    {
                        MessageBox.Show($"Stock insuficiente. Ya tiene {cantidadActual} en el carrito y solo quedan {stockReal} en total.",
                                        "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Si pasa la validación, actualizamos
                    decimal precio = decimal.Parse(txtPrecio.Text);
                    row.Cells["colCantidad"].Value = nuevaCantidadTotal;
                    row.Cells["colSubTotal"].Value = (nuevaCantidadTotal * precio).ToString("0.00");

                    RecalcularTotales();
                    ActualizarStockVisual();
                    return;
                }
            }

            // --- VALIDACIÓN PARA PRODUCTOS NUEVOS (la que faltaba) ---
            // Si llegamos aquí, es un producto nuevo en el carrito.
            if (cantidadDeseada > stockReal)
            {
                MessageBox.Show($"No hay stock suficiente. Solo quedan {stockReal} unidades.",
                                "Stock Insuficiente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Detiene la acción
            }

            // Si pasa, lo agregamos
            decimal precioNuevo = decimal.Parse(txtPrecio.Text);
            decimal subTotalNuevo = precioNuevo * cantidadDeseada;

            int rowIndex = dgvDetalle.Rows.Add();
            DataGridViewRow nuevaFila = dgvDetalle.Rows[rowIndex];
            nuevaFila.Cells["colIdProducto"].Value = _idProducto;
            nuevaFila.Cells["colProducto"].Value = txtNombreProd.Text;
            nuevaFila.Cells["colPrecio"].Value = precioNuevo.ToString("0.00");
            nuevaFila.Cells["colCantidad"].Value = cantidadDeseada;
            nuevaFila.Cells["colSubTotal"].Value = subTotalNuevo.ToString("0.00");

            RecalcularTotales();
            ActualizarStockVisual();
        }
        // CÓDIGO CORREGIDO
        private void ActualizarStockVisual()
        {
            if (_idProducto == 0) return;

            int stockReal = ProductoData.ObtenerStock(_idProducto);
            int reservado = 0;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;
                if (Convert.ToInt32(row.Cells["colIdProducto"].Value) == _idProducto)
                {
                    reservado += Convert.ToInt32(row.Cells["colCantidad"].Value);
                }
            }

            int disponible = Math.Max(0, stockReal - reservado);
            txtStock.Text = disponible.ToString();
            txtStock.BackColor = disponible <= 0 ? Color.LightCoral : Color.White;
            btnAgregar.Enabled = disponible > 0;

            // nudCantidad.Maximum = disponible > 0 ? disponible : 1; // ✅ ¡Línea eliminada!
        }

        // =====================================================
        // CREAR VENTA
        // =====================================================
        private void btnCrearVenta_Click(object sender, EventArgs e)
        {
            if (_idCliente == 0)
            {
                MessageBox.Show("Seleccione un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbFormaPago.SelectedItem == null || string.IsNullOrWhiteSpace(cbFormaPago.Text))
            {
                MessageBox.Show("Debe seleccionar un medio de pago antes de registrar la venta.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crea el objeto de cabecera de venta con el usuario actual logueado
            var venta = new Venta
            {
                IdCliente = _idCliente,
                IdUsuario = SesionUsuario.IdUsuario, // ✅ Guarda el vendedor actual
                NumeroDocumento = cbTipoDoc.SelectedItem?.ToString() ?? "Boleta",
                FechaRegistro = DateTime.Now,
                MontoTotal = decimal.Parse(txtTotal.Text),
                Estado = true
            };

            int idVenta = VentaData.InsertarVenta(venta);
            if (idVenta <= 0)
            {
                MessageBox.Show("No se pudo registrar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Registrar detalles
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;

                int idProducto = Convert.ToInt32(row.Cells["colIdProducto"].Value);
                int cantidad = Convert.ToInt32(row.Cells["colCantidad"].Value);
                decimal precioUnitario = Convert.ToDecimal(row.Cells["colPrecio"].Value);
                decimal subTotal = Convert.ToDecimal(row.Cells["colSubTotal"].Value);

                int stockActual = ProductoData.ObtenerStock(idProducto);
                if (cantidad > stockActual)
                {
                    MessageBox.Show($"El producto con ID {idProducto} ya no tiene suficiente stock. Disponible: {stockActual}",
                                    "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var det = new DetalleVenta
                {
                    IdVenta = idVenta,
                    IdProducto = idProducto,
                    Cantidad = cantidad,
                    PrecioUnitario = precioUnitario,
                    SubTotal = subTotal
                };

                DetalleVentaData.InsertarDetalle(det);
                ProductoData.DescontarStock(idProducto, cantidad);
            }

            MessageBox.Show("✅ Venta registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvDetalle.Rows.Clear();
            txtTotal.Text = "0.00";
            txtPagaCon.Text = "";
            txtCambio.Text = "0.00";
            _idCliente = 0;
            txtDocumentoCliente.Text = "";
            txtNombreCliente.Text = "";
            _idProducto = 0;
            txtCodProducto.Text = "";
            txtNombreProd.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            nudCantidad.Value = 1;
            cbFormaPago.SelectedIndex = -1;

            // Mostrar factura
            DialogResult imprimir = MessageBox.Show(
                "¿Deseas imprimir la factura de esta venta?",
                "Imprimir factura",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (imprimir == DialogResult.Yes)
            {
                using (var frmFactura = new FacturaForm(idVenta))
                {
                    frmFactura.ShowDialog();
                }
            }
        }

        // =====================================================
        // OTROS MÉTODOS
        // =====================================================
        private void RecalcularTotales()
        {
            decimal total = 0m;
            int idxSubTotal = dgvDetalle.Columns["colSubTotal"].Index;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells[idxSubTotal].Value != null &&
                    decimal.TryParse(row.Cells[idxSubTotal].Value.ToString(), out decimal st))
                {
                    total += st;
                }
            }

            txtTotal.Text = total.ToString("0.00");
            ActualizarCambio();
        }

        private void txtPagaCon_TextChanged(object sender, EventArgs e)
        {
            if (cbFormaPago.SelectedItem?.ToString() != "Efectivo")
            {
                txtCambio.Text = "0.00";
                return;
            }

            if (!decimal.TryParse(txtTotal.Text, out decimal total))
                total = 0;

            if (decimal.TryParse(txtPagaCon.Text, out decimal pagaCon))
            {
                decimal cambio = pagaCon - total;
                if (cambio < 0) cambio = 0;
                txtCambio.Text = cambio.ToString("0.00");
            }
            else
            {
                txtCambio.Text = "0.00";
            }
        }

        private void cbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esEfectivo = cbFormaPago.SelectedItem?.ToString() == "Efectivo";
            txtPagaCon.ReadOnly = !esEfectivo;
            txtPagaCon.BackColor = esEfectivo ? Color.White : SystemColors.Control;

            if (!esEfectivo)
            {
                txtPagaCon.Text = string.Empty;
                txtCambio.Text = "0.00";
            }
        }

        private void ActualizarCambio()
        {
            if (cbFormaPago.SelectedItem?.ToString() != "Efectivo")
            {
                txtCambio.Text = "0.00";
                return;
            }

            if (!decimal.TryParse(txtTotal.Text, out decimal total)) total = 0m;

            if (decimal.TryParse(txtPagaCon.Text, out decimal pago))
            {
                decimal cambio = Math.Max(0, pago - total);
                txtCambio.Text = cambio.ToString("0.00");
            }
            else
            {
                txtCambio.Text = "0.00";
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalle.Columns[e.ColumnIndex].Name == "colQuitar")
            {
                dgvDetalle.Rows.RemoveAt(e.RowIndex);
                RecalcularTotales();
                ActualizarStockVisual();
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (ClienteBusquedaForm frm = new ClienteBusquedaForm())
            {
                frm.ClienteSeleccionado += (s, ev) =>
                {
                    _idCliente = ev.IdCliente;
                    txtDocumentoCliente.Text = ev.Documento;
                    txtNombreCliente.Text = ev.Nombre;
                    txtApellido.Text = ev.Apellido;
                    txtTelefono.Text = ev.Telefono;
                    txtCorreo.Text = ev.Correo;
                };
                frm.ShowDialog();
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (ProductoBusquedaForm frm = new ProductoBusquedaForm())
            {
                frm.ProductoSeleccionado += (s, ev) =>
                {
                    _idProducto = ev.IdProducto;
                    txtCodProducto.Text = ev.Codigo;
                    txtNombreProd.Text = ev.Nombre;
                    txtPrecio.Text = ev.PrecioVenta.ToString("0.00");
                    txtStock.Text = ev.Stock.ToString();

                    nudCantidad.Value = 1;

                    // --- CAMBIO AQUÍ ---
                    nudCantidad.Maximum = 9999; // Ponemos un máximo alto

                    if (!string.IsNullOrEmpty(ev.RutaImagen) && File.Exists(ev.RutaImagen))
                    {
                        pbProducto.Image = Image.FromFile(ev.RutaImagen);
                        pbProducto.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pbProducto.Image = null;
                    }

                    txtStock.BackColor = ev.Stock <= 0 ? Color.LightCoral : Color.White;
                    btnAgregar.Enabled = ev.Stock > 0;
                };
                frm.ShowDialog();
            }
        }

        private void btnHistorialVentas_Click(object sender, EventArgs e)
        {
            using (var frm = new HistorialVentasForm())
            {
                frm.ShowDialog(this);
            }
        }

        private void txtPagaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (Backspace, etc.) y dígitos
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                return;

            // Permitir UN separador decimal (coma o punto)
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                // Si ya hay coma o punto, bloquear
                if (txtPagaCon.Text.Contains(",") || txtPagaCon.Text.Contains("."))
                    e.Handled = true;
                return;
            }

            // Todo lo demás, bloquear
            e.Handled = true;
        }
    }
}
