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

        private readonly string _rol;
        public Form1(string rol)
        {
            InitializeComponent();
            _rol = rol;
        }

        public Form1() : this("Vendedor") // Rol por defecto para diseño
        {
        }


        private void pbMenu_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Habilita/deshabilita íconos según el rol
            ConfigurarMenuPorRol(_rol);
            panelContenedor.Controls.Clear();
        }

        private void ConfigurarMenuPorRol(string rol)
        {
            // Ejemplo: pbUsuario, pbReportes, pbVentas, pbClientes, pbProductos son los íconos
            // Ajusta según los nombres reales de tus PictureBox o botones

            // Primero, habilita todo
            pbUsuario.Enabled = true;
            pbReportes.Enabled = true;
            pbVentas.Enabled = true;
            pbClientes.Enabled = true;
            pbProductos.Enabled = true;

            if (rol == "Administrador")
            {
                // Acceso total
            }
            else if (rol == "Supervisor")
            {
                pbUsuario.Enabled = false;   // No puede gestionar usuarios
                pbProductos.Enabled = false; // No puede gestionar productos
            }
            else if (rol == "Vendedor")
            {
                pbUsuario.Enabled = false;
                pbReportes.Enabled = false;
                pbProductos.Enabled = false;
            }
        }

        // Método general para mostrar cualquier UserControl en el panelContenedor
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

        // Muestra el control de Mantenimiento para Reportes
        private void pbReportes_Click(object sender, EventArgs e)
        {
            MostrarControl(new ReportesControl());
        }

        // Muestra el control de Mantenimiento para Ventas
        private void pbVentas_Click(object sender, EventArgs e)
        {
            MostrarControl(new VentaControl());
        }

        // Muestra el control de Clientes
        private void pbClientes_Click(object sender, EventArgs e)
        {
            MostrarControl(new ClienteControl());
        }

        // Muestra el control de Mantenimiento para Productos
        private void pbProductos_Click(object sender, EventArgs e)
        {
            MostrarControl(new ProductoControl());
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
        /*
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
        }*/

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }


        // Se eliminan los métodos duplicados o vacíos, y las referencias a panel3
        // lbMenu_Click_1, label4_Click, label6_Click y panelContenedor_Paint, entre otros, no son necesarios.
    }
}