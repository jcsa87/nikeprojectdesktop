using nikeproject.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace nikeproject.UserControls
{
    public partial class ReportesControl : UserControl
    {
        public ReportesControl()
        {
            InitializeComponent();
            ConfigurarGraficos();
            CargarCategorias();
        }

        private void ConfigurarGraficos()
        {
            // Chart de Ventas Mensuales
            chartVentas.ChartAreas.Add(new ChartArea());
            chartVentas.Titles.Add("Ventas por Mes");
            chartVentas.Series.Add("Ventas");
            chartVentas.Series["Ventas"].ChartType = SeriesChartType.Column;
            chartVentas.Series["Ventas"].Color = Color.SteelBlue;

            // Chart de Productos más vendidos
            chartProductos.ChartAreas.Add(new ChartArea());
            chartProductos.Titles.Add("Productos Más Vendidos");
            chartProductos.Series.Add("Productos");
            chartProductos.Series["Productos"].ChartType = SeriesChartType.Pie;

            // Chart de Ingresos por Categoría
            chartCategorias.ChartAreas.Add(new ChartArea());
            chartCategorias.Titles.Add("Ingresos por Categoría");
            chartCategorias.Series.Add("Ingresos");
            chartCategorias.Series["Ingresos"].ChartType = SeriesChartType.Line;
            chartCategorias.Series["Ingresos"].Color = Color.MediumSeaGreen;
            chartCategorias.Series["Ingresos"].BorderWidth = 3;
        }

        private void CargarCategorias()
        {
            // Simulación de categorías
            cbCategoria.Items.AddRange(new string[] { "Todas", "Calzado", "Ropa", "Accesorios" });
            cbCategoria.SelectedIndex = 0;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarReportes();
        }

        private void GenerarReportes()
        {
            // Limpia los gráficos
            foreach (var chart in new[] { chartVentas, chartProductos, chartCategorias })
                chart.Series[0].Points.Clear();

            // Simulación de datos
            var random = new Random();

            // Ventas por Mes
            string[] meses = { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };
            foreach (var mes in meses)
                chartVentas.Series["Ventas"].Points.AddXY(mes, random.Next(50, 300));

            // Productos más vendidos
            string[] productos = { "Nike Air Max", "Camiseta", "Gorra", "Zapatilla Running", "Mochila" };
            foreach (var prod in productos)
                chartProductos.Series["Productos"].Points.AddXY(prod, random.Next(20, 150));

            // Ingresos por Categoría
            string[] categorias = { "Calzado", "Ropa", "Accesorios" };
            foreach (var cat in categorias)
                chartCategorias.Series["Ingresos"].Points.AddXY(cat, random.Next(5000, 20000));
        }
    }
}
