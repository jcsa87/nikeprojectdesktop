using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using nikeproject.Models;
using nikeproject.DataAccess;

namespace nikeproject.Data
{
    public class ProductoData
    {

        public static bool DescontarStock(int idProducto, int cantidad)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.CadenaConexion))
            {
                cn.Open();
                string sql = @"UPDATE PRODUCTO
                               SET Stock = Stock - @Cantidad
                               WHERE IdProducto = @IdProducto AND Stock >= @Cantidad;";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool AgregarProducto(Producto p)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    string query = @"INSERT INTO PRODUCTO
                            (Codigo, Nombre, Descripcion, Stock, PrecioCompra, PrecioVenta, Estado, ImagenRuta, IdCategoria, FechaCreacion)
                            VALUES (@Codigo, @Nombre, @Descripcion, @Stock, @PrecioCompra, @PrecioVenta, @Estado, @ImagenRuta, @IdCategoria, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
                        cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrEmpty(p.Descripcion) ? DBNull.Value : p.Descripcion);
                        cmd.Parameters.AddWithValue("@Stock", p.Stock);
                        cmd.Parameters.AddWithValue("@PrecioCompra", p.PrecioCompra);
                        cmd.Parameters.AddWithValue("@PrecioVenta", p.PrecioVenta);
                        cmd.Parameters.AddWithValue("@Estado", p.Estado);
                        cmd.Parameters.AddWithValue("@ImagenRuta", string.IsNullOrEmpty(p.ImagenRuta) ? DBNull.Value : p.ImagenRuta);
                        cmd.Parameters.AddWithValue("@IdCategoria", p.IdCategoria);

                        oConexion.Open();
                        resultado = cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en AgregarProducto: " + ex.Message,
                                "Error SQL",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                resultado = false;
            }


            return resultado;
        }

        public bool CambiarEstadoProducto(int idProducto, bool activo)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    oConexion.Open();
                    string query = "UPDATE PRODUCTO SET Estado = @estado WHERE IdProducto = @idproducto";

                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@estado", activo ? 1 : 0);
                        cmd.Parameters.AddWithValue("@idproducto", idProducto);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }
        public static string ObtenerRutaImagen(int idProducto)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.CadenaConexion))
            {
                cn.Open();
                string query = "SELECT ImagenRuta FROM PRODUCTO WHERE IdProducto = @IdProducto";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? result.ToString() : string.Empty;
                }
            }
        }



        public static int ObtenerStock(int idProducto)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.CadenaConexion))
            {
                cn.Open();
                string sql = "SELECT Stock FROM PRODUCTO WHERE IdProducto = @IdProducto";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int stock))
                    {
                        return stock;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }


        public static bool ExisteCodigo(string codigo)
        {
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                string query = "SELECT COUNT(*) FROM PRODUCTO WHERE Codigo = @Codigo";
                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    oConexion.Open();

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }



        public static List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    string query = @"SELECT p.IdProducto, p.Codigo, p.Nombre, p.Descripcion,
       p.Stock, p.PrecioCompra, p.PrecioVenta,
       p.Estado, p.ImagenRuta, p.FechaCreacion,
       p.IdCategoria, c.Descripcion AS CategoriaNombre
FROM PRODUCTO p
INNER JOIN CATEGORIA c ON p.IdCategoria = c.IdCategoria
";

                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Stock = Convert.ToInt32(dr["Stock"]),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                ImagenRuta = dr["ImagenRuta"].ToString(),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]),
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                CategoriaNombre = dr["CategoriaNombre"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = new List<Producto>(); // si falla, devolvemos lista vacía
            }

            return lista;
        }


        public static bool EditarProducto(Producto p)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    string query = @"UPDATE PRODUCTO SET
                Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion,
                Stock=@Stock, PrecioCompra=@PrecioCompra, PrecioVenta=@PrecioVenta,
                Estado=@Estado, ImagenRuta=@ImagenRuta, IdCategoria=@IdCategoria
                WHERE IdProducto=@IdProducto";


                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.Parameters.AddWithValue("@IdProducto", p.IdProducto);
                    cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
                    cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", p.IdCategoria);
                    cmd.Parameters.AddWithValue("@Stock", p.Stock);
                    cmd.Parameters.AddWithValue("@PrecioCompra", p.PrecioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVenta", p.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", p.Estado);
                    cmd.Parameters.AddWithValue("@ImagenRuta", p.ImagenRuta ?? string.Empty);

                    oConexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return resultado;
        }

        public static bool EliminarProducto(int idProducto)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    string query = "UPDATE PRODUCTO SET Estado = 0 WHERE IdProducto=@IdProducto";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                    oConexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return resultado;
        }
    }
}
