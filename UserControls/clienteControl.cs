using Microsoft.Data.SqlClient;
using nikeproject.Auth;
using nikeproject.DataAccess;
using nikeproject.Helpers;
using nikeproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            GridHelper.PintarInactivos(dgvCliente);
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

        private void CargarClientes()
        {
            ClienteData clienteData = new ClienteData();
            dgvCliente.DataSource = clienteData.ListarClientes();


            // Ocultar la columna Estado, pero mantenerla para el coloreo
            if (dgvCliente.Columns.Contains("Estado"))
                dgvCliente.Columns["Estado"].Visible = false;
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
                    MessageBox.Show("⚠️ El correo debe ser válido y terminar en .com", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return;
                }

                if (!ClienteValidacion.TelefonoValido(txtTelefono.Text))
                {
                    MessageBox.Show("⚠️ El teléfono solo puede contener números", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvCliente.Rows[e.RowIndex];

                // Guardar id
                idClienteSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["IdCliente"].Value);

                // Llenar campos
                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
                txtNroDocumento.Text = filaSeleccionada.Cells["Documento"].Value.ToString();
                txtCorreo.Text = filaSeleccionada.Cells["Correo"].Value.ToString();
                txtTelefono.Text = filaSeleccionada.Cells["Telefono"].Value.ToString();

                // Estado
                bool estadoEsActivo = Convert.ToBoolean(filaSeleccionada.Cells["Estado"].Value);
                cbEstado.Text = estadoEsActivo ? "Activo" : "Inactivo";

                // Cambiar botón según estado
                if (estadoEsActivo)
                {
                    btnBaja.Text = "Dar de Baja";
                    btnBaja.BackColor = Color.Firebrick; // rojo
                }
                else
                {
                    btnBaja.Text = "Reactivar Cliente";
                    btnBaja.BackColor = Color.SeaGreen; // verde
                }
            }
        }

        private void dgvCliente_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCliente.Rows)
            {
                if (row.DataBoundItem is Cliente c)
                {
                    if (!c.Estado)
                    {
                        // Cliente inactivo → rojo
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        // Cliente activo → blanco
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }






        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado > 0)
            {
                ClienteData clienteData = new ClienteData();
                // Tomamos el estado actual desde el combo
                bool estadoActual = (cbEstado.Text == "Activo");

                string accion = estadoActual ? "dar de baja" : "reactivar";
                if (MessageBox.Show($"¿Está seguro que desea {accion} este cliente?",
                                    "Confirmar acción", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Cambiar estado en DB
                    bool resultado = clienteData.CambiarEstadoCliente(idClienteSeleccionado, !estadoActual);

                    if (resultado)
                    {
                        string msg = estadoActual ? "Cliente dado de baja correctamente."
                                                  : "Cliente reactivado correctamente.";
                        MessageBox.Show("✅ " + msg);
                        CargarClientes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("⚠️ No se pudo completar la acción.");
                    }
                }
            }
            else
            {
                MessageBox.Show("⚠️ Seleccione un cliente de la lista.");
            }
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado > 0)
            {
                // Validar nombre
                if (!ClienteValidacion.NombreValido(txtNombre.Text))
                {
                    MessageBox.Show("⚠️ El nombre solo puede contener letras y espacios, y no puede estar vacío.",
                                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                // Validar apellido
                if (!ClienteValidacion.ApellidoValido(txtApellido.Text))
                {
                    MessageBox.Show("⚠️ El apellido solo puede contener letras y espacios, y no puede estar vacío.",
                                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellido.Focus();
                    return;
                }

                // Validar documento
                if (!ClienteValidacion.DocumentoValido(txtNroDocumento.Text) || !txtNroDocumento.Text.All(char.IsDigit))
                {
                    MessageBox.Show("El documento debe ser numérico y no puede estar vacío.",
                                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNroDocumento.Focus();
                    return;
                }

                // Validar correo
                if (!ClienteValidacion.CorreoValido(txtCorreo.Text))
                {
                    MessageBox.Show("⚠️ El correo debe ser válido y terminar en .com",
                                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return;
                }

                // Validar teléfono
                if (!ClienteValidacion.TelefonoValido(txtTelefono.Text))
                {
                    MessageBox.Show("⚠️ El teléfono solo puede contener números",
                                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return;
                }

                // Crear objeto cliente con datos del formulario
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




        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaBusqueda = cbBusqueda.SelectedItem?.ToString() ?? string.Empty;
            string valorBusqueda = txtBusqueda.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(valorBusqueda))
            {
                MessageBox.Show("⚠️ Por favor, ingrese un valor de búsqueda.", "Error de búsqueda",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClienteData clienteData = new ClienteData();
            dgvCliente.DataSource = clienteData.BuscarClientes(columnaBusqueda, valorBusqueda);
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            if (cbBusqueda.Items.Count > 0)
                cbBusqueda.SelectedIndex = 0;

            // Volver a cargar todos los clientes
            CargarClientes();
        }




        private void dgvCliente_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Validar que estamos en la columna Estado
            if (dgvCliente.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
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

        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            // Obtener el control que disparó el evento
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

            // 1. Crear un nuevo string que contenga SOLO los dígitos
            string cleanText = new string(text.Where(char.IsDigit).ToArray());

            // 2. Comprobar si el texto original tenía letras (para evitar un bucle)
            if (text != cleanText)
            {
                // 3. Guardar la posición actual del cursor
                int cursorPosition = textBox.SelectionStart;

                // 4. Calcular cuántos caracteres "malos" había ANTES del cursor
                int nonDigitCharsBeforeCursor = text.Take(cursorPosition).Count(c => !char.IsDigit(c));

                // 5. Asignar el texto limpio
                textBox.Text = cleanText;

                // 6. Restaurar el cursor a su posición correcta
                // (Esto es para que el cursor no salte al inicio cada vez que pega)
                textBox.SelectionStart = Math.Max(0, cursorPosition - nonDigitCharsBeforeCursor);
            }
        }
    }
}
