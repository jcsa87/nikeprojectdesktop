using System;
using System.Collections.Generic;

namespace nikeproject.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }   // 👈 Vendedor
        public string NumeroDocumento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal MontoTotal { get; set; }
        public bool Estado { get; set; }

        // Relaciones
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }   // 👈 Vendedor
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
