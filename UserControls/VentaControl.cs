using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using nikeproject.Models;
using nikeproject.Forms;

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
            txtPrecio.Text = p.PrecioVenta.ToString("0.##");
            txtStock.Text = p.Stock.ToString();
            nudCantidad.Value = 1;
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
            // valores iniciales
            this.Load += VentaControl_Load;
            _instance = this;

        }

        private void VentaControl_Load(object sender, EventArgs e)
        {
            // Cantidad
            nudCantidad.Minimum = 1;
            nudCantidad.Value = 1;

            cbTipoDoc.Items.Clear();
            cbTipoDoc.Items.AddRange(new object[]
            {
        "Boleta",
        "Factura A",
        "Factura B",
        "Factura C",
        "Ticket"
            });
            cbTipoDoc.SelectedIndex = 0;

            cbFormaPago.Items.Clear();
            cbFormaPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Cheque" });
            cbFormaPago.SelectedIndex = 0;

            // 👇 muy importante: enganchar el evento
            cbFormaPago.SelectedIndexChanged += cbFormaPago_SelectedIndexChanged;

            // Estado inicial
            txtPagaCon.ReadOnly = cbFormaPago.SelectedItem?.ToString() != "Efectivo";
            txtPagaCon.BackColor = txtPagaCon.ReadOnly ? SystemColors.Control : Color.White;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones mínimas
            if (string.IsNullOrWhiteSpace(txtNombreProd.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Seleccione un producto válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Stock inválido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)nudCantidad.Value;

            if (stock == 0)
            {
                txtStock.BackColor = Color.LightCoral;
                MessageBox.Show("No hay stock disponible para este producto.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cantidad > stock)
            {
                MessageBox.Show("La cantidad no puede superar el stock disponible.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCantidad.Value = stock;
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Precio inválido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string producto = txtNombreProd.Text;
            decimal subTotal = precio * cantidad;

            // Agregar fila (orden: Producto | Precio | Cantidad | Sub Total)
            dgvDetalle.Rows.Add(producto, precio.ToString("0.00"), cantidad, subTotal.ToString("0.00"));

            // Actualizar stock visual
            int nuevoStock = stock - cantidad;
            txtStock.Text = nuevoStock.ToString();
            nudCantidad.Maximum = Math.Max(nuevoStock, 1);
            btnAgregar.Enabled = nuevoStock > 0;
            txtStock.BackColor = nuevoStock == 0 ? Color.LightCoral : Color.White;

            // Recalcular totales
            RecalcularTotales();
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
            ActualizarCambio();
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
                    txtCodProducto.Text = ev.Codigo;
                    txtNombreProd.Text = ev.Nombre;
                    txtPrecio.Text = ev.PrecioVenta.ToString("0.00");
                    txtStock.Text = ev.Stock.ToString();

                    if (!string.IsNullOrEmpty(ev.RutaImagen) && File.Exists(ev.RutaImagen))
                    {
                        pbProducto.Image = Image.FromFile(ev.RutaImagen);
                        pbProducto.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pbProducto.Image = null;
                    }
                };

                frm.ShowDialog();
            }
        }


        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalle.Columns[e.ColumnIndex].Name == "colQuitar")
            {
                dgvDetalle.Rows.RemoveAt(e.RowIndex);
                CalcularTotal();
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

            // TODO: Insert en VENTA, DETALLE_VENTA y UPDATE de stock.
            MessageBox.Show("Venta registrada (pendiente lógica de BD).", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // limpiar todo
            dgvDetalle.Rows.Clear();
            txtTotal.Text = "0.00";
            txtPagaCon.Text = "";
            txtCambio.Text = "0.00";
            _idCliente = 0;
            txtDocumentoCliente.Text = "";
            txtNombreCliente.Text = "";
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
    }
}
