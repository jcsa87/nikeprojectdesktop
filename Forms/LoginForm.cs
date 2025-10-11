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

namespace nikeproject.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text.Trim();
            string clave = txtClave.Text;

            if (string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Debe ingresar documento y contraseña.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioData oUsuarioData = new UsuarioData();
            // Recordá que tu ObtenerUsuario ahora debe ser la versión segura con Hashing (BCrypt)
            Usuario? usuarioValidado = oUsuarioData.ObtenerUsuario(documento, clave);

            if (usuarioValidado != null)
            {
                // --- INICIO DE LA MODIFICACIÓN ---

                // 1. Guardamos los datos del usuario en la sesión estática.
                // Ahora toda la aplicación sabrá quién está conectado.
                SesionUsuario.IniciarSesion(
                    usuarioValidado.IdUsuario,
                    usuarioValidado.Nombre,
                    usuarioValidado.Apellido,
                    usuarioValidado.Rol
                );

                // 2. Pasamos el rol desde la sesión al formulario principal.
                // Esto asegura que la información es consistente.
                Form1 form = new Form1(SesionUsuario.Rol);

                // --- FIN DE LA MODIFICACIÓN ---

                form.Show();
                this.Hide();
                form.FormClosing += FrmClosing; // Tu lógica para re-abrir el login
            }
            else
            {
                MessageBox.Show("Documento o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Clear();
                txtClave.Focus();
            }
        }

        private void FrmClosing(object? sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtClave.Text = "";
            this.Show();
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un dígito y tampoco es una tecla de control (como backspace).
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, se cancela el evento.
                // El carácter no aparecerá en el TextBox.
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void lbNroDocumento_Click(object sender, EventArgs e)
        {

        }
    }
}
