using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using nikeproject.Models;

namespace nikeproject.DataAccess
{
    public class DetalleVentaData
    {
        public static bool InsertarDetalle(DetalleVenta d)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.CadenaConexion))
            {
                cn.Open();
                string sql = @"INSERT INTO DETALLE_VENTA
                (IdVenta, IdProducto, Cantidad, PrecioUnitario, SubTotal)
                VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario, @SubTotal);";

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
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }



        public static List<DetalleVenta> ListarPorVenta(int idVenta)
        {
            var lista = new List<DetalleVenta>();

            using (var cn = new SqlConnection(Conexion.CadenaConexion))
            {
                cn.Open();
                string sql = @"
                    SELECT 
                        d.IdDetalle,
                        d.IdVenta,
                        d.IdProducto,
                        d.Cantidad,
                        d.PrecioUnitario,
                        d.SubTotal,
                        p.Nombre,      -- para llenar Producto.Nombre
                        p.ImagenRuta
                    FROM DETALLE_VENTA d
                    INNER JOIN PRODUCTO p ON p.IdProducto = d.IdProducto
                    WHERE d.IdVenta = @idVenta
                    ORDER BY d.IdDetalle;";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var det = new DetalleVenta
                            {
                                IdDetalle = dr.GetInt32(0),
                                IdVenta = dr.GetInt32(1),
                                IdProducto = dr.GetInt32(2),
                                Cantidad = dr.GetInt32(3),
                                PrecioUnitario = dr.GetDecimal(4),
                                SubTotal = dr.GetDecimal(5),
                                Producto = new Producto
                                {
                                    Nombre = dr.GetString(6),
                                    ImagenRuta = dr.IsDBNull(7) ? null : dr.GetString(7)
                                }

                            };
                            lista.Add(det);
                        }
                    }
                }
            }

            return lista;
        }
    }
}
