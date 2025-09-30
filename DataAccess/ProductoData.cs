using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using nikeproject.Models;
using nikeproject.DataAccess;

namespace nikeproject.Data
{
    public static class ProductoData
    {

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
                // Te recomiendo loguear el error para debug
                Console.WriteLine("Error al insertar producto: " + ex.Message);
                resultado = false;
            }

            return resultado;
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
                    cmd.Parameters.AddWithValue("@Categoria", p.IdCategoria);
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
