using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using nikeproject.Models;

namespace nikeproject.DataAccess
{
    public class UsuarioData
    {
        public bool GuardarUsuario(Usuario oUsuario)
        {
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                string query = "INSERT INTO USUARIO (Nombre, Apellido, Documento, Clave, Rol, Estado) VALUES (@nombre, @apellido, @documento, @clave, @rol, @estado)";
                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", oUsuario.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", oUsuario.Apellido);
                    cmd.Parameters.AddWithValue("@documento", oUsuario.Documento);
                    cmd.Parameters.AddWithValue("@clave", oUsuario.Clave);
                    cmd.Parameters.AddWithValue("@rol", oUsuario.Rol);
                    cmd.Parameters.AddWithValue("@estado", oUsuario.Estado);
                    cmd.CommandType = CommandType.Text;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EditarUsuario(Usuario oUsuario)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    oConexion.Open();

                    // Usa un comando parametrizado para evitar inyección de SQL
                    string query = "UPDATE USUARIO SET Nombre = @nombre, Apellido = @apellido, Documento = @documento, Clave = @clave, Rol = @rol, Estado = @estado WHERE IdUsuario = @idusuario";

                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", oUsuario.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", oUsuario.Apellido);
                        cmd.Parameters.AddWithValue("@documento", oUsuario.Documento);
                        cmd.Parameters.AddWithValue("@clave", oUsuario.Clave);
                        cmd.Parameters.AddWithValue("@rol", oUsuario.Rol);
                        cmd.Parameters.AddWithValue("@estado", oUsuario.Estado);
                        cmd.Parameters.AddWithValue("@idusuario", oUsuario.IdUsuario);
                        cmd.CommandType = CommandType.Text;
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            resultado = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }

        public bool EliminarUsuario(int idUsuario)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    oConexion.Open();
                    string query = "UPDATE USUARIO SET Estado = 0 WHERE IdUsuario = @idusuario";

                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@idusuario", idUsuario);
                        cmd.CommandType = CommandType.Text;

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            resultado = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }


        // Se agrega el '?' para indicar que el método puede devolver un valor nulo
        public Usuario? ObtenerUsuario(string documento, string clave)
        {
            Usuario? oUsuario = null; // Se agrega el '?'

            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                string query = "SELECT * FROM USUARIO WHERE Documento = @documento AND Clave = @clave";

                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    cmd.Parameters.AddWithValue("@documento", documento);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oUsuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Nombre = dr["Nombre"].ToString()!, // Usas '!' porque sabes que no es nulo
                                Apellido = dr["Apellido"].ToString()!, // Usas '!' porque sabes que no es nulo
                                Documento = dr["Documento"].ToString()!, // Usas '!'
                                Clave = dr["Clave"].ToString()!, // Usas '!'
                                Rol = dr["Rol"].ToString()!, // Usas '!'
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])
                            };
                        }
                    }
                }
            }
            return oUsuario;
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                string query = "SELECT * FROM USUARIO WHERE Estado <> 0";

                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Nombre = dr["Nombre"].ToString()!,
                                Apellido = dr["Apellido"].ToString()!,
                                Documento = dr["Documento"].ToString()!,
                                Clave = dr["Clave"].ToString()!,
                                Rol = dr["Rol"].ToString()!,
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public List<Usuario> BuscarUsuarios(string columna, string valor)
        {
            List<Usuario> lista = new List<Usuario>();

            // 1. Validar la columna para evitar inyección SQL
            string[] columnasPermitidas = { "Nombre", "Apellido", "Documento", "Rol" };
            if (!columnasPermitidas.Contains(columna))
            {
                // Puedes lanzar una excepción o devolver una lista vacía si la columna no es válida
                return lista;
            }

            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();

                // 2. Construir la consulta de forma segura
                string query = $"SELECT * FROM USUARIO WHERE {columna} LIKE @valor";

                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    // 3. Usar un parámetro para el valor de búsqueda
                    cmd.Parameters.AddWithValue("@valor", $"%{valor}%");
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                // Usa 'as string ?? string.Empty' para manejar la nulabilidad de los datos
                                Nombre = dr["Nombre"] as string ?? string.Empty,
                                Apellido = dr["Apellido"] as string ?? string.Empty,
                                Documento = dr["Documento"] as string ?? string.Empty,
                                Clave = dr["Clave"] as string ?? string.Empty,
                                Rol = dr["Rol"] as string ?? string.Empty,
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

    }
}
