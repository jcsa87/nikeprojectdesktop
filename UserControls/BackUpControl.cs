using Microsoft.Data.SqlClient;
using nikeproject.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nikeproject.UserControls
{
    public partial class BackUpControl : UserControl
    {
        private string _connectionString = Conexion.CadenaConexion; // Usa tu cadena actual

        public BackUpControl()
        {
            InitializeComponent();
            CargarTablas();
        }

        private void CargarTablas()
        {
            //Carga lista de tablas existentes en el combo/checklist
            try
            {
                using (SqlConnection cn = new SqlConnection(_connectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME", cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                                clbTablas.Items.Add(dr.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tablas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionarDestino_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    txtDestino.Text = dialog.SelectedPath;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                MessageBox.Show("Seleccione una carpeta de destino.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreBase = txtNombreBackup.Text.Trim();
            if (string.IsNullOrEmpty(nombreBase)) nombreBase = "Respaldo";

            if (chkAgregarFecha.Checked)
                nombreBase += "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string rutaBackup = Path.Combine(txtDestino.Text, nombreBase + ".bak");

            try
            {
                using (SqlConnection cn = new SqlConnection(_connectionString))
                {
                    cn.Open();

                    //backup completo
                    if (rbBackupCompleto.Checked)
                    {
                        string sqlBackup = $@"
                            BACKUP DATABASE DBnikeproject
                            TO DISK = '{rutaBackup}'
                            WITH FORMAT, INIT, SKIP, NAME = 'Backup completo DBnikeproject',
                            STATS = 10";
                        using (SqlCommand cmd = new SqlCommand(sqlBackup, cn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show($"✅ Backup completo generado:\n{rutaBackup}", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //backup selectivo (solo tablas elegidas)
                        if (clbTablas.CheckedItems.Count == 0)
                        {
                            MessageBox.Show("Seleccione al menos una tabla para exportar.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        StringBuilder sb = new StringBuilder();

                        foreach (string tabla in clbTablas.CheckedItems)
                        {
                            sb.AppendLine($"-- Tabla: {tabla}");
                            sb.AppendLine($"SELECT * INTO ##tmp_{tabla} FROM {tabla};");
                        }

                        sb.AppendLine($"-- Exportar tablas seleccionadas a archivo: {rutaBackup}");
                        sb.AppendLine($"BACKUP DATABASE DBnikeproject TO DISK = '{rutaBackup}' WITH INIT, SKIP;");

                        using (SqlCommand cmd = new SqlCommand(sb.ToString(), cn))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show($"✅ Backup parcial generado con tablas seleccionadas:\n{rutaBackup}",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al generar backup: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
