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
                // El operador ??= (null-coalescing assignment) es la forma más limpia
                // de hacer lo que intentas. Si cadenaConexion es null, asigna el valor
                // de la cadena de conexión.
                return cadenaConexion ??= ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;
            }
        }

        public static SqlConnection Conectar()
        {
            return new SqlConnection(CadenaConexion);
        }
    }
}