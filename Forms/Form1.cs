using Microsoft.Data.SqlClient;
using nikeproject.DataAccess;
using nikeproject.Forms;
using nikeproject.Models;
using nikeproject.UserControls;
using System;
using System.Windows.Forms;

namespace nikeproject
{
    public partial class Form1 : Form
    {
        // 1. Cambiá el tipo del campo de string a RolUsuario.
        private readonly RolUsuario _rol;
        // 2. Cambiá el tipo del parámetro en el constructor.
        public Form1(RolUsuario rol)
        {
            InitializeComponent();
            _rol = rol;
        }


        // 3. Pasá un valor del enum en el constructor por defecto
        public Form1() : this(RolUsuario.Vendedor)
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

        private void ConfigurarMenuPorRol(RolUsuario rol) // <-- 1. Acepta el enum, no un string
        {
            // Habilitar todo por defecto para empezar desde un estado limpio
            pbUsuario.Visible = true;
            pbBackUp.Visible = true;
            pbVentas.Visible = true;
            pbClientes.Visible = true;
            pbProductos.Visible = true;
            lbUsuario.Visible = true;
            lbBackup.Visible = true;
            lbProductos.Visible = true;

            // 2. Usamos un 'switch' que es más limpio y seguro que 'if-else if'
            switch (rol)
            {
                case RolUsuario.Administrador:
                    lRol.Text = "Administrador";
                    // No se necesita hacer nada más, el admin puede ver todo.
                    break;

                case RolUsuario.Supervisor:
                    lRol.Text = "Supervisor";
                    pbUsuario.Visible = false;
                    pbProductos.Visible = false;
                    lbUsuario.Visible = false;
                    lbProductos.Visible = false;
                    break;

                case RolUsuario.Vendedor:
                    lRol.Text = "Vendedor";
                    pbUsuario.Visible = false;
                    pbBackUp.Visible = false;
                    pbProductos.Visible = false;
                    lbUsuario.Visible = false;
                    lbBackup.Visible = false;
                    lbProductos.Visible = false;
                    break;
            }

            ReordenarMenu();
        }

        private void ReordenarMenu()
        {
            int y = 20; // posición inicial en Y
            int separacion = 100; // espacio entre iconos

            // Lista de pares PictureBox + Label
            var items = new (PictureBox, Label)[]
            {
        (pbUsuario, lbUsuario),
        (pbBackUp, lbBackup),
        (pbVentas, lbVentas),
        (pbClientes, lbCliente),
        (pbReportes, lbReportes)

            };

            foreach (var (pb, lb) in items)
            {
                if (pb.Visible)
                {
                    pb.Location = new Point(pb.Location.X, y);
                    lb.Location = new Point(lb.Location.X, y + pb.Height + 2); // label debajo del icono
                    y += separacion; // avanzar para el próximo
                }
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
        private void pbBackUp_Click(object sender, EventArgs e)
        {
            MostrarControl(new BackUpControl());
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

        private void lbUsuario_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void lbProductos_Click(object sender, EventArgs e)
        {

        }

        private void lbVentas_Click(object sender, EventArgs e)
        {

        }

        private void pbReportes_Click(object sender, EventArgs e)
        {
            MostrarControl(new ReportesControl());
        }

        private void lbReportes_Click(object sender, EventArgs e)
        {
            MostrarControl(new ReportesControl());
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

        //private void panelContenedor_Paint(object sender, PaintEventArgs e)
        //{

        //}


        // Se eliminan los métodos duplicados o vacíos, y las referencias a panel3
        // lbMenu_Click_1, label4_Click, label6_Click y panelContenedor_Paint, entre otros, no son necesarios.
    }
}