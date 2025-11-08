using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidades;

namespace Capa_Logica
{

    public class ClassReporteLogica
    {
        ClassReporte reporte = new ClassReporte();
        public List<(string semana, decimal total)> ObtenerVentasConcretadasPorSemana(DateTime mes)
        {
            return reporte.ObtenerVentasConcretadasPorSemana(mes);
        }
        public List<(string familia, int cantidad)> ObtenerTopFamiliasVendidas(DateTime mes)
        {
            return reporte.ObtenerTopFamiliasVendidas(mes);
        }
    
        public List<(string semana, decimal total)> ObtenerVentasConcretadasPorSemanaComparativa(DateTime mes)
        {
            return reporte.ObtenerVentasConcretadasPorSemanaComparativa(mes);
        }
        public List<(string producto, int cantidad)> ObtenerTopProductosVendidos(DateTime mes)
        {
            return reporte.ObtenerTopProductosVendidos(mes);
        }
        public List<(string vendedor, decimal total)> ObtenerVentasPorVendedor(DateTime mes)
        {
            return reporte.ObtenerVentasPorVendedor(mes);
        }
    }
}




