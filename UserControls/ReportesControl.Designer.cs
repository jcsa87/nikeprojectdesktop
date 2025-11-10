namespace nikeproject.UserControls
{
    partial class ReportesControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowIndicadores = new FlowLayoutPanel();
            pnlVentas = new Panel();
            lblVentasTitulo = new Label();
            lblVentasValor = new Label();
            pnlVariacion = new Panel();
            lblVariacionTitulo = new Label();
            lblVariacionValor = new Label();
            pnlStock = new Panel();
            lblStockTitulo = new Label();
            lblStockValor = new Label();
            pnlClientes = new Panel();
            lblClientesTitulo = new Label();
            lblClientesValor = new Label();
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
            chartPrincipal = new System.Windows.Forms.DataVisualization.Charting.Chart();

            tableLayoutPanel1.SuspendLayout();
            flowIndicadores.SuspendLayout();
            pnlVentas.SuspendLayout();
            pnlVariacion.SuspendLayout();
            pnlStock.SuspendLayout();
            pnlClientes.SuspendLayout();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(chartPrincipal)).BeginInit();
            SuspendLayout();

            // ========================= TABLELAYOUT PRINCIPAL =========================
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));  // Indicadores
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));   // Filtros
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));   // Gráfico

            // ========================= INDICADORES =========================
            flowIndicadores.Dock = DockStyle.Fill;
            flowIndicadores.FlowDirection = FlowDirection.LeftToRight;
            flowIndicadores.WrapContents = true;
            flowIndicadores.Padding = new Padding(10);
            flowIndicadores.BackColor = Color.White;

            // Panel Ventas
            pnlVentas.BackColor = Color.WhiteSmoke;
            pnlVentas.Size = new Size(250, 80);
            pnlVentas.Margin = new Padding(20);
            pnlVentas.BorderStyle = BorderStyle.FixedSingle;

            lblVentasTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVentasTitulo.Text = "Ventas mes";
            lblVentasTitulo.AutoSize = true;
            lblVentasTitulo.Location = new Point(15, 8);

            lblVentasValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblVentasValor.AutoSize = true;
            lblVentasValor.Text = "$0";
            lblVentasValor.Location = new Point(15, 33);

            pnlVentas.Controls.Add(lblVentasTitulo);
            pnlVentas.Controls.Add(lblVentasValor);

            // Panel Variación
            pnlVariacion.BackColor = Color.WhiteSmoke;
            pnlVariacion.Size = new Size(250, 80);
            pnlVariacion.Margin = new Padding(20);
            pnlVariacion.BorderStyle = BorderStyle.FixedSingle;

            lblVariacionTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVariacionTitulo.Text = "Variación (vs mes anterior)";
            lblVariacionTitulo.AutoSize = true;
            lblVariacionTitulo.Location = new Point(15, 8);

            lblVariacionValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblVariacionValor.ForeColor = Color.ForestGreen;
            lblVariacionValor.AutoSize = true;
            lblVariacionValor.Text = "0%";
            lblVariacionValor.Location = new Point(15, 33);

            pnlVariacion.Controls.Add(lblVariacionTitulo);
            pnlVariacion.Controls.Add(lblVariacionValor);

            // Panel Stock
            pnlStock.BackColor = Color.WhiteSmoke;
            pnlStock.Size = new Size(250, 80);
            pnlStock.Margin = new Padding(20);
            pnlStock.BorderStyle = BorderStyle.FixedSingle;

            lblStockTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStockTitulo.Text = "Artículos sin stock";
            lblStockTitulo.AutoSize = true;
            lblStockTitulo.Location = new Point(15, 8);

            lblStockValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblStockValor.ForeColor = Color.Firebrick;
            lblStockValor.AutoSize = true;
            lblStockValor.Text = "0";
            lblStockValor.Location = new Point(15, 33);

            pnlStock.Controls.Add(lblStockTitulo);
            pnlStock.Controls.Add(lblStockValor);

            // Panel Clientes
            pnlClientes.BackColor = Color.WhiteSmoke;
            pnlClientes.Size = new Size(250, 80);
            pnlClientes.Margin = new Padding(20);
            pnlClientes.BorderStyle = BorderStyle.FixedSingle;

            lblClientesTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClientesTitulo.Text = "Clientes activos";
            lblClientesTitulo.AutoSize = true;
            lblClientesTitulo.Location = new Point(15, 8);

            lblClientesValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblClientesValor.AutoSize = true;
            lblClientesValor.Text = "0";
            lblClientesValor.Location = new Point(15, 33);

            pnlClientes.Controls.Add(lblClientesTitulo);
            pnlClientes.Controls.Add(lblClientesValor);

            // Añadir paneles al flow
            flowIndicadores.Controls.Add(pnlVentas);
            flowIndicadores.Controls.Add(pnlVariacion);
            flowIndicadores.Controls.Add(pnlStock);
            flowIndicadores.Controls.Add(pnlClientes);

            // ========================= PANEL FILTROS =========================
            pnlFiltros.Dock = DockStyle.Fill;
            pnlFiltros.BackColor = Color.WhiteSmoke;

            lblTipoReporte.Text = "Tipo de reporte:";
            lblTipoReporte.AutoSize = true;
            lblTipoReporte.Location = new Point(20, 18);

            cbReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReporte.Location = new Point(130, 15);
            cbReporte.Size = new Size(200, 28);

            lblDesde.Text = "Desde:";
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(360, 18);

            dtpDesde.Location = new Point(410, 15);
            dtpDesde.Size = new Size(150, 27);

            lblHasta.Text = "Hasta:";
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(580, 18);

            dtpHasta.Location = new Point(630, 15);
            dtpHasta.Size = new Size(150, 27);

            btnAplicar.Text = "Aplicar";
            btnAplicar.BackColor = Color.DodgerBlue;
            btnAplicar.ForeColor = Color.White;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.Location = new Point(800, 15);
            btnAplicar.Size = new Size(85, 30);
            btnAplicar.Click += btnAplicar_Click;

            btnReset.Text = "Resetear";
            btnReset.BackColor = Color.Gray;
            btnReset.ForeColor = Color.White;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Location = new Point(895, 15);
            btnReset.Size = new Size(85, 30);
            btnReset.Click += btnReset_Click;

            lblLeyenda.AutoSize = true;
            lblLeyenda.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblLeyenda.ForeColor = Color.DimGray;
            lblLeyenda.Location = new Point(1000, 22);
            lblLeyenda.Text = "Mostrando datos de los últimos 30 días.";

            pnlFiltros.Controls.Add(lblTipoReporte);
            pnlFiltros.Controls.Add(cbReporte);
            pnlFiltros.Controls.Add(lblDesde);
            pnlFiltros.Controls.Add(dtpDesde);
            pnlFiltros.Controls.Add(lblHasta);
            pnlFiltros.Controls.Add(dtpHasta);
            pnlFiltros.Controls.Add(btnAplicar);
            pnlFiltros.Controls.Add(btnReset);
            pnlFiltros.Controls.Add(lblLeyenda);

            // ========================= CHART =========================
            chartPrincipal.Dock = DockStyle.Fill;
            chartPrincipal.BackColor = Color.White;

            chartArea1.Name = "MainArea";
            chartArea1.AxisX.Interval = 1;
            chartArea1.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartPrincipal.ChartAreas.Add(chartArea1);

            legend1.Name = "Legend1"; // 👈 nombre fijo
            chartPrincipal.Legends.Add(legend1);

            series1.ChartArea = "MainArea";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartPrincipal.Series.Add(series1);

            // ========================= ENSAMBLADO =========================
            tableLayoutPanel1.Controls.Add(flowIndicadores, 0, 0); // 🔼 Tarjetas arriba
            tableLayoutPanel1.Controls.Add(pnlFiltros, 0, 1);      // 🔽 Filtros abajo
            tableLayoutPanel1.Controls.Add(chartPrincipal, 0, 2);

            Controls.Add(tableLayoutPanel1);
            BackColor = Color.WhiteSmoke;
            Name = "ReportesControl";
            Size = new Size(1600, 850);

            tableLayoutPanel1.ResumeLayout(false);
            flowIndicadores.ResumeLayout(false);
            pnlVentas.ResumeLayout(false);
            pnlVentas.PerformLayout();
            pnlVariacion.ResumeLayout(false);
            pnlVariacion.PerformLayout();
            pnlStock.ResumeLayout(false);
            pnlStock.PerformLayout();
            pnlClientes.ResumeLayout(false);
            pnlClientes.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(chartPrincipal)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowIndicadores;
        private Panel pnlVentas;
        private Label lblVentasTitulo;
        private Label lblVentasValor;
        private Panel pnlVariacion;
        private Label lblVariacionTitulo;
        private Label lblVariacionValor;
        private Panel pnlStock;
        private Label lblStockTitulo;
        private Label lblStockValor;
        private Panel pnlClientes;
        private Label lblClientesTitulo;
        private Label lblClientesValor;
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
    }
}
