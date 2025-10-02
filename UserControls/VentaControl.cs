using nikeproject.Data;
using nikeproject.DataAccess;
using nikeproject.Forms;
using nikeproject.Models;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

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

            CargarHistorialVentas();
        }

        private void CargarHistorialVentas()
        {
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = VentaData.ListarVentas();

            // opcional: renombrar headers
            if (dgvVentas.Columns.Contains("IdVenta"))
                dgvVentas.Columns["IdVenta"].HeaderText = "ID";

            if (dgvVentas.Columns.Contains("NumeroDocumento"))
                dgvVentas.Columns["NumeroDocumento"].HeaderText = "Documento";

            if (dgvVentas.Columns.Contains("FechaRegistro"))
                dgvVentas.Columns["FechaRegistro"].HeaderText = "Fecha";

            if (dgvVentas.Columns.Contains("MontoTotal"))
                dgvVentas.Columns["MontoTotal"].HeaderText = "Total";

            if (dgvVentas.Columns.Contains("Cliente"))
                dgvVentas.Columns["Cliente"].HeaderText = "Cliente";
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_idProducto == 0) return;

            if (!int.TryParse(txtStock.Text, out int stockActual)) return;

            int cantidad = (int)nudCantidad.Value;
            if (cantidad > stockActual)
            {
                MessageBox.Show("La cantidad no puede superar el stock disponible.");
                return;
            }

            decimal precio = decimal.Parse(txtPrecio.Text);
            decimal subTotal = precio * cantidad;

            dgvDetalle.Rows.Add(_idProducto, txtNombreProd.Text,
                                precio.ToString("0.00"), cantidad,
                                subTotal.ToString("0.00"));

            // 🔥 Descontar stock visual
            int nuevoStock = stockActual - cantidad;
            txtStock.Text = nuevoStock.ToString();

            nudCantidad.Maximum = nuevoStock > 0 ? nuevoStock : 1;
            btnAgregar.Enabled = nuevoStock > 0;
            txtStock.BackColor = nuevoStock == 0 ? Color.LightCoral : Color.White;

            RecalcularTotales();
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

            // 1) Insertar cabecera de venta
            var venta = new Venta
            {
                IdCliente = _idCliente,
                IdUsuario = 1, // TODO: reemplazar por el usuario logueado
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

            // 2) Insertar detalles y descontar stock
            foreach (DataGridViewRow r in dgvDetalle.Rows)
            {
                int idProducto = Convert.ToInt32(r.Cells["colIdProducto"].Value);
                int cantidad = Convert.ToInt32(r.Cells["colCantidad"].Value);

                // insertar en detalle_venta
                var det = new DetalleVenta
                {
                    IdVenta = idVenta,
                    IdProducto = idProducto,
                    Cantidad = cantidad,
                    PrecioUnitario = Convert.ToDecimal(r.Cells["colPrecio"].Value),
                    SubTotal = Convert.ToDecimal(r.Cells["colSubTotal"].Value)
                };
                DetalleVentaData.InsertarDetalle(det);

                // ahora sí: descontar stock real
                ProductoData.DescontarStock(idProducto, cantidad);
            }


            MessageBox.Show("✅ Venta registrada con éxito.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarHistorialVentas();

            // 3) Limpiar formulario
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
            ActualizarCambio();
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
                int idProdFila = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells["colIdProducto"].Value);
                int cantFila = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells["colCantidad"].Value);

                // 🔥 devolver stock solo si es el producto actualmente cargado en el panel
                if (idProdFila == _idProducto)
                {
                    int stockActual = int.TryParse(txtStock.Text, out int s) ? s : 0;
                    int nuevoStock = stockActual + cantFila;

                    txtStock.Text = nuevoStock.ToString();
                    nudCantidad.Maximum = nuevoStock > 0 ? nuevoStock : 1;
                    btnAgregar.Enabled = nuevoStock > 0;
                    txtStock.BackColor = nuevoStock == 0 ? Color.LightCoral : Color.White;
                }

                dgvDetalle.Rows.RemoveAt(e.RowIndex);
                RecalcularTotales();
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
    }
}
