using nikeproject.Models;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace nikeproject.Auth
{
    public static class VentaValidacion
    {
        public static bool NumeroDocumentoValido(string numero)
            => string.IsNullOrWhiteSpace(numero) || numero.Length <= 20;

        public static bool MontoTotalValido(decimal monto)
            => monto >= 0;
    }
}
 