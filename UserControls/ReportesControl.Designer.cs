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
            lblTitulo = new Label();
            pnlIndicadores = new Panel();
            cardVentas = new Panel();
            lblVentasTitulo = new Label();
            lblVentasValor = new Label();
            cardVariacion = new Panel();
            lblVariacionTitulo = new Label();
            lblVariacionValor = new Label();
            cardStock = new Panel();
            lblStockTitulo = new Label();
            lblStockValor = new Label();
            cardClientes = new Panel();
            lblClientesTitulo = new Label();
            lblClientesValor = new Label();
            pnlFiltros = new Panel();
            lblPeriodo = new Label();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            lblTipoReporte = new Label();
            cbReporte = new ComboBox();
            lblTipoGrafico = new Label();
            cbGrafico = new ComboBox();
            btnAplicar = new Button();
            btnReset = new Button();
            lblLeyenda = new Label();
            pnlIndicadores.SuspendLayout();
            cardVentas.SuspendLayout();
            cardVariacion.SuspendLayout();
            cardStock.SuspendLayout();
            cardClientes.SuspendLayout();
            pnlFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(500, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Panel de Reportes y Estadísticas";
            // 
            // pnlIndicadores
            // 
            pnlIndicadores.Controls.Add(cardVentas);
            pnlIndicadores.Controls.Add(cardVariacion);
            pnlIndicadores.Controls.Add(cardStock);
            pnlIndicadores.Controls.Add(cardClientes);
            pnlIndicadores.Location = new Point(20, 60);
            pnlIndicadores.Name = "pnlIndicadores";
            pnlIndicadores.Size = new Size(650, 90);
            pnlIndicadores.TabIndex = 1;
            // 
            // cardVentas
            // 
            cardVentas.BackColor = Color.FromArgb(235, 245, 235);
            cardVentas.BorderStyle = BorderStyle.FixedSingle;
            cardVentas.Controls.Add(lblVentasTitulo);
            cardVentas.Controls.Add(lblVentasValor);
            cardVentas.Location = new Point(0, 5);
            cardVentas.Name = "cardVentas";
            cardVentas.Size = new Size(150, 80);
            cardVentas.TabIndex = 0;
            // 
            // lblVentasTitulo
            // 
            lblVentasTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVentasTitulo.Location = new Point(10, 10);
            lblVentasTitulo.Name = "lblVentasTitulo";
            lblVentasTitulo.Size = new Size(100, 23);
            lblVentasTitulo.TabIndex = 0;
            lblVentasTitulo.Text = "Ventas mes";
            // 
            // lblVentasValor
            // 
            lblVentasValor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblVentasValor.Location = new Point(10, 35);
            lblVentasValor.Name = "lblVentasValor";
            lblVentasValor.Size = new Size(100, 23);
            lblVentasValor.TabIndex = 1;
            lblVentasValor.Text = "$0";
            // 
            // cardVariacion
            // 
            cardVariacion.BackColor = Color.FromArgb(240, 240, 220);
            cardVariacion.BorderStyle = BorderStyle.FixedSingle;
            cardVariacion.Controls.Add(lblVariacionTitulo);
            cardVariacion.Controls.Add(lblVariacionValor);
            cardVariacion.Location = new Point(160, 5);
            cardVariacion.Name = "cardVariacion";
            cardVariacion.Size = new Size(150, 80);
            cardVariacion.TabIndex = 1;
            // 
            // lblVariacionTitulo
            // 
            lblVariacionTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVariacionTitulo.Location = new Point(10, 10);
            lblVariacionTitulo.Name = "lblVariacionTitulo";
            lblVariacionTitulo.Size = new Size(100, 23);
            lblVariacionTitulo.TabIndex = 0;
            lblVariacionTitulo.Text = "Variación";
            // 
            // lblVariacionValor
            // 
            lblVariacionValor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblVariacionValor.Location = new Point(10, 35);
            lblVariacionValor.Name = "lblVariacionValor";
            lblVariacionValor.Size = new Size(100, 23);
            lblVariacionValor.TabIndex = 1;
            lblVariacionValor.Text = "0%";
            // 
            // cardStock
            // 
            cardStock.BackColor = Color.FromArgb(245, 235, 230);
            cardStock.BorderStyle = BorderStyle.FixedSingle;
            cardStock.Controls.Add(lblStockTitulo);
            cardStock.Controls.Add(lblStockValor);
            cardStock.Location = new Point(320, 5);
            cardStock.Name = "cardStock";
            cardStock.Size = new Size(150, 80);
            cardStock.TabIndex = 2;
            // 
            // lblStockTitulo
            // 
            lblStockTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStockTitulo.Location = new Point(10, 10);
            lblStockTitulo.Name = "lblStockTitulo";
            lblStockTitulo.Size = new Size(100, 23);
            lblStockTitulo.TabIndex = 0;
            lblStockTitulo.Text = "Sin stock";
            // 
            // lblStockValor
            // 
            lblStockValor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStockValor.Location = new Point(10, 35);
            lblStockValor.Name = "lblStockValor";
            lblStockValor.Size = new Size(100, 23);
            lblStockValor.TabIndex = 1;
            lblStockValor.Text = "0";
            // 
            // cardClientes
            // 
            cardClientes.BackColor = Color.FromArgb(230, 240, 250);
            cardClientes.BorderStyle = BorderStyle.FixedSingle;
            cardClientes.Controls.Add(lblClientesTitulo);
            cardClientes.Controls.Add(lblClientesValor);
            cardClientes.Location = new Point(480, 5);
            cardClientes.Name = "cardClientes";
            cardClientes.Size = new Size(150, 80);
            cardClientes.TabIndex = 3;
            // 
            // lblClientesTitulo
            // 
            lblClientesTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClientesTitulo.Location = new Point(10, 10);
            lblClientesTitulo.Name = "lblClientesTitulo";
            lblClientesTitulo.Size = new Size(100, 23);
            lblClientesTitulo.TabIndex = 0;
            lblClientesTitulo.Text = "Clientes activos";
            // 
            // lblClientesValor
            // 
            lblClientesValor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblClientesValor.Location = new Point(10, 35);
            lblClientesValor.Name = "lblClientesValor";
            lblClientesValor.Size = new Size(100, 23);
            lblClientesValor.TabIndex = 1;
            lblClientesValor.Text = "0";
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.FromArgb(245, 245, 245);
            pnlFiltros.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltros.Controls.Add(lblPeriodo);
            pnlFiltros.Controls.Add(dtpDesde);
            pnlFiltros.Controls.Add(dtpHasta);
            pnlFiltros.Controls.Add(lblTipoReporte);
            pnlFiltros.Controls.Add(cbReporte);
            pnlFiltros.Controls.Add(lblTipoGrafico);
            pnlFiltros.Controls.Add(cbGrafico);
            pnlFiltros.Controls.Add(btnAplicar);
            pnlFiltros.Controls.Add(btnReset);
            pnlFiltros.Controls.Add(lblLeyenda);
            pnlFiltros.Location = new Point(690, 170);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(210, 400);
            pnlFiltros.TabIndex = 2;
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.Location = new Point(15, 10);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(108, 15);
            lblPeriodo.TabIndex = 0;
            lblPeriodo.Text = "Periodo de tiempo:";
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(15, 30);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(180, 23);
            dtpDesde.TabIndex = 1;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(15, 60);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(180, 23);
            dtpHasta.TabIndex = 2;
            // 
            // lblTipoReporte
            // 
            lblTipoReporte.AutoSize = true;
            lblTipoReporte.Location = new Point(15, 100);
            lblTipoReporte.Name = "lblTipoReporte";
            lblTipoReporte.Size = new Size(90, 15);
            lblTipoReporte.TabIndex = 3;
            lblTipoReporte.Text = "Tipo de reporte:";
            // 
            // cbReporte
            // 
            cbReporte.Location = new Point(15, 120);
            cbReporte.Name = "cbReporte";
            cbReporte.Size = new Size(180, 23);
            cbReporte.TabIndex = 4;
            // 
            // lblTipoGrafico
            // 
            lblTipoGrafico.AutoSize = true;
            lblTipoGrafico.Location = new Point(15, 160);
            lblTipoGrafico.Name = "lblTipoGrafico";
            lblTipoGrafico.Size = new Size(89, 15);
            lblTipoGrafico.TabIndex = 5;
            lblTipoGrafico.Text = "Tipo de gráfico:";
            // 
            // cbGrafico
            // 
            cbGrafico.Location = new Point(15, 180);
            cbGrafico.Name = "cbGrafico";
            cbGrafico.Size = new Size(180, 23);
            cbGrafico.TabIndex = 6;
            // 
            // btnAplicar
            // 
            btnAplicar.BackColor = Color.SeaGreen;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.ForeColor = Color.White;
            btnAplicar.Location = new Point(15, 225);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(180, 30);
            btnAplicar.TabIndex = 7;
            btnAplicar.Text = "Aplicar filtro";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Gray;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(15, 265);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(180, 30);
            btnReset.TabIndex = 8;
            btnReset.Text = "Restablecer";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // lblLeyenda
            // 
            lblLeyenda.Font = new Font("Segoe UI", 8F);
            lblLeyenda.Location = new Point(15, 310);
            lblLeyenda.Name = "lblLeyenda";
            lblLeyenda.Size = new Size(180, 60);
            lblLeyenda.TabIndex = 9;
            lblLeyenda.Text = "Mostrando datos de los últimos 30 días.";
            lblLeyenda.Visible = false;
            // 
            // ReportesControl
            // 
            BackColor = Color.White;
            Controls.Add(lblTitulo);
            Controls.Add(pnlIndicadores);
            Controls.Add(pnlFiltros);
            Name = "ReportesControl";
            Size = new Size(920, 640);
            pnlIndicadores.ResumeLayout(false);
            cardVentas.ResumeLayout(false);
            cardVariacion.ResumeLayout(false);
            cardStock.ResumeLayout(false);
            cardClientes.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ResumeLayout(false);
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
