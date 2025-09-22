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
            cbRol.SelectedIndex = 0; // Seleccionar el primer elemento por defecto

            // Llenar el ComboBox de estados
            cbEstado.Items.Add("Activo");
            cbEstado.Items.Add("Inactivo");
            cbEstado.SelectedIndex = 0; // Seleccionar el primer elemento por defecto
        }

        private void CargarUsuarios()
        {
            UsuarioData usuarioData = new UsuarioData();
            dgvUsuarios.DataSource = usuarioData.ListarUsuarios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar la confirmación de la clave
                if (!UsuarioValidacion.ConfirmarClave(txtClave.Text, txtConfirmarClave.Text))
                {
                    MessageBox.Show("⚠️ La clave y la confirmación no coinciden. Por favor, verifícalas.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                Usuario oUsuario = new Usuario()
                {
                    NombreCompleto = txtNombreCompleto.Text.Trim(),
                    Documento = txtNroDocumento.Text.Trim(),
                    Clave = txtClave.Text.Trim(),
                    Rol = cbRol.SelectedItem?.ToString() ?? "Vendedor",
                    Estado = (cbEstado.SelectedItem?.ToString() == "Activo") // <-- Corregido aquí
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
            txtNombreCompleto.Clear();
            txtNroDocumento.Clear();
            txtClave.Clear();
            txtConfirmarClave.Clear();
            cbRol.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0; // <-- Corregido aquí
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Asegúrate de que estás en la columna 'Estado'
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Estado")
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

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que no se haga clic en la fila de encabezado
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvUsuarios.Rows[e.RowIndex];

                // Asigna el IdUsuario de la fila seleccionada a la variable
                // Convert.ToInt32 es necesario porque el valor en la celda es un objeto
                idUsuarioSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["IdUsuario"].Value);

                // Opcional: llenar los campos del formulario con los datos de la fila
                txtNombreCompleto.Text = filaSeleccionada.Cells["NombreCompleto"].Value.ToString();
                txtNroDocumento.Text = filaSeleccionada.Cells["Documento"].Value.ToString();
                txtClave.Text = filaSeleccionada.Cells["Clave"].Value.ToString();
                cbRol.Text = filaSeleccionada.Cells["Rol"].Value.ToString();
                cbEstado.Text = (Convert.ToBoolean(filaSeleccionada.Cells["Estado"].Value) == true) ? "Activo" : "Inactivo";
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado > 0)
            {
                Usuario oUsuario = new Usuario()
                {
                    IdUsuario = idUsuarioSeleccionado,
                    NombreCompleto = txtNombreCompleto.Text.Trim(),
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
                if (MessageBox.Show("¿Está seguro que desea eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UsuarioData usuarioData = new UsuarioData();
                    if (usuarioData.EliminarUsuario(idUsuarioSeleccionado))
                    {
                        MessageBox.Show("✅ Usuario eliminado correctamente.");
                        CargarUsuarios();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("⚠️ No se pudo eliminar el usuario.");
                    }
                }
            }
            else
            {
                MessageBox.Show("⚠️ Seleccione un usuario para eliminar.");
            }
        }



        // --- MÉTODOS Y EVENTOS SIN FUNCIONALIDAD ---
        // Se han eliminado todos los métodos y eventos vacíos o sin usar
        // para mantener el código limpio y organizado.
    }
}