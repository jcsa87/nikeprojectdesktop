using nikeproject.Models;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace nikeproject.Auth
{
    internal class UsuarioValidacion
    {
        public static bool NombreValido(string p_nombre)
        {
            return !string.IsNullOrWhiteSpace(p_nombre) && Regex.IsMatch(p_nombre, @"^[a-zA-Z\s]+$");
        }

        public static bool ApellidoValido(string p_apellido)
        {
            return !string.IsNullOrWhiteSpace(p_apellido) && Regex.IsMatch(p_apellido, @"^[a-zA-Z\s]+$");
        }

        public static bool UsuarioValido(string p_usuario)
        {
            return !string.IsNullOrWhiteSpace(p_usuario);
        }

        public static bool ClaveValida(string p_clave)
        {
            return !string.IsNullOrWhiteSpace(p_clave) && p_clave.Length >= 6;
        
        public static bool ConfirmarClave(string p_clave, string p_confirmarClave)
        {
            return p_clave.Trim() == p_confirmarClave.Trim();
        }

        public static bool RolValido(string p_rol)
        {
            return Enum.GetNames(typeof(RolUsuario)).Contains(p_rol);
        }

        public static bool EstadoValido(bool p_estado)
            => p_estado == true || p_estado == false;
    }
}