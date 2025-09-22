using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nikeproject.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Suponiendo que los TextBox se llaman txtDocumento y txtClave
            string usuario = txtDocumento.Text.Trim();
            string clave = txtClave.Text.Trim();

            if (usuario == "admin" && clave == "admin")
            {
                Form1 form = new Form1();
                form.Show();
                this.Hide();

                form.FormClosing += FrmClosing;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Intente nuevamente.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Clear();
                txtClave.Focus();
            }
        }

        private void FrmClosing(object? sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtClave.Text = "";
            this.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
