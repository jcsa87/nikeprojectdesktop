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

            cbGrafico.Items.AddRange(new string[]
            {
                "Línea",
                "Barras",
                "Torta"
            });
            cbGrafico.SelectedIndex = 0;

            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddDays(-30);
        }

        // ========================= EVENTOS =========================
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;
            string tipo = cbReporte.SelectedItem.ToString();
            string grafico = cbGrafico.SelectedItem.ToString();

            CargarDatosEnChart(desde, hasta, tipo, grafico);
            lblLeyenda.Text = $"Mostrando datos de {desde:dd/MM/yyyy} a {hasta:dd/MM/yyyy}.";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            cbReporte.SelectedIndex = 0;
            cbGrafico.SelectedIndex = 0;

            GenerarReportePorDefecto();
            lblLeyenda.Text = "Mostrando datos de los últimos 30 días.";
        }

        // ========================= INDICADORES SUPERIORES =========================
        private void CargarIndicadores()
        {
            decimal ventasActual = ObtenerDecimal("SELECT ISNULL(SUM(MontoTotal),0) FROM VENTA WHERE MONTH(FechaRegistro)=MONTH(GETDATE()) AND YEAR(FechaRegistro)=YEAR(GETDATE())");
            decimal ventasAnterior = ObtenerDecimal("SELECT ISNULL(SUM(MontoTotal),0) FROM VENTA WHERE MONTH(FechaRegistro)=MONTH(DATEADD(MONTH,-1,GETDATE())) AND YEAR(FechaRegistro)=YEAR(DATEADD(MONTH,-1,GETDATE()))");
            int productosSinStock = ObtenerEntero("SELECT COUNT(*) FROM PRODUCTO WHERE Stock = 0");
            int clientesActivos = ObtenerEntero("SELECT COUNT(*) FROM CLIENTE WHERE Estado = 1");

            // Variación mensual
            decimal variacion = 0;
            if (ventasAnterior > 0)
                variacion = ((ventasActual - ventasAnterior) / ventasAnterior) * 100;

            // Mostrar valores
            lblVentasValor.Text = $"${ventasActual:N0}";
            lblVariacionValor.Text = $"{variacion:N1}%";
            lblStockValor.Text = productosSinStock.ToString();
            lblClientesValor.Text = clientesActivos.ToString();

            // Color de variación
            lblVariacionValor.ForeColor = variacion >= 0 ? Color.ForestGreen : Color.Firebrick;
        }

        // ========================= REPORTES =========================
        private void GenerarReportePorDefecto()
        {
            DateTime desde = DateTime.Now.AddDays(-30);
            DateTime hasta = DateTime.Now;
            string tipo = "Ventas por mes";
            string grafico = "Línea";

            CargarDatosEnChart(desde, hasta, tipo, grafico);
            lblLeyenda.Text = "Mostrando datos de los últimos 30 días.";
        }

        private void CargarDatosEnChart(DateTime desde, DateTime hasta, string tipo, string tipoGrafico)
        {
            chartPrincipal.Series.Clear();

            Series serie = new Series("Datos");
            chartPrincipal.Series.Add(serie);
            serie.BorderWidth = 3;

            // Tipo de gráfico
            switch (tipoGrafico)
            {
                case "Línea":
                    serie.ChartType = SeriesChartType.Line;
                    serie.Color = Color.MediumSeaGreen;
                    break;
                case "Barras":
                    serie.ChartType = SeriesChartType.Column;
                    serie.Color = Color.SteelBlue;
                    break;
                case "Torta":
                    serie.ChartType = SeriesChartType.Pie;
                    serie.Color = Color.SteelBlue;
                    serie["PieStartAngle"] = "270";
                    serie.IsValueShownAsLabel = true; // Mostrar porcentajes dentro
                    serie.Label = "#PERCENT{P0}";
                    serie.LegendText = "#VALX – #PERCENT{P0}";
                    chartPrincipal.Legends.Clear();
                    chartPrincipal.Legends.Add(new Legend("Leyenda"));
                    chartPrincipal.Legends["Leyenda"].Docking = Docking.Bottom;
                    break;
            }

            string query = "";
            if (tipo == "Ventas por mes")
            {
                query = @"
                SELECT FORMAT(FechaRegistro, 'yyyy-MM') AS Periodo,
               SUM(MontoTotal) AS Total
                FROM VENTA
                WHERE FechaRegistro BETWEEN @Desde AND @Hasta
                GROUP BY FORMAT(FechaRegistro, 'yyyy-MM')
                ORDER BY FORMAT(FechaRegistro, 'yyyy-MM');";
            }

            else if (tipo == "Top 5 productos más vendidos")
            {
                query = @"
            SELECT TOP 5 p.Nombre AS Nombre, SUM(dv.Cantidad) AS TotalVendidos
            FROM DETALLE_VENTA dv
            INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
            INNER JOIN VENTA v ON v.IdVenta = dv.IdVenta
            WHERE v.FechaRegistro BETWEEN @Desde AND @Hasta
            GROUP BY p.Nombre
            ORDER BY TotalVendidos DESC;";
            }
            else if (tipo == "Ingresos diarios")
            {
                query = @"
            SELECT CAST(FechaRegistro AS DATE) AS Dia, SUM(MontoTotal) AS Ingreso
            FROM VENTA
            WHERE FechaRegistro BETWEEN @Desde AND @Hasta
            GROUP BY CAST(FechaRegistro AS DATE)
            ORDER BY Dia;";
            }

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Desde", desde);
                cmd.Parameters.AddWithValue("@Hasta", hasta);
                SqlDataReader dr = cmd.ExecuteReader();

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

            // 🔹 Actualiza título con el período
            ActualizarTituloGrafico(desde, hasta);
            chartPrincipal.Invalidate();
        }

        private void ActualizarTituloGrafico(DateTime desde, DateTime hasta)
        {
            string titulo = "Gráfico de Reportes";
            string periodo = "";

            if (desde.Date == DateTime.Now.AddDays(-30).Date && hasta.Date == DateTime.Now.Date)
                periodo = "(últimos 30 días)";
            else
                periodo = $"({desde:dd/MM/yyyy} - {hasta:dd/MM/yyyy})";

            if (chartPrincipal.Titles.Count > 0)
                chartPrincipal.Titles[0].Text = $"{titulo} {periodo}";
        }


        // ========================= FUNCIONES AUXILIARES =========================
        private decimal ObtenerDecimal(string sql)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                object result = cmd.ExecuteScalar();
                return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
            }
        }

        private int ObtenerEntero(string sql)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                object result = cmd.ExecuteScalar();
                return result == DBNull.Value ? 0 : Convert.ToInt32(result);
            }
        }
    }
}
