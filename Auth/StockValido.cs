using nikeproject.Models;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace nikeproject.Auth
{
    public static class TalleStockValidacion
    {
        public static bool TalleValido(decimal talle)
            => talle > 0;

        public static bool StockValido(int stock)
            => stock >= 0;
    }
}
 