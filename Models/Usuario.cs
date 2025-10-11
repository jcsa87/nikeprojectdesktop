using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace nikeproject.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public RolUsuario Rol { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
