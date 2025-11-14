using System;

namespace Capa_Entidades.DTOs
{
    public class CompraHistorialDto
    {
        public int CompraId { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Marca { get; set; }
        public decimal Monto { get; set; }
        public int NumeroFactura { get; set; }
    }
}