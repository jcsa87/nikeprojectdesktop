using System;
using System.Drawing;
using System.Windows.Forms;

namespace nikeproject.Helpers
{
    public static class GridHelper
    {
        public static void PintarInactivos(DataGridView dgv, string nombreColumnaEstado = "Estado")
        {
            dgv.CellFormatting += (s, e) =>
            {
                if (dgv.Columns[e.ColumnIndex].Name == nombreColumnaEstado)
                {
                    var estado = dgv.Rows[e.RowIndex].Cells[nombreColumnaEstado].Value;
                    if (estado != null && estado != DBNull.Value && !Convert.ToBoolean(estado))
                    {
                        dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                        dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            };
        }
    }
}
