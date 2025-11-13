using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Capa_Entidades;

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
    }
}