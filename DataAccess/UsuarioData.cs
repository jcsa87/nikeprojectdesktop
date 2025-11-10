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

                    // Usa un comando parametrizado para evitar inyección de SQL
                    string query = "UPDATE USUARIO SET Nombre = @nombre, Apellido = @apellido, Documento = @documento, Clave = @clave, Rol = @rol, Estado = @estado WHERE IdUsuario = @idusuario";

                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", oUsuario.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", oUsuario.Apellido);
                        cmd.Parameters.AddWithValue("@documento", oUsuario.Documento);
                        cmd.Parameters.AddWithValue("@clave", oUsuario.Clave);
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


        // Se agrega el '?' para indicar que el método puede devolver un valor nulo
        public Usuario? ObtenerUsuario(string documento, string clave)
        {
            Usuario? oUsuario = null;

            // 1. La consulta ahora es explícita: solo trae los datos necesarios para la sesión.
            string query = @"SELECT IdUsuario, Nombre, Apellido, Rol
                     FROM USUARIO
                     WHERE Documento = @documento AND Clave = @clave AND Estado = 1";

            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    oConexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@documento", documento);
                        cmd.Parameters.AddWithValue("@clave", clave);
                        // No es necesario 'cmd.CommandType = CommandType.Text;', es el valor por defecto.

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                // --- INICIO DE LA MODIFICACIÓN ---

                                // 2. Leemos el rol como texto desde la base de datos.
                                string rolDesdeDB = dr["Rol"].ToString()!;
                                RolUsuario rolEnum;

                                // 3. "Traducimos" el texto al enum para usarlo de forma segura en la aplicación.
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
                                        // Si el rol en la BD no es válido, se impide el login por seguridad.
                                        return null;
                                }

                                // 4. Creamos el objeto Usuario SOLO con los datos esenciales para la sesión.
                                oUsuario = new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    Nombre = dr["Nombre"].ToString()!,
                                    Apellido = dr["Apellido"].ToString()!,
                                    Rol = rolEnum // <-- Asignamos el enum ya convertido.
                                };

                                // --- FIN DE LA MODIFICACIÓN ---
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si hay un error (ej. la BD está offline), evitamos que la app se cierre.
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
                            // --- INICIO DE LA MODIFICACIÓN ---

                            // 1. Leemos el rol como texto desde la base de datos.
                            string rolDesdeDB = dr["Rol"].ToString()!;

                            // 2. "Traducimos" el texto al enum correspondiente.
                            // Enum.TryParse es la forma más segura de hacerlo.
                            Enum.TryParse<RolUsuario>(rolDesdeDB, out RolUsuario rolEnum);

                            // --- FIN DE LA MODIFICACIÓN ---

                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Nombre = dr["Nombre"].ToString()!,
                                Apellido = dr["Apellido"].ToString()!,
                                Documento = dr["Documento"].ToString()!,
                                Clave = dr["Clave"].ToString()!,

                                // 3. Asignamos el enum ya convertido a la propiedad Rol.
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
                            // --- INICIO DE LA MODIFICACIÓN ---

                            // 1. Leemos el rol como texto desde la base de datos.
                            string rolDesdeDB = dr["Rol"].ToString()!;

                            // 2. "Traducimos" el texto al enum correspondiente.
                            Enum.TryParse<RolUsuario>(rolDesdeDB, out RolUsuario rolEnum);

                            // --- FIN DE LA MODIFICACIÓN ---

                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Nombre = dr["Nombre"] as string ?? string.Empty,
                                Apellido = dr["Apellido"] as string ?? string.Empty,
                                Documento = dr["Documento"] as string ?? string.Empty,
                                Clave = dr["Clave"] as string ?? string.Empty,

                                // 3. Asignamos el enum ya convertido a la propiedad Rol.
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
