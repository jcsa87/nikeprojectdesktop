using nikeproject.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace nikeproject.UserControls
{
    public partial class BackUpControl : UserControl
    {
        public BackUpControl()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtDestino.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                MessageBox.Show("Selecciona una carpeta para guardar el respaldo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreArchivo = $"DBnikeproject_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string rutaCompleta = Path.Combine(txtDestino.Text, nombreArchivo);

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CadenaConexion))
                {
                    con.Open();
                    string query = $@"BACKUP DATABASE DBnikeproject 
                                      TO DISK = '{rutaCompleta}' 
                                      WITH FORMAT, INIT, 
                                      NAME = 'Respaldo DBnikeproject', 
                                      SKIP, NOREWIND, NOUNLOAD, STATS = 10;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"✅ Respaldo completado con éxito.\nUbicación: {rutaCompleta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al generar el respaldo:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

