using System;
using System.Windows.Forms;
using nikeproject.Forms;
using nikeproject.UserControls;
using nikeproject.DataAccess;
using Microsoft.Data.SqlClient;

namespace nikeproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProbarConexion();
            MostrarControl(new UsuariosControl());
        }

        // Método general para mostrar cualquier UserControl
        private void MostrarControl(UserControl control)
        {
            panelContenedor.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(control);
        }

        // Lógica de los botones de navegación
        private void pbUsuario_Click(object sender, EventArgs e)
        {
            MostrarControl(new UsuariosControl());
        }

        // Mantienes el método para mostrar el control de Mantenimiento
        private void pbReportes_Click(object sender, EventArgs e)
        {
            MostrarControl(new MantenimientoControl());
        }

        private void pbVentas_Click(object sender, EventArgs e)
        {
            MostrarControl(new MantenimientoControl());
        }

        private void pbClientes_Click(object sender, EventArgs e)
        {
            MostrarControl(new ClienteControl());
        }

        private void pbProductos_Click(object sender, EventArgs e)
        {
            MostrarControl(new MantenimientoControl());
        }

        // Lógica del botón de salir
        private void pbSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "¿Estás seguro de que deseas salir del programa?",
                "Confirmar operación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        // Método para probar la conexión a la base de datos
        private void ProbarConexion()
        {
            try
            {
                using (var oConexion = Conexion.Conectar())
                {
                    oConexion.Open();
                    MessageBox.Show("¡Conexión exitosa a la base de datos!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        // Los demás métodos redundantes o vacíos que habías mencionado han sido eliminados.
    }
}