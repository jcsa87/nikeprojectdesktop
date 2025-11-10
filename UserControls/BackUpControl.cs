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
                            {
                                string nombreTabla = dr.GetString(0);
                                // Agrega la tabla marcada por defecto
                                clbTablas.Items.Add(nombreTabla, true);
                            }
                        }
                    }
                }

                // 🔹 Evita que el usuario cambie los checks manualmente
                clbTablas.SelectionMode = SelectionMode.None;

                // (Opcional) cambia el color para indicar que es informativo
                clbTablas.BackColor = SystemColors.Control;
                clbTablas.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tablas: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BackUpControl_Resize(object sender, EventArgs e)
        {
            // --- 1. Calcular el centro horizontal ---
            // Usamos el GroupBox (que es lo más ancho) para centrar todo.
            int centroHorizontal = (this.ClientSize.Width - grpOpciones.Width) / 2;
            int bordeDerecho = centroHorizontal + grpOpciones.Width;

            // --- 2. Calcular la altura total de tus controles ---
            int alturaTotal = 0;
            alturaTotal += lblDestino.Height + 5; // 5px de espacio
            alturaTotal += txtDestino.Height + 10; // 10px de espacio
            alturaTotal += grpOpciones.Height + 10; // 10px de espacio
            alturaTotal += btnBackup.Height;

            // --- 3. Calcular la posición 'Top' inicial ---
            // Esto centra el bloque completo verticalmente
            int currentY = (this.ClientSize.Height - alturaTotal) / 2;

            // --- 4. Posicionar cada control en orden ---

            // Posiciona 'lblDestino'
            lblDestino.Left = centroHorizontal;
            lblDestino.Top = currentY;

            // Posiciona 'txtDestino' y 'btnSeleccionarDestino'
            currentY = lblDestino.Bottom + 5; // Añade 5px de espacio

            btnSeleccionarDestino.Left = bordeDerecho - btnSeleccionarDestino.Width;
            btnSeleccionarDestino.Top = currentY;

            txtDestino.Left = centroHorizontal;
            txtDestino.Top = currentY;
            txtDestino.Width = btnSeleccionarDestino.Left - centroHorizontal - 5; // 5px de espacio

            // Posiciona 'grpOpciones'
            currentY = txtDestino.Bottom + 10; // Añade 10px de espacio

            grpOpciones.Left = centroHorizontal;
            grpOpciones.Top = currentY;

            // Posiciona 'btnBackup'
            currentY = grpOpciones.Bottom + 10; // Añade 10px de espacio

            btnBackup.Left = centroHorizontal;
            btnBackup.Top = currentY;
            btnBackup.Width = grpOpciones.Width; // Opcional: mismo ancho que el groupbox
        }
    }
}
