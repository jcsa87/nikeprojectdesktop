using nikeproject.Auth;
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

            InicializarControles();

            CargarClientes();
        }

        private void ClienteControl_Load(object sender, EventArgs e)
        {
            CargarClientes();

            // ComboBox Estado
            cbEstado.Items.Add("Activo");
            cbEstado.Items.Add("Inactivo");
            cbEstado.SelectedIndex = 0;

            // ComboBox Búsqueda
            cbBusqueda.Items.Clear();
            cbBusqueda.Items.Add("Nombre");
            cbBusqueda.Items.Add("Apellido");
            cbBusqueda.Items.Add("Documento");
            cbBusqueda.Items.Add("Correo");
            cbBusqueda.Items.Add("Telefono");
            cbBusqueda.SelectedIndex = 0;

            dgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void InicializarControles()
        {
            // --- ⚠️ ORDEN CORREGIDO para evitar 'InvalidArgument=Value of 0 is not valid' ---

            // ComboBox Estado
            cbEstado.Items.Clear();
            cbEstado.Items.Add("Activo"); // Índice 0
            cbEstado.Items.Add("Inactivo"); // Índice 1
            cbEstado.SelectedIndex = 0; // Ahora sí se puede establecer el índice 0 ("Activo")

            // ComboBox Búsqueda
            cbBusqueda.Items.Clear();
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
                // Validación de campos usando ClienteValidacion
                if (!ClienteValidacion.NombreValido(txtNombre.Text))
                {
                    MessageBox.Show("El nombre solo puede contener letras y espacios, y no puede estar vacío.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (!ClienteValidacion.ApellidoValido(txtApellido.Text))
                {
                    MessageBox.Show("El apellido solo puede contener letras y espacios, y no puede estar vacío.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellido.Focus();
                    return;
                }

                if (!ClienteValidacion.DocumentoValido(txtNroDocumento.Text) || !txtNroDocumento.Text.All(char.IsDigit))
                {
                    MessageBox.Show("El documento debe ser numérico y no puede estar vacío.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNroDocumento.Focus();
                    return;
                }

                if (!ClienteValidacion.CorreoValido(txtCorreo.Text))
                {
                    MessageBox.Show("El correo ingresado no es válido.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return;
                }

                if (!ClienteValidacion.TelefonoValido(txtTelefono.Text))
                {
                    MessageBox.Show("El teléfono ingresado no es válido.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
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
            // Asegúrate de que no se haga clic en la fila de encabezado
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvCliente.Rows[e.RowIndex];

                // Asigna el IdCliente de la fila seleccionada a la variable
                idClienteSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["IdCliente"].Value);

                // Llenar los campos del formulario con los datos de la fila
                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
                txtNroDocumento.Text = filaSeleccionada.Cells["Documento"].Value.ToString();
                txtCorreo.Text = filaSeleccionada.Cells["Correo"].Value.ToString();
                txtTelefono.Text = filaSeleccionada.Cells["Telefono"].Value.ToString();
                cbEstado.Text = (Convert.ToBoolean(filaSeleccionada.Cells["Estado"].Value) == true) ? "Activo" : "Inactivo";
            }
        }

        private void dgvCliente_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Asegúrate de que estás en la columna 'Estado'
            if (dgvCliente.Columns[e.ColumnIndex].Name == "Estado")
            {
                // Verifica si el valor de la celda es un booleano
                if (e.Value is bool)
                {
                    bool estado = (bool)e.Value;
                    // Asigna el valor de texto correspondiente
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

        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
