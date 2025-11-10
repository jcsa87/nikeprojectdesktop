using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using nikeproject.Models;

namespace nikeproject.DataAccess
{
    public class ClienteData
    {
        public bool GuardarCliente(Cliente oCliente)
        {
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                string query = "INSERT INTO CLIENTE (Nombre, Apellido, Documento, Correo, Telefono, Estado) VALUES (@nombre, @apellido, @documento, @correo, @telefono, @estado)";
                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", oCliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", oCliente.Apellido);
                    cmd.Parameters.AddWithValue("@documento", oCliente.Documento);
                    cmd.Parameters.AddWithValue("@correo", oCliente.Correo);
                    cmd.Parameters.AddWithValue("@telefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("@estado", oCliente.Estado);
                    cmd.CommandType = CommandType.Text;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CambiarEstadoCliente(int idCliente, bool activo)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                conn.Open();
                string query = "UPDATE CLIENTE SET Estado = @estado WHERE IdCliente = @idCliente";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estado", activo ? 1 : 0);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool EditarCliente(Cliente oCliente)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    oConexion.Open();
                    string query = "UPDATE CLIENTE SET Nombre = @nombre, Apellido = @apellido, Documento = @documento, Correo = @correo, Telefono = @telefono, Estado = @estado WHERE IdCliente = @idcliente";
                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", oCliente.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", oCliente.Apellido);
                        cmd.Parameters.AddWithValue("@documento", oCliente.Documento);
                        cmd.Parameters.AddWithValue("@correo", oCliente.Correo);
                        cmd.Parameters.AddWithValue("@telefono", oCliente.Telefono);
                        cmd.Parameters.AddWithValue("@estado", oCliente.Estado);
                        cmd.Parameters.AddWithValue("@idcliente", oCliente.IdCliente);
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

        public bool EliminarCliente(int idCliente)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection oConexion = Conexion.Conectar())
                {
                    oConexion.Open();
                    string query = "UPDATE CLIENTE SET Estado = 0 WHERE IdCliente = @idcliente";
                    using (SqlCommand cmd = new SqlCommand(query, oConexion))
                    {
                        cmd.Parameters.AddWithValue("@idcliente", idCliente);
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

        public Cliente? ObtenerCliente(string documento)
        {
            Cliente? oCliente = null;
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                string query = "SELECT * FROM CLIENTE WHERE Documento = @documento";
                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    cmd.Parameters.AddWithValue("@documento", documento);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oCliente = new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Nombre = dr["Nombre"].ToString()!,
                                Apellido = dr["Apellido"].ToString()!,
                                Documento = dr["Documento"].ToString()!,
                                Correo = dr["Correo"].ToString()!,
                                Telefono = dr["Telefono"].ToString()!,
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])
                            };
                        }
                    }
                }
            }
            return oCliente;
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                string query = "SELECT * FROM CLIENTE";
                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Nombre = dr["Nombre"].ToString()!,
                                Apellido = dr["Apellido"].ToString()!,
                                Documento = dr["Documento"].ToString()!,
                                Correo = dr["Correo"].ToString()!,
                                Telefono = dr["Telefono"].ToString()!,
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public List<Cliente> BuscarClientes(string columna, string valor)
        {
            List<Cliente> lista = new List<Cliente>();
            string[] columnasPermitidas = { "Nombre", "Apellido", "Documento", "Correo", "Telefono" };
            if (!columnasPermitidas.Contains(columna))
            {
                return lista;
            }
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                string query = $"SELECT * FROM CLIENTE WHERE {columna} LIKE @valor AND Estado <> 0";
                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    cmd.Parameters.AddWithValue("@valor", $"%{valor}%");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Nombre = dr["Nombre"].ToString()!,
                                Apellido = dr["Apellido"].ToString()!,
                                Documento = dr["Documento"].ToString()!,
                                Correo = dr["Correo"].ToString()!,
                                Telefono = dr["Telefono"].ToString()!,
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])
                            });
                        }
                    }
                }
            }
            return lista;
        }


        public Cliente? ObtenerClientePorId(int idCliente)
        {
            Cliente? oCliente = null;
            using (SqlConnection oConexion = Conexion.Conectar())
            {
                oConexion.Open();
                string query = "SELECT * FROM CLIENTE WHERE IdCliente = @idcliente";
                using (SqlCommand cmd = new SqlCommand(query, oConexion))
                {
                    cmd.Parameters.AddWithValue("@idcliente", idCliente);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oCliente = new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Nombre = dr["Nombre"].ToString()!,
                                Apellido = dr["Apellido"].ToString()!,
                                Documento = dr["Documento"].ToString()!,
                                Correo = dr["Correo"].ToString()!,
                                Telefono = dr["Telefono"].ToString()!,
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])
                            };
                        }
                    }
                }
            }
            return oCliente;
        }
    }
}
