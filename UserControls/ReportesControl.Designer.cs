namespace nikeproject.UserControls
{
    partial class ReportesControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
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
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartProductos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartIngresos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresos)).BeginInit();
            this.pnlIndicadores.SuspendLayout();
            this.cardVentas.SuspendLayout();
            this.cardVariacion.SuspendLayout();
            this.cardStock.SuspendLayout();
            this.cardClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Size = new System.Drawing.Size(400, 40);
            this.lblTitulo.Text = "Panel de Reportes y Estadísticas";
            // 
            // pnlIndicadores
            // 
            this.pnlIndicadores.Location = new System.Drawing.Point(20, 60);
            this.pnlIndicadores.Size = new System.Drawing.Size(880, 90);
            this.pnlIndicadores.Controls.Add(this.cardVentas);
            this.pnlIndicadores.Controls.Add(this.cardVariacion);
            this.pnlIndicadores.Controls.Add(this.cardStock);
            this.pnlIndicadores.Controls.Add(this.cardClientes);
            // 
            // Cards
            // 
            int cardWidth = 200, cardHeight = 80, spacing = 10;
            // --- Ventas
            this.cardVentas.BackColor = System.Drawing.Color.FromArgb(223, 240, 216);
            this.cardVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardVentas.Location = new System.Drawing.Point(0, 5);
            this.cardVentas.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.lblVentasTitulo.Text = "Ventas del mes";
            this.lblVentasTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVentasTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblVentasValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVentasValor.Location = new System.Drawing.Point(10, 35);
            this.lblVentasValor.Text = "$0";
            this.cardVentas.Controls.Add(this.lblVentasTitulo);
            this.cardVentas.Controls.Add(this.lblVentasValor);
            // --- Variación
            this.cardVariacion.BackColor = System.Drawing.Color.FromArgb(240, 240, 216);
            this.cardVariacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardVariacion.Location = new System.Drawing.Point(cardWidth + spacing, 5);
            this.cardVariacion.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.lblVariacionTitulo.Text = "Variación mensual";
            this.lblVariacionTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVariacionTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblVariacionValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVariacionValor.Location = new System.Drawing.Point(10, 35);
            this.lblVariacionValor.Text = "0%";
            this.cardVariacion.Controls.Add(this.lblVariacionTitulo);
            this.cardVariacion.Controls.Add(this.lblVariacionValor);
            // --- Stock
            this.cardStock.BackColor = System.Drawing.Color.FromArgb(252, 228, 214);
            this.cardStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardStock.Location = new System.Drawing.Point(2 * (cardWidth + spacing), 5);
            this.cardStock.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.lblStockTitulo.Text = "Productos sin stock";
            this.lblStockTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStockTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblStockValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStockValor.Location = new System.Drawing.Point(10, 35);
            this.lblStockValor.Text = "0";
            this.cardStock.Controls.Add(this.lblStockTitulo);
            this.cardStock.Controls.Add(this.lblStockValor);
            // --- Clientes
            this.cardClientes.BackColor = System.Drawing.Color.FromArgb(214, 234, 248);
            this.cardClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardClientes.Location = new System.Drawing.Point(3 * (cardWidth + spacing), 5);
            this.cardClientes.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.lblClientesTitulo.Text = "Clientes activos";
            this.lblClientesTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClientesTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblClientesValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblClientesValor.Location = new System.Drawing.Point(10, 35);
            this.lblClientesValor.Text = "0";
            this.cardClientes.Controls.Add(this.lblClientesTitulo);
            this.cardClientes.Controls.Add(this.lblClientesValor);
            // 
            // chartVentas
            // 
            this.chartVentas.Location = new System.Drawing.Point(20, 160);
            this.chartVentas.Size = new System.Drawing.Size(880, 200);
            // 
            // chartProductos
            // 
            this.chartProductos.Location = new System.Drawing.Point(20, 380);
            this.chartProductos.Size = new System.Drawing.Size(400, 220);
            // 
            // chartIngresos
            // 
            this.chartIngresos.Location = new System.Drawing.Point(500, 380);
            this.chartIngresos.Size = new System.Drawing.Size(400, 220);
            // 
            // ReportesControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlIndicadores);
            this.Controls.Add(this.chartVentas);
            this.Controls.Add(this.chartProductos);
            this.Controls.Add(this.chartIngresos);
            this.Size = new System.Drawing.Size(920, 640);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresos)).EndInit();
            this.pnlIndicadores.ResumeLayout(false);
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProductos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIngresos;
    }
}
