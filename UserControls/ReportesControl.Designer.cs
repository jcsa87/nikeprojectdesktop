namespace nikeproject.UserControls
{
    partial class ReportesControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código del Diseñador

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlIndicadores = new System.Windows.Forms.Panel();
            this.cardVentas = new System.Windows.Forms.Panel();
            this.lblVentasValor = new System.Windows.Forms.Label();
            this.lblVentasTitulo = new System.Windows.Forms.Label();
            this.cardVariacion = new System.Windows.Forms.Panel();
            this.lblVariacionValor = new System.Windows.Forms.Label();
            this.lblVariacionTitulo = new System.Windows.Forms.Label();
            this.cardStock = new System.Windows.Forms.Panel();
            this.lblStockValor = new System.Windows.Forms.Label();
            this.lblStockTitulo = new System.Windows.Forms.Label();
            this.cardClientes = new System.Windows.Forms.Panel();
            this.lblClientesValor = new System.Windows.Forms.Label();
            this.lblClientesTitulo = new System.Windows.Forms.Label();
            this.chartPrincipal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblTipoReporte = new System.Windows.Forms.Label();
            this.cbReporte = new System.Windows.Forms.ComboBox();
            this.lblTipoGrafico = new System.Windows.Forms.Label();
            this.cbGrafico = new System.Windows.Forms.ComboBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblLeyenda = new System.Windows.Forms.Label();

            this.pnlIndicadores.SuspendLayout();
            this.cardVentas.SuspendLayout();
            this.cardVariacion.SuspendLayout();
            this.cardStock.SuspendLayout();
            this.cardClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrincipal)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();

            // =================== TITULO ===================
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Size = new System.Drawing.Size(500, 40);
            this.lblTitulo.Text = "Panel de Reportes y Estadísticas";

            // =================== PANEL DE INDICADORES ===================
            this.pnlIndicadores.Location = new System.Drawing.Point(20, 60);
            this.pnlIndicadores.Size = new System.Drawing.Size(650, 90);
            this.pnlIndicadores.Controls.Add(this.cardVentas);
            this.pnlIndicadores.Controls.Add(this.cardVariacion);
            this.pnlIndicadores.Controls.Add(this.cardStock);
            this.pnlIndicadores.Controls.Add(this.cardClientes);

            // ======= CARD VENTAS =======
            this.cardVentas.BackColor = System.Drawing.Color.FromArgb(235, 245, 235);
            this.cardVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardVentas.Location = new System.Drawing.Point(0, 5);
            this.cardVentas.Size = new System.Drawing.Size(150, 80);
            this.lblVentasTitulo.Text = "Ventas mes";
            this.lblVentasTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVentasTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblVentasValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVentasValor.Location = new System.Drawing.Point(10, 35);
            this.lblVentasValor.Text = "$0";
            this.cardVentas.Controls.Add(this.lblVentasTitulo);
            this.cardVentas.Controls.Add(this.lblVentasValor);

            // ======= CARD VARIACIÓN =======
            this.cardVariacion.BackColor = System.Drawing.Color.FromArgb(240, 240, 220);
            this.cardVariacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardVariacion.Location = new System.Drawing.Point(160, 5);
            this.cardVariacion.Size = new System.Drawing.Size(150, 80);
            this.lblVariacionTitulo.Text = "Variación";
            this.lblVariacionTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVariacionTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblVariacionValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVariacionValor.Location = new System.Drawing.Point(10, 35);
            this.lblVariacionValor.Text = "0%";
            this.cardVariacion.Controls.Add(this.lblVariacionTitulo);
            this.cardVariacion.Controls.Add(this.lblVariacionValor);

            // ======= CARD STOCK =======
            this.cardStock.BackColor = System.Drawing.Color.FromArgb(245, 235, 230);
            this.cardStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardStock.Location = new System.Drawing.Point(320, 5);
            this.cardStock.Size = new System.Drawing.Size(150, 80);
            this.lblStockTitulo.Text = "Sin stock";
            this.lblStockTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStockTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblStockValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStockValor.Location = new System.Drawing.Point(10, 35);
            this.lblStockValor.Text = "0";
            this.cardStock.Controls.Add(this.lblStockTitulo);
            this.cardStock.Controls.Add(this.lblStockValor);

            // ======= CARD CLIENTES =======
            this.cardClientes.BackColor = System.Drawing.Color.FromArgb(230, 240, 250);
            this.cardClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardClientes.Location = new System.Drawing.Point(480, 5);
            this.cardClientes.Size = new System.Drawing.Size(150, 80);
            this.lblClientesTitulo.Text = "Clientes activos";
            this.lblClientesTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClientesTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblClientesValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblClientesValor.Location = new System.Drawing.Point(10, 35);
            this.lblClientesValor.Text = "0";
            this.cardClientes.Controls.Add(this.lblClientesTitulo);
            this.cardClientes.Controls.Add(this.lblClientesValor);

            // =================== GRÁFICO PRINCIPAL ===================
            this.chartPrincipal.Location = new System.Drawing.Point(20, 170);
            this.chartPrincipal.Size = new System.Drawing.Size(650, 400);
            this.chartPrincipal.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.chartPrincipal.BorderlineColor = System.Drawing.Color.LightGray;
            this.chartPrincipal.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;

            // =================== PANEL DE FILTROS ===================
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltros.Location = new System.Drawing.Point(690, 170);
            this.pnlFiltros.Size = new System.Drawing.Size(210, 400);
            this.pnlFiltros.Controls.Add(this.lblPeriodo);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.lblTipoReporte);
            this.pnlFiltros.Controls.Add(this.cbReporte);
            this.pnlFiltros.Controls.Add(this.lblTipoGrafico);
            this.pnlFiltros.Controls.Add(this.cbGrafico);
            this.pnlFiltros.Controls.Add(this.btnAplicar);
            this.pnlFiltros.Controls.Add(this.btnReset);
            this.pnlFiltros.Controls.Add(this.lblLeyenda);

            // ======= FILTROS =======
            this.lblPeriodo.Text = "Periodo de tiempo:";
            this.lblPeriodo.Location = new System.Drawing.Point(15, 10);
            this.lblPeriodo.AutoSize = true;

            this.dtpDesde.Location = new System.Drawing.Point(15, 30);
            this.dtpDesde.Size = new System.Drawing.Size(180, 23);

            this.dtpHasta.Location = new System.Drawing.Point(15, 60);
            this.dtpHasta.Size = new System.Drawing.Size(180, 23);

            this.lblTipoReporte.Text = "Tipo de reporte:";
            this.lblTipoReporte.Location = new System.Drawing.Point(15, 100);
            this.lblTipoReporte.AutoSize = true;

            this.cbReporte.Location = new System.Drawing.Point(15, 120);
            this.cbReporte.Size = new System.Drawing.Size(180, 23);

            this.lblTipoGrafico.Text = "Tipo de gráfico:";
            this.lblTipoGrafico.Location = new System.Drawing.Point(15, 160);
            this.lblTipoGrafico.AutoSize = true;

            this.cbGrafico.Location = new System.Drawing.Point(15, 180);
            this.cbGrafico.Size = new System.Drawing.Size(180, 23);

            this.btnAplicar.Text = "Aplicar filtro";
            this.btnAplicar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Location = new System.Drawing.Point(15, 225);
            this.btnAplicar.Size = new System.Drawing.Size(180, 30);
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);

            this.btnReset.Text = "Restablecer";
            this.btnReset.BackColor = System.Drawing.Color.Gray;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(15, 265);
            this.btnReset.Size = new System.Drawing.Size(180, 30);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            this.lblLeyenda.Location = new System.Drawing.Point(15, 310);
            this.lblLeyenda.Size = new System.Drawing.Size(180, 60);
            this.lblLeyenda.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLeyenda.Text = "Mostrando datos de los últimos 30 días.";

            // =================== CONTROL PRINCIPAL ===================
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlIndicadores);
            this.Controls.Add(this.chartPrincipal);
            this.Controls.Add(this.pnlFiltros);
            this.Size = new System.Drawing.Size(920, 640);

            // =================== FIN ===================
            this.pnlIndicadores.ResumeLayout(false);
            this.cardVentas.ResumeLayout(false);
            this.cardVariacion.ResumeLayout(false);
            this.cardStock.ResumeLayout(false);
            this.cardClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPrincipal)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlIndicadores;
        private System.Windows.Forms.Panel cardVentas;
        private System.Windows.Forms.Label lblVentasValor;
        private System.Windows.Forms.Label lblVentasTitulo;
        private System.Windows.Forms.Panel cardVariacion;
        private System.Windows.Forms.Label lblVariacionValor;
        private System.Windows.Forms.Label lblVariacionTitulo;
        private System.Windows.Forms.Panel cardStock;
        private System.Windows.Forms.Label lblStockValor;
        private System.Windows.Forms.Label lblStockTitulo;
        private System.Windows.Forms.Panel cardClientes;
        private System.Windows.Forms.Label lblClientesValor;
        private System.Windows.Forms.Label lblClientesTitulo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPrincipal;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblTipoReporte;
        private System.Windows.Forms.ComboBox cbReporte;
        private System.Windows.Forms.Label lblTipoGrafico;
        private System.Windows.Forms.ComboBox cbGrafico;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblLeyenda;
    }
}
