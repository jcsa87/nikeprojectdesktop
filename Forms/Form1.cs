using nikeproject;
using nikeproject.Forms;
using nikeproject.UserControls;

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
            MostrarUsuariosControl();
        }

        private void pbMenu_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pbMenu_Click_1(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
        }
        private void pbUsuario_Click(object sender, EventArgs e)

        {
            MostrarUsuariosControl();
        }



        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.Controls.Clear();
        }

        //usuarios
        private void MostrarUsuariosControl()
        {
            panel3.Controls.Clear();
            var usuariosControl = new UsuariosControl();
            usuariosControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(usuariosControl);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MostrarUsuariosControl();
        }

        //reportes
        private void pbReportes_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var reportesControl = new ReportesControl();
            reportesControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(reportesControl);
        }
        private void lbMenu_Click_1(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var reportesControl = new ReportesControl();
            reportesControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(reportesControl);
        }

        //ventas
        private void pbVentas_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var ventasControl = new VentaControl();
            ventasControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(ventasControl);
        }
        private void label4_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var ventasControl = new VentaControl();
            ventasControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(ventasControl);
        }

        //clientes
        private void pbClientes_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var clienteControl = new ClienteControl();
            clienteControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(clienteControl);
        }
        private void label5Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var clienteControl = new ClienteControl();
            clienteControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(clienteControl);
        }

        //productos
        private void pbProductos_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var productosControl = new ProductoControl();
            productosControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(productosControl);
        }


        private void label6_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var productosControl = new ProductoControl();
            productosControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(productosControl);
        }


        

        //boton salir
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
                LoginForm loginForm = new LoginForm();

                loginForm.Show();
                this.Hide();
            }
            else
            {

            }
        }

        private void pbSalir_DoubleClick(object sender, EventArgs e)
        {

        }


        //back up (fuera de uso)
        //private void MostrarBackUpControl()
        //{
        //    panel3.Controls.Clear();
        //    var backUpControl = new BackUpControl();
        //    backUpControl.Dock = DockStyle.Fill;
        //    panel3.Controls.Add(backUpControl);
        //}

    }
}
