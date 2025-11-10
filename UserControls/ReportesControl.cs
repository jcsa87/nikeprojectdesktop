using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace nikeproject.UserControls
{
    public partial class ReportesControl : UserControl
    {
        private readonly string connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["cadena_conexion"].ToString();

        // Controla si hay datos para mostrar en el gráfico
        private bool hayDatosEnGrafico = true;

        public ReportesControl()
        {
            InitializeComponent();
            ConfigurarChart();
            CargarIndicadores();
            InicializarFiltros();
            GenerarReportePorDefecto();

            // Evento para texto cuando no hay datos
            chartPrincipal.Paint += chartPrincipal_Paint;
        }

        // ========================= CONFIGURACIÓN INICIAL =========================
        private void ConfigurarChart()
        {
            if (chartPrincipal == null) return;

            chartPrincipal.ChartAreas.Clear();
            chartPrincipal.Series.Clear();
            chartPrincipal.Titles.Clear();
            chartPrincipal.Annotations.Clear();

            var area = new ChartArea("MainArea");
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartPrincipal.ChartAreas.Add(area);

            chartPrincipal.Titles.Add(new Title("Gráfico de Reportes")
            {
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            });
        }

        private void InicializarFiltros()
        {
            cbReporte.Items.Clear();
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
            DateTime hasta = dtpHasta.Value.Date;
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

        // ========================= INDICADORES =========================
        // ========================= INDICADORES =========================
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

            decimal variacion = 0;
            if (ventasAnterior > 0)
                variacion = ((ventasActual - ventasAnterior) / ventasAnterior) * 100;

            // Actualizamos directamente las etiquetas ya referenciadas desde el diseñador
            lblVentasTitulo.Text = $"Ventas mes ({DateTime.Now:MMMM})";
            lblVentasValor.Text = $"${ventasActual:N0}";

            lblVariacionTitulo.Text = "Variación (vs mes anterior)";
            lblVariacionValor.Text = $"{variacion:N1}%";
            lblVariacionValor.ForeColor = variacion >= 0 ? Color.ForestGreen : Color.Firebrick;

            lblStockTitulo.Text = "Artículos sin stock";
            lblStockValor.Text = productosSinStock.ToString();
            lblStockValor.ForeColor = Color.Firebrick;

            lblClientesTitulo.Text = "Clientes activos";
            lblClientesValor.Text = clientesActivos.ToString();
            lblClientesValor.ForeColor = Color.Black;
        }


        private void ActualizarTarjeta(string tituloContiene, string nuevoValor, Color color)
        {
            foreach (Panel p in flowIndicadores.Controls.OfType<Panel>())
            {
                // Encuentra el Label de título
                var lblTitulo = p.Controls.OfType<Label>().FirstOrDefault(l => l.ForeColor == Color.DimGray);
                var lblValor = p.Controls.OfType<Label>().FirstOrDefault(l => l.Font.Size >= 13);

                if (lblTitulo != null && lblTitulo.Text.Contains(tituloContiene, StringComparison.OrdinalIgnoreCase))
                {
                    if (lblValor != null)
                    {
                        lblValor.Text = nuevoValor;
                        lblValor.ForeColor = color;
                    }
                    break;
                }
            }
        }

        // ========================= REPORTES =========================
        private void GenerarReportePorDefecto()
        {
            DateTime desde = DateTime.Now.AddDays(-30).Date;
            DateTime hasta = DateTime.Now.Date;
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
            chartPrincipal.Annotations.Clear();
            chartPrincipal.Legends.Clear();

            if (chartPrincipal.Titles.Count == 0)
                chartPrincipal.Titles.Add("Gráfico de Reportes");

            chartPrincipal.Titles[0].Text = "Gráfico de Reportes";

            // === Serie principal ===
            Series serie = new Series("Datos")
            {
                BorderWidth = 3,
                ChartArea = "MainArea",
                Legend = "Legend1"
            };
            chartPrincipal.Series.Add(serie);

            switch (tipo)
            {
                case "Ventas por mes":
                    serie.ChartType = SeriesChartType.Line;
                    serie.Color = Color.MediumSeaGreen;
                    serie.MarkerStyle = MarkerStyle.Circle;
                    serie.MarkerSize = 7;
                    chartPrincipal.Legends.Add(new Legend("Legend1"));
                    break;

                case "Top 5 productos más vendidos":
                    serie.ChartType = SeriesChartType.Pie;
                    serie.Color = Color.SteelBlue;
                    serie["PieStartAngle"] = "270";
                    serie.IsValueShownAsLabel = true;
                    serie.Label = "#PERCENT{P0}";
                    serie.LegendText = "#VALX – #PERCENT{P0}";
                    chartPrincipal.Legends.Add(new Legend("Legend1") { Docking = Docking.Bottom });
                    break;

                case "Ingresos diarios":
                    serie.ChartType = SeriesChartType.Column;
                    serie.Color = Color.SteelBlue;
                    chartPrincipal.Legends.Add(new Legend("Legend1"));
                    break;
            }

            string query = tipo switch
            {
                "Ventas por mes" => @"
                    SELECT DATEFROMPARTS(YEAR(FechaRegistro), MONTH(FechaRegistro), 1) AS Periodo,
                           SUM(MontoTotal) AS Total
                    FROM VENTA
                    WHERE FechaRegistro >= @Desde 
                      AND FechaRegistro < DATEADD(DAY, 1, @Hasta)
                    GROUP BY DATEFROMPARTS(YEAR(FechaRegistro), MONTH(FechaRegistro), 1)
                    ORDER BY DATEFROMPARTS(YEAR(FechaRegistro), MONTH(FechaRegistro), 1);",

                "Top 5 productos más vendidos" => @"
                    SELECT TOP 5 p.Nombre AS Nombre, SUM(dv.Cantidad) AS TotalVendidos
                    FROM DETALLE_VENTA dv
                    INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
                    INNER JOIN VENTA v ON v.IdVenta = dv.IdVenta
                    WHERE v.FechaRegistro >= @Desde 
                      AND v.FechaRegistro < DATEADD(DAY, 1, @Hasta)
                    GROUP BY p.Nombre
                    ORDER BY TotalVendidos DESC;",

                "Ingresos diarios" => @"
                    SELECT CAST(FechaRegistro AS DATE) AS Dia, SUM(MontoTotal) AS Ingreso
                    FROM VENTA
                    WHERE FechaRegistro >= @Desde 
                      AND FechaRegistro < DATEADD(DAY, 1, @Hasta)
                    GROUP BY CAST(FechaRegistro AS DATE)
                    ORDER BY Dia;",
                _ => ""
            };

            bool hayDatos = false;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Desde", desde);
                cmd.Parameters.AddWithValue("@Hasta", hasta);

                using SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    hayDatos = true;

                    if (tipo == "Ventas por mes")
                    {
                        DateTime periodo = Convert.ToDateTime(dr["Periodo"]);
                        decimal total = Convert.ToDecimal(dr["Total"]);
                        serie.Points.AddXY(periodo.ToString("MMM yyyy", new System.Globalization.CultureInfo("es-ES")), total);
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

            if (!hayDatos)
            {
                hayDatosEnGrafico = false;
                chartPrincipal.Series.Clear();
                chartPrincipal.Invalidate();
                ActualizarTituloGrafico(desde, hasta);
                return;
            }
            else
            {
                hayDatosEnGrafico = true;
            }

            ActualizarTituloGrafico(desde, hasta);
            chartPrincipal.Invalidate();
        }

        // ========================= DIBUJO DEL TEXTO CUANDO NO HAY DATOS =========================
        private void chartPrincipal_Paint(object sender, PaintEventArgs e)
        {
            if (!hayDatosEnGrafico)
            {
                string texto = "No hay datos para este intervalo";
                using (Font fuente = new Font("Segoe UI", 10, FontStyle.Italic))
                using (Brush brocha = new SolidBrush(Color.Gray))
                {
                    SizeF tamaño = e.Graphics.MeasureString(texto, fuente);
                    float x = (chartPrincipal.Width - tamaño.Width) / 2;
                    float y = (chartPrincipal.Height - tamaño.Height) / 2;
                    e.Graphics.DrawString(texto, fuente, brocha, x, y);
                }
            }
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

        private void ReportesControl_Load(object sender, EventArgs e) { }
    }
}
