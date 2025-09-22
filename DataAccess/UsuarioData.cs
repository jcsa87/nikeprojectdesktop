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
                string query = "INSERT INTO USUARIO (NombreCompleto, Documento, Clave, Rol, Estado) VALUES (@nombre, @documento, @clave, @rol, @estado)";
                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", oUsuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("@documento", oUsuario.Documento);
                    cmd.Parameters.AddWithValue("@clave", oUsuario.Clave);
                    cmd.Parameters.AddWithValue("@rol", oUsuario.Rol);
                    cmd.Parameters.AddWithValue("@estado", oUsuario.Estado);
                    cmd.CommandType = CommandType.Text;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
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
                                NombreCompleto = dr["NombreCompleto"].ToString()!, // Usas '!' porque sabes que no es nulo
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
    }
}
