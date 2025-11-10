using System;

namespace nikeproject.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int Stock { get; set; }              // 👈 agregado
        public decimal PrecioCompra { get; set; }   // 👈 agregado
        public decimal PrecioVenta { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ImagenRuta { get; set; } = string.Empty;

        // FK
        public int IdCategoria { get; set; }
        public string CategoriaNombre { get; set; }
    }

}
