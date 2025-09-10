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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MostrarBackUpControl();
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


    }
}
