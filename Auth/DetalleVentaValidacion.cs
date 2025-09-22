using nikeproject.Models;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace nikeproject.Auth
{
    public static class DetalleVentaValidacion
    {
        public static bool TalleValido(decimal talle)
            => talle > 0;

        public static bool CantidadValida(int cantidad)
            => cantidad > 0;

        public static bool PrecioVentaValido(decimal precio)
            => precio >= 0;

        public static bool SubTotalValido(decimal subtotal)
            => subtotal >= 0;
    }
}
 