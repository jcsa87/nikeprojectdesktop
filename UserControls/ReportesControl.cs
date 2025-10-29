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
            ConfigurarGraficos();
            CargarDashboard();
        }

        // ===================== CONFIGURACIÓN INICIAL =====================

        private void ConfigurarGraficos()
        {
            // ====== Ventas en el tiempo ======
            chartVentas.ChartAreas.Add(new ChartArea("AreaVentas"));
            chartVentas.Titles.Add("Ventas Mensuales");
            chartVentas.Series.Add("Ventas");
            chartVentas.Series["Ventas"].ChartType = SeriesChartType.Line;
            chartVentas.Series["Ventas"].BorderWidth = 3;
            chartVentas.Series["Ventas"].Color = Color.MediumSeaGreen;
            chartVentas.ChartAreas["AreaVentas"].AxisX.Interval = 1;
            chartVentas.ChartAreas["AreaVentas"].AxisX.Title = "Mes";
            chartVentas.ChartAreas["AreaVentas"].AxisY.Title = "Monto Total ($)";

            // ====== Productos más vendidos ======
            chartProductos.ChartAreas.Add(new ChartArea("AreaProductos"));
            chartProductos.Titles.Add("Top 5 Productos Más Vendidos");
            chartProductos.Series.Add("Productos");
            chartProductos.Series["Productos"].ChartType = SeriesChartType.Pie;
            chartProductos.Series["Productos"]["PieLabelStyle"] = "Disabled"; // sin texto dentro
            chartProductos.Legends.Add(new Legend("Leyenda"));
            chartProductos.Legends["Leyenda"].Docking = Docking.Bottom;
            chartProductos.Legends["Leyenda"].Alignment = StringAlignment.Center;
            chartProductos.Series["Productos"].IsValueShownAsLabel = true;
            chartProductos.Series["Productos"].Label = "#PERCENT{P0}";
            chartProductos.Series["Productos"].LegendText = "#VALX – #PERCENT{P0}";
            chartProductos.Series["Productos"]["PieStartAngle"] = "270";

            // ====== Ingresos diarios ======
            chartIngresos.ChartAreas.Add(new ChartArea("AreaIngresos"));
            chartIngresos.Titles.Add("Ingresos Diarios (últimos 30 días)");
            chartIngresos.Series.Add("Ingresos");
            chartIngresos.Series["Ingresos"].ChartType = SeriesChartType.Column;
            chartIngresos.Series["Ingresos"].Color = Color.SteelBlue;
            chartIngresos.Series["Ingresos"].BorderWidth = 2;
            chartIngresos.ChartAreas["AreaIngresos"].AxisX.Interval = 1;
            chartIngresos.ChartAreas["AreaIngresos"].AxisX.Title = "Día";
            chartIngresos.ChartAreas["AreaIngresos"].AxisY.Title = "Ingresos ($)";
        }

        // ===================== CARGA PRINCIPAL =====================

        private void CargarDashboard()
        {
            DateTime desde = DateTime.Now.AddDays(-30);
            DateTime hasta = DateTime.Now;

            CargarIndicadores();
            CargarGraficoVentas();
            CargarGraficoProductos(desde, hasta);
            CargarGraficoIngresos(desde, hasta);
        }

        // ===================== INDICADORES SUPERIORES =====================

        private void CargarIndicadores()
        {
            decimal ventasActual = ObtenerDecimal("SELECT ISNULL(SUM(MontoTotal),0) FROM VENTA WHERE MONTH(FechaRegistro)=MONTH(GETDATE()) AND YEAR(FechaRegistro)=YEAR(GETDATE())");
            decimal ventasAnterior = ObtenerDecimal("SELECT ISNULL(SUM(MontoTotal),0) FROM VENTA WHERE MONTH(FechaRegistro)=MONTH(DATEADD(MONTH,-1,GETDATE())) AND YEAR(FechaRegistro)=YEAR(DATEADD(MONTH,-1,GETDATE()))");
            int productosSinStock = ObtenerEntero("SELECT COUNT(*) FROM PRODUCTO WHERE Stock = 0");
            int clientesActivos = ObtenerEntero("SELECT COUNT(*) FROM CLIENTE WHERE Estado = 1");

            // Calcular variación porcentual
            decimal variacion = 0;
            if (ventasAnterior > 0)
                variacion = ((ventasActual - ventasAnterior) / ventasAnterior) * 100;

            // Mostrar resultados
            lblVentasValor.Text = $"${ventasActual:N2}";
            lblVariacionValor.Text = $"{variacion:N1}%";
            lblStockValor.Text = productosSinStock.ToString();
            lblClientesValor.Text = clientesActivos.ToString();

            // Colores condicionales
            lblVariacionValor.ForeColor = variacion >= 0 ? Color.ForestGreen : Color.Firebrick;
            cardVariacion.BackColor = variacion >= 0
                ? Color.FromArgb(223, 240, 216)
                : Color.FromArgb(252, 228, 214);
        }

        // ===================== GRÁFICOS =====================

        private void CargarGraficoVentas()
        {
            chartVentas.Series["Ventas"].Points.Clear();

            string query = @"
                SELECT DATENAME(MONTH, FechaRegistro) AS Mes,
                       SUM(MontoTotal) AS Total
                FROM VENTA
                WHERE FechaRegistro >= DATEADD(MONTH,-6,GETDATE())
                GROUP BY DATENAME(MONTH, FechaRegistro), MONTH(FechaRegistro)
                ORDER BY MONTH(FechaRegistro);";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string mes = dr["Mes"].ToString();
                    decimal total = Convert.ToDecimal(dr["Total"]);
                    chartVentas.Series["Ventas"].Points.AddXY(mes, total);
                }
            }
        }

        private void CargarGraficoProductos(DateTime desde, DateTime hasta)
        {
            chartProductos.Series["Productos"].Points.Clear();

            string query = @"
                SELECT TOP 5 p.Nombre, SUM(dv.Cantidad) AS TotalVendidos
                FROM DETALLE_VENTA dv
                INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
                INNER JOIN VENTA v ON v.IdVenta = dv.IdVenta
                WHERE v.FechaRegistro BETWEEN @Desde AND @Hasta
                GROUP BY p.Nombre
                ORDER BY TotalVendidos DESC;";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Desde", desde);
                cmd.Parameters.AddWithValue("@Hasta", hasta);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string nombre = dr["Nombre"].ToString();
                    int cantidad = Convert.ToInt32(dr["TotalVendidos"]);
                    chartProductos.Series["Productos"].Points.AddXY(nombre, cantidad);
                }
            }
        }

        private void CargarGraficoIngresos(DateTime desde, DateTime hasta)
        {
            chartIngresos.Series["Ingresos"].Points.Clear();

            string query = @"
                SELECT CAST(FechaRegistro AS DATE) AS Dia, SUM(MontoTotal) AS Ingresos
                FROM VENTA
                WHERE FechaRegistro BETWEEN @Desde AND @Hasta
                GROUP BY CAST(FechaRegistro AS DATE)
                ORDER BY Dia;";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Desde", desde);
                cmd.Parameters.AddWithValue("@Hasta", hasta);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DateTime dia = Convert.ToDateTime(dr["Dia"]);
                    decimal ingreso = Convert.ToDecimal(dr["Ingresos"]);
                    chartIngresos.Series["Ingresos"].Points.AddXY(dia.ToString("dd/MM"), ingreso);
                }
            }
        }

        // ===================== MÉTODOS AUXILIARES =====================

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
