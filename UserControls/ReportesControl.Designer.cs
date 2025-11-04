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

        #region Código del Diseñador

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlIndicadores = new System.Windows.Forms.Panel();
            this.cardVentas = new System.Windows.Forms.Panel();
            this.lblVentasTitulo = new System.Windows.Forms.Label();
            this.lblVentasValor = new System.Windows.Forms.Label();
            this.cardVariacion = new System.Windows.Forms.Panel();
            this.lblVariacionTitulo = new System.Windows.Forms.Label();
            this.lblVariacionValor = new System.Windows.Forms.Label();
            this.cardStock = new System.Windows.Forms.Panel();
            this.lblStockTitulo = new System.Windows.Forms.Label();
            this.lblStockValor = new System.Windows.Forms.Label();
            this.cardClientes = new System.Windows.Forms.Panel();
            this.lblClientesTitulo = new System.Windows.Forms.Label();
            this.lblClientesValor = new System.Windows.Forms.Label();

            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.chartPrincipal = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblTipoReporte = new System.Windows.Forms.Label();
            this.cbReporte = new System.Windows.Forms.ComboBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblLeyenda = new System.Windows.Forms.Label();

            this.pnlIndicadores.SuspendLayout();
            this.cardVentas.SuspendLayout();
            this.cardVariacion.SuspendLayout();
            this.cardStock.SuspendLayout();
            this.cardClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrincipal)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(520, 40);
            this.lblTitulo.Text = "Panel de Reportes y Estadísticas";

            // pnlIndicadores
            this.pnlIndicadores.Location = new System.Drawing.Point(20, 60);
            this.pnlIndicadores.Name = "pnlIndicadores";
            this.pnlIndicadores.Size = new System.Drawing.Size(880, 90);
            this.pnlIndicadores.Controls.Add(this.cardVentas);
            this.pnlIndicadores.Controls.Add(this.cardVariacion);
            this.pnlIndicadores.Controls.Add(this.cardStock);
            this.pnlIndicadores.Controls.Add(this.cardClientes);

            // cardVentas
            this.cardVentas.BackColor = System.Drawing.Color.FromArgb(235, 245, 235);
            this.cardVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardVentas.Location = new System.Drawing.Point(0, 5);
            this.cardVentas.Size = new System.Drawing.Size(200, 80);
            this.cardVentas.Controls.Add(this.lblVentasTitulo);
            this.cardVentas.Controls.Add(this.lblVentasValor);
            this.lblVentasTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVentasTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblVentasTitulo.Size = new System.Drawing.Size(130, 20);
            this.lblVentasTitulo.Text = "Ventas mes";
            this.lblVentasValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVentasValor.Location = new System.Drawing.Point(10, 35);
            this.lblVentasValor.Size = new System.Drawing.Size(170, 26);
            this.lblVentasValor.Text = "$0";

            // cardVariacion
            this.cardVariacion.BackColor = System.Drawing.Color.FromArgb(240, 240, 220);
            this.cardVariacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardVariacion.Location = new System.Drawing.Point(220, 5);
            this.cardVariacion.Size = new System.Drawing.Size(200, 80);
            this.cardVariacion.Controls.Add(this.lblVariacionTitulo);
            this.cardVariacion.Controls.Add(this.lblVariacionValor);
            this.lblVariacionTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVariacionTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblVariacionTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblVariacionTitulo.Text = "Variación";
            this.lblVariacionValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVariacionValor.Location = new System.Drawing.Point(10, 35);
            this.lblVariacionValor.Size = new System.Drawing.Size(150, 26);
            this.lblVariacionValor.Text = "0%";

            // cardStock
            this.cardStock.BackColor = System.Drawing.Color.FromArgb(245, 235, 230);
            this.cardStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardStock.Location = new System.Drawing.Point(440, 5);
            this.cardStock.Size = new System.Drawing.Size(200, 80);
            this.cardStock.Controls.Add(this.lblStockTitulo);
            this.cardStock.Controls.Add(this.lblStockValor);
            this.lblStockTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStockTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblStockTitulo.Size = new System.Drawing.Size(130, 20);
            this.lblStockTitulo.Text = "Artículos sin stock";
            this.lblStockValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStockValor.Location = new System.Drawing.Point(10, 35);
            this.lblStockValor.Size = new System.Drawing.Size(120, 26);
            this.lblStockValor.Text = "0";

            // cardClientes
            this.cardClientes.BackColor = System.Drawing.Color.FromArgb(230, 240, 250);
            this.cardClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardClientes.Location = new System.Drawing.Point(660, 5);
            this.cardClientes.Size = new System.Drawing.Size(200, 80);
            this.cardClientes.Controls.Add(this.lblClientesTitulo);
            this.cardClientes.Controls.Add(this.lblClientesValor);
            this.lblClientesTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClientesTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblClientesTitulo.Size = new System.Drawing.Size(130, 20);
            this.lblClientesTitulo.Text = "Clientes activos";
            this.lblClientesValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblClientesValor.Location = new System.Drawing.Point(10, 35);
            this.lblClientesValor.Size = new System.Drawing.Size(120, 26);
            this.lblClientesValor.Text = "0";

            // splitMain
            this.splitMain.Location = new System.Drawing.Point(20, 160);
            this.splitMain.Name = "splitMain";
            this.splitMain.Size = new System.Drawing.Size(880, 460);
            this.splitMain.SplitterWidth = 6;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitMain.Panel1MinSize = 300;
            this.splitMain.Panel2MinSize = 240;
            this.splitMain.SplitterDistance = 600;
            this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

            // chartPrincipal
            this.chartPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPrincipal.Name = "chartPrincipal";
            this.chartPrincipal.TabIndex = 3;
            this.chartPrincipal.Text = "chartPrincipal";
            this.splitMain.Panel1.Controls.Add(this.chartPrincipal);

            // pnlFiltros
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(12);
            this.splitMain.Panel2.Controls.Add(this.pnlFiltros);

            // lblPeriodo
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(15, 15);
            this.lblPeriodo.Text = "Periodo de tiempo:";
            this.dtpDesde.Location = new System.Drawing.Point(15, 35);
            this.dtpDesde.Size = new System.Drawing.Size(200, 23);
            this.dtpHasta.Location = new System.Drawing.Point(15, 65);
            this.dtpHasta.Size = new System.Drawing.Size(200, 23);

            // lblTipoReporte y combo
            this.lblTipoReporte.AutoSize = true;
            this.lblTipoReporte.Location = new System.Drawing.Point(15, 105);
            this.lblTipoReporte.Text = "Tipo de reporte:";
            this.cbReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReporte.Location = new System.Drawing.Point(15, 125);
            this.cbReporte.Size = new System.Drawing.Size(200, 23);

            // Botones
            this.btnAplicar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.Location = new System.Drawing.Point(15, 170);
            this.btnAplicar.Size = new System.Drawing.Size(200, 30);
            this.btnAplicar.Text = "Aplicar filtro";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);

            this.btnReset.BackColor = System.Drawing.Color.Gray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(15, 210);
            this.btnReset.Size = new System.Drawing.Size(200, 30);
            this.btnReset.Text = "Restablecer";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // Leyenda
            this.lblLeyenda.Location = new System.Drawing.Point(15, 260);
            this.lblLeyenda.Size = new System.Drawing.Size(200, 60);
            this.lblLeyenda.Text = "Mostrando datos de los últimos 30 días.";
            this.lblLeyenda.Font = new System.Drawing.Font("Segoe UI", 8F);

            this.pnlFiltros.Controls.Add(this.lblPeriodo);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.lblTipoReporte);
            this.pnlFiltros.Controls.Add(this.cbReporte);
            this.pnlFiltros.Controls.Add(this.btnAplicar);
            this.pnlFiltros.Controls.Add(this.btnReset);
            this.pnlFiltros.Controls.Add(this.lblLeyenda);

            // ReportesControl
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlIndicadores);
            this.Controls.Add(this.lblTitulo);
            this.Name = "ReportesControl";
            this.Size = new System.Drawing.Size(920, 640);

            this.pnlIndicadores.ResumeLayout(false);
            this.cardVentas.ResumeLayout(false);
            this.cardVariacion.ResumeLayout(false);
            this.cardStock.ResumeLayout(false);
            this.cardClientes.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPrincipal)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlIndicadores;
        private System.Windows.Forms.Panel cardVentas;
        private System.Windows.Forms.Label lblVentasTitulo;
        private System.Windows.Forms.Label lblVentasValor;
        private System.Windows.Forms.Panel cardVariacion;
        private System.Windows.Forms.Label lblVariacionTitulo;
        private System.Windows.Forms.Label lblVariacionValor;
        private System.Windows.Forms.Panel cardStock;
        private System.Windows.Forms.Label lblStockTitulo;
        private System.Windows.Forms.Label lblStockValor;
        private System.Windows.Forms.Panel cardClientes;
        private System.Windows.Forms.Label lblClientesTitulo;
        private System.Windows.Forms.Label lblClientesValor;

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPrincipal;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblTipoReporte;
        private System.Windows.Forms.ComboBox cbReporte;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblLeyenda;
    }
}
