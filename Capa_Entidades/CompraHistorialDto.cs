using System;

namespace Capa_Entidades.DTOs
{
    public class CompraHistorialDto
    {
        public DateTime FechaCompra { get; set; }
        public int Cantidad { get; set; }
        public decimal Monto { get; set; }
        public int NumeroFactura { get; set; }
        public int IdProducto { get; set; }
    }
}