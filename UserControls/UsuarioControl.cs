using Microsoft.Data.SqlClient;
using nikeproject.Auth;
using nikeproject.DataAccess;
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
    public partial class UsuariosControl : UserControl
    {
        private int idUsuarioSeleccionado = 0;
        public UsuariosControl()
        {
            InitializeComponent();
        }

        private void UsuariosControl_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            // Llenar el ComboBox de roles
            cbRol.Items.Add("Administrador");
            cbRol.Items.Add("Vendedor");
            cbRol.Items.Add("Supervisor");
            cbRol.SelectedIndex = 0;

            // Llenar el ComboBox de estados
            cbEstado.Items.Add("Activo");
            cbEstado.Items.Add("Inactivo");
            cbEstado.SelectedIndex = 0; // Seleccionar el primer elemento por defecto

            // Llenar el ComboBox de búsqueda
            cbBusqueda.Items.Add("Nombre");
            cbBusqueda.Items.Add("Apellido");
            cbBusqueda.Items.Add("Documento");
            cbBusqueda.Items.Add("Rol");
            
            cbBusqueda.SelectedIndex = 0; // Seleccionar el primer elemento por defecto

            dgvUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarUsuarios()
        {
            UsuarioData usuarioData = new UsuarioData();
            dgvUsuario.DataSource = usuarioData.ListarUsuarios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos usando UsuarioValidacion
                if (!UsuarioValidacion.NombreValido(txtNombre.Text))
                {
                    MessageBox.Show("El nombre solo puede contener letras y espacios, y no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (!UsuarioValidacion.Apellido(txtApellido.Text))
                {
                    MessageBox.Show("El apellido solo puede contener letras y espacios, y no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (!UsuarioValidacion.UsuarioValido(txtNroDocumento.Text) || !txtNroDocumento.Text.All(char.IsDigit))
                {
                    MessageBox.Show("El documento debe ser numérico y no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNroDocumento.Focus();
                    return;
                }

                if (!UsuarioValidacion.claveValida(txtClave.Text))
                {
                    MessageBox.Show("La clave debe tener al menos 6 caracteres.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClave.Focus();
                    return;
                }

                if (!UsuarioValidacion.ConfirmarClave(txtClave.Text, txtConfirmarClave.Text))
                {
                    MessageBox.Show("⚠️ La clave y la confirmación no coinciden. Por favor, verifícalas.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmarClave.Focus();
                    return;
                }

                if (!UsuarioValidacion.RolValido(cbRol.SelectedItem?.ToString() ?? ""))
                {
                    MessageBox.Show("Seleccione un rol válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbRol.Focus();
                    return;
                }

                // Estado siempre será válido porque el ComboBox solo tiene dos opciones

                Usuario oUsuario = new Usuario()
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Documento = txtNroDocumento.Text.Trim(),
                    Clave = txtClave.Text.Trim(),
                    Rol = cbRol.SelectedItem?.ToString() ?? "Vendedor",
                    Estado = (cbEstado.SelectedItem?.ToString() == "Activo")
                };

                UsuarioData usuarioData = new UsuarioData();
                bool resultado = usuarioData.GuardarUsuario(oUsuario);

                if (resultado)
                {
                    MessageBox.Show("✅ Usuario guardado correctamente.");
                    CargarUsuarios();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("⚠️ No se pudo guardar el usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNroDocumento.Clear();
            txtClave.Clear();
            txtConfirmarClave.Clear();
            cbRol.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0; // <-- Corregido aquí
        }

        private void dgvUsuario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Asegúrate de que estás en la columna 'Estado'
            if (dgvUsuario.Columns[e.ColumnIndex].Name == "Estado")
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

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvUsuario.Rows[e.RowIndex];

                idUsuarioSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["IdUsuario"].Value);

                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
                txtNroDocumento.Text = filaSeleccionada.Cells["Documento"].Value.ToString();
                txtClave.Text = filaSeleccionada.Cells["Clave"].Value.ToString();
                cbRol.Text = filaSeleccionada.Cells["Rol"].Value.ToString();
                cbEstado.Text = (Convert.ToBoolean(filaSeleccionada.Cells["Estado"].Value) == true) ? "Activo" : "Inactivo";

                bool estadoEsActivo = Convert.ToBoolean(filaSeleccionada.Cells["Estado"].Value);

                // 👇 Actualizar el botón según estado
                if (estadoEsActivo)
                {
                    btnEliminar.Text = "Dar de Baja";
                    btnEliminar.BackColor = Color.Firebrick;  // rojo
                }
                else
                {
                    btnEliminar.Text = "Reactivar Usuario";
                    btnEliminar.BackColor = Color.SeaGreen;  // verde distinto
                }

                cbEstado.Enabled = !estadoEsActivo;
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado > 0)
            {
                if (!UsuarioValidacion.NombreValido(txtNombre.Text))
                {
                    MessageBox.Show("El nombre solo puede contener letras y espacios, y no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (!UsuarioValidacion.Apellido(txtApellido.Text))
                {
                    MessageBox.Show("El apellido solo puede contener letras y espacios, y no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellido.Focus();
                    return;
                }

                if (!UsuarioValidacion.UsuarioValido(txtNroDocumento.Text) || !txtNroDocumento.Text.All(char.IsDigit))
                {
                    MessageBox.Show("El documento debe ser numérico y no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNroDocumento.Focus();
                    return;
                }

                if (!UsuarioValidacion.claveValida(txtClave.Text))
                {
                    MessageBox.Show("La clave debe tener al menos 6 caracteres.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClave.Focus();
                    return;
                }

                if (!UsuarioValidacion.ConfirmarClave(txtClave.Text, txtConfirmarClave.Text))
                {
                    MessageBox.Show("⚠️ La clave y la confirmación no coinciden. Por favor, verifícalas.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmarClave.Focus();
                    return;
                }

                if (!UsuarioValidacion.RolValido(cbRol.SelectedItem?.ToString() ?? ""))
                {
                    MessageBox.Show("Seleccione un rol válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbRol.Focus();
                    return;
                }


                Usuario oUsuario = new Usuario()
                {
                    IdUsuario = idUsuarioSeleccionado,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Documento = txtNroDocumento.Text.Trim(),
                    Clave = txtClave.Text.Trim(),
                    Rol = cbRol.SelectedItem?.ToString() ?? "Vendedor",
                    Estado = (cbEstado.SelectedItem?.ToString() == "Activo")
                };

                UsuarioData usuarioData = new UsuarioData();
                if (usuarioData.EditarUsuario(oUsuario))
                {
                    MessageBox.Show("✅ Usuario editado correctamente.");
                    CargarUsuarios();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("⚠️ No se pudo editar el usuario.");
                }
            }
            else
            {
                MessageBox.Show("⚠️ Seleccione un usuario para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado > 0)
            {
                UsuarioData usuarioData = new UsuarioData();

                bool reactivar = (btnEliminar.Text == "Reactivar Usuario");

                string mensajeConfirmacion = reactivar
                    ? "¿Está seguro que desea reactivar este usuario?"
                    : "¿Está seguro que desea dar de baja este usuario?";

                if (MessageBox.Show(mensajeConfirmacion, "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool resultado;

                    if (reactivar)
                    {
                        resultado = usuarioData.CambiarEstadoUsuario(idUsuarioSeleccionado, true); // activo
                    }
                    else
                    {
                        resultado = usuarioData.CambiarEstadoUsuario(idUsuarioSeleccionado, false); // inactivo
                    }

                    if (resultado)
                    {
                        MessageBox.Show(reactivar
                            ? "✅ Usuario reactivado correctamente."
                            : "✅ Usuario dado de baja correctamente.");

                        CargarUsuarios();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("⚠️ No se pudo actualizar el usuario.");
                    }
                }
            }
            else
            {
                MessageBox.Show("⚠️ Seleccione un usuario.");
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaBusqueda = cbBusqueda.SelectedItem?.ToString() ?? string.Empty;
            string valorBusqueda = txtBusqueda.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(valorBusqueda))
            {
                MessageBox.Show("⚠️ Por favor, ingrese un valor de búsqueda.", "Error de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioData usuarioData = new UsuarioData();
            dgvUsuario.DataSource = usuarioData.BuscarUsuarios(columnaBusqueda, valorBusqueda);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtBusqueda.Clear();
            cbBusqueda.SelectedIndex = 0;
            CargarUsuarios();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}