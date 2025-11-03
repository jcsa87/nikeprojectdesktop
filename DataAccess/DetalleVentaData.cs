using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using nikeproject.Models;

namespace nikeproject.DataAccess
{
    public class DetalleVentaData
    {

        public static List<DetalleVenta> ListarPorVenta(int idVenta)
        {
            List<DetalleVenta> lista = new();

            using (SqlConnection cn = new SqlConnection(Conexion.CadenaConexion))
            {
                cn.Open();
                string query = @"
            SELECT dv.IdDetalle,
                   dv.IdVenta,
                   dv.IdProducto,
                   p.Nombre AS NombreProducto,
                   dv.Cantidad,
                   dv.PrecioUnitario,
                   dv.SubTotal
            FROM DETALLE_VENTA dv
            INNER JOIN PRODUCTO p ON dv.IdProducto = p.IdProducto
            WHERE dv.IdVenta = @IdVenta";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DetalleVenta
                            {
                                IdDetalle = Convert.ToInt32(dr["IdDetalle"]), // 👈 ahora usa el nombre correcto
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"])
                            });
                        }
                    }
                }
            }

            return lista;
        }



        public static bool InsertarDetalle(DetalleVenta d)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.CadenaConexion))
                {
                    cn.Open();
                    string sql = @"
                        INSERT INTO DETALLE_VENTA
                        (IdVenta, IdProducto, Cantidad, PrecioUnitario, SubTotal)
                        VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario, @SubTotal);
                    ";

                    // Validación de cantidad
                    if (d.Cantidad <= 0)
                    {
                        MessageBox.Show("⚠️ La cantidad debe ser mayor que cero.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdVenta", d.IdVenta);
                        cmd.Parameters.AddWithValue("@IdProducto", d.IdProducto);
                        cmd.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                        cmd.Parameters.AddWithValue("@PrecioUnitario", d.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@SubTotal", d.SubTotal);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar detalle de venta:\n{ex.Message}",
                    "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        
    }
}
