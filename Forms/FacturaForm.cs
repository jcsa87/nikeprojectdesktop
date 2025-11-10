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

//se crea otro namespace para no "chocar" con el original. Este namespace es de la factura.
namespace nikeproject.Forms.FacturaFormNS
{
    // ====== Clases de datos (plantilla dinámica) ======
    public class EmpresaInfo
    {
        public string Nombre { get; set; } = "Nombre de su compañía";
        public string Lema { get; set; } = "Lema de su compañía";
        public string Direccion { get; set; } = "Dirección";
        public string CiudadCodigoPostal { get; set; } = "Ciudad, Código postal";
        public string Telefono { get; set; } = "Teléfono";
        public string Fax { get; set; } = "Fax";
        public Image? Logo { get; set; } = null;
    }

    public class ClienteInfo
    {
        public string Nombre { get; set; } = "Nombre";
        public string Compania { get; set; } = "Nombre de la compañía";
        public string Direccion { get; set; } = "Dirección";
        public string CiudadCodigoPostal { get; set; } = "Ciudad, Código postal";
        public string Telefono { get; set; } = "Teléfono";
        public string Documento { get; set; } = "DNI/CUIT";
    }

    public class ItemFactura
    {
        public string Codigo { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }

    public class FacturaData
    {
        public string NumeroFactura { get; set; } = "VENT-000001";
        public DateTime Fecha { get; set; } = DateTime.Today;
        public string DescripcionGeneral { get; set; } = "Venta mostrador";
        public string TipoPago { get; set; } = "efectivo";  // ← mapeado desde VENTA.NumeroDocumento
        public string Vendedor { get; set; } = "";          // USUARIO.Nombre + Apellido

        public EmpresaInfo Empresa { get; set; } = new EmpresaInfo();
        public ClienteInfo Cliente { get; set; } = new ClienteInfo();
        public List<ItemFactura> Items { get; set; } = new List<ItemFactura>();

        public decimal PorcentajeIva { get; set; } = 0.21m;
        public decimal Otros { get; set; } = 0m;

        public decimal Subtotal => Math.Round(SumaItems(), 2);
        public decimal Iva => Math.Round(Subtotal * PorcentajeIva, 2);
        public decimal Total => Subtotal + Iva + Otros;

        private decimal SumaItems()
        {
            decimal s = 0m;
            foreach (var it in Items) s += it.Subtotal;
            return s;
        }
    }
}

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

                lblNumeroFacturaValor.Text = venta.IdVenta.ToString("000000");


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

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int left = e.MarginBounds.Left;
            int top = e.MarginBounds.Top;
            int right = e.MarginBounds.Right;

            // Colores y fuentes
            using var fTitulo = new Font("Segoe UI", 16, FontStyle.Bold);
            using var fText = new Font("Segoe UI", 9);
            using var fSub = new Font("Segoe UI", 9, FontStyle.Bold);
            using var fWater = new Font("Segoe UI", 28, FontStyle.Bold);
            using var pen = new Pen(Color.Gray, 1);

            // Encabezado con logo
            if (pbLogo.Image != null)
                g.DrawImage(pbLogo.Image, left, top, 80, 50);

            g.DrawString("FACTURA", fWater, new SolidBrush(Color.FromArgb(25, 0, 0, 0)), new RectangleF(right - 240, top - 20, 220, 60), new StringFormat { Alignment = StringAlignment.Far });

            g.DrawString("Nike Corrientes", fTitulo, Brushes.Black, left + 100, top + 10);
            g.DrawString("Calzado y ropa deportiva", fText, Brushes.Gray, left + 100, top + 38);

            int y = top + 80;

            // Información de la venta
            g.DrawString("Tipo de pago:", fSub, Brushes.Black, left, y);
            g.DrawString(lblTipoDocumentoValor.Text, fText, Brushes.Black, left + 120, y);
            g.DrawString("Fecha:", fSub, Brushes.Black, right - 200, y);
            g.DrawString(lblFechaValor.Text, fText, Brushes.Black, right - 100, y);
            y += 25;

            // Cliente
            g.DrawString("Cliente:", fSub, Brushes.Black, left, y);
            g.DrawString(lblClienteValor.Text, fText, Brushes.Black, left + 120, y);
            y += 18;
            g.DrawString("Teléfono:", fSub, Brushes.Black, left, y);
            g.DrawString(lblTelefonoValor.Text, fText, Brushes.Black, left + 120, y);
            y += 18;
            g.DrawString("Correo:", fSub, Brushes.Black, left, y);
            g.DrawString(lblCorreoValor.Text, fText, Brushes.Black, left + 120, y);
            y += 25;
            g.DrawString("Vendedor:", fSub, Brushes.Black, left, y);
            g.DrawString(lblVendedorValor.Text, fText, Brushes.Black, left + 120, y);
            y += 40;

            // Cabecera de tabla
            int x = left;
            int ancho = right - left;
            int altoCab = 22;
            g.FillRectangle(Brushes.LightGray, x, y, ancho, altoCab);
            g.DrawRectangle(pen, x, y, ancho, altoCab);
            g.DrawString("Producto", fSub, Brushes.Black, x + 5, y + 4);
            g.DrawString("Cant.", fSub, Brushes.Black, right - 280, y + 4);
            g.DrawString("Precio", fSub, Brushes.Black, right - 180, y + 4);
            g.DrawString("Subtotal", fSub, Brushes.Black, right - 80, y + 4);
            y += altoCab;

            // Filas de detalle
            foreach (DataGridViewRow row in dgvDetalleFactura.Rows)
            {
                string prod = row.Cells["NombreProducto"].Value?.ToString() ?? "";
                string cant = row.Cells["Cantidad"].Value?.ToString() ?? "";
                string precio = string.Format("{0:C2}", row.Cells["PrecioUnitario"].Value);
                string subtotal = string.Format("{0:C2}", row.Cells["SubTotal"].Value);

                g.DrawRectangle(pen, x, y, ancho, altoCab);
                g.DrawString(prod, fText, Brushes.Black, x + 5, y + 4);
                g.DrawString(cant, fText, Brushes.Black, right - 270, y + 4);
                g.DrawString(precio, fText, Brushes.Black, right - 180, y + 4);
                g.DrawString(subtotal, fText, Brushes.Black, right - 80, y + 4);
                y += altoCab;
            }

            y += 20;

            // Totales
            g.DrawString("Subtotal:", fSub, Brushes.Black, right - 200, y);
            g.DrawString(lblTotalValor.Text, fSub, Brushes.Black, right - 80, y);
            y += 20;
            g.DrawString($"IVA (21%):", fSub, Brushes.Black, right - 200, y);
            decimal total = decimal.Parse(lblTotalValor.Text, System.Globalization.NumberStyles.Currency);
            decimal iva = Math.Round(total * 0.21m, 2);
            g.DrawString($"{iva:C2}", fSub, Brushes.Black, right - 80, y);
            y += 20;
            g.DrawString("TOTAL:", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, right - 200, y);
            g.DrawString($"{(total + iva):C2}", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, right - 80, y);
            y += 40;

            // Pie
            g.DrawString("Gracias por su compra.", fText, Brushes.Gray, left, y);
            g.DrawString("Nike Corrientes — www.nikeproject.com", fText, Brushes.Gray, right - 280, y);
        }

        private void btnGuardarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                using SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Archivo PDF|*.pdf",
                    FileName = $"Factura_{_idVenta:000000}.pdf"
                };

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                printDocument1.PrintPage -= printDocument1_PrintPage; // aseguramos no duplicar el evento
                printDocument1.PrintPage += printDocument_Profesional_PrintPage;

                var ps = printDocument1.PrinterSettings;
                ps.PrinterName = "Microsoft Print to PDF";
                ps.PrintToFile = true;
                ps.PrintFileName = sfd.FileName;

                printDocument1.Print();
                MessageBox.Show("Factura profesional guardada correctamente como PDF.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
        }

        private void printDocument_Profesional_PrintPage(object sender, PrintPageEventArgs e)
        {
            var venta = VentaData.ObtenerVentaPorId(_idVenta);
            var detalles = DetalleVentaData.ListarPorVenta(_idVenta);

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int left = e.MarginBounds.Left;
            int top = e.MarginBounds.Top;
            int right = e.MarginBounds.Right;
            int ancho = right - left;

            // Paleta y fuentes
            using var fTitulo = new Font("Segoe UI", 16, FontStyle.Bold);
            using var fText = new Font("Segoe UI", 9);
            using var fSub = new Font("Segoe UI", 9, FontStyle.Bold);
            using var fWater = new Font("Segoe UI", 28, FontStyle.Bold);
            using var pen = new Pen(Color.Gray, 1);

            // === ENCABEZADO ===
            if (pbLogo.Image != null)
                g.DrawImage(pbLogo.Image, left, top, 100, 60);

            g.DrawString("FACTURA", fWater, new SolidBrush(Color.FromArgb(30, 0, 0, 0)),
                new RectangleF(right - 250, top - 20, 250, 60),
                new StringFormat { Alignment = StringAlignment.Far });

            g.DrawString($"N°: {venta.IdVenta:000000}", fSub, Brushes.Black, right - 250, top + 10);

            g.DrawString("Nike Corrientes", fTitulo, Brushes.Black, left + 110, top + 10);
            g.DrawString("Calzado y ropa deportiva", fText, Brushes.Gray, left + 110, top + 38);

            int y = top + 80;

            // === DATOS CABECERA ===
            g.DrawString("Tipo de pago:", fSub, Brushes.Black, left, y);
            g.DrawString(venta.NumeroDocumento, fText, Brushes.Black, left + 120, y);
            g.DrawString("Fecha:", fSub, Brushes.Black, right - 200, y);
            g.DrawString(venta.FechaRegistro.ToString("dd/MM/yyyy HH:mm"), fText, Brushes.Black, right - 100, y);
            y += 25;

            g.DrawString("Cliente:", fSub, Brushes.Black, left, y);
            g.DrawString(venta.NombreCliente, fText, Brushes.Black, left + 120, y);
            y += 18;
            g.DrawString("Teléfono:", fSub, Brushes.Black, left, y);
            g.DrawString(venta.TelefonoCliente, fText, Brushes.Black, left + 120, y);
            y += 18;
            g.DrawString("Correo:", fSub, Brushes.Black, left, y);
            g.DrawString(venta.CorreoCliente, fText, Brushes.Black, left + 120, y);
            y += 25;
            g.DrawString("Vendedor:", fSub, Brushes.Black, left, y);
            g.DrawString(venta.NombreVendedor, fText, Brushes.Black, left + 120, y);
            y += 40;

            // === TABLA DETALLE ===
            g.FillRectangle(Brushes.LightGray, left, y, ancho, 22);
            g.DrawRectangle(pen, left, y, ancho, 22);
            g.DrawString("Producto", fSub, Brushes.Black, left + 5, y + 4);
            g.DrawString("Cant.", fSub, Brushes.Black, right - 280, y + 4);
            g.DrawString("Precio", fSub, Brushes.Black, right - 180, y + 4);
            g.DrawString("Subtotal", fSub, Brushes.Black, right - 80, y + 4);
            y += 22;

            foreach (var d in detalles)
            {
                string nombre = d.NombreProducto;
                string cant = d.Cantidad.ToString();
                string precio = $"{d.PrecioUnitario:C2}";
                string subtotalTexto = $"{d.SubTotal:C2}";

                g.DrawRectangle(pen, left, y, ancho, 20);
                g.DrawString(nombre, fText, Brushes.Black, left + 5, y + 4);
                g.DrawString(cant, fText, Brushes.Black, right - 270, y + 4);
                g.DrawString(precio, fText, Brushes.Black, right - 180, y + 4);
                g.DrawString(subtotalTexto, fText, Brushes.Black, right - 80, y + 4);
                y += 20;
            }


            y += 20;

            // === TOTALES ===
            decimal subtotal = 0m;

            // Sumamos los subtotales directamente desde la lista de detalles
            foreach (var d in detalles)
                subtotal += d.SubTotal;

            decimal iva = Math.Round(subtotal * 0.21m, 2);
            decimal totalFinal = subtotal + iva;

            // Dibujamos los valores
            g.DrawString("Subtotal:", fSub, Brushes.Black, right - 200, y);
            g.DrawString($"{subtotal:C2}", fSub, Brushes.Black, right - 80, y);
            y += 20;

            g.DrawString("IVA (21%):", fSub, Brushes.Black, right - 200, y);
            g.DrawString($"{iva:C2}", fSub, Brushes.Black, right - 80, y);
            y += 20;

            g.DrawString("TOTAL:", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, right - 200, y);
            g.DrawString($"{totalFinal:C2}", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, right - 80, y);
            y += 40;

        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                // Nos aseguramos de usar el método de dibujo profesional
                printDocument1.PrintPage -= printDocument1_PrintPage;
                printDocument1.PrintPage += printDocument_Profesional_PrintPage;

                using PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = printDocument1;
                preview.Width = 1200;
                preview.Height = 800;
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar vista previa: " + ex.Message);
            }
        }




    }
}
