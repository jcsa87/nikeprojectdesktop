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

        // M�todo general para mostrar cualquier UserControl
        private void MostrarControl(UserControl control)
        {
            panelContenedor.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(control);
        }

        // L�gica de los botones de navegaci�n
        private void pbUsuario_Click(object sender, EventArgs e)
        {
            MostrarControl(new UsuariosControl());
        }

        // Mantienes el m�todo para mostrar el control de Mantenimiento
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

        // L�gica del bot�n de salir
        private void pbSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "�Est�s seguro de que deseas salir del programa?",
                "Confirmar operaci�n",
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

        // M�todo para probar la conexi�n a la base de datos
        private void ProbarConexion()
        {
            try
            {
                using (var oConexion = Conexion.Conectar())
                {
                    oConexion.Open();
                    MessageBox.Show("�Conexi�n exitosa a la base de datos!", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexi�n: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        // Los dem�s m�todos redundantes o vac�os que hab�as mencionado han sido eliminados.
    }
}