using nikeproject.Models;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace nikeproject.Auth
{
    public static class ClienteValidacion
    {
        public static bool NombreValido(string nombre)
            => !string.IsNullOrWhiteSpace(nombre) && Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$") && nombre.Length <= 100;

        public static bool ApellidoValido(string apellido)
            => !string.IsNullOrWhiteSpace(apellido) && Regex.IsMatch(apellido, @"^[a-zA-Z\s]+$") && apellido.Length <= 100;

        public static bool DocumentoValido(string documento)
            => !string.IsNullOrWhiteSpace(documento) && documento.Length <= 20;

        public static bool CorreoValido(string correo)
            => string.IsNullOrWhiteSpace(correo) ||
               (correo.Length <= 100 && Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"));

        public static bool TelefonoValido(string telefono)
            => string.IsNullOrWhiteSpace(telefono) || telefono.Length <= 20;

        public static bool EstadoValido(bool estado)
            => estado == true || estado == false;
    }
}
 