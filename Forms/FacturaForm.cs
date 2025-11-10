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

namespace nikeproject.Forms.FacturaFormNS
{
    // ====== Clases de datos (plantilla dinámica) ======
    public class EmpresaInfo
    {
        public string Nombre { get; set; } = "Nike Corrientes";
        public string Lema { get; set; } = "Calzado y ropa deportiva";
        public string Direccion { get; set; } = "Av. Principal 1234";
        public string CiudadCodigoPostal { get; set; } = "Corrientes, 3400";
        public string Telefono { get; set; } = "(379) 400-1234";
        public string Fax { get; set; } = "-";
        public Image? Logo { get; set; } = null;
    }

    public class ClienteInfo
    {
        public string Nombre { get; set; } = "Nombre Cliente";
        public string Compania { get; set; } = "Compañía";
        public string Direccion { get; set; } = "Dirección";
        public string CiudadCodigoPostal { get; set; } = "Ciudad, CP";
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
        public string TipoPago { get; set; } = "efectivo";
        public string Vendedor { get; set; } = "";

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

                lblTipoDocumentoValor.Text = venta.NumeroDocumento;
                lblFechaValor.Text = venta.FechaRegistro.ToString("dd/MM/yyyy HH:mm");
                lblClienteValor.Text = venta.NombreCliente;
                lblTelefonoValor.Text = venta.TelefonoCliente;
                lblCorreoValor.Text = venta.CorreoCliente;
                lblVendedorValor.Text = venta.NombreVendedor;
                lblTotalValor.Text = venta.MontoTotal.ToString("C2");
                lblNumeroFacturaValor.Text = venta.IdVenta.ToString("000000");

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

        private void btnCerrar_Click(object sender, EventArgs e) => Close();

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new() { Document = printDocument1 };
            if (dlg.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        // ==================== FACTURA SIMPLE ====================
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            var venta = VentaData.ObtenerVentaPorId(_idVenta);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int left = e.MarginBounds.Left, top = e.MarginBounds.Top, right = e.MarginBounds.Right;

            using var fTitulo = new Font("Segoe UI", 16, FontStyle.Bold);
            using var fText = new Font("Segoe UI", 9);
            using var fSub = new Font("Segoe UI", 9, FontStyle.Bold);
            using var pen = new Pen(Color.Gray, 1);

            // ================= ENCABEZADO =================
            if (pbLogo.Image != null)
                g.DrawImage(pbLogo.Image, left, top, 100, 60);

            string tituloFactura = $"FACTURA N° {venta.IdVenta:000000}";
            g.DrawString(tituloFactura, fTitulo, Brushes.Black, right - 250, top);
            g.DrawString("Nike Corrientes", fTitulo, Brushes.Black, left + 110, top + 10);
            g.DrawString("Calzado y ropa deportiva", fText, Brushes.Gray, left + 110, top + 38);

            int y = top + 80;

            // ================= DATOS PRINCIPALES =================
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

            // ================= TABLA =================
            int ancho = right - left;
            g.FillRectangle(Brushes.LightGray, left, y, ancho, 22);
            g.DrawRectangle(pen, left, y, ancho, 22);
            g.DrawString("Producto", fSub, Brushes.Black, left + 5, y + 4);
            g.DrawString("Cant.", fSub, Brushes.Black, right - 280, y + 4);
            g.DrawString("Precio", fSub, Brushes.Black, right - 180, y + 4);
            g.DrawString("Subtotal", fSub, Brushes.Black, right - 80, y + 4);
            y += 22;

            var detalles = DetalleVentaData.ListarPorVenta(_idVenta);
            foreach (var d in detalles)
            {
                g.DrawRectangle(pen, left, y, ancho, 20);
                g.DrawString(d.NombreProducto, fText, Brushes.Black, left + 5, y + 4);
                g.DrawString(d.Cantidad.ToString(), fText, Brushes.Black, right - 270, y + 4);
                g.DrawString($"{d.PrecioUnitario:C2}", fText, Brushes.Black, right - 180, y + 4);
                g.DrawString($"{d.SubTotal:C2}", fText, Brushes.Black, right - 80, y + 4);
                y += 20;
            }

            decimal subtotal = detalles.Sum(d => d.SubTotal);
            decimal iva = Math.Round(subtotal * 0.21m, 2);
            decimal total = subtotal + iva;

            y += 20;
            g.DrawString("Subtotal:", fSub, Brushes.Black, right - 200, y);
            g.DrawString($"{subtotal:C2}", fSub, Brushes.Black, right - 80, y);
            y += 20;
            g.DrawString("IVA (21%):", fSub, Brushes.Black, right - 200, y);
            g.DrawString($"{iva:C2}", fSub, Brushes.Black, right - 80, y);
            y += 20;
            g.DrawString("TOTAL:", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, right - 200, y);
            g.DrawString($"{total:C2}", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, right - 80, y);
            y += 40;

            g.DrawString("Gracias por su compra.", fText, Brushes.Gray, left, y);

            /// === SELLO FACTURA ANULADA===
            if (!venta.Estado)
            {
                using var fontAnulada = new Font("Segoe UI", 70, FontStyle.Bold); // 
                using var brushRojo = new SolidBrush(Color.FromArgb(90, 255, 0, 0)); // rojo translúcido
                var texto = "FACTURA ANULADA";
                var formato = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };


                var rect = e.PageBounds;
                g.TranslateTransform(rect.Width / 2, rect.Height / 2);
                g.RotateTransform(-35);
                g.DrawString(texto, fontAnulada, brushRojo, 0, 0, formato);
                g.ResetTransform();
            }

        }

        private void printDocument_Profesional_PrintPage(object sender, PrintPageEventArgs e)
        {
            var venta = VentaData.ObtenerVentaPorId(_idVenta);
            var detalles = DetalleVentaData.ListarPorVenta(_idVenta);

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int left = e.MarginBounds.Left, top = e.MarginBounds.Top, right = e.MarginBounds.Right;
            int ancho = right - left;

            using var fTitulo = new Font("Segoe UI", 16, FontStyle.Bold);
            using var fText = new Font("Segoe UI", 9);
            using var fSub = new Font("Segoe UI", 9, FontStyle.Bold);
            using var pen = new Pen(Color.Gray, 1);

            // ================= ENCABEZADO =================
            if (pbLogo.Image != null)
                g.DrawImage(pbLogo.Image, left, top, 100, 60);

            string tituloFactura = $"FACTURA N° {venta.IdVenta:000000}";
            g.DrawString(tituloFactura, fTitulo, Brushes.Black, right - 250, top);
            g.DrawString("Nike Corrientes", fTitulo, Brushes.Black, left + 110, top + 10);
            g.DrawString("Calzado y ropa deportiva", fText, Brushes.Gray, left + 110, top + 38);

            int y = top + 80;

            // ================= DATOS PRINCIPALES =================
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

            // ================= TABLA =================
            g.FillRectangle(Brushes.LightGray, left, y, ancho, 22);
            g.DrawRectangle(pen, left, y, ancho, 22);
            g.DrawString("Producto", fSub, Brushes.Black, left + 5, y + 4);
            g.DrawString("Cant.", fSub, Brushes.Black, right - 280, y + 4);
            g.DrawString("Precio", fSub, Brushes.Black, right - 180, y + 4);
            g.DrawString("Subtotal", fSub, Brushes.Black, right - 80, y + 4);
            y += 22;

            foreach (var d in detalles)
            {
                g.DrawRectangle(pen, left, y, ancho, 20);
                g.DrawString(d.NombreProducto, fText, Brushes.Black, left + 5, y + 4);
                g.DrawString(d.Cantidad.ToString(), fText, Brushes.Black, right - 270, y + 4);
                g.DrawString($"{d.PrecioUnitario:C2}", fText, Brushes.Black, right - 180, y + 4);
                g.DrawString($"{d.SubTotal:C2}", fText, Brushes.Black, right - 80, y + 4);
                y += 20;
            }

            decimal subtotal = detalles.Sum(d => d.SubTotal);
            decimal iva = Math.Round(subtotal * 0.21m, 2);
            decimal total = subtotal + iva;

            y += 20;
            g.DrawString("Subtotal:", fSub, Brushes.Black, right - 200, y);
            g.DrawString($"{subtotal:C2}", fSub, Brushes.Black, right - 80, y);
            y += 20;
            g.DrawString("IVA (21%):", fSub, Brushes.Black, right - 200, y);
            g.DrawString($"{iva:C2}", fSub, Brushes.Black, right - 80, y);
            y += 20;
            g.DrawString("TOTAL:", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, right - 200, y);
            g.DrawString($"{total:C2}", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, right - 80, y);
            y += 40;

            g.DrawString("Gracias por su compra.", fText, Brushes.Gray, left, y);

            // === SELLO FACTURA ANULADA (ajustado) ===
            if (!venta.Estado)
            {
                using var fontAnulada = new Font("Segoe UI", 70, FontStyle.Bold); //
                using var brushRojo = new SolidBrush(Color.FromArgb(90, 255, 0, 0)); 
                var texto = "FACTURA ANULADA";
                var formato = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // 🔹 Centramos sobre toda la página (PageBounds)
                var rect = e.PageBounds;
                g.TranslateTransform(rect.Width / 2, rect.Height / 2);
                g.RotateTransform(-35);
                g.DrawString(texto, fontAnulada, brushRojo, 0, 0, formato);
                g.ResetTransform();
            }

        }

        private void btnGuardarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                using SaveFileDialog sfd = new()
                {
                    Filter = "Archivo PDF|*.pdf",
                    FileName = $"Factura_{_idVenta:000000}.pdf"
                };
                if (sfd.ShowDialog() != DialogResult.OK) return;

                printDocument1.PrintPage -= printDocument1_PrintPage;
                printDocument1.PrintPage += printDocument_Profesional_PrintPage;

                var ps = printDocument1.PrinterSettings;
                ps.PrinterName = "Microsoft Print to PDF";
                ps.PrintToFile = true;
                ps.PrintFileName = sfd.FileName;

                printDocument1.Print();
                MessageBox.Show("Factura guardada como PDF correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message);
            }
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument1.PrintPage -= printDocument1_PrintPage;
                printDocument1.PrintPage += printDocument_Profesional_PrintPage;

                using PrintPreviewDialog prev = new() { Document = printDocument1, Width = 1200, Height = 800 };
                prev.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar vista previa: " + ex.Message);
            }
        }
    }
}
