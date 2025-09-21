using nikeproject.Models;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace nikeproject.Auth
{
    public static class ProductoValidacion
    {
        public static bool CodigoValido(string codigo)
            => !string.IsNullOrWhiteSpace(codigo) && codigo.Length <= 20;

        public static bool NombreValido(string nombre)
            => !string.IsNullOrWhiteSpace(nombre) && nombre.Length <= 100;

        public static bool DescripcionValida(string descripcion)
            => string.IsNullOrWhiteSpace(descripcion) || descripcion.Length <= 200;

        public static bool PrecioVentaValido(decimal precio)
            => precio >= 0;

        public static bool EstadoValido(bool estado)
            => estado == true || estado == false;
    }
}
 