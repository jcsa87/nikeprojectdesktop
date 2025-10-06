using nikeproject.DataAccess;
using nikeproject.UserControls;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace nikeproject.Forms
{

    public class ProductoSeleccionadoEventArgs : EventArgs
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
    }
    public partial class ProductoBusquedaForm : Form
    {
        public ProductoBusquedaForm()
        {
            InitializeComponent();
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
        }

        private void ProductoBusquedaForm_Load(object sender, EventArgs e)
        {
            cbBusqueda.Items.AddRange(new object[] { "Codigo", "Nombre", "Descripcion" });
            cbBusqueda.SelectedIndex = 0;

            cbBusqueda.Items.Add("Codigo");
            cbBusqueda.Items.Add("Nombre");
            cbBusqueda.Items.Add("Descripcion");
            cbBusqueda.SelectedIndex = 0;
            CargarProductos();
        }

        private void CargarProductos(string filtro = "", string columna = "")
        {
            // Mapa seguro de columnas permitidas (whitelist)
            var columnasPermitidas = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "Codigo", "Codigo" },
        { "Nombre", "Nombre" },
        { "Descripcion", "Descripcion" }
    };

            string columnaSql = null;
            if (!string.IsNullOrWhiteSpace(columna) && columnasPermitidas.ContainsKey(columna))
                columnaSql = columnasPermitidas[columna];

            using (SqlConnection oConexion = new SqlConnection(Conexion.CadenaConexion))
            {
                oConexion.Open();

                // Solo activos y con stock > 0
                string query = @"
                    SELECT IdProducto, Codigo, Nombre, Descripcion, Stock, PrecioVenta, ImagenRuta
                     FROM PRODUCTO
                     WHERE Estado = 1 AND Stock > 0";

                if (!string.IsNullOrWhiteSpace(filtro) && !string.IsNullOrWhiteSpace(columnaSql))
                    query += $" AND {columnaSql} LIKE @filtro";

                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    if (!string.IsNullOrWhiteSpace(filtro) && !string.IsNullOrWhiteSpace(columnaSql))
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvProductos.DataSource = dt;
                    }
                }
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                var rutaImagen = dgvProductos.CurrentRow.Cells["ImagenRuta"].Value?.ToString();

                if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
                {
                    pbPreview.Image = Image.FromFile(rutaImagen);
                }
                else
                {
                    pbPreview.Image = null;
                }
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProductos(txtBusqueda.Text.Trim(), cbBusqueda.SelectedItem?.ToString());
        }

        public event EventHandler<ProductoSeleccionadoEventArgs> ProductoSeleccionado;

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "btnSeleccionar" && e.RowIndex >= 0)
            {
                var ev = new ProductoSeleccionadoEventArgs
                {
                    IdProducto = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["IdProducto"].Value),
                    Codigo = dgvProductos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString(),
                    Nombre = dgvProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(),
                    PrecioVenta = Convert.ToDecimal(dgvProductos.Rows[e.RowIndex].Cells["PrecioVenta"].Value),
                    Stock = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["Stock"].Value),
                    RutaImagen = dgvProductos.Rows[e.RowIndex].Cells["ImagenRuta"].Value.ToString()
                };

                ProductoSeleccionado?.Invoke(this, ev);
                this.Close();
            }
        }
    }
}
