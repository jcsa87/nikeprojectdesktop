using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace nikeproject.DataAccess
{
    public class Conexion
    {
        private static string? cadenaConexion;

        public static string CadenaConexion
        {
            get
            {
                return cadenaConexion ??= ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;
            }
        }

        public static SqlConnection Conectar()
        {
            return new SqlConnection(CadenaConexion);
        }
    }
}