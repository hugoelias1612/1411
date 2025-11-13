using System.Collections.Generic;
using Capa_Datos;
using Capa_Entidades;

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
    }
}