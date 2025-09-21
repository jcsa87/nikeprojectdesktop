using nikeproject.Forms;

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

        private void lbMenu_Click_1(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
        }

        private void pbUsuario_Click(object sender, EventArgs e)

        {
            MostrarUsuariosControl();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MostrarUsuariosControl();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MostrarUsuariosControl()
        {
            panel3.Controls.Clear();
            var usuariosControl = new UsuariosControl();
            usuariosControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(usuariosControl);
        }

        private void MostrarBackUpControl()
        {
            panel3.Controls.Clear();
            var backUpControl = new BackUpControl();
            backUpControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(backUpControl);
        }

        private void pbSalir_DoubleClick(object sender, EventArgs e)
        {

        }

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

        private void pbReportes_Click(object sender, EventArgs e)
        {

        }

        private void pbVentas_Click(object sender, EventArgs e)
        {

        }

        private void pbClientes_Click(object sender, EventArgs e)
        {

        }

        private void pbProductos_Click(object sender, EventArgs e)
        {

        }
    }
}
