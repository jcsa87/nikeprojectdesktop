using System.Security.Cryptography;
using System.Text;

namespace nikeproject.Auth
{
    public static class PasswordHelper
    {
        // Genera un hash SHA256 a partir de la contraseña
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2")); // Convierte a string hexadecimal
                return builder.ToString();
            }
        }

        // Verifica si la contraseña ingresada coincide con el hash guardado
        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword);
            return inputHash == storedHash;
        }
    }
}
