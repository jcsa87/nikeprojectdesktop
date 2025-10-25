using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace nikeproject.UserControls
{
    public partial class ReportesControl : UserControl
    {
        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();

        public ReportesControl()
        {
            InitializeComponent();
            ConfigurarGraficos();
            CargarCategorias();
        }

        private void ConfigurarGraficos()
        {
            // Gráfico 1: Ventas mensuales
            chartVentas.ChartAreas.Add(new ChartArea());
            chartVentas.Titles.Add("Ventas por Mes");
            chartVentas.Series.Add("Ventas");
            chartVentas.Series["Ventas"].ChartType = SeriesChartType.Column;
            chartVentas.Series["Ventas"].Color = Color.SteelBlue;

            // Gráfico 2: Productos más vendidos
            chartProductos.ChartAreas.Add(new ChartArea());
            chartProductos.Titles.Add("Productos Más Vendidos");
            chartProductos.Series.Add("Productos");
            chartProductos.Series["Productos"].ChartType = SeriesChartType.Pie;

            // Gráfico 3: Ingresos por categoría
            chartCategorias.ChartAreas.Add(new ChartArea());
            chartCategorias.Titles.Add("Ingresos por Categoría");
            chartCategorias.Series.Add("Ingresos");
            chartCategorias.Series["Ingresos"].ChartType = SeriesChartType.Line;
            chartCategorias.Series["Ingresos"].BorderWidth = 3;
            chartCategorias.Series["Ingresos"].Color = Color.MediumSeaGreen;
        }

        private void CargarCategorias()
        {
            cbCategoria.Items.Clear();
            cbCategoria.Items.Add("Todas");

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Descripcion FROM CATEGORIA", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    cbCategoria.Items.Add(dr.GetString(0));
            }

            cbCategoria.SelectedIndex = 0;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;
            string categoria = cbCategoria.SelectedItem.ToString();

            CargarVentasMensuales(desde, hasta);
            CargarProductosMasVendidos(desde, hasta);
            CargarIngresosPorCategoria(desde, hasta, categoria);
        }

        private void CargarVentasMensuales(DateTime desde, DateTime hasta)
        {
            chartVentas.Series["Ventas"].Points.Clear();

            string query = @"
                SELECT DATENAME(MONTH, FechaRegistro) AS Mes,
                       SUM(MontoTotal) AS Monto
                FROM VENTA
                WHERE FechaRegistro BETWEEN @Desde AND @Hasta
                GROUP BY DATENAME(MONTH, FechaRegistro), MONTH(FechaRegistro)
                ORDER BY MONTH(FechaRegistro);";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Desde", desde);
                cmd.Parameters.AddWithValue("@Hasta", hasta);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string mes = dr["Mes"].ToString();
                    decimal monto = Convert.ToDecimal(dr["Monto"]);
                    chartVentas.Series["Ventas"].Points.AddXY(mes, monto);
                }
            }
        }

        private void CargarProductosMasVendidos(DateTime desde, DateTime hasta)
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
                    int vendidos = Convert.ToInt32(dr["TotalVendidos"]);
                    chartProductos.Series["Productos"].Points.AddXY(nombre, vendidos);
                }
            }
        }

        private void CargarIngresosPorCategoria(DateTime desde, DateTime hasta, string categoriaSeleccionada)
        {
            chartCategorias.Series["Ingresos"].Points.Clear();

            string query = @"
                SELECT c.Descripcion AS Categoria, SUM(dv.SubTotal) AS Ingresos
                FROM DETALLE_VENTA dv
                INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
                INNER JOIN CATEGORIA c ON c.IdCategoria = p.IdCategoria
                INNER JOIN VENTA v ON v.IdVenta = dv.IdVenta
                WHERE v.FechaRegistro BETWEEN @Desde AND @Hasta
                GROUP BY c.Descripcion;";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Desde", desde);
                cmd.Parameters.AddWithValue("@Hasta", hasta);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string categoria = dr["Categoria"].ToString();
                    decimal ingreso = Convert.ToDecimal(dr["Ingresos"]);

                    if (categoriaSeleccionada == "Todas" || categoriaSeleccionada == categoria)
                        chartCategorias.Series["Ingresos"].Points.AddXY(categoria, ingreso);
                }
            }
        }
    }
}
