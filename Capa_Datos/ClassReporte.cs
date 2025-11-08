using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class ClassReporte
    {
        public List<(string semana, decimal total)> ObtenerVentasConcretadasPorSemana(DateTime mes)
        {
            using (var context = new ArimaERPEntities())
            {
                DateTime inicioMes = new DateTime(mes.Year, mes.Month, 1);
                DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);

                var pedidosConcretados = from p in context.PEDIDO
                                         join pp in context.pedido_pago on p.id_pedido equals pp.id_pedido
                                         where pp.saldo == 0 && p.fecha_entrega >= inicioMes && p.fecha_entrega <= finMes
                                         select new { p.fecha_entrega, p.total };

                var agrupado = pedidosConcretados
                    .ToList()
                    .GroupBy(p =>
                    {
                        int dia = p.fecha_entrega.Day;
                        if (dia <= 7) return "Semana 1";
                        else if (dia <= 14) return "Semana 2";
                        else if (dia <= 21) return "Semana 3";
                        else return "Semana 4";
                    })
                    .Select(g => (semana: g.Key, total: g.Sum(x => x.total)))
                    .OrderBy(g => g.semana)
                    .ToList();

                return agrupado;
            }
        }
        public List<(string semana, decimal total)> ObtenerVentasConcretadasPorSemanaComparativa(DateTime mes)
        {
            using (var context = new ArimaERPEntities())
            {
                DateTime inicioMes = new DateTime(mes.Year, mes.Month, 1);
                DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);
                int año = mes.Year;

                var ventas = from p in context.PEDIDO
                             join pp in context.pedido_pago on p.id_pedido equals pp.id_pedido
                             where pp.saldo == 0 && p.fecha_entrega >= inicioMes && p.fecha_entrega <= finMes
                             select new
                             {
                                 semana = SqlFunctions.DatePart("wk", p.fecha_entrega),
                                 total = p.total
                             };

                var agrupado = ventas
            .ToList()
            .GroupBy(v => v.semana ?? 0)
            .Select(g =>
            {
                var (inicio, fin) = ObtenerRangoSemana(g.Key, año);
                string texto = $"Semana {g.Key} ({inicio:dd/MM} al {fin:dd/MM})";
                return (semanaTexto: texto, total: g.Sum(x => x.total));
            })
            .OrderBy(g => g.semanaTexto)
            .ToList();

                return agrupado;
            }
        }
        private (DateTime inicio, DateTime fin) ObtenerRangoSemana(int semana, int año)
        {
            DateTime primerDiaDelAño = new DateTime(año, 1, 1);

            // Ajustar al primer domingo (SQL Server usa semanas que comienzan en domingo)
            int diasHastaDomingo = ((int)DayOfWeek.Sunday - (int)primerDiaDelAño.DayOfWeek + 7) % 7;
            DateTime primerDomingo = primerDiaDelAño.AddDays(diasHastaDomingo);

            DateTime inicioSemana = primerDomingo.AddDays((semana - 1) * 7);
            DateTime finSemana = inicioSemana.AddDays(6);

            return (inicioSemana, finSemana);
        }

        public List<(string familia, int cantidad)> ObtenerTopFamiliasVendidas(DateTime mes)
        {
            using (var context = new ArimaERPEntities())
            {
                DateTime inicioMes = new DateTime(mes.Year, mes.Month, 1);
                DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);

                // Paso 1: obtener IDs de pedidos concretados
                var pedidosConcretados = (from p in context.PEDIDO
                                          join pp in context.pedido_pago on p.id_pedido equals pp.id_pedido
                                          where pp.saldo == 0
                                                && p.fecha_entrega >= inicioMes && p.fecha_entrega <= finMes
                                          select p.id_pedido).ToList();

                // Paso 2: obtener detalles con familia
                var detalles = (from dp in context.DETALLE_PEDIDO
                                join prod in context.PRODUCTO on dp.id_producto equals prod.id_producto
                                join fam in context.FAMILIA on prod.id_familia equals fam.id_familia
                                join ppres in context.producto_presentacion
                                     on new { dp.id_producto, dp.ID_presentacion }
                                     equals new { ppres.id_producto, ppres.ID_presentacion }
                                where pedidosConcretados.Contains(dp.id_pedido)
                                select new
                                {
                                    familia = fam.descripcion,
                                    cantidad = (dp.cantidad ?? 0) + ((dp.cantidad_bultos ?? 0) * ppres.unidades_bulto)
                                }).ToList();

                // Paso 3: agrupar y ordenar
                var agrupado = detalles
                    .GroupBy(d => d.familia)
                    .Select(g => new
                    {
                        familia = g.Key,
                        cantidad = g.Sum(x => x.cantidad)
                    })
                    .OrderByDescending(x => x.cantidad)
                    .Take(10)
                    .ToList();

                return agrupado.Select(x => (x.familia, x.cantidad)).ToList();
            }
        }

        public List<(string producto, int cantidad)> ObtenerTopProductosVendidos(DateTime mes)
        {
            using (var context = new ArimaERPEntities())
            {
                DateTime inicioMes = new DateTime(mes.Year, mes.Month, 1);
                DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);

                // Paso 1: obtener IDs de pedidos concretados
                var pedidosConcretados = (from p in context.PEDIDO
                                          join pp in context.pedido_pago on p.id_pedido equals pp.id_pedido
                                          where pp.saldo == 0
                                                && p.fecha_entrega >= inicioMes && p.fecha_entrega <= finMes
                                          select p.id_pedido).ToList(); // ← ejecutado en memoria

                // Paso 2: obtener detalles filtrados
                var detalles = (from dp in context.DETALLE_PEDIDO
                                join prod in context.PRODUCTO on dp.id_producto equals prod.id_producto
                                join pres in context.PRESENTACION on dp.ID_presentacion equals pres.ID_presentacion
                                join ppres in context.producto_presentacion
                                     on new { dp.id_producto, dp.ID_presentacion }
                                     equals new { ppres.id_producto, ppres.ID_presentacion }
                                where pedidosConcretados.Contains(dp.id_pedido)
                                select new
                                {
                                    nombre = prod.nombre + " (" + pres.descripcion + ")",
                                    cantidad = (dp.cantidad ?? 0) + ((dp.cantidad_bultos ?? 0) * ppres.unidades_bulto)
                                }).ToList(); // ← ejecutado en memoria

                // Paso 3: agrupar y ordenar
                var agrupado = detalles
                    .GroupBy(d => d.nombre)
                    .Select(g => new
                    {
                        producto = g.Key,
                        cantidad = g.Sum(x => x.cantidad)
                    })
                    .OrderByDescending(x => x.cantidad)
                    .Take(10)
                    .ToList();

                return agrupado.Select(x => (x.producto, x.cantidad)).ToList();
            }
        }
        public List<(string vendedor, decimal total)> ObtenerVentasPorVendedor(DateTime mes)
        {
            using (var context = new ArimaERPEntities())
            {
                DateTime inicioMes = new DateTime(mes.Year, mes.Month, 1);
                DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);

                // Paso 1: traer datos desde la base
                var ventasRaw = (from p in context.PEDIDO
                                 join pp in context.pedido_pago on p.id_pedido equals pp.id_pedido
                                 join u in context.USUARIOS on p.vendedor equals u.nombre
                                 join e in context.Empleado on u.nombre equals e.nombre_usuario
                                 where pp.saldo == 0
                                       && p.fecha_entrega >= inicioMes && p.fecha_entrega <= finMes
                                       && (u.id_rol == 5 || u.id_rol == 6 || u.id_rol == 8)
                                 group p by new { e.nombre, e.apellido, u.id_rol } into g
                                 select new
                                 {
                                     nombre = g.Key.nombre,
                                     apellido = g.Key.apellido,
                                     id_rol = g.Key.id_rol,
                                     total = g.Sum(x => x.total)
                                 }).ToList(); // ejecutado en SQL

                // Paso 2: traducir roles en memoria
                var roles = new Dictionary<int, string>
                {
                    { 5, "Preventista" },
                    { 6, "Empleado Clientes" },
                    { 8, "Administrador" }
                };

                var ventas = ventasRaw
                    .Select(v => (
                        vendedor: $"{v.nombre} {v.apellido} ({roles[v.id_rol]})",
                        total: v.total
                    ))
                    .OrderByDescending(v => v.total)
                    .ToList();

                return ventas;
            }
        }
    }
}
