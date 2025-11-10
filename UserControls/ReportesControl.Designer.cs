using System.Drawing.Drawing2D;
using nikeproject.Models; // para usar SesionUsuario y RolUsuario

namespace nikeproject.UserControls
{
    partial class ReportesControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new();

            tableLayoutPanel1 = new TableLayoutPanel();
            panelHeader = new Panel();
            lblTituloPrincipal = new Label();
            flowIndicadores = new FlowLayoutPanel();
            pnlVentas = CrearTarjeta("📊", "Ventas mes (noviembre)", "$0", Color.Black, out lblVentasTitulo, out lblVentasValor);
            pnlVariacion = CrearTarjeta("📈", "Variación (vs mes anterior)", "0%", Color.ForestGreen, out lblVariacionTitulo, out lblVariacionValor);
            pnlStock = CrearTarjeta("⚠️", "Artículos sin stock", "0", Color.Firebrick, out lblStockTitulo, out lblStockValor);
            pnlClientes = CrearTarjeta("👥", "Clientes activos", "0", Color.Black, out lblClientesTitulo, out lblClientesValor);

            panelDivider = new Panel();
            pnlFiltros = new Panel();
            lblTipoReporte = new Label();
            cbReporte = new ComboBox();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            btnAplicar = new Button();
            btnReset = new Button();
            lblLeyenda = new Label();
            chkIncluirAnuladas = new CheckBox(); // Nuevo checkbox
            chartPrincipal = new System.Windows.Forms.DataVisualization.Charting.Chart();

            tableLayoutPanel1.SuspendLayout();
            panelHeader.SuspendLayout();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(chartPrincipal)).BeginInit();
            SuspendLayout();

            // ========================= LAYOUT PRINCIPAL =========================
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));   // Encabezado
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));  // Tarjetas
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));    // Divisor
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));   // Filtros
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));   // Gráfico
            tableLayoutPanel1.BackColor = Color.FromArgb(243, 244, 246);

            // ========================= ENCABEZADO =========================
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.BackColor = Color.White;
            panelHeader.Padding = new Padding(25, 15, 25, 5);

            lblTituloPrincipal.Text = "📊 Panel de Reportes y Estadísticas";
            lblTituloPrincipal.Font = new Font("Segoe UI Semibold", 14F);
            lblTituloPrincipal.ForeColor = Color.FromArgb(50, 50, 50);
            lblTituloPrincipal.Dock = DockStyle.Fill;
            lblTituloPrincipal.TextAlign = ContentAlignment.MiddleLeft;

            panelHeader.Controls.Add(lblTituloPrincipal);

            // ========================= TARJETAS =========================
            flowIndicadores.Dock = DockStyle.Fill;
            flowIndicadores.FlowDirection = FlowDirection.LeftToRight;
            flowIndicadores.WrapContents = true;
            flowIndicadores.Padding = new Padding(30, 15, 30, 15);
            flowIndicadores.BackColor = Color.WhiteSmoke;

            flowIndicadores.Controls.AddRange(new Control[] { pnlVentas, pnlVariacion, pnlStock, pnlClientes });

            // ========================= DIVISOR =========================
            panelDivider.Dock = DockStyle.Fill;
            panelDivider.BackColor = Color.FromArgb(210, 210, 210);

            // ========================= FILTROS =========================
            pnlFiltros.Dock = DockStyle.Fill;
            pnlFiltros.BackColor = Color.WhiteSmoke;

            lblTipoReporte.Text = "Tipo de reporte:";
            lblTipoReporte.Location = new Point(25, 25);
            lblTipoReporte.AutoSize = true;

            cbReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReporte.Location = new Point(130, 22);
            cbReporte.Size = new Size(200, 28);

            lblDesde.Text = "Desde:";
            lblDesde.Location = new Point(360, 25);
            lblDesde.AutoSize = true;

            dtpDesde.Location = new Point(410, 22);
            dtpDesde.Size = new Size(150, 27);

            lblHasta.Text = "Hasta:";
            lblHasta.Location = new Point(580, 25);
            lblHasta.AutoSize = true;

            dtpHasta.Location = new Point(630, 22);
            dtpHasta.Size = new Size(150, 27);

            btnAplicar.Text = "Aplicar";
            btnAplicar.BackColor = Color.FromArgb(0, 120, 215);
            btnAplicar.ForeColor = Color.White;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.Location = new Point(800, 20);
            btnAplicar.Size = new Size(90, 32);
            btnAplicar.Click += btnAplicar_Click;

            btnReset.Text = "Resetear";
            btnReset.BackColor = Color.FromArgb(80, 80, 80);
            btnReset.ForeColor = Color.White;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Location = new Point(900, 20);
            btnReset.Size = new Size(90, 32);
            btnReset.Click += btnReset_Click;

            lblLeyenda.AutoSize = true;
            lblLeyenda.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblLeyenda.ForeColor = Color.DimGray;
            lblLeyenda.Location = new Point(1000, 27);
            lblLeyenda.Text = "Mostrando datos de los últimos 30 días.";

            // ===== Nuevo CheckBox: Incluir ventas anuladas =====
            chkIncluirAnuladas.Text = "Incluir ventas anuladas";
            chkIncluirAnuladas.AutoSize = true;
            chkIncluirAnuladas.Location = new Point(1020, 50);
            chkIncluirAnuladas.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            chkIncluirAnuladas.ForeColor = Color.Black;
            chkIncluirAnuladas.Checked = false;
            chkIncluirAnuladas.Visible =
                SesionUsuario.Rol == RolUsuario.Administrador ||
                SesionUsuario.Rol == RolUsuario.Supervisor;

            pnlFiltros.Controls.AddRange(new Control[]
            {
                lblTipoReporte, cbReporte, lblDesde, dtpDesde,
                lblHasta, dtpHasta, btnAplicar, btnReset, lblLeyenda, chkIncluirAnuladas
            });

            // ========================= CHART =========================
            chartPrincipal.Dock = DockStyle.Fill;
            chartPrincipal.BackColor = Color.White;

            chartArea1.Name = "MainArea";
            chartArea1.AxisX.Interval = 1;
            chartArea1.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartPrincipal.ChartAreas.Add(chartArea1);

            legend1.Name = "Legend1";
            chartPrincipal.Legends.Add(legend1);

            series1.ChartArea = "MainArea";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartPrincipal.Series.Add(series1);

            // ========================= ENSAMBLADO =========================
            tableLayoutPanel1.Controls.Add(panelHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(flowIndicadores, 0, 1);
            tableLayoutPanel1.Controls.Add(panelDivider, 0, 2);
            tableLayoutPanel1.Controls.Add(pnlFiltros, 0, 3);
            tableLayoutPanel1.Controls.Add(chartPrincipal, 0, 4);

            Controls.Add(tableLayoutPanel1);
            BackColor = Color.FromArgb(243, 244, 246);
            Name = "ReportesControl";
            Size = new Size(1600, 850);

            tableLayoutPanel1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(chartPrincipal)).EndInit();
            ResumeLayout(false);
        }

        // ========================= TARJETA PREMIUM =========================
        private Panel CrearTarjeta(string icono, string titulo, string valor, Color colorTexto,
                                   out Label lblTitulo, out Label lblValor)
        {
            Panel card = new Panel
            {
                BackColor = Color.White,
                Size = new Size(280, 100),
                Margin = new Padding(20),
            };
            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = card.ClientRectangle;
                using (var path = RoundedRect(rect, 10))
                using (var shadow = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(shadow, new Rectangle(rect.X + 3, rect.Y + 3, rect.Width - 3, rect.Height - 3));
                    e.Graphics.FillPath(Brushes.White, path);
                    e.Graphics.DrawPath(new Pen(Color.Gainsboro, 1.5f), path);
                }
            };

            TableLayoutPanel layout = new()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                Padding = new Padding(12)
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            Label lblIcon = new()
            {
                Text = icono,
                Font = new Font("Segoe UI Emoji", 24F),
                ForeColor = Color.FromArgb(100, 100, 100),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblTitulo = new()
            {
                Text = titulo,
                Font = new Font("Segoe UI Semibold", 9F),
                ForeColor = Color.DimGray,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };

            lblValor = new()
            {
                Text = valor,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = colorTexto,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft
            };

            layout.Controls.Add(lblIcon, 0, 0);
            layout.SetRowSpan(lblIcon, 2);
            layout.Controls.Add(lblTitulo, 1, 0);
            layout.Controls.Add(lblValor, 1, 1);

            card.Controls.Add(layout);
            return card;
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelHeader;
        private Label lblTituloPrincipal;
        private FlowLayoutPanel flowIndicadores;
        private Panel panelDivider;
        private Panel pnlFiltros;
        private Label lblTipoReporte;
        private ComboBox cbReporte;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Button btnAplicar;
        private Button btnReset;
        private Label lblLeyenda;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPrincipal;

        // 🔹 Paneles e indicadores dinámicos
        private Panel pnlVentas, pnlVariacion, pnlStock, pnlClientes;
        private Label lblVentasTitulo, lblVentasValor, lblVariacionTitulo, lblVariacionValor;
        private Label lblStockTitulo, lblStockValor, lblClientesTitulo, lblClientesValor;

        // 🔹 Nuevo checkbox
        private CheckBox chkIncluirAnuladas;
    }
}
