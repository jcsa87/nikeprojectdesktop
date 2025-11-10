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
    public partial class UsuariosControl : UserControl
    {
        private int idUsuarioSeleccionado = 0;
        public UsuariosControl()
        {
            InitializeComponent();
            GridHelper.PintarInactivos(dgvUsuario);
        }

        private void UsuariosControl_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            // Llenar el ComboBox de roles
            // Carga los nombres del enum ("Administrador", "Vendedor", etc.) como ítems.
            cbRol.DataSource = Enum.GetNames(typeof(RolUsuario));

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

            // Ocultar la columna Estado, pero mantenerla para el coloreo
            if (dgvUsuario.Columns.Contains("Estado"))
                dgvUsuario.Columns["Estado"].Visible = false;
        }


        private void dgvUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvUsuario.Rows)
            {
                if (row.DataBoundItem is Usuario u)
                {
                    if (!u.Estado)
                    {
                        // Usuario inactivo → rojo
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        // Usuario activo → normal
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // --- Toda tu validación de campos se mantiene igual ---
                if (!UsuarioValidacion.NombreValido(txtNombre.Text))
                {
                    MessageBox.Show("El nombre solo puede contener letras y espacios, y no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (!UsuarioValidacion.ApellidoValido(txtApellido.Text))
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

                if (!UsuarioValidacion.ClaveValida(txtClave.Text))
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

                // --- INICIO DE LA MODIFICACIÓN CENTRADA EN EL ENUM ---

                // 1. Obtenemos el texto seleccionado en el ComboBox.
                string rolSeleccionadoTexto = cbRol.SelectedItem?.ToString() ?? "";

                // 2. Validamos ese texto (esta línea funciona como antes).
                if (!UsuarioValidacion.RolValido(rolSeleccionadoTexto))
                {
                    MessageBox.Show("Seleccione un rol válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbRol.Focus();
                    return;
                }

                // 3. Si la validación pasa, "traducimos" el texto al enum.
                Enum.TryParse<RolUsuario>(rolSeleccionadoTexto, out RolUsuario rolSeleccionadoEnum);

                // --- FIN DE LA MODIFICACIÓN ---

                // 4. Creamos el objeto Usuario usando el enum ya convertido.
                Usuario oUsuario = new Usuario()
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Documento = txtNroDocumento.Text.Trim(),
                    Clave = txtClave.Text.Trim(),
                    Rol = rolSeleccionadoEnum, // ✨ ¡Aquí asignamos el enum, solucionando el error!
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

         public bool EditarCliente(Cliente oCliente)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    oConexion.Open();
                    string query = "UPDATE CLIENTE SET Nombre = @nombre, Apellido = @apellido, Documento = @documento, Correo = @correo, Telefono = @telefono, Estado = @estado WHERE IdCliente = @idcliente";
                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", oCliente.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", oCliente.Apellido);
                        cmd.Parameters.AddWithValue("@documento", oCliente.Documento);
                        cmd.Parameters.AddWithValue("@correo", oCliente.Correo);
                        cmd.Parameters.AddWithValue("@telefono", oCliente.Telefono);
                        cmd.Parameters.AddWithValue("@estado", oCliente.Estado);
                        cmd.Parameters.AddWithValue("@idcliente", oCliente.IdCliente);
                        cmd.CommandType = CommandType.Text;
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            resultado = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }

        private string claveOriginal = "";
        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvUsuario.Rows[e.RowIndex];

                idUsuarioSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["IdUsuario"].Value);

                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
                txtNroDocumento.Text = filaSeleccionada.Cells["Documento"].Value.ToString();
                claveOriginal = Convert.ToString(filaSeleccionada.Cells["Clave"].Value) ?? string.Empty;
                txtClave.Text = claveOriginal;
                txtConfirmarClave.Text = "";
                // 2. Obtenemos el valor del enum directamente desde la celda.
                RolUsuario rolDelUsuario = (RolUsuario)filaSeleccionada.Cells["Rol"].Value;
                // 3. Lo convertimos a texto para poder seleccionar el ítem correcto en el ComboBox.
                // Usar SelectedItem es más robusto que asignar a .Text.
                cbRol.SelectedItem = rolDelUsuario.ToString();
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
                // --- Todas tus validaciones se mantienen exactamente igual ---
                if (!UsuarioValidacion.NombreValido(txtNombre.Text))
                {
                    MessageBox.Show("El nombre solo puede contener letras y espacios, y no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (!UsuarioValidacion.ApellidoValido(txtApellido.Text))
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

                string claveParaGuardar = claveOriginal; // Por defecto, guardamos la clave original

                // Verificamos si el usuario INTENTÓ cambiar la clave
                // (ya sea cambiando txtClave o escribiendo en txtConfirmarClave)
                if (txtClave.Text != claveOriginal || !string.IsNullOrEmpty(txtConfirmarClave.Text))
                {
                    // Si intentó cambiarla, AHORA SÍ validamos
                    if (!UsuarioValidacion.ClaveValida(txtClave.Text))
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

                    // Si las validaciones pasan, preparamos la NUEVA clave para guardarla
                    claveParaGuardar = txtClave.Text.Trim();
                }
                // Si el usuario no tocó los campos de clave, este bloque IF se salta 
                // y 'claveParaGuardar' mantiene su valor original.

                // --- INICIO DE LA MODIFICACIÓN CENTRADA EN EL ENUM ---

                // 1. Obtenemos el texto seleccionado en el ComboBox.
                string rolSeleccionadoTexto = cbRol.SelectedItem?.ToString() ?? "";

                // 2. Validamos ese texto (esta línea se mantiene igual).
                if (!UsuarioValidacion.RolValido(rolSeleccionadoTexto))
                {
                    MessageBox.Show("Seleccione un rol válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbRol.Focus();
                    return;
                }

                // 3. Si la validación pasa, "traducimos" el texto al enum.
                Enum.TryParse<RolUsuario>(rolSeleccionadoTexto, out RolUsuario rolSeleccionadoEnum);

                // --- FIN DE LA MODIFICACIÓN ---

                // 4. Creamos el objeto Usuario usando el enum ya convertido.
                Usuario oUsuario = new Usuario()
                {
                    IdUsuario = idUsuarioSeleccionado,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Documento = txtNroDocumento.Text.Trim(),
                    Clave = claveParaGuardar,
                    // ✨ ¡Aquí asignamos el enum, solucionando el error!
                    Rol = rolSeleccionadoEnum,
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