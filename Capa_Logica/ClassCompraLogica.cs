using Capa_Datos;
using Capa_Entidades;
using Capa_Entidades.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Logica
{
    public class ClassCompraLogica
    {
        private readonly ClassCompra compraDatos = new ClassCompra();

        public List<string> ErroresValidacion => compraDatos.ErroresValidacion;

        public bool RegistrarCompra(compra nuevaCompra, List<detalle_compra> detalles)
        {
            return compraDatos.RegistrarCompra(nuevaCompra, detalles);
        }

        public int ObtenerSiguienteNumeroFactura()
        {
            using (var context = new ArimaERPEntities())
            {
                int ultimo = context.compra
                    .Select(c => c.nro_factura)
                    .DefaultIfEmpty(0)
                    .Max();

                return ultimo + 1;
            }
        }

        public List<CompraHistorialDto> ObtenerHistorialCompras()
        {
            return compraDatos.ObtenerHistorialCompras();
        }
    }
}
