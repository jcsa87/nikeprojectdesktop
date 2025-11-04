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

        public static Venta ObtenerVentaPorId(int idVenta)
        {
            Venta venta = null;

            using (SqlConnection cn = new SqlConnection(Conexion.CadenaConexion))
            {
                cn.Open();
                string query = @"
                    SELECT v.IdVenta,
                   v.NumeroDocumento,
                   v.FechaRegistro,
                   v.MontoTotal,
                   c.Nombre AS NombreCliente,
                   c.Apellido AS ApellidoCliente,
                   c.Documento,
                   c.Telefono,
                   c.Correo,
                   u.Nombre AS NombreUsuario,
                   u.Apellido AS ApellidoUsuario
                    FROM VENTA v
                    INNER JOIN CLIENTE c ON v.IdCliente = c.IdCliente
                    INNER JOIN USUARIO u ON v.IdUsuario = u.IdUsuario
                    WHERE v.IdVenta = @IdVenta";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            venta = new Venta
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                NombreCliente = $"{dr["NombreCliente"]} {dr["ApellidoCliente"]}",
                                DocumentoCliente = dr["Documento"].ToString(),
                                TelefonoCliente = dr["Telefono"].ToString(),
                                CorreoCliente = dr["Correo"].ToString(),
                                NombreVendedor = $"{dr["NombreUsuario"]} {dr["ApellidoUsuario"]}"
                            };
                        }
                    }
                }
            }
            return venta;
        }





        public static int InsertarVenta(Venta v)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.CadenaConexion))
            {
                cn.Open();
                string sql = @"
                INSERT INTO VENTA (IdCliente, IdUsuario, NumeroDocumento, FechaRegistro, MontoTotal, Estado)
                VALUES (@IdCliente, @IdUsuario, @NumeroDocumento, @FechaRegistro, @MontoTotal, @Estado);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", v.IdCliente);
                    cmd.Parameters.AddWithValue("@IdUsuario", v.IdUsuario);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", v.NumeroDocumento);
                    cmd.Parameters.AddWithValue("@FechaRegistro", v.FechaRegistro);
                    cmd.Parameters.AddWithValue("@MontoTotal", v.MontoTotal);
                    cmd.Parameters.AddWithValue("@Estado", v.Estado ? 1 : 0);

                    object o = cmd.ExecuteScalar();
                    return (o == null) ? 0 : Convert.ToInt32(o);
                }
            }
        }

        public static List<dynamic> ListarVentas()
        {
            var lista = new List<dynamic>();

            using (SqlConnection cn = new SqlConnection(Conexion.CadenaConexion))
            {
                cn.Open();

                // Base query
                string sql = @"
            SELECT v.IdVenta, 
                   v.NumeroDocumento, 
                   v.FechaRegistro, 
                   v.MontoTotal,
                   c.Nombre + ' ' + c.Apellido AS Cliente
            FROM VENTA v
            INNER JOIN CLIENTE c ON v.IdCliente = c.IdCliente";

                // Si el usuario actual es vendedor, solo muestra sus ventas
                if (SesionUsuario.Rol == RolUsuario.Vendedor)
                {
                    sql += " WHERE v.IdUsuario = @IdUsuario";
                }

                sql += " ORDER BY v.FechaRegistro DESC";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    // Agregar parámetro solo si es vendedor
                    if (SesionUsuario.Rol == RolUsuario.Vendedor)
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", SesionUsuario.IdUsuario);
                    }

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new
                            {
                                IdVenta = dr.GetInt32(0),
                                NumeroDocumento = dr.GetString(1),
                                FechaRegistro = dr.GetDateTime(2),
                                MontoTotal = dr.GetDecimal(3),
                                Cliente = dr.GetString(4)
                            });
                        }
                    }
                }
            }

            return lista;
        }


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
