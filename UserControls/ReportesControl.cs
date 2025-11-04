using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace nikeproject.UserControls
{
    public partial class ReportesControl : UserControl
    {
        private readonly string connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["cadena_conexion"].ToString();

        public ReportesControl()
        {
            InitializeComponent();
            ConfigurarChart();
            CargarIndicadores();
            InicializarFiltros();
            GenerarReportePorDefecto();
        }

        // ========================= CONFIGURACIÓN INICIAL =========================
        private void ConfigurarChart()
        {
            if (chartPrincipal == null)
                return;

            chartPrincipal.ChartAreas.Add(new ChartArea("MainArea"));
            chartPrincipal.Titles.Add("Gráfico de Reportes");
            chartPrincipal.Titles[0].Font = new Font("Segoe UI", 11, FontStyle.Bold);
            chartPrincipal.ChartAreas[0].AxisX.Interval = 1;
            chartPrincipal.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartPrincipal.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        private void InicializarFiltros()
        {
            cbReporte.Items.AddRange(new string[]
            {
                "Ventas por mes",
                "Top 5 productos más vendidos",
                "Ingresos diarios"
            });
            cbReporte.SelectedIndex = 0;

            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddDays(-30);

            cbReporte.SelectedIndexChanged += cbTipoReporte_SelectedIndexChanged;
        }

        // ========================= EVENTOS =========================
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1); // ✅ Incluye todo el último día seleccionado

            string tipo = cbReporte.SelectedItem.ToString();
            CargarDatosEnChart(desde, hasta, tipo);
            lblLeyenda.Text = $"Mostrando datos de {dtpDesde.Value:dd/MM/yyyy} a {dtpHasta.Value:dd/MM/yyyy}.";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            cbReporte.SelectedIndex = 0;
            GenerarReportePorDefecto();
            lblLeyenda.Text = "Mostrando datos de los últimos 30 días.";
        }

        // ========================= INDICADORES SUPERIORES =========================
        private void CargarIndicadores()
        {
            decimal ventasActual = ObtenerDecimal(@"
                SELECT ISNULL(SUM(MontoTotal),0)
                FROM VENTA
                WHERE MONTH(FechaRegistro) = MONTH(GETDATE())
                AND YEAR(FechaRegistro) = YEAR(GETDATE())");

            decimal ventasAnterior = ObtenerDecimal(@"
                SELECT ISNULL(SUM(MontoTotal),0)
                FROM VENTA
                WHERE MONTH(FechaRegistro) = MONTH(DATEADD(MONTH,-1,GETDATE()))
                AND YEAR(FechaRegistro) = YEAR(DATEADD(MONTH,-1,GETDATE()))");

            int productosSinStock = ObtenerEntero("SELECT COUNT(*) FROM PRODUCTO WHERE Stock = 0");
            int clientesActivos = ObtenerEntero("SELECT COUNT(*) FROM CLIENTE WHERE Estado = 1");

            // Cálculo de variación mensual
            decimal variacion = 0;
            if (ventasAnterior > 0)
                variacion = ((ventasActual - ventasAnterior) / ventasAnterior) * 100;

            // Asignación de textos
            lblVentasTitulo.Text = $"Ventas mes ({DateTime.Now:MMMM})";
            lblVentasValor.Text = $"${ventasActual:N0}";
            lblVariacionTitulo.Text = "Variación (vs mes anterior)";
            lblVariacionValor.Text = $"{variacion:N1}%";
            lblStockTitulo.Text = "Artículos sin stock";
            lblStockValor.Text = productosSinStock.ToString();
            lblClientesValor.Text = clientesActivos.ToString();

            // Color visual según tendencia
            lblVariacionValor.ForeColor = variacion >= 0 ? Color.ForestGreen : Color.Firebrick;
        }

        // ========================= REPORTES =========================
        private void GenerarReportePorDefecto()
        {
            DateTime desde = DateTime.Now.AddDays(-30);
            DateTime hasta = DateTime.Now.AddDays(1); // ✅ incluir día actual completo
            string tipo = "Ventas por mes";

            CargarDatosEnChart(desde, hasta, tipo);
            lblLeyenda.Text = "Mostrando datos de los últimos 30 días.";
        }

        private void cbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAplicar_Click(sender, e);
        }

        private void CargarDatosEnChart(DateTime desde, DateTime hasta, string tipo)
        {
            chartPrincipal.Series.Clear();

            Series serie = new Series("Datos");
            chartPrincipal.Series.Add(serie);
            serie.BorderWidth = 3;

            // Tipo de gráfico según reporte
            switch (tipo)
            {
                case "Ventas por mes":
                    serie.ChartType = SeriesChartType.Line;
                    serie.Color = Color.MediumSeaGreen;
                    break;

                case "Top 5 productos más vendidos":
                    serie.ChartType = SeriesChartType.Pie;
                    serie.Color = Color.SteelBlue;
                    serie["PieStartAngle"] = "270";
                    serie.IsValueShownAsLabel = true;
                    serie.Label = "#PERCENT{P0}";
                    serie.LegendText = "#VALX – #PERCENT{P0}";
                    chartPrincipal.Legends.Clear();
                    chartPrincipal.Legends.Add(new Legend("Leyenda") { Docking = Docking.Bottom });
                    break;

                case "Ingresos diarios":
                    serie.ChartType = SeriesChartType.Column;
                    serie.Color = Color.SteelBlue;
                    break;
            }

            // Query SQL según tipo
            string query = tipo switch
            {
                "Ventas por mes" => @"
                    SELECT FORMAT(FechaRegistro, 'yyyy-MM') AS Periodo,
                           SUM(MontoTotal) AS Total
                    FROM VENTA
                    WHERE FechaRegistro BETWEEN @Desde AND @Hasta
                    GROUP BY FORMAT(FechaRegistro, 'yyyy-MM')
                    ORDER BY FORMAT(FechaRegistro, 'yyyy-MM');",

                "Top 5 productos más vendidos" => @"
                    SELECT TOP 5 p.Nombre AS Nombre, SUM(dv.Cantidad) AS TotalVendidos
                    FROM DETALLE_VENTA dv
                    INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
                    INNER JOIN VENTA v ON v.IdVenta = dv.IdVenta
                    WHERE v.FechaRegistro BETWEEN @Desde AND @Hasta
                    GROUP BY p.Nombre
                    ORDER BY TotalVendidos DESC;",

                "Ingresos diarios" => @"
                    SELECT CAST(FechaRegistro AS DATE) AS Dia, SUM(MontoTotal) AS Ingreso
                    FROM VENTA
                    WHERE FechaRegistro BETWEEN @Desde AND @Hasta
                    GROUP BY CAST(FechaRegistro AS DATE)
                    ORDER BY Dia;",
                _ => ""
            };

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Desde", desde);
                cmd.Parameters.AddWithValue("@Hasta", hasta); // ✅ hasta +1 día ya aplicado antes
                using SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (tipo == "Ventas por mes")
                    {
                        string periodo = dr["Periodo"].ToString();
                        decimal total = Convert.ToDecimal(dr["Total"]);
                        serie.Points.AddXY(periodo, total);
                    }
                    else if (tipo == "Top 5 productos más vendidos")
                    {
                        string nombre = dr["Nombre"].ToString();
                        int vendidos = Convert.ToInt32(dr["TotalVendidos"]);
                        serie.Points.AddXY(nombre, vendidos);
                    }
                    else if (tipo == "Ingresos diarios")
                    {
                        DateTime dia = Convert.ToDateTime(dr["Dia"]);
                        decimal ingreso = Convert.ToDecimal(dr["Ingreso"]);
                        serie.Points.AddXY(dia.ToString("dd/MM"), ingreso);
                    }
                }
            }

            ActualizarTituloGrafico(desde, hasta.AddDays(-1)); // mostrar rango real
            chartPrincipal.Invalidate();
        }

        private void ActualizarTituloGrafico(DateTime desde, DateTime hasta)
        {
            string titulo = "Gráfico de Reportes";
            string periodo = (desde.Date == DateTime.Now.AddDays(-30).Date && hasta.Date == DateTime.Now.Date)
                ? "(últimos 30 días)"
                : $"({desde:dd/MM/yyyy} - {hasta:dd/MM/yyyy})";

            if (chartPrincipal.Titles.Count > 0)
                chartPrincipal.Titles[0].Text = $"{titulo} {periodo}";
        }

        // ========================= FUNCIONES AUXILIARES =========================
        private decimal ObtenerDecimal(string sql)
        {
            using SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            using SqlCommand cmd = new SqlCommand(sql, cn);
            object result = cmd.ExecuteScalar();
            return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
        }

        private int ObtenerEntero(string sql)
        {
            using SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            using SqlCommand cmd = new SqlCommand(sql, cn);
            object result = cmd.ExecuteScalar();
            return result == DBNull.Value ? 0 : Convert.ToInt32(result);
        }

        private void ReportesControl_Load(object sender, EventArgs e)
        {

        }
    }
}
