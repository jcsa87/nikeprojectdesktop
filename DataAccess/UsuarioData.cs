using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using nikeproject.Models;
using nikeproject.Auth; // para usar PasswordHelper

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
                    //hasheamos la contraseña antes de guardarla
                    cmd.Parameters.AddWithValue("@clave", PasswordHelper.HashPassword(oUsuario.Clave));
                    cmd.Parameters.AddWithValue("@rol", oUsuario.Rol.ToString());
                    cmd.Parameters.AddWithValue("@estado", oUsuario.Estado);
                    cmd.CommandType = CommandType.Text;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CambiarEstadoUsuario(int idUsuario, bool activo)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    oConexion.Open();
                    string query = "UPDATE USUARIO SET Estado = @estado WHERE IdUsuario = @idusuario";

                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@estado", activo ? 1 : 0);
                        cmd.Parameters.AddWithValue("@idusuario", idUsuario);

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

        public bool EditarUsuario(Usuario oUsuario)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    oConexion.Open();

                    string query = "UPDATE USUARIO SET Nombre = @nombre, Apellido = @apellido, Documento = @documento, Clave = @clave, Rol = @rol, Estado = @estado WHERE IdUsuario = @idusuario";

                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", oUsuario.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", oUsuario.Apellido);
                        cmd.Parameters.AddWithValue("@documento", oUsuario.Documento);
                        // 🔒 Re-hasheamos la contraseña por seguridad
                        cmd.Parameters.AddWithValue("@clave", PasswordHelper.HashPassword(oUsuario.Clave));
                        cmd.Parameters.AddWithValue("@rol", oUsuario.Rol.ToString());
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

        // ======================= LOGIN SEGURIDAD =======================
        public Usuario? ObtenerUsuario(string documento, string clave)
        {
            Usuario? oUsuario = null;

            string query = @"SELECT IdUsuario, Nombre, Apellido, Rol, Clave
                             FROM USUARIO
                             WHERE Documento = @documento AND Estado = 1";

            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    oConexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@documento", documento);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string hashGuardado = dr["Clave"].ToString()!;
                                // 🔒 Verificamos si la contraseña ingresada coincide
                                if (!PasswordHelper.VerifyPassword(clave, hashGuardado))
                                    return null;

                                string rolDesdeDB = dr["Rol"].ToString()!;
                                RolUsuario rolEnum;

                                switch (rolDesdeDB)
                                {
                                    case "Administrador":
                                        rolEnum = RolUsuario.Administrador;
                                        break;
                                    case "Supervisor":
                                        rolEnum = RolUsuario.Supervisor;
                                        break;
                                    case "Vendedor":
                                        rolEnum = RolUsuario.Vendedor;
                                        break;
                                    default:
                                        return null;
                                }

                                oUsuario = new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    Nombre = dr["Nombre"].ToString()!,
                                    Apellido = dr["Apellido"].ToString()!,
                                    Rol = rolEnum
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de base de datos al autenticar: " + ex.Message);
                return null;
            }

            return oUsuario;
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                string query = "SELECT * FROM USUARIO";

                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string rolDesdeDB = dr["Rol"].ToString()!;
                            Enum.TryParse<RolUsuario>(rolDesdeDB, out RolUsuario rolEnum);

                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Nombre = dr["Nombre"].ToString()!,
                                Apellido = dr["Apellido"].ToString()!,
                                Documento = dr["Documento"].ToString()!,
                                Clave = dr["Clave"].ToString()!, // 🔒 sigue siendo hash, no texto plano
                                Rol = rolEnum,
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

            string[] columnasPermitidas = { "Nombre", "Apellido", "Documento", "Rol" };
            if (!columnasPermitidas.Contains(columna))
                return lista;

            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                string query = $"SELECT * FROM USUARIO WHERE {columna} LIKE @valor";

                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    cmd.Parameters.AddWithValue("@valor", $"%{valor}%");
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string rolDesdeDB = dr["Rol"].ToString()!;
                            Enum.TryParse<RolUsuario>(rolDesdeDB, out RolUsuario rolEnum);

                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Nombre = dr["Nombre"] as string ?? string.Empty,
                                Apellido = dr["Apellido"] as string ?? string.Empty,
                                Documento = dr["Documento"] as string ?? string.Empty,
                                Clave = dr["Clave"] as string ?? string.Empty,
                                Rol = rolEnum,
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
