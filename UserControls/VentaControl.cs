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
            _instance = this;

        }

        //private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dgvProductos.Columns[e.ColumnIndex].Name == "btnSeleccionar" && e.RowIndex >= 0)
        //    {
        //        string codigo = dgvProductos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
        //        string nombre = dgvProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
        //        decimal precioVenta = Convert.ToDecimal(dgvProductos.Rows[e.RowIndex].Cells["PrecioVenta"].Value);
        //        int stock = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["Stock"].Value);
        //        string rutaImagen = dgvProductos.Rows[e.RowIndex].Cells["ImagenRuta"].Value.ToString();

        //        // Autocompletar en VentaControl
        //        VentaControl.Instance.txtCodProducto.Text = codigo;
        //        VentaControl.Instance.txtNombreProd.Text = nombre;
        //        VentaControl.Instance.txtPrecio.Text = precioVenta.ToString("0.00");
        //        VentaControl.Instance.txtStock.Text = stock.ToString();

        //        // Mostrar Imagen
        //        if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
        //        {
        //            VentaControl.Instance.pbProducto.Image = Image.FromFile(rutaImagen);
        //            VentaControl.Instance.pbProducto.SizeMode = PictureBoxSizeMode.Zoom;
        //        }
        //        else
        //        {
        //            VentaControl.Instance.pbProducto.Image = null;
        //        }
        //    }
        //}

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


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_idProducto == 0 || string.IsNullOrWhiteSpace(txtNombreProd.Text))
            {
                MessageBox.Show("Seleccione un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtStock.Text, out int stock)) stock = 0;
            int cantidad = (int)nudCantidad.Value;
            if (cantidad > stock)
            {
                MessageBox.Show("La cantidad supera el stock disponible.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtPrecio.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal precio))
            {
                MessageBox.Show("Precio inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal sub = precio * cantidad;

            // si el producto ya está en la grilla, acumular cantidad
            foreach (DataGridViewRow r in dgvDetalle.Rows)
            {
                int idProdRow = Convert.ToInt32(r.Cells["colIdProducto"].Value);
                if (idProdRow == _idProducto)
                {
                    int cantActual = Convert.ToInt32(r.Cells["colCantidad"].Value);
                    int nuevaCant = cantActual + cantidad;
                    if (nuevaCant > stock)
                    {
                        MessageBox.Show("No podés superar el stock.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    r.Cells["colCantidad"].Value = nuevaCant;
                    r.Cells["colSubTotal"].Value = (precio * nuevaCant).ToString("0.##");
                    CalcularTotal();
                    LimpiarProducto();
                    return;
                }
            }

            dgvDetalle.Rows.Add(_idProducto, txtNombreProd.Text, precio.ToString("0.##"), cantidad, sub.ToString("0.##"));
            CalcularTotal();
            LimpiarProducto();
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

        private void txtPagaCon_TextChanged(object sender, EventArgs e)
        {
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
