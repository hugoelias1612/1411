using Capa_Datos;
using Capa_Entidades;
using Capa_Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Capa_Logica
{
    public class ClassCompraLogica
    {
        private readonly ClassCompra compraDatos = new ClassCompra();

        public List<string> ErroresValidacion => compraDatos.ErroresValidacion;

        public bool RegistrarCompra(compra nuevaCompra, List<detalle_compra> detalles)
        {
            ErroresValidacion.Clear();

            try
            {
                using (var context = new ArimaERPEntities())
                {
                    nuevaCompra.detalle_compra = detalles;
                    context.compra.Add(nuevaCompra);
                    context.SaveChanges();
                }

                return true;
            }
            catch (DbUpdateException ex)
            {
                var innerMost = ex.InnerException;
                while (innerMost?.InnerException != null)
                {
                    innerMost = innerMost.InnerException;
                }

                ErroresValidacion.Add("Error al registrar la compra: " + (innerMost?.Message ?? ex.Message));
                return false;
            }
            catch (Exception ex)
            {
                ErroresValidacion.Add("Error inesperado al registrar la compra: " + ex.ToString());
                return false;
            }
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