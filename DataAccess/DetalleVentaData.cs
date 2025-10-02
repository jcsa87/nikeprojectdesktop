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
            List<DetalleVenta> lista = new List<DetalleVenta>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.CadenaConexion))
            {
                oConexion.Open();
                string query = @"SELECT IdDetalle, IdVenta, IdProducto, Cantidad, PrecioUnitario, SubTotal
                                 FROM DETALLE_VENTA WHERE IdVenta = @IdVenta";

                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DetalleVenta
                            {
                                IdDetalle = Convert.ToInt32(dr["IdDetalle"]),
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
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
    }
}
