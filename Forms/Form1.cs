using Microsoft.Data.SqlClient;
using nikeproject.DataAccess;
using nikeproject.Forms;
using nikeproject.Models;
using nikeproject.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace nikeproject
{
    public partial class Form1 : Form
    {
        private readonly RolUsuario _rol;

        public Form1(RolUsuario rol)
        {
            InitializeComponent();
            // Conecta el evento Resize con el método que posiciona el botón

            _rol = rol;
        }

        public Form1() : this(RolUsuario.Vendedor) { }


        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarMenuPorRol(_rol); // ¡Perfecto! Esto llama a ReordenarMenu
            panelContenedor.Controls.Clear();

            // Configurar flowMenu (esto está bien)
            flowMenu.Dock = DockStyle.Fill;
            flowMenu.FlowDirection = FlowDirection.TopDown;
            flowMenu.WrapContents = false;
            flowMenu.AutoScroll = false;
            flowMenu.AutoSize = false;
            flowMenu.Padding = new Padding(0);
            flowMenu.Margin = new Padding(0);
        }





        private void ConfigurarMenuPorRol(RolUsuario rol)
        {
            // Mostrar todo por defecto
            pbUsuario.Visible = true;
            pbBackUp.Visible = true;
            pbVentas.Visible = true;
            pbClientes.Visible = true;
            pbProductos.Visible = true;
            pbReportes.Visible = true;
            lbUsuario.Visible = true;
            lbBackup.Visible = true;
            lbVentas.Visible = true;
            lbCliente.Visible = true;
            lbProductos.Visible = true;
            lbReportes.Visible = true;

            switch (rol)
            {
                case RolUsuario.Administrador:
                    lRol.Text = "Administrador";
                    // No se oculta nada
                    break;

                case RolUsuario.Supervisor:
                    lRol.Text = "Supervisor";
                    // No puede gestionar usuarios ni backups
                    pbUsuario.Visible = false;
                    pbBackUp.Visible = false;
                    lbUsuario.Visible = false;
                    lbBackup.Visible = false;
                    break;

                case RolUsuario.Vendedor:
                    lRol.Text = "Vendedor";
                    // No puede gestionar usuarios, backups, ni ver reportes
                    pbUsuario.Visible = false;
                    pbBackUp.Visible = false;
                    pbReportes.Visible = false; // <-- Modificación clave
                    lbUsuario.Visible = false;
                    lbBackup.Visible = false;
                    lbReportes.Visible = false; // <-- Modificación clave
                    break;
            }

            ReordenarMenu();
        }

        private void ReordenarMenu()
        {
            // Limpia el FlowLayout y reacomoda ítems visibles
            flowMenu.Controls.Clear();

            var items = new (PictureBox pb, Label lb)[]
            {
                (pbUsuario, lbUsuario),
                (pbBackUp, lbBackup),
                (pbVentas, lbVentas),
                (pbClientes, lbCliente),
                (pbProductos, lbProductos),
                (pbReportes, lbReportes)
            };

            foreach (var (pb, lb) in items)
            {
                if (pb.Visible)
                {
                    Panel itemPanel = new Panel
                    {
                        Width = flowMenu.Width - 20,
                        Height = pb.Height + (lb?.Height ?? 0) + 10,
                        Margin = new Padding(0, 0, 0, 5),
                        BackColor = Color.Transparent
                    };

                    pb.Dock = DockStyle.Top;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Cursor = Cursors.Hand;
                    itemPanel.Controls.Add(pb);

                    if (lb != null)
                    {
                        lb.Dock = DockStyle.Bottom;
                        lb.TextAlign = ContentAlignment.MiddleCenter;
                        lb.Cursor = Cursors.Hand;
                        itemPanel.Controls.Add(lb);
                    }

                    flowMenu.Controls.Add(itemPanel);
                }
            }
        }

        // -------------------------------
        // Eventos de los iconos del menú
        // -------------------------------

        private void pbUsuario_Click(object sender, EventArgs e)
        {
            MostrarControl(new UsuariosControl());
        }

        private void pbBackUp_Click(object sender, EventArgs e)
        {
            MostrarControl(new BackUpControl());
        }

        private void pbVentas_Click(object sender, EventArgs e)
        {
            MostrarControl(new VentaControl());
        }

        private void pbClientes_Click(object sender, EventArgs e)
        {
            MostrarControl(new ClienteControl());
        }

        private void pbProductos_Click(object sender, EventArgs e)
        {
            MostrarControl(new ProductoControl());
        }

        private void pbReportes_Click(object sender, EventArgs e)
        {
            MostrarControl(new ReportesControl());
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
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        // -------------------------------
        // Función para mostrar los UserControls
        // -------------------------------
        private void MostrarControl(UserControl control)
        {
            panelContenedor.Controls.Clear();
            control.Dock = DockStyle.Fill; // <--- Déjalo así de simple
            panelContenedor.Controls.Add(control);
        }




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

        //private void panelContenedor_Paint(object sender, PaintEventArgs e)
        //{

        //}


        // Se eliminan los métodos duplicados o vacíos, y las referencias a panel3
        // lbMenu_Click_1, label4_Click, label6_Click y panelContenedor_Paint, entre otros, no son necesarios.
    
