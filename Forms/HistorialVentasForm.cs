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

        private SplitContainer splitMain;     // Ventas (arriba) / Detalle+Imagen (abajo)
        private SplitContainer splitDetalle;  // Detalle (izq) / Imagen (der)
        private PictureBox pbPreview;

        private void InicializarUI()
        {
            // ----- Panel superior de filtros (no tapa nada) -----
            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 64, Padding = new Padding(8) };

            cbBuscar = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 160,
                Left = 8,
                Top = 18
            };
            cbBuscar.Items.Clear();
            cbBuscar.Items.AddRange(new object[] { "NumeroDocumento", "Cliente" });
            cbBuscar.SelectedIndex = 0;

            txtBuscar = new TextBox { Left = cbBuscar.Right + 8, Top = 18, Width = 220 };
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();

            dtpDesde = new DateTimePicker { Left = txtBuscar.Right + 16, Top = 18, Width = 140, Format = DateTimePickerFormat.Short };
            dtpHasta = new DateTimePicker { Left = dtpDesde.Right + 8, Top = 18, Width = 140, Format = DateTimePickerFormat.Short };

            btnFiltrarFechas = new Button { Text = "Filtrar fechas", Left = dtpHasta.Right + 8, Top = 16, Width = 110, Height = 28 };
            btnFiltrarFechas.Click += (s, e) => AplicarFiltros();

            btnLimpiar = new Button { Text = "Limpiar", Left = btnFiltrarFechas.Right + 8, Top = 16, Width = 90, Height = 28 };
            btnLimpiar.Click += (s, e) =>
            {
                txtBuscar.Clear();
                dtpDesde.Value = DateTime.Today.AddDays(-7);
                dtpHasta.Value = DateTime.Today;
                AplicarFiltros();
            };

            btnCerrar = new Button { Text = "Cerrar", Width = 90, Height = 28, Top = 16, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            // lo posicionamos al final (cuando tengamos el ancho)
            pnlTop.Controls.Add(cbBuscar);
            pnlTop.Controls.Add(txtBuscar);
            pnlTop.Controls.Add(dtpDesde);
            pnlTop.Controls.Add(dtpHasta);
            pnlTop.Controls.Add(btnFiltrarFechas);
            pnlTop.Controls.Add(btnLimpiar);
            Controls.Add(pnlTop);

            // ----- Grillas -----
            dgvVentas = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = true
            };
            dgvVentas.CellClick += DgvVentas_CellClick;

            dgvDetalle = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = true
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
                FixedPanel = FixedPanel.Panel2
            };
            splitDetalle.Panel1.Controls.Add(dgvDetalle);
            splitDetalle.Panel2.Controls.Add(pbPreview);
            splitDetalle.SplitterDistance = Math.Max(Width - 280, 600); // deja ~260px para la imagen

            // ----- Split principal: Ventas (arriba) / Detalle+Imagen (abajo) -----
            splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterWidth = 6
            };
            splitMain.Panel1.Controls.Add(dgvVentas);
            splitMain.Panel2.Controls.Add(splitDetalle);
            splitMain.SplitterDistance = 300;

            Controls.Add(splitMain);

            // botón Cerrar a la derecha del panel superior
            btnCerrar.Left = pnlTop.Width - btnCerrar.Width - 8;
            btnCerrar.Click += (s, e) => Close();
            pnlTop.Controls.Add(btnCerrar);

            // Fechas iniciales
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;

            // ... creas pnlTop, splitMain, etc. ...

            splitMain.Dock = DockStyle.Fill;
            pnlTop.Dock = DockStyle.Top;

            // IMPORTANTE: agregar primero el contenido y al final el top
            Controls.Add(splitMain);
            Controls.Add(pnlTop);

            // Fuerza el orden correcto para el docking
            Controls.SetChildIndex(pnlTop, 0);        // pnlTop “arriba” en el orden
            Controls.SetChildIndex(splitMain, 1);     // splitMain ocupa el resto

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
