using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Capa_Entidades;
using Capa_Entidades.DTOs;


namespace Capa_Datos
{
    public class ClassCompra
    {
        public List<string> ErroresValidacion { get; private set; } = new List<string>();

        public bool RegistrarCompra(compra nuevaCompra, List<detalle_compra> detalles)
        {
            ErroresValidacion.Clear();

            if (nuevaCompra == null)
            {
                ErroresValidacion.Add("La información de la compra es requerida.");
                return false;
            }

            if (nuevaCompra.fecha == default(DateTime))
            {
                nuevaCompra.fecha = DateTime.Now.Date;
            }
            else
            {
                nuevaCompra.fecha = nuevaCompra.fecha.Date;
            }


            if (detalles == null || detalles.Count == 0)
            {
                ErroresValidacion.Add("Debe especificar al menos un detalle de compra.");
                return false;
            }

            try
            {
                using (var context = new ArimaERPEntities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.compra.Add(nuevaCompra);
                            context.SaveChanges();

                            int correlativo = 1;

                            foreach (var detalle in detalles)
                            {
                                if (detalle == null)
                                {
                                    continue;
                                }

                                if (detalle.cantidad_bulto <= 0)
                                {
                                    ErroresValidacion.Add("La cantidad de un detalle debe ser mayor a cero.");
                                    transaction.Rollback();
                                    return false;
                                }

                                detalle.compra_id = nuevaCompra.compra_id;
                                detalle.detalle_compra_id = correlativo++;

                                context.detalle_compra.Add(detalle);

                                var presentacion = context.producto_presentacion
                                    .FirstOrDefault(pp => pp.id_producto == detalle.id_producto &&
                                                          pp.ID_presentacion == detalle.ID_presentacion);

                                if (presentacion == null)
                                {
                                    ErroresValidacion.Add("No se encontró la presentación del producto seleccionado.");
                                    transaction.Rollback();
                                    return false;
                                }

                                presentacion.precioLista = detalle.precio_unitario;

                                var registroStock = context.stock
                                    .FirstOrDefault(s => s.id_producto == detalle.id_producto &&
                                                         s.ID_presentacion == detalle.ID_presentacion);

                                if (registroStock == null)
                                {
                                    ErroresValidacion.Add("No se encontró el registro de stock del producto seleccionado.");
                                    transaction.Rollback();
                                    return false;
                                }

                                registroStock.stock_actual += detalle.cantidad_bulto;
                            }

                            context.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Add("Error al registrar la compra: " + ex.Message);
                if (ex.InnerException != null)
                {
                    ErroresValidacion.Add("Detalle: " + ex.InnerException.Message);
                }

                return false;
            }
        }


        public List<CompraHistorialDto> ObtenerHistorialCompras()
        {
            ErroresValidacion.Clear();

            try
            {
                using (var context = new ArimaERPEntities())
                {
                    var historial = context.compra
                        .Select(c => new CompraHistorialDto
                        {
                            CompraId = c.compra_id,
                            FechaCompra = c.fecha,
                            Marca = c.detalle_compra
                                .Select(dc => dc.producto_presentacion.PRODUCTO.MARCA.nombre)
                                .FirstOrDefault(),
                            Monto = c.monto,
                            NumeroFactura = c.nro_factura
                        })
                        .OrderByDescending(d => d.FechaCompra)
                        .ThenByDescending(d => d.NumeroFactura)
                        .ToList();

                    return historial;
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Add("Error al obtener el historial de compras: " + ex.Message);
                if (ex.InnerException != null)
                {
                    ErroresValidacion.Add("Detalle: " + ex.InnerException.Message);
                }

                return new List<CompraHistorialDto>();
            }
        }

        public List<CompraDetalleDto> ObtenerDetalleCompra(int compraId)
        {
            ErroresValidacion.Clear();

            try
            {
                using (var context = new ArimaERPEntities())
                {
                    var detalles = context.detalle_compra
                        .Include(d => d.producto_presentacion.PRODUCTO)
                        .Where(d => d.compra_id == compraId)
                        .OrderBy(d => d.detalle_compra_id)
                        .Select(d => new CompraDetalleDto
                        {
                            IdProducto = d.id_producto,
                            NombreProducto = d.producto_presentacion.PRODUCTO.nombre,
                            Cantidad = d.cantidad_bulto,
                            PrecioUnitario = d.precio_unitario
                        })
                        .ToList();

                    return detalles;
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Add("Error al obtener el detalle de la compra: " + ex.Message);
                if (ex.InnerException != null)
                {
                    ErroresValidacion.Add("Detalle: " + ex.InnerException.Message);
                }

                return new List<CompraDetalleDto>();
            }
        }
    }
}
