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


        private void pbMenu_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Prueba la conexi�n a la base de datos al iniciar el programa
            //ProbarConexion();

            // Muestra el control de usuarios por defecto
            panelContenedor.Controls.Clear();
           // MostrarControl(new UsuariosControl());
        }

        // M�todo general para mostrar cualquier UserControl en el panelContenedor
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
        /*
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
        }*/

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }


        // Se eliminan los m�todos duplicados o vac�os, y las referencias a panel3
        // lbMenu_Click_1, label4_Click, label6_Click y panelContenedor_Paint, entre otros, no son necesarios.
    }
}