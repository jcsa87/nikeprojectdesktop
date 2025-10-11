using Microsoft.Data.SqlClient;
using nikeproject.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nikeproject.UserControls
{
    public partial class BackUpControl : UserControl
    {
        public BackUpControl()
        {
            InitializeComponent();
        }

        private void btnSeleccionarOrigen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    txtOrigen.Text = dialog.SelectedPath;
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
            string origen = txtOrigen.Text.Trim();
            string destino = txtDestino.Text.Trim();

            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino))
            {
                MessageBox.Show("Debes seleccionar tanto una carpeta origen como una de destino.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(origen))
            {
                MessageBox.Show("La carpeta de origen no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombreBase = txtNombreBackup.Text.Trim();
            if (chkAgregarFecha.Checked)
                nombreBase += "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string rutaDestino = Path.Combine(destino, nombreBase);

            try
            {
                if (rbComprimirZip.Checked)
                {
                    string archivoZip = rutaDestino + ".zip";
                    if (File.Exists(archivoZip) && !chkSobrescribir.Checked)
                    {
                        MessageBox.Show("El archivo ZIP ya existe. Activa 'Sobrescribir' si deseas reemplazarlo.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (File.Exists(archivoZip)) File.Delete(archivoZip);
                    ZipFile.CreateFromDirectory(origen, archivoZip, CompressionLevel.Fastest, true);
                    lblResultado.Text = $"✅ Backup ZIP creado: {archivoZip}";
                }
                else
                {
                    // Copia directa
                    string carpetaDestino = rutaDestino;
                    if (!Directory.Exists(carpetaDestino))
                        Directory.CreateDirectory(carpetaDestino);

                    foreach (string archivo in Directory.GetFiles(origen, "*", SearchOption.AllDirectories))
                    {
                        string rutaRelativa = archivo.Substring(origen.Length + 1);
                        string destinoArchivo = Path.Combine(carpetaDestino, rutaRelativa);
                        string carpetaSub = Path.GetDirectoryName(destinoArchivo);
                        if (!Directory.Exists(carpetaSub)) Directory.CreateDirectory(carpetaSub);

                        if (File.Exists(destinoArchivo) && !chkSobrescribir.Checked)
                            continue;

                        File.Copy(archivo, destinoArchivo, true);
                    }

                    lblResultado.Text = $"✅ Copia directa completada en: {carpetaDestino}";
                }

                MessageBox.Show("Respaldo completado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el backup:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

