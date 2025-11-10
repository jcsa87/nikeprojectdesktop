using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using nikeproject.Models;
using nikeproject.DataAccess;
using nikeproject.Forms.FacturaFormNS;

namespace nikeproject.Data
{
    public class VentaData
    {
        // =====================================================
        // 🔹 OBTENER DATOS DEL VENDEDOR POR ID DE VENTA
        // =====================================================
        public static string ObtenerDatosVendedor(int idVenta)
        {
            string resultado = null;

            using (SqlConnection cn = new SqlConnection(Conexion.CadenaConexion))
            {
                string query = @"
                    SELECT u.Nombre + ' ' + u.Apellido AS Vendedor
                    FROM VENTA v
                    INNER JOIN USUARIO u ON v.IdUsuario = u.IdUsuario
                    WHERE v.IdVenta = @IdVenta";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    cn.Open();

                    var obj = cmd.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value)
                        resultado = obj.ToString();
                }
            }

            return resultado;
        }

        // =====================================================
        // 🔹 OBTENER FACTURA POR ID DE VENTA (FACTURAFORM)
        // =====================================================
        public FacturaData ObtenerFacturaPorId(int idVenta)
        {
            var factura = new FacturaData
            {
                NumeroFactura = $"VENT-{idVenta:000000}",
                PorcentajeIva = 0.21m,
                Empresa = new EmpresaInfo
                {
                    Nombre = "Nike Corrientes",
                    Lema = "Calzado y ropa deportiva",
                    Direccion = "San Martín 1234",
                    CiudadCodigoPostal = "Corrientes, 3400",
                    Telefono = "Tel. (379) 555-0190",
                    Fax = "Fax (379) 555-0191",
                    Logo = null
                }
            };

            using (var cn = new SqlConnection(Conexion.CadenaConexion))
            {
                cn.Open();

                // CABECERA: VENTA + CLIENTE + USUARIO
                using (var cmd = new SqlCommand(@"
                    SELECT v.IdVenta,
                           v.FechaRegistro,
                           v.MontoTotal,
                           v.NumeroDocumento AS TipoPago,
                           c.Nombre AS CliNombre,
                           c.Apellido AS CliApellido,
                           c.Documento AS CliDocumento,
                           c.Correo AS CliCorreo,
                           c.Telefono AS CliTelefono,
                           u.Nombre AS UsuNombre,
                           u.Apellido AS UsuApellido
                    FROM   VENTA v
                    INNER JOIN CLIENTE c ON c.IdCliente = v.IdCliente
                    INNER JOIN USUARIO u ON u.IdUsuario = v.IdUsuario
                    WHERE  v.IdVenta = @idVenta;", cn))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    using var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        factura.Fecha = Convert.ToDateTime(dr["FechaRegistro"]);
                        factura.TipoPago = dr["TipoPago"]?.ToString() ?? "N/D";

                        factura.Cliente = new ClienteInfo
                        {
                            Nombre = $"{dr["CliNombre"]} {dr["CliApellido"]}",
                            Compania = "Particular",
                            Direccion = "",
                            CiudadCodigoPostal = "",
                            Telefono = dr["CliTelefono"]?.ToString() ?? "",
                            Documento = dr["CliDocumento"]?.ToString() ?? ""
                        };

                        factura.Vendedor = $"{dr["UsuNombre"]} {dr["UsuApellido"]}";
                    }
                }

                // DETALLE: DETALLE_VENTA + PRODUCTO
                using (var cmdDet = new SqlCommand(@"
                    SELECT p.Codigo,
                           p.Nombre AS ProdNombre,
                           dv.Cantidad,
                           dv.PrecioUnitario,
                           dv.SubTotal
                    FROM   DETALLE_VENTA dv
                    INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
                    WHERE  dv.IdVenta = @idVenta
                    ORDER BY dv.IdDetalle;", cn))
                {
                    cmdDet.Parameters.AddWithValue("@idVenta", idVenta);
                    using var drDet = cmdDet.ExecuteReader();
                    while (drDet.Read())
                    {
                        factura.Items.Add(new ItemFactura
                        {
                            Codigo = drDet["Codigo"]?.ToString() ?? "",
                            Descripcion = drDet["ProdNombre"]?.ToString() ?? "",
                            Cantidad = Convert.ToInt32(drDet["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(drDet["PrecioUnitario"])
                        });
                    }
                }
            }

            return factura;
        }

        // =====================================================
        // 🔹 OBTENER UNA VENTA POR ID
        // =====================================================
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

        // =====================================================
        // 🔹 INSERTAR UNA NUEVA VENTA
        // =====================================================
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

        // =====================================================
        // 🔹 LISTAR TODAS LAS VENTAS (CON FILTRO POR ROL)
        // =====================================================
        public static List<dynamic> ListarVentas()
        {
            var lista = new List<dynamic>();

            using (SqlConnection cn = new SqlConnection(Conexion.CadenaConexion))
            {
                cn.Open();

                string sql = @"
                    SELECT v.IdVenta, 
                           v.IdUsuario,
                           v.NumeroDocumento, 
                           v.FechaRegistro, 
                           v.MontoTotal,
                           c.Nombre + ' ' + c.Apellido AS Cliente,
                           u.Nombre + ' ' + u.Apellido AS Vendedor
                    FROM VENTA v
                    INNER JOIN CLIENTE c ON v.IdCliente = c.IdCliente
                    INNER JOIN USUARIO u ON v.IdUsuario = u.IdUsuario";

                // Si el usuario actual es vendedor, filtra solo sus ventas
                if (SesionUsuario.Rol == RolUsuario.Vendedor)
                {
                    sql += " WHERE v.IdUsuario = @IdUsuario";
                }

                sql += " ORDER BY v.FechaRegistro DESC";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
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
                                IdUsuario = dr.GetInt32(1),
                                NumeroDocumento = dr.GetString(2),
                                FechaRegistro = dr.GetDateTime(3),
                                MontoTotal = dr.GetDecimal(4),
                                Cliente = dr.GetString(5),
                                Vendedor = dr.GetString(6)
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // =====================================================
        // 🔹 REGISTRAR UNA VENTA CON DETALLES (TRANSACCIÓN)
        // =====================================================
        public static bool RegistrarVenta(Venta venta)
        {
            bool resultado = false;

            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                SqlTransaction transaction = oConexion.BeginTransaction();

                try
                {
                    // Insertar venta
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

                    // Insertar detalles
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
                catch
                {
                    transaction.Rollback();
                    resultado = false;
                }
            }

            return resultado;
        }

        // =====================================================
        // 🔹 LISTAR DETALLES POR VENTA
        // =====================================================
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

        // =====================================================
        // 🔹 ANULAR UNA VENTA
        // =====================================================
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
