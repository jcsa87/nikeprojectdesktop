using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using nikeproject.Data;
using nikeproject.DataAccess;
using nikeproject.Models;

namespace nikeproject.Forms
{
    public partial class HistorialVentasForm : Form
    {
        private class VentaRow
        {
            public int IdVenta { get; set; }
            public string NumeroDocumento { get; set; }
            public DateTime FechaRegistro { get; set; }
            public decimal MontoTotal { get; set; }
            public string Cliente { get; set; }
            public string Vendedor { get; set; }
        }

        // UI
        private DataGridView dgvVentas;
        private DataGridView dgvDetalle;
        private TextBox txtBuscar;
        private ComboBox cbBuscar;
        private DateTimePicker dtpDesde, dtpHasta;
        private Button btnFiltrarFechas, btnLimpiar, btnCerrar;
        private PictureBox pbPreview;
        private SplitContainer splitMain, splitDetalle;
        private TableLayoutPanel root;
        private Panel pnlTop, spacer;
        private const int PreviewMinWidth = 360;

        // Data
        private List<VentaRow> _ventas = new();
        private List<VentaRow> _vistaActual = new();

        public HistorialVentasForm()
        {
            Text = "Historial de Ventas";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(900, 600);
            Width = 1000;
            Height = 650;

            InicializarUI();
            CargarVentas();
        }

        // =====================================================
        // CONFIGURACIÓN DE INTERFAZ
        // =====================================================
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            BeginInvoke((Action)(() =>
            {
                splitMain.Panel1MinSize = 140;
                splitMain.Panel2MinSize = 180;
                splitDetalle.Panel1MinSize = 300;
                splitDetalle.Panel2MinSize = PreviewMinWidth;
                splitDetalle.FixedPanel = FixedPanel.Panel2;
                ApplySplitterPositions();
            }));
        }

        private void InicializarUI()
        {
            // ---- Barra superior ----
            pnlTop = new Panel { AutoSize = true, Dock = DockStyle.Top, Padding = new Padding(8) };

            cbBuscar = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160, Left = 8, Top = 10 };
            cbBuscar.Items.AddRange(new object[] { "Tipo de Documento", "Cliente", "Vendedor" });
            cbBuscar.SelectedIndex = 0;

            txtBuscar = new TextBox { Left = cbBuscar.Right + 8, Top = 10, Width = 220 };
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();

            dtpDesde = new DateTimePicker { Left = txtBuscar.Right + 16, Top = 10, Width = 140, Format = DateTimePickerFormat.Short };
            dtpHasta = new DateTimePicker { Left = dtpDesde.Right + 8, Top = 10, Width = 140, Format = DateTimePickerFormat.Short };

            btnFiltrarFechas = new Button { Text = "Filtrar fechas", Left = dtpHasta.Right + 8, Top = 8, Width = 110, Height = 28 };
            btnFiltrarFechas.Click += (s, e) => AplicarFiltros();

            btnLimpiar = new Button { Text = "Limpiar", Left = btnFiltrarFechas.Right + 8, Top = 8, Width = 90, Height = 28 };
            btnLimpiar.Click += (s, e) =>
            {
                txtBuscar.Clear();
                cbBuscar.SelectedIndex = 0;
                _vistaActual = _ventas.ToList();
                RefrescarGridVentas();
                dgvDetalle.DataSource = null;
                pbPreview.Image = null;
            };

            btnCerrar = new Button { Text = "Cerrar", Width = 90, Height = 28, Top = 8, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnCerrar.Click += (s, e) => Close();

            pnlTop.Controls.Add(cbBuscar);
            pnlTop.Controls.Add(txtBuscar);
            pnlTop.Controls.Add(dtpDesde);
            pnlTop.Controls.Add(dtpHasta);
            pnlTop.Controls.Add(btnFiltrarFechas);
            pnlTop.Controls.Add(btnLimpiar);
            pnlTop.Controls.Add(btnCerrar);
            pnlTop.Resize += (s, e) => { btnCerrar.Left = pnlTop.Width - btnCerrar.Width - 8; };

            spacer = new Panel { Dock = DockStyle.Fill, Height = 6, BackColor = SystemColors.Control };

            // ---- Grilla de Ventas ----
            dgvVentas = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvVentas.CellClick += DgvVentas_CellClick;

            // Botón "Ver"
            var colVerFactura = new DataGridViewButtonColumn
            {
                HeaderText = "Factura",
                Name = "colVerFactura",
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvVentas.Columns.Add(colVerFactura);

            // Columnas de datos
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdVenta", HeaderText = "ID" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NumeroDocumento", HeaderText = "Documento" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaRegistro",
                HeaderText = "Fecha",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "g", Font = new Font("Segoe UI", 9, FontStyle.Bold) }
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MontoTotal",
                HeaderText = "Total",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente" });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Vendedor", HeaderText = "Vendedor" });

            // ---- Grilla de Detalle ----
            dgvDetalle = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvDetalle.CellClick += DgvDetalle_CellClick;

            pbPreview = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // ---- Contenedores ----
            splitDetalle = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterWidth = 6
            };
            splitDetalle.Panel1.Controls.Add(dgvDetalle);
            splitDetalle.Panel2.Controls.Add(pbPreview);

            splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterWidth = 6
            };
            splitMain.Panel1.Controls.Add(dgvVentas);
            splitMain.Panel2.Controls.Add(splitDetalle);

            root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3
            };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 6));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.Controls.Add(pnlTop, 0, 0);
            root.Controls.Add(spacer, 0, 1);
            root.Controls.Add(splitMain, 0, 2);
            Controls.Add(root);

            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;

            Resize += Form_Resize;
        }

        // =====================================================
        // POSICIÓN AUTOMÁTICA DE SPLITCONTAINERS
        // =====================================================
        private void Form_Resize(object sender, EventArgs e) => BeginInvoke((Action)(() => ApplySplitterPositions()));

        private void ApplySplitterPositions()
        {
            if (!IsHandleCreated) return;
            if (splitMain.IsHandleCreated && splitMain.ClientSize.Height > 0)
                SetSafeSplitterDistance(splitMain, (int)(splitMain.ClientSize.Height * 0.58));
            if (splitDetalle.IsHandleCreated && splitDetalle.ClientSize.Width > 0)
            {
                int ancho = splitDetalle.ClientSize.Width - splitDetalle.SplitterWidth;
                int rightWidth = Math.Max(PreviewMinWidth, Math.Min(420, ancho / 3));
                int desiredDetalleLeft = Math.Max(300, ancho - rightWidth);
                SetSafeSplitterDistance(splitDetalle, desiredDetalleLeft);
            }
        }

        private static void SetSafeSplitterDistance(SplitContainer sc, int desired)
        {
            if (sc == null || !sc.IsHandleCreated) return;
            int total = (sc.Orientation == Orientation.Vertical) ? sc.ClientSize.Width : sc.ClientSize.Height;
            if (total <= 0) return;
            int available = total - sc.SplitterWidth;
            desired = Math.Max(sc.Panel1MinSize, Math.Min(desired, available - sc.Panel2MinSize));
            try { sc.SplitterDistance = desired; } catch { }
        }

        // =====================================================
        // CARGA DE DATOS
        // =====================================================
        private void CargarVentas()
        {
            try
            {
                var listaDyn = VentaData.ListarVentas();

                _ventas = listaDyn.Select(v => new VentaRow
                {
                    IdVenta = (int)v.IdVenta,
                    NumeroDocumento = (string)v.NumeroDocumento,
                    FechaRegistro = (DateTime)v.FechaRegistro,
                    MontoTotal = (decimal)v.MontoTotal,
                    Cliente = (string)v.Cliente,
                    Vendedor = (string)v.Vendedor
                }).ToList();

                _vistaActual = _ventas.ToList();
                RefrescarGridVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el historial: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefrescarGridVentas()
        {
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = _vistaActual;
        }

        private void AplicarFiltros()
        {
            if (_ventas == null) return;

            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

            IEnumerable<VentaRow> q = _ventas.Where(v => v.FechaRegistro >= desde && v.FechaRegistro <= hasta);
            string columna = cbBuscar.SelectedItem?.ToString() ?? "NumeroDocumento";
            string texto = (txtBuscar.Text ?? "").Trim().ToLower();

            if (!string.IsNullOrEmpty(texto))
            {
                if (columna == "Cliente")
                    q = q.Where(v => (v.Cliente ?? "").ToLower().Contains(texto));
                else if (columna == "Vendedor")
                    q = q.Where(v => (v.Vendedor ?? "").ToLower().Contains(texto));
                else
                    q = q.Where(v => (v.NumeroDocumento ?? "").ToLower().Contains(texto));
            }

            _vistaActual = q.ToList();
            RefrescarGridVentas();
            dgvDetalle.DataSource = null;
            pbPreview.Image = null;
        }

        // =====================================================
        // EVENTOS DE GRILLAS
        // =====================================================
        private void DgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Botón "Ver"
            if (dgvVentas.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                dgvVentas.Columns[e.ColumnIndex].Name == "colVerFactura")
            {
                int idVentaBtn = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells[1].Value);
                using (var frmFactura = new FacturaForm(idVentaBtn))
                {
                    frmFactura.ShowDialog(this);
                }
                return;
            }

            // Selección normal → carga detalle
            int idVenta = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells[1].Value);
            CargarDetalleVenta(idVenta);
        }

        private void CargarDetalleVenta(int idVenta)
        {
            try
            {
                var detalles = DetalleVentaData.ListarPorVenta(idVenta);
                var vista = detalles.Select(d => new
                {
                    Producto = d.NombreProducto,
                    Cantidad = d.Cantidad,
                    Precio = d.PrecioUnitario,
                    SubTotal = d.SubTotal,
                    RutaImagen = ProductoData.ObtenerRutaImagen(d.IdProducto)
                }).ToList();

                dgvDetalle.DataSource = null;
                dgvDetalle.DataSource = vista;

                if (dgvDetalle.Columns["Precio"] != null)
                    dgvDetalle.Columns["Precio"].DefaultCellStyle.Format = "N2";
                if (dgvDetalle.Columns["SubTotal"] != null)
                    dgvDetalle.Columns["SubTotal"].DefaultCellStyle.Format = "N2";
                if (dgvDetalle.Columns["RutaImagen"] != null)
                    dgvDetalle.Columns["RutaImagen"].Visible = false;

                MostrarPreviewDesdeFilaDetalle(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) MostrarPreviewDesdeFilaDetalle(e.RowIndex);
        }

        private void MostrarPreviewDesdeFilaDetalle(int rowIndex)
        {
            try
            {
                if (dgvDetalle.Rows.Count == 0 || rowIndex < 0 || rowIndex >= dgvDetalle.Rows.Count)
                {
                    pbPreview.Image = null;
                    return;
                }

                var cell = dgvDetalle.Rows[rowIndex].Cells["RutaImagen"];
                if (cell == null) { pbPreview.Image = null; return; }

                string ruta = cell.Value?.ToString();
                if (!string.IsNullOrWhiteSpace(ruta) && System.IO.File.Exists(ruta))
                {
                    using (var tmp = Image.FromFile(ruta))
                        pbPreview.Image = new Bitmap(tmp);
                }
                else pbPreview.Image = null;
            }
            catch { pbPreview.Image = null; }
        }
    }
}
