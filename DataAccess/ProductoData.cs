using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using nikeproject.Models;
using nikeproject.DataAccess;

namespace nikeproject.Data
{
    public static class ProductoData
    {
        // CREATE
        public static bool Agregar(Producto p)
        {
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                string query = @"INSERT INTO PRODUCTO
                                (Codigo, Nombre, Descripcion, Categoria, Stock, PrecioCompra, PrecioVenta, Estado, ImagenRuta, FechaCreacion)
                                VALUES (@Codigo, @Nombre, @Descripcion, @Categoria, @Stock, @PrecioCompra, @PrecioVenta, @Estado, @ImagenRuta, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@Categoria", p.Categoria);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                cmd.Parameters.AddWithValue("@PrecioCompra", p.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVenta", p.PrecioVenta);
                cmd.Parameters.AddWithValue("@Estado", p.Estado);
                cmd.Parameters.AddWithValue("@ImagenRuta", p.ImagenRuta);

                oConexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // READ
        public static List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                string query = "SELECT * FROM PRODUCTO";
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
                            Categoria = dr["Categoria"].ToString(),
                            Stock = Convert.ToInt32(dr["Stock"]),
                            PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                            Estado = Convert.ToBoolean(dr["Estado"]),
                            ImagenRuta = dr["ImagenRuta"].ToString(),
                            FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])
                        });
                    }
                }
            }
            return lista;
        }

        // UPDATE
        public static bool Editar(Producto p)
        {
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                string query = @"UPDATE PRODUCTO SET
                                Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, 
                                Categoria=@Categoria, Stock=@Stock, 
                                PrecioCompra=@PrecioCompra, PrecioVenta=@PrecioVenta, Estado=@Estado,
                                ImagenRuta=@ImagenRuta
                                WHERE IdProducto=@IdProducto";

                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@IdProducto", p.IdProducto);
                cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@Categoria", p.Categoria);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                cmd.Parameters.AddWithValue("@PrecioCompra", p.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVenta", p.PrecioVenta);
                cmd.Parameters.AddWithValue("@Estado", p.Estado);
                cmd.Parameters.AddWithValue("@ImagenRuta", p.ImagenRuta);

                oConexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE (baja lógica)
        public static bool Eliminar(int idProducto)
        {
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                string query = "UPDATE PRODUCTO SET Estado = 0 WHERE IdProducto=@IdProducto";
                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                oConexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
