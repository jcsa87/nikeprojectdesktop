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

        public Form1() : this("Vendedor") // Rol por defecto para dise�o
        {
        }


        private void pbMenu_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Habilita/deshabilita �conos seg�n el rol
            ConfigurarMenuPorRol(_rol);
            panelContenedor.Controls.Clear();
        }

        private void ConfigurarMenuPorRol(string rol)
        {

            lRol.Enabled = true;
            pbUsuario.Enabled = true;
            pbReportes.Enabled = true;
            pbVentas.Enabled = true;
            pbClientes.Enabled = true;
            pbProductos.Enabled = true;

            if (rol == "Administrador")
            {
                lRol.Text = "Administrador";
            }
            else if (rol == "Supervisor")
            {
                pbUsuario.Enabled = false;   // No puede gestionar usuarios
                pbProductos.Enabled = false; // No puede gestionar productos

                pbUsuario.Visible = false;   // No puede gestionar usuarios
                pbProductos.Visible = false; // No puede gestionar productos
                lbUsuario.Visible = false;
                lbProductos.Visible = false;


                lRol.Text = "Supervisor";
            }
            else if (rol == "Vendedor")
            {
                pbUsuario.Enabled = false;
                pbReportes.Enabled = false;
                pbProductos.Enabled = false;

                pbUsuario.Visible = false;
                pbReportes.Visible = false;
                pbProductos.Visible = false;
                lbUsuario.Visible = false;
                lbReporte.Visible = false;
                lbProductos.Visible = false;

                lRol.Text = "Vendedor";

            }

            ReordenarMenu();
        }

        private void ReordenarMenu()
        {
            int y = 20; // posici�n inicial en Y
            int separacion = 100; // espacio entre iconos

            // Lista de pares PictureBox + Label en el orden que quer�s
            var items = new (PictureBox, Label)[]
            {
        (pbUsuario, lbUsuario),
        (pbReportes, lbReporte),
        (pbVentas, lbVentas),
        (pbClientes, lbCliente),
        (pbProductos, lbProductos)
            };

            foreach (var (pb, lb) in items)
            {
                if (pb.Visible)
                {
                    pb.Location = new Point(pb.Location.X, y);
                    lb.Location = new Point(lb.Location.X, y + pb.Height + 2); // label debajo del icono
                    y += separacion; // avanzar para el pr�ximo
                }
            }
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

        private void lbUsuario_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        //private void panelContenedor_Paint(object sender, PaintEventArgs e)
        //{

        //}


        // Se eliminan los m�todos duplicados o vac�os, y las referencias a panel3
        // lbMenu_Click_1, label4_Click, label6_Click y panelContenedor_Paint, entre otros, no son necesarios.
    }
}