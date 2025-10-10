using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using nikeproject.Data;        // Conexion.CadenaConexion
using nikeproject.DataAccess;  // VentaData.ListarVentas()

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
          
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            BeginInvoke((Action)(() =>
            {
                // ahora que ya hay tamaño real, aplicamos mínimos deseados
                splitMain.Panel1MinSize = 140;
                splitMain.Panel2MinSize = 180;

                splitDetalle.Panel1MinSize = 300;
                splitDetalle.Panel2MinSize = PreviewMinWidth; // 360 o 420

                // si querés fijar el panel derecho como "fijo", ahora sí:
                splitDetalle.FixedPanel = FixedPanel.Panel2;

                // y recién ahora colocamos los splitters
                ApplySplitterPositions();
            }));
        }


        // UI
        private DataGridView dgvVentas;
        private DataGridView dgvDetalle;
        private TextBox txtBuscar;
        private ComboBox cbBuscar;
        private DateTimePicker dtpDesde, dtpHasta;
        private Button btnFiltrarFechas, btnLimpiar, btnCerrar;

        // Datos en memoria (listas, no DataTable)
        private List<VentaRow> _ventas = new();
        private List<VentaRow> _vistaActual = new();

        public HistorialVentasForm()
        {
            Text = "Historial de Ventas";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(900, 600);
            Width = 1000; Height = 650;

            InicializarUI();
            CargarVentas();
        }

        private TableLayoutPanel root;
        private Panel pnlTop, spacer;
        private SplitContainer splitMain;     // Ventas (arriba) / Detalle+Imagen (abajo)
        private SplitContainer splitDetalle;  // Detalle (izq) / Imagen (der)
        private PictureBox pbPreview;
        private const int PreviewMinWidth = 360; // ancho mínimo deseado de miniatura

        private void InicializarUI()
        {
            // ----- Barra superior (filtros) -----
            pnlTop = new Panel { AutoSize = true, Dock = DockStyle.Top, Padding = new Padding(8, 8, 8, 8) };

            cbBuscar = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160, Left = 8, Top = 10 };
            cbBuscar.Items.Clear();
            cbBuscar.Items.AddRange(new object[] { "NumeroDocumento", "Cliente" });
            cbBuscar.SelectedIndex = 0;

            txtBuscar = new TextBox { Left = cbBuscar.Right + 8, Top = 10, Width = 220 };
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();

            dtpDesde = new DateTimePicker { Left = txtBuscar.Right + 16, Top = 10, Width = 140, Format = DateTimePickerFormat.Short };
            dtpHasta = new DateTimePicker { Left = dtpDesde.Right + 8, Top = 10, Width = 140, Format = DateTimePickerFormat.Short };

            btnFiltrarFechas = new Button { Text = "Filtrar fechas", Left = dtpHasta.Right + 8, Top = 8, Width = 110, Height = 28 };
            btnFiltrarFechas.Click += (s, e) => AplicarFiltros();

            btnLimpiar = new Button { Text = "Limpiar", Left = btnFiltrarFechas.Right + 8, Top = 8, Width = 90, Height = 28 };
            btnLimpiar.Click += (s, e) => { txtBuscar.Clear(); dtpDesde.Value = DateTime.Today.AddDays(-7); dtpHasta.Value = DateTime.Today; AplicarFiltros(); };

            btnCerrar = new Button { Text = "Cerrar", Width = 90, Height = 28, Top = 8, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            btnCerrar.Click += (s, e) => Close();

            pnlTop.Controls.Add(cbBuscar);
            pnlTop.Controls.Add(txtBuscar);
            pnlTop.Controls.Add(dtpDesde);
            pnlTop.Controls.Add(dtpHasta);
            pnlTop.Controls.Add(btnFiltrarFechas);
            pnlTop.Controls.Add(btnLimpiar);
            pnlTop.Controls.Add(btnCerrar);

            // Botón "Cerrar" alineado a la derecha del panel
            pnlTop.Resize += (s, e) => { btnCerrar.Left = pnlTop.Width - btnCerrar.Width - 8; };

            // Separador fino (aire visual)
            spacer = new Panel { Dock = DockStyle.Fill, Height = 6, BackColor = SystemColors.Control };

            // ----- Grillas -----
            dgvVentas = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvVentas.CellClick += DgvVentas_CellClick;

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

            // ----- Imagen de vista previa -----
            pbPreview = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // ----- Split inferior: Detalle (izq) / Imagen (der) -----
            splitDetalle = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterWidth = 6,
                Panel1MinSize = 0,
                Panel2MinSize = 0
            };

            splitDetalle.Panel1.Controls.Add(dgvDetalle);
            splitDetalle.Panel2.Controls.Add(pbPreview);

            splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterWidth = 6,
                Panel1MinSize = 0,
                Panel2MinSize = 0
            };

            splitMain.Panel1.Controls.Add(dgvVentas);
            splitMain.Panel2.Controls.Add(splitDetalle);

            // ----- TableLayoutPanel raíz (NO hay z-order problem) -----
            root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3
            };
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));             // barra filtros
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 6));          // separador
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));         // todo lo demás
            root.Controls.Add(pnlTop, 0, 0);
            root.Controls.Add(spacer, 0, 1);
            root.Controls.Add(splitMain, 0, 2);

            Controls.Add(root);

            // Fechas iniciales
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;

            // Ajustes de márgenes
            dgvVentas.Margin = new Padding(8);
            dgvDetalle.Margin = new Padding(8);
            pbPreview.Margin = new Padding(8);

            // Reaccionar a resize para mantener preview ancho cómodo
            this.Resize += Form_Resize;
        }

        private static void SetSafeSplitterDistance(SplitContainer sc, int desired)
        {
            if (sc == null || !sc.IsHandleCreated) return;

            // Tamaño útil según orientación
            int total = (sc.Orientation == Orientation.Vertical)
                        ? sc.ClientSize.Width
                        : sc.ClientSize.Height;

            if (total <= 0) return;

            int splitter = sc.SplitterWidth;
            int min1 = sc.Panel1MinSize;
            int min2 = sc.Panel2MinSize;

            // Espacio útil sin el splitter
            int available = total - splitter;
            if (available <= 0) return;

            // Si ni siquiera los mínimos entran, NO seteamos (evita excepción)
            if (min1 + min2 > available)
            {
                // Relajamos el min2 para no romper (dejarlo en lo máximo que entre)
                int nuevoMin2 = Math.Max(0, available - min1);
                sc.Panel2MinSize = nuevoMin2;
                min2 = nuevoMin2;

                if (min1 + min2 > available)
                    return; // aún no entra, abortamos sin asignar
            }

            // Máximo permitido para Panel1
            int maxForPanel1 = Math.Max(min1, available - min2);

            int clamped = Math.Max(min1, Math.Min(desired, maxForPanel1));

            try
            {
                sc.SplitterDistance = clamped;
            }
            catch
            {
                // última defensa si Windows ajustó internamente tamaños
                try { sc.SplitterDistance = Math.Max(min1, available - min2); }
                catch { /* ignore */ }
            }
        }






        private void ApplySplitterPositions()
        {
            if (!IsHandleCreated) return;

            // splitMain: Ventas ~ 58% arriba
            if (splitMain.IsHandleCreated && splitMain.ClientSize.Height > 0)
            {
                int desiredMainTop = (int)(splitMain.ClientSize.Height * 0.58);
                SetSafeSplitterDistance(splitMain, desiredMainTop);
            }

            // splitDetalle: preview entre 360 y 420 (o ~1/3 del ancho)
            if (splitDetalle.IsHandleCreated && splitDetalle.ClientSize.Width > 0)
            {
                int ancho = splitDetalle.ClientSize.Width - splitDetalle.SplitterWidth;
                int rightWidth = Math.Max(PreviewMinWidth, Math.Min(420, Math.Max(0, ancho / 3)));
                int desiredDetalleLeft = Math.Max(300, ancho - rightWidth);
                SetSafeSplitterDistance(splitDetalle, desiredDetalleLeft);
            }
        }

        // Mantener proporciones al redimensionar (después del layout)
        private void Form_Resize(object sender, EventArgs e)
        {
            BeginInvoke((Action)(() => ApplySplitterPositions()));
        }





        private void CargarVentas()
        {
            try
            {
                // Convierte List<dynamic> a List<VentaRow> fuerte
                var listaDyn = VentaData.ListarVentas(); // List<dynamic>
                _ventas = listaDyn.Select(v => new VentaRow
                {
                    IdVenta = (int)v.IdVenta,
                    NumeroDocumento = (string)v.NumeroDocumento,
                    FechaRegistro = (DateTime)v.FechaRegistro,
                    MontoTotal = (decimal)v.MontoTotal,
                    Cliente = (string)v.Cliente,
  
                }).ToList();

                _vistaActual = _ventas.ToList(); // copia
                RefrescarGridVentas();
                dgvDetalle.DataSource = null;
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

            // Formatos
            if (dgvVentas.Columns["FechaRegistro"] != null)
            {
                dgvVentas.Columns["FechaRegistro"].HeaderText = "Fecha";
                dgvVentas.Columns["FechaRegistro"].DefaultCellStyle.Format = "g";
            }
            if (dgvVentas.Columns["MontoTotal"] != null)
            {
                dgvVentas.Columns["MontoTotal"].HeaderText = "Total";
                dgvVentas.Columns["MontoTotal"].DefaultCellStyle.Format = "N2";
            }
            if (dgvVentas.Columns["NumeroDocumento"] != null)
                dgvVentas.Columns["NumeroDocumento"].HeaderText = "Documento";
            if (dgvVentas.Columns["Cliente"] != null)
                dgvVentas.Columns["Cliente"].HeaderText = "Cliente";

            if (dgvVentas.Columns["IdVenta"] != null)
                dgvVentas.Columns["IdVenta"].HeaderText = "ID";
        }

        private void AplicarFiltros()
        {
            if (_ventas == null) return;

            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1); // inclusivo

            IEnumerable<VentaRow> q = _ventas.Where(v => v.FechaRegistro >= desde && v.FechaRegistro <= hasta);

            string columna = cbBuscar.SelectedItem?.ToString() ?? "NumeroDocumento";
            string texto = (txtBuscar.Text ?? "").Trim().ToLower();

        
            if (!string.IsNullOrEmpty(texto))
            {
                q = columna == "Cliente"
                    ? q.Where(v => (v.Cliente ?? "").ToLower().Contains(texto))
                    : q.Where(v => (v.NumeroDocumento ?? "").ToLower().Contains(texto));
            }


            _vistaActual = q.ToList();
            RefrescarGridVentas();
            dgvDetalle.DataSource = null;
        }

        private void DgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // ✅ acceso seguro por nombre de columna (sin Contains(string))
            if (dgvVentas.Columns["IdVenta"] == null) return;

            int idVenta = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["IdVenta"].Value);
            CargarDetalleVenta(idVenta);
        }



        private void CargarDetalleVenta(int idVenta)
        {
            try
            {
                // TIPADO (usa tu método ya creado)
                var detalles = nikeproject.DataAccess.DetalleVentaData.ListarPorVenta(idVenta);

                // Proyección para la grilla + columna oculta con ruta
                var vista = detalles.Select(d => new
                {
                    Producto = d.Producto?.Nombre ?? "(sin nombre)",
                    Cantidad = d.Cantidad,
                    Precio = d.PrecioUnitario,
                    SubTotal = d.SubTotal,
                    RutaImagen = d.Producto?.ImagenRuta // oculta (para preview)
                }).ToList();

                dgvDetalle.DataSource = null;
                dgvDetalle.DataSource = vista;

                if (dgvDetalle.Columns["Precio"] != null)
                    dgvDetalle.Columns["Precio"].DefaultCellStyle.Format = "N2";
                if (dgvDetalle.Columns["SubTotal"] != null)
                    dgvDetalle.Columns["SubTotal"].DefaultCellStyle.Format = "N2";
                if (dgvDetalle.Columns["RutaImagen"] != null)
                    dgvDetalle.Columns["RutaImagen"].Visible = false;

                // Previsualizar la 1.ª imagen si existe
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
                    // Evitar bloqueo de archivo: cargar en memoria
                    using (var tmp = Image.FromFile(ruta))
                    {
                        pbPreview.Image = new Bitmap(tmp);
                    }
                }
                else
                {
                    pbPreview.Image = null;
                }
            }
            catch
            {
                pbPreview.Image = null;
            }
        }




    }
}
