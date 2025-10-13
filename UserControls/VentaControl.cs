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

     
       



        // para pasar selección desde buscadores
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
            nudCantidad.Maximum = p.Stock > 0 ? p.Stock : 1;

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

            // Imagen
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


        private int _idCliente = 0;
        private int _idProducto = 0;

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

        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_idProducto == 0)
            {
                MessageBox.Show("Seleccione un producto válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stockActual) || stockActual <= 0)
            {
                MessageBox.Show("No hay stock disponible para este producto.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal precio = decimal.Parse(txtPrecio.Text);
            decimal subTotal = precio * cantidad;

            // 🔍 Verificamos si el producto ya está en el detalle
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;

                int idExistente = Convert.ToInt32(row.Cells["colIdProducto"].Value);
                if (idExistente == _idProducto)
                {
                    int cantidadActual = Convert.ToInt32(row.Cells["colCantidad"].Value);
                    int nuevaCantidad = cantidadActual + cantidad;

                    int stockReal = ProductoData.ObtenerStock(_idProducto);
                    if (nuevaCantidad > stockReal)
                    {
                        MessageBox.Show($"Stock insuficiente. Disponible: {stockReal}, intentando agregar {nuevaCantidad}.",
                                        "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    row.Cells["colCantidad"].Value = nuevaCantidad;
                    row.Cells["colSubTotal"].Value = (nuevaCantidad * precio).ToString("0.00");
                    RecalcularTotales();
                    ActualizarStockVisual();
                    return;
                }
            }

            // Si no estaba en la grilla, agregamos una nueva fila
            int rowIndex = dgvDetalle.Rows.Add();
            DataGridViewRow nuevaFila = dgvDetalle.Rows[rowIndex];
            nuevaFila.Cells["colIdProducto"].Value = _idProducto;
            nuevaFila.Cells["colProducto"].Value = txtNombreProd.Text;
            nuevaFila.Cells["colPrecio"].Value = precio.ToString("0.00");
            nuevaFila.Cells["colCantidad"].Value = cantidad;
            nuevaFila.Cells["colSubTotal"].Value = subTotal.ToString("0.00");

            RecalcularTotales();
            ActualizarStockVisual(); // 👈 recalcular stock disponible visualmente
        }


        private void ActualizarStockVisual()
        {
            if (_idProducto == 0) return;

            // Obtener stock real desde la base
            int stockReal = ProductoData.ObtenerStock(_idProducto);

            // Calcular cuánto de ese producto ya está en el detalle
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
            nudCantidad.Maximum = disponible > 0 ? disponible : 1;
        }

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

            // ⚠️ NUEVO: verificar que haya al menos un producto válido (no fila vacía)
            int filasValidas = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["colCantidad"].Value != null &&
                    int.TryParse(row.Cells["colCantidad"].Value.ToString(), out int cantidad) &&
                    cantidad > 0)
                {
                    filasValidas++;
                }
            }

            if (filasValidas == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto con cantidad mayor que cero.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si paga en efectivo, validar monto
            if (cbFormaPago.SelectedItem?.ToString() == "Efectivo")
            {
                if (!(decimal.TryParse(txtPagaCon.Text, out decimal pagaCon) &&
                      decimal.TryParse(txtTotal.Text, out decimal total) &&
                      pagaCon >= total))
                {
                    MessageBox.Show("El monto entregado no cubre el total a pagar.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 1) Insertar cabecera
            var venta = new Venta
            {
                IdCliente = _idCliente,
                IdUsuario = 1, // reemplazar por usuario logueado
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



            // 2) Insertar detalle
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

                // insert detalle y descuenta stock real
                DetalleVentaData.InsertarDetalle(det);
                ProductoData.DescontarStock(idProducto, cantidad);
            }

            MessageBox.Show("✅ Venta registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3) Limpiar
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
        }






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
            // Solo aplica si la forma de pago es Efectivo
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

            // habilitar/deshabilitar el cuadro de texto
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
            // Cambio solo aplica en EFECTIVO
            if (cbFormaPago.SelectedItem?.ToString() != "Efectivo")
            {
                txtCambio.Text = "0.00";
                return;
            }

            if (!decimal.TryParse(txtTotal.Text, out decimal total)) total = 0m;

            if (decimal.TryParse(txtPagaCon.Text, out decimal pago))
            {
                // Si ingresa menos de lo debido, el cambio se queda en 0
                decimal cambio = Math.Max(0, pago - total);
                txtCambio.Text = cambio.ToString("0.00");
            }
            else
            {
                txtCambio.Text = "0.00";
            }
        }




        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtStock.Text, out int stock))
            {
                if (stock <= 0)
                {
                    txtStock.BackColor = Color.LightCoral;
                    btnAgregar.Enabled = false;
                    nudCantidad.Value = 1;
                    nudCantidad.Maximum = 1;
                }
                else
                {
                    txtStock.BackColor = Color.White;
                    btnAgregar.Enabled = true;

                    // Si el usuario sube más que el stock, lo “recorta”
                    if (nudCantidad.Value > stock) nudCantidad.Value = stock;
                    nudCantidad.Maximum = stock;
                }
            }
            else
            {
                // Stock inválido
                btnAgregar.Enabled = false;
                txtStock.BackColor = Color.LightCoral;
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
                    _idProducto = ev.IdProducto;  // 👈 aquí se carga el id real
                    txtCodProducto.Text = ev.Codigo;
                    txtNombreProd.Text = ev.Nombre;
                    txtPrecio.Text = ev.PrecioVenta.ToString("0.00");
                    txtStock.Text = ev.Stock.ToString();

                    nudCantidad.Value = 1;
                    nudCantidad.Maximum = ev.Stock > 0 ? ev.Stock : 1;

                    if (!string.IsNullOrEmpty(ev.RutaImagen) && File.Exists(ev.RutaImagen))
                    {
                        pbProducto.Image = Image.FromFile(ev.RutaImagen);
                        pbProducto.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pbProducto.Image = null;
                    }

                    // resetear colores según stock real
                    txtStock.BackColor = ev.Stock <= 0 ? Color.LightCoral : Color.White;
                    btnAgregar.Enabled = ev.Stock > 0;
                };

                frm.ShowDialog();
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








        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow r in dgvDetalle.Rows)
            {
                if (r.Cells["colSubTotal"].Value != null &&
                    decimal.TryParse(r.Cells["colSubTotal"].Value.ToString(), out decimal sub))
                {
                    total += sub;
                }
            }
            txtTotal.Text = total.ToString("0.00");
            RecalcularCambio();
        }

        private void RecalcularCambio()
        {
            if (decimal.TryParse(txtPagaCon.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal pagaCon) &&
                decimal.TryParse(txtTotal.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal total))
            {
                txtCambio.Text = pagaCon >= total ? (pagaCon - total).ToString("0.00") : "0.00";
            }
            else
            {
                txtCambio.Text = "0.00";
            }
        }


        private void LimpiarProducto()
        {
            _idProducto = 0;
            txtCodProducto.Text = "";
            txtNombreProd.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            nudCantidad.Value = 1;
        }

        private void lblPagaCon_Click(object sender, EventArgs e)
        {

        }

        private void txtPagaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            // Verifica que los valores sean válidos (numéricos)
            if (decimal.TryParse(lblCambio.Text, out decimal efectivo) &&
                decimal.TryParse(lblTotal.Text, out decimal total))
            {
                // Calcula el cambio solo si el efectivo es mayor o igual al total
                decimal cambio = efectivo - total;
                txtCambio.Text = cambio >= 0 ? cambio.ToString("0.00") : "0.00";

            }

        }
            private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHistorialVentas_Click(object sender, EventArgs e)
        {
            using (var frm = new HistorialVentasForm())
            {
                frm.ShowDialog(this);
            }
        }

    }
}
