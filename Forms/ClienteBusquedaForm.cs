using nikeproject.DataAccess;
using nikeproject.UserControls;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace nikeproject.Forms
{

    public class ClienteSeleccionadoEventArgs : EventArgs
    {

        public int IdCliente { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
    public partial class ClienteBusquedaForm : Form
    {

        public ClienteBusquedaForm()
        {
            InitializeComponent();
        }

        public event EventHandler<ClienteSeleccionadoEventArgs> ClienteSeleccionado;

        private void ClienteBusquedaForm_Load(object sender, EventArgs e)
        {
            cbBusqueda.Items.Add("Documento");
            cbBusqueda.Items.Add("Nombre");
            cbBusqueda.Items.Add("Apellido");
            cbBusqueda.SelectedIndex = 0;
            CargarClientes();
        }



        private void CargarClientes(string filtro = "", string columna = "")
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.CadenaConexion))
            {
                oConexion.Open();
                string query = @"SELECT IdCliente, Nombre, Apellido, Documento, Correo, Telefono 
                                 FROM CLIENTE WHERE Estado = 1";

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
                    dgvClientes.DataSource = dt;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes(txtBusqueda.Text.Trim(), cbBusqueda.SelectedItem.ToString());
        }


        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.Columns[e.ColumnIndex].Name == "btnSeleccionar" && e.RowIndex >= 0)
            {
                var ev = new ClienteSeleccionadoEventArgs
                {
                    IdCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["IdCliente"].Value),
                    Documento = dgvClientes.Rows[e.RowIndex].Cells["Documento"].Value.ToString(),
                    Nombre = dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(),
                    Apellido = dgvClientes.Rows[e.RowIndex].Cells["Apellido"].Value.ToString(),
                    Telefono = dgvClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString(),
                    Correo = dgvClientes.Rows[e.RowIndex].Cells["Correo"].Value.ToString()
                };

                ClienteSeleccionado?.Invoke(this, ev); // 🔥 disparamos el evento
                this.Close();
            }
        }
    }
}

