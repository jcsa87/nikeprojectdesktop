using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace nikeproject.DataAccess
{
    public class Conexion
    {
        private static string cadenaConexion = string.Empty;

        public static string CadenaConexion
        {
            get
            {
                if (cadenaConexion == null)
                {
                    // Obtiene la cadena de conexión del archivo App.config
                    cadenaConexion = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;
                }
                return cadenaConexion;
            }
        }

        public static SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            return conexion;
        }
    }
}
