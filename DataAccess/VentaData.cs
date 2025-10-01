using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using nikeproject.Models;
using nikeproject.DataAccess;

namespace nikeproject.Data
{
    public class VentaData
    {
        public static bool RegistrarVenta(Venta venta)
        {
            bool resultado = false;

            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                SqlTransaction transaction = oConexion.BeginTransaction();

                try
                {
                    // Insertar la venta
                    string queryVenta = @"INSERT INTO VENTA (IdCliente, IdUsuario, NumeroDocumento, MontoTotal, Estado)
                                          OUTPUT INSERTED.IdVenta
                                          VALUES (@IdCliente, @IdUsuario, @NumeroDocumento, @MontoTotal, 1)";

                    int idVentaGenerado;
                    using (SqlCommand cmd = new SqlCommand(queryVenta, oConexion, transaction))
                    {
                        cmd.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
                        cmd.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                        cmd.Parameters.AddWithValue("@NumeroDocumento", venta.NumeroDocumento);
                        cmd.Parameters.AddWithValue("@MontoTotal", venta.MontoTotal);

                        idVentaGenerado = (int)cmd.ExecuteScalar();
                    }

                    // Insertar los detalles
                    foreach (var detalle in venta.Detalles)
                    {
                        string queryDetalle = @"INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario, SubTotal)
                                                VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario, @SubTotal)";
                        using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, oConexion, transaction))
                        {
                            cmdDetalle.Parameters.AddWithValue("@IdVenta", idVentaGenerado);
                            cmdDetalle.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                            cmdDetalle.Parameters.AddWithValue("@SubTotal", detalle.SubTotal);
                            cmdDetalle.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    resultado = true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    resultado = false;
                }
            }

            return resultado;
        }

        public static List<Venta> ListarVentas()
        {
            var lista = new List<Venta>();

            using (SqlConnection oConexion = Conexion.Conectar())
            {
                string query = @"
            SELECT v.IdVenta, v.NumeroDocumento, v.FechaRegistro, v.MontoTotal, v.Estado,
                   (c.Nombre + ' ' + c.Apellido) AS ClienteNombre,
                   (u.Nombre + ' ' + u.Apellido) AS UsuarioNombre
            FROM VENTA v
            INNER JOIN CLIENTE c ON v.IdCliente = c.IdCliente
            INNER JOIN USUARIO u ON v.IdUsuario = u.IdUsuario";

                SqlCommand cmd = new SqlCommand(query, oConexion);
                oConexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Venta
                        {
                            IdVenta = Convert.ToInt32(dr["IdVenta"]),
                            NumeroDocumento = dr["NumeroDocumento"].ToString(),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                            Estado = Convert.ToBoolean(dr["Estado"]),

                            // 👇 ahora ClienteNombre es la concatenación
                            Cliente = new Cliente
                            {
                                Nombre = dr["ClienteNombre"].ToString()
                            },

                            // 👇 igual para el usuario
                            Usuario = new Usuario
                            {
                                Nombre = dr["UsuarioNombre"].ToString()
                            }
                        });
                    }
                }
            }

            return lista;
        }



        public static List<DetalleVenta> ListarDetallesPorVenta(int idVenta)
        {
            var lista = new List<DetalleVenta>();

            using (SqlConnection oConexion = Conexion.Conectar())
            {
                string query = @"SELECT d.IdDetalle, d.IdProducto, d.Cantidad, d.PrecioUnitario, d.SubTotal,
                                        p.Nombre AS ProductoNombre
                                 FROM DETALLE_VENTA d
                                 INNER JOIN PRODUCTO p ON d.IdProducto = p.IdProducto
                                 WHERE d.IdVenta = @IdVenta";

                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                oConexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new DetalleVenta
                        {
                            IdDetalle = Convert.ToInt32(dr["IdDetalle"]),
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                            SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                            Producto = new Producto { Nombre = dr["ProductoNombre"].ToString() }
                        });
                    }
                }
            }

            return lista;
        }

        public static bool AnularVenta(int idVenta)
        {
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                string query = "UPDATE VENTA SET Estado = 0 WHERE IdVenta=@IdVenta";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                oConexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
