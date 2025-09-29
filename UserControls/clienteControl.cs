using nikeproject.DataAccess;
using nikeproject.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace nikeproject
{
    public partial class ClienteControl : UserControl
    {
        private int idClienteSeleccionado = 0;

        public ClienteControl()
        {
            InitializeComponent();
        }

        private void ClienteControl_Load(object sender, EventArgs e)
        {
            CargarClientes();

            // ComboBox Estado
            cbEstado.Items.Add("Activo");
            cbEstado.Items.Add("Inactivo");
            cbEstado.SelectedIndex = 0;

            // ComboBox Búsqueda
            cbBusqueda.Items.Add("Nombre");
            cbBusqueda.Items.Add("Apellido");
            cbBusqueda.Items.Add("Documento");
            cbBusqueda.Items.Add("Correo");
            cbBusqueda.Items.Add("Telefono");
            cbBusqueda.SelectedIndex = 0;

            dgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarClientes()
        {
            ClienteData clienteData = new ClienteData();
            dgvCliente.DataSource = clienteData.ListarClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("⚠️ El nombre es obligatorio.");
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("⚠️ El apellido es obligatorio.");
                    txtApellido.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNroDocumento.Text) || !txtNroDocumento.Text.All(char.IsDigit))
                {
                    MessageBox.Show("⚠️ El documento debe ser numérico.");
                    txtNroDocumento.Focus();
                    return;
                }

                Cliente oCliente = new Cliente()
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Documento = txtNroDocumento.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Estado = (cbEstado.SelectedItem?.ToString() == "Activo"),
                    FechaCreacion = DateTime.Now
                };

                ClienteData clienteData = new ClienteData();
                bool resultado = clienteData.GuardarCliente(oCliente);

                if (resultado)
                {
                    MessageBox.Show("✅ Cliente guardado correctamente.");
                    CargarClientes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("⚠️ No se pudo guardar el cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado > 0)
            {
                Cliente oCliente = new Cliente()
                {
                    IdCliente = idClienteSeleccionado,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Documento = txtNroDocumento.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Estado = (cbEstado.SelectedItem?.ToString() == "Activo")
                };

                ClienteData clienteData = new ClienteData();
                if (clienteData.EditarCliente(oCliente))
                {
                    MessageBox.Show("✅ Cliente editado correctamente.");
                    CargarClientes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("⚠️ No se pudo editar el cliente.");
                }
            }
            else
            {
                MessageBox.Show("⚠️ Seleccione un cliente para editar.");
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado > 0)
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClienteData clienteData = new ClienteData();
                    if (clienteData.EliminarCliente(idClienteSeleccionado))
                    {
                        MessageBox.Show("✅ Cliente eliminado correctamente.");
                        CargarClientes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("⚠️ No se pudo eliminar el cliente.");
                    }
                }
            }
            else
            {
                MessageBox.Show("⚠️ Seleccione un cliente para eliminar.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaBusqueda = cbBusqueda.SelectedItem?.ToString() ?? string.Empty;
            string valorBusqueda = txtBusqueda.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(valorBusqueda))
            {
                MessageBox.Show("⚠️ Ingrese un valor de búsqueda.");
                return;
            }

            ClienteData clienteData = new ClienteData();
            dgvCliente.DataSource = clienteData.BuscarClientes(columnaBusqueda, valorBusqueda);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtBusqueda.Clear();
            cbBusqueda.SelectedIndex = 0;
            CargarClientes();
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvCliente.Rows[e.RowIndex];
                idClienteSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["IdCliente"].Value);

                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
                txtNroDocumento.Text = filaSeleccionada.Cells["Documento"].Value.ToString();
                txtCorreo.Text = filaSeleccionada.Cells["Correo"].Value.ToString();
                txtTelefono.Text = filaSeleccionada.Cells["Telefono"].Value.ToString();
                cbEstado.Text = (Convert.ToBoolean(filaSeleccionada.Cells["Estado"].Value)) ? "Activo" : "Inactivo";
            }
        }

        private void dgvCliente_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCliente.Columns[e.ColumnIndex].Name == "Estado")
            {
                if (e.Value is bool estado)
                {
                    e.Value = estado ? "Activo" : "Inactivo";
                    e.FormattingApplied = true;
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNroDocumento.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            cbEstado.SelectedIndex = 0;
            idClienteSeleccionado = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
