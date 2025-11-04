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
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 40);
            this.lblTitulo.Text = "Panel de Reportes y Estadísticas";
            // 
            // pnlIndicadores
            // 
            this.pnlIndicadores.Controls.Add(this.cardVentas);
            this.pnlIndicadores.Controls.Add(this.cardVariacion);
            this.pnlIndicadores.Controls.Add(this.cardStock);
            this.pnlIndicadores.Controls.Add(this.cardClientes);
            this.pnlIndicadores.Location = new System.Drawing.Point(20, 60);
            this.pnlIndicadores.Name = "pnlIndicadores";
            this.pnlIndicadores.Size = new System.Drawing.Size(880, 90);
            // ===================== TARJETAS PARTE SUPERIOR=====================
            // cardVentas
            this.cardVentas.BackColor = System.Drawing.Color.FromArgb(235, 245, 235);
            this.cardVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardVentas.Controls.Add(this.lblVentasTitulo);
            this.cardVentas.Controls.Add(this.lblVentasValor);
            this.cardVentas.Location = new System.Drawing.Point(0, 5);
            this.cardVentas.Size = new System.Drawing.Size(200, 80);

            // lblVentasTitulo
            this.lblVentasTitulo.AutoSize = true;
            this.lblVentasTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVentasTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblVentasTitulo.Text = "Ventas mes";

            // lblVentasValor
            this.lblVentasValor.AutoSize = true;
            this.lblVentasValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVentasValor.Location = new System.Drawing.Point(10, 40);
            this.lblVentasValor.Text = "$0";

            // cardVariacion
            this.cardVariacion.BackColor = System.Drawing.Color.FromArgb(240, 240, 220);
            this.cardVariacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardVariacion.Controls.Add(this.lblVariacionTitulo);
            this.cardVariacion.Controls.Add(this.lblVariacionValor);
            this.cardVariacion.Location = new System.Drawing.Point(220, 5);
            this.cardVariacion.Size = new System.Drawing.Size(200, 80);

            // lblVariacionTitulo
            this.lblVariacionTitulo.AutoSize = true;
            this.lblVariacionTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVariacionTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblVariacionTitulo.Text = "Variación (vs mes anterior)";

            // lblVariacionValor
            this.lblVariacionValor.AutoSize = true;
            this.lblVariacionValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVariacionValor.Location = new System.Drawing.Point(10, 40);
            this.lblVariacionValor.Text = "0%";

            // cardStock
            this.cardStock.BackColor = System.Drawing.Color.FromArgb(245, 235, 230);
            this.cardStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardStock.Controls.Add(this.lblStockTitulo);
            this.cardStock.Controls.Add(this.lblStockValor);
            this.cardStock.Location = new System.Drawing.Point(440, 5);
            this.cardStock.Size = new System.Drawing.Size(200, 80);

            // lblStockTitulo
            this.lblStockTitulo.AutoSize = true;
            this.lblStockTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStockTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblStockTitulo.Text = "Artículos sin stock";

            // lblStockValor
            this.lblStockValor.AutoSize = true;
            this.lblStockValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStockValor.Location = new System.Drawing.Point(10, 40);
            this.lblStockValor.Text = "0";

            // cardClientes
            this.cardClientes.BackColor = System.Drawing.Color.FromArgb(230, 240, 250);
            this.cardClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardClientes.Controls.Add(this.lblClientesTitulo);
            this.cardClientes.Controls.Add(this.lblClientesValor);
            this.cardClientes.Location = new System.Drawing.Point(660, 5);
            this.cardClientes.Size = new System.Drawing.Size(200, 80);

            // lblClientesTitulo
            this.lblClientesTitulo.AutoSize = true;
            this.lblClientesTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClientesTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblClientesTitulo.Text = "Clientes activos";

            // lblClientesValor
            this.lblClientesValor.AutoSize = true;
            this.lblClientesValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblClientesValor.Location = new System.Drawing.Point(10, 40);
            this.lblClientesValor.Text = "0";

            // splitMain
            // 
            this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitMain.Location = new System.Drawing.Point(20, 160);
            this.splitMain.Name = "splitMain";
            this.splitMain.Panel1.Controls.Add(this.chartPrincipal);
            this.splitMain.Panel2.Controls.Add(this.pnlFiltros);
            this.splitMain.Size = new System.Drawing.Size(880, 460);
            this.splitMain.SplitterDistance = 630;
            // 
            // chartPrincipal
            // 
            this.chartPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPrincipal.Name = "chartPrincipal";
            this.chartPrincipal.Size = new System.Drawing.Size(630, 460);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltros.Controls.Add(this.lblPeriodo);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.lblTipoReporte);
            this.pnlFiltros.Controls.Add(this.cbReporte);
            this.pnlFiltros.Controls.Add(this.btnAplicar);
            this.pnlFiltros.Controls.Add(this.btnReset);
            this.pnlFiltros.Controls.Add(this.lblLeyenda);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(246, 460);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(15, 15);
            this.lblPeriodo.Text = "Periodo de tiempo:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(15, 35);
            this.dtpDesde.Size = new System.Drawing.Size(200, 23);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(15, 65);
            this.dtpHasta.Size = new System.Drawing.Size(200, 23);
            // 
            // lblTipoReporte
            // 
            this.lblTipoReporte.AutoSize = true;
            this.lblTipoReporte.Location = new System.Drawing.Point(15, 105);
            this.lblTipoReporte.Text = "Tipo de reporte:";
            // 
            // cbReporte
            // 
            this.cbReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReporte.Location = new System.Drawing.Point(15, 125);
            this.cbReporte.Size = new System.Drawing.Size(200, 23);
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.Location = new System.Drawing.Point(15, 230);
            this.btnAplicar.Size = new System.Drawing.Size(200, 30);
            this.btnAplicar.Text = "Aplicar filtro";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Gray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(15, 270);
            this.btnReset.Size = new System.Drawing.Size(200, 30);
            this.btnReset.Text = "Restablecer";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLeyenda.Location = new System.Drawing.Point(15, 320);
            this.lblLeyenda.Size = new System.Drawing.Size(200, 60);
            this.lblLeyenda.Text = "Mostrando datos de los últimos 30 días.";
            // 
            // ReportesControl
            // 
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
