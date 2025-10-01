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
        }

        private void ProductoBusquedaForm_Load(object sender, EventArgs e)
        {
            cbBusqueda.Items.Add("Codigo");
            cbBusqueda.Items.Add("Nombre");
            cbBusqueda.Items.Add("Descripcion");
            cbBusqueda.SelectedIndex = 0;
            CargarProductos();
        }

        private void CargarProductos(string filtro = "", string columna = "")
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.CadenaConexion))
            {
                oConexion.Open();
                string query = @"SELECT IdProducto, Codigo, Nombre, Descripcion, Stock, PrecioVenta, ImagenRuta 
                                 FROM PRODUCTO WHERE Estado = 1";

                if (!string.IsNullOrEmpty(filtro) && !string.IsNullOrEmpty(columna))
                {
                    query += $" AND {columna} LIKE @filtro";
                }

                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    if (!string.IsNullOrEmpty(filtro))
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProductos.DataSource = dt;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProductos(txtBusqueda.Text.Trim(), cbBusqueda.SelectedItem.ToString());
        }

        public event EventHandler<ProductoSeleccionadoEventArgs> ProductoSeleccionado;

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "btnSeleccionar" && e.RowIndex >= 0)
            {
                var args = new ProductoSeleccionadoEventArgs
                {
                    Codigo = dgvProductos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString(),
                    Nombre = dgvProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(),
                    PrecioVenta = Convert.ToDecimal(dgvProductos.Rows[e.RowIndex].Cells["PrecioVenta"].Value),
                    Stock = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["Stock"].Value),
                    RutaImagen = dgvProductos.Rows[e.RowIndex].Cells["ImagenRuta"].Value.ToString()
                };

                ProductoSeleccionado?.Invoke(this, args);
                this.Close();
            }
        }
    }
}
