namespace Capa_Entidades.DTOs
{
    public class CompraDetalleDto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}