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
            //MostrarUsuariosControl();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var usuariosControl = new UsuariosControl();
            usuariosControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(usuariosControl);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var backUpControl = new BackUpControl();
            backUpControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(backUpControl);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //panel3.Controls.Clear();
            //var ventasControl = new VentasControl();
            //ventasControl.Dock = DockStyle.Fill;
            //panel3.Controls.Add(ventasControl);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            var clientesControl = new ClienteControl();
            clientesControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(clientesControl);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //panel3.Controls.Clear();
            //var productosControl = new ProductosControl();
            //productosControl.Dock = DockStyle.Fill;
            //panel3.Controls.Add(productosControl);
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

        private void pictureBox8_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "¿Estás seguro de que deseas salir del programa?",
                "Confirmar operación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {

            }
        }
    }
}
