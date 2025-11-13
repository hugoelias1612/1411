using System;

namespace Capa_Entidades.DTOs
{
    public class ProductoCatalogoDto
    {
        public int IdProducto { get; set; }
        public int IdPresentacion { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Familia { get; set; }
        public string Presentacion { get; set; }
        public decimal PrecioLista { get; set; }
        public int UnidadesPorBulto { get; set; }
        public bool Activo { get; set; }
        public int StockActual { get; set; }
        public int UmbralStock { get; set; }
        public string Proveedor { get; set; }

        public bool StockPorDebajoDelUmbral => StockActual <= UmbralStock;
    }
}
