using System;

namespace Capa_Entidades.DTOs
{
    public class ProductoVentaDto
    {
        public int IdProducto { get; set; }
        public int IdPresentacion { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Presentacion { get; set; }
        public int TotalUnidadesVendidas { get; set; }
        public int TotalBultosVendidos { get; set; }
        public decimal TotalIngresos { get; set; }

        public decimal PrecioPromedioUnitario
        {
            get
            {
                if (TotalUnidadesVendidas <= 0)
                {
                    return 0m;
                }

                return Math.Round(TotalIngresos / Math.Max(1, TotalUnidadesVendidas), 2);
            }
        }
    }
}