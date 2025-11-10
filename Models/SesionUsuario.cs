using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nikeproject.Models
{
    public static class SesionUsuario
    {
        // --- Propiedades Esenciales ---
        public static int IdUsuario { get; private set; }
        public static string Nombre { get; private set; } = string.Empty;
        public static string Apellido { get; private set; } = string.Empty;
        public static RolUsuario Rol { get; private set; } // Usando el enum para más seguridad

        // --- Propiedad de Conveniencia (Solo Lectura) ---
        // Une el nombre y el apellido automáticamente
        public static string NombreCompleto => $"{Nombre} {Apellido}";
        /// <summary>
        /// Guarda los datos esenciales del usuario al iniciar sesión.
        /// </summary>
        public static void IniciarSesion(int idUsuario, string nombre, string apellido, RolUsuario rol)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellido = apellido;
            Rol = rol;
        }

        /// <summary>
        /// Limpia todos los datos de la sesión al cerrarla.
        /// </summary>
        public static void CerrarSesion()
        {
            IdUsuario = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Rol = default; // Restablece el enum a su valor predeterminado
        }
    }
}
