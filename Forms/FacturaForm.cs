using nikeproject.Data;
using nikeproject.DataAccess;
using nikeproject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace nikeproject.Forms
{
    public partial class FacturaForm : Form
    {
        private int _idVenta;

        public FacturaForm(int idVenta)
        {
            InitializeComponent();
            _idVenta = idVenta;
        }

        private void FacturaForm_Load(object sender, EventArgs e)
        {
            try
            {
                var venta = VentaData.ObtenerVentaPorId(_idVenta);
                var detalles = DetalleVentaData.ListarPorVenta(_idVenta);

                // --- Cabecera ---
                lblTipoDocumentoValor.Text = venta.NumeroDocumento;
                lblFechaValor.Text = venta.FechaRegistro.ToString("dd/MM/yyyy HH:mm");

                lblClienteValor.Text = $"{venta.NombreCliente}";
                lblTelefonoValor.Text = $"{venta.TelefonoCliente}";
                lblCorreoValor.Text = $"{venta.CorreoCliente}";
                lblVendedorValor.Text = $"{venta.NombreVendedor}";

                lblTotalValor.Text = venta.MontoTotal.ToString("C2");

                // --- Detalle ---
                dgvDetalleFactura.AutoGenerateColumns = false;
                dgvDetalleFactura.Columns.Clear();

                dgvDetalleFactura.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NombreProducto",
                    HeaderText = "Producto",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dgvDetalleFactura.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Cantidad",
                    HeaderText = "Cantidad",
                    Width = 80
                });
                dgvDetalleFactura.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "PrecioUnitario",
                    HeaderText = "Precio",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                });
                dgvDetalleFactura.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SubTotal",
                    HeaderText = "SubTotal",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                });

                dgvDetalleFactura.DataSource = detalles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la factura: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
