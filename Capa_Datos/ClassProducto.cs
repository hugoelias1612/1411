using Capa_Entidades;
using Capa_Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class ClassProducto
    {
        public List<string> ErroresValidacion { get; private set; } = new List<string>();
        //obtener producto_presentacion por cod_producto
        public int CrearProducto(PRODUCTO producto)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    context.PRODUCTO.Add(producto);
                    context.SaveChanges();
                }
                return producto.id_producto;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                ErroresValidacion.Clear();
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var error in validationErrors.ValidationErrors)
                    {
                        string mensaje = $"Entidad: {validationErrors.Entry.Entity.GetType().Name}, Campo: {error.PropertyName}, Error: {error.ErrorMessage}";
                        ErroresValidacion.Add(mensaje);
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error general al guardar el producto: " + ex.Message);
                if (ex.InnerException != null)
                    ErroresValidacion.Add("Inner: " + ex.InnerException.Message);
                if (ex.InnerException?.InnerException != null)
                    ErroresValidacion.Add("Inner deeper: " + ex.InnerException.InnerException.Message);
                return -1;
            }
        }
        public producto_presentacion CrearProductoPresentacion(producto_presentacion nuevoProductoPresentacion)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    context.producto_presentacion.Add(nuevoProductoPresentacion);
                    context.SaveChanges();
                }
                return nuevoProductoPresentacion;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                ErroresValidacion.Clear();
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var error in validationErrors.ValidationErrors)
                    {
                        string mensaje = $"Entidad: {validationErrors.Entry.Entity.GetType().Name}, Campo: {error.PropertyName}, Error: {error.ErrorMessage}";
                        ErroresValidacion.Add(mensaje);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error general al guardar producto_presentacion: " + ex.Message);
                if (ex.InnerException != null)
                    ErroresValidacion.Add("Inner: " + ex.InnerException.Message);
                if (ex.InnerException?.InnerException != null)
                    ErroresValidacion.Add("Inner deeper: " + ex.InnerException.InnerException.Message);
                return null;
            }
        }

        public producto_presentacion ObtenerProductoPresentacionPorCodigo(int cod_producto)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.producto_presentacion.FirstOrDefault(p => p.cod_producto == cod_producto);
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add(ex.Message);
                return null;
            }
        }
        public stock CrearStock(stock nuevoStock)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    context.stock.Add(nuevoStock);
                    context.SaveChanges();
                }
                return nuevoStock;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                ErroresValidacion.Clear();
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var error in validationErrors.ValidationErrors)
                    {
                        string mensaje = $"Entidad: {validationErrors.Entry.Entity.GetType().Name}, Campo: {error.PropertyName}, Error: {error.ErrorMessage}";
                        ErroresValidacion.Add(mensaje);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error general al guardar el stock: " + ex.Message);
                if (ex.InnerException != null)
                    ErroresValidacion.Add("Inner: " + ex.InnerException.Message);
                if (ex.InnerException?.InnerException != null)
                    ErroresValidacion.Add("Inner deeper: " + ex.InnerException.InnerException.Message);
                return null;
            }
        }

        //obtener producto por id_producto
        public PRODUCTO ObtenerProductoPorId(int id_producto)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.PRODUCTO.FirstOrDefault(p => p.id_producto == id_producto);
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add(ex.Message);
                return null;
            }
        }
        //obtener  PRESENTACION por id_presentacion
        public PRESENTACION ObtenerPresentacionPorId(int id_presentacion)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.PRESENTACION.FirstOrDefault(p => p.ID_presentacion == id_presentacion);
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add(ex.Message);
                return null;
            }
        }
        //obtener objeto stock por id_producto y id_presentacion
        public stock ObtenerStockPorProductoYPresentacion(int id_producto, int id_presentacion)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.stock.FirstOrDefault(s => s.id_producto == id_producto && s.ID_presentacion == id_presentacion);
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add(ex.Message);
                return null;
            }
        }

        //validar disponibilidad del código de producto
        public bool EsCodigoDeProductoDisponible(int codigo, int? idProductoExcluir = null, int? idPresentacionExcluir = null)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    ErroresValidacion.Clear();
                    var query = context.producto_presentacion.AsQueryable();

                    if (idProductoExcluir.HasValue && idPresentacionExcluir.HasValue)
                    {
                        int productoId = idProductoExcluir.Value;
                        int presentacionId = idPresentacionExcluir.Value;
                        query = query.Where(pp => !(pp.id_producto == productoId && pp.ID_presentacion == presentacionId));
                    }
                    else if (idProductoExcluir.HasValue)
                    {
                        int productoId = idProductoExcluir.Value;
                        query = query.Where(pp => pp.id_producto != productoId);
                    }

                    return !query.Any(pp => pp.cod_producto == codigo);
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al validar el código del producto: " + ex.Message);
                return false;
            }
        }
        //crear producto, presentación y stock inicial
        public bool CrearProductoConPresentacionYStock(
            PRODUCTO nuevoProducto,
            producto_presentacion nuevaPresentacion,
            stock stockInicial)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    ErroresValidacion.Clear();

                    if (!context.PRESENTACION.Any(p => p.ID_presentacion == nuevaPresentacion.ID_presentacion))
                    {
                        ErroresValidacion.Add("La presentación indicada no existe.");
                        return false;
                    }

                    if (context.producto_presentacion.Any(pp => pp.cod_producto == nuevaPresentacion.cod_producto))
                    {
                        ErroresValidacion.Add("El código de producto ya está asignado a otra presentación.");
                        return false;
                    }

                    if (stockInicial != null)
                    {
                        if (stockInicial.stock_actual < 0)
                        {
                            ErroresValidacion.Add("El stock inicial no puede ser negativo.");
                            return false;
                        }

                        if (stockInicial.umbral_stock < 0)
                        {
                            ErroresValidacion.Add("El umbral de stock no puede ser negativo.");
                            return false;
                        }
                    }

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.PRODUCTO.Add(nuevoProducto);
                            context.SaveChanges();

                            nuevaPresentacion.id_producto = nuevoProducto.id_producto;
                            context.producto_presentacion.Add(nuevaPresentacion);
                            context.SaveChanges();

                            if (stockInicial != null)
                            {
                                stockInicial.id_producto = nuevoProducto.id_producto;
                                stockInicial.ID_presentacion = nuevaPresentacion.ID_presentacion;
                                context.stock.Add(stockInicial);
                                context.SaveChanges();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al crear el producto: " + ex.Message);
                return false;
            }
        }
        public List<ProductoCatalogoDto> BuscarCatalogoProductos(string termino, int? idFamilia, int? idMarca, int? _idProveedor, bool? activo)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    ErroresValidacion.Clear();

                    var query = from pp in context.producto_presentacion
                                join producto in context.PRODUCTO on pp.id_producto equals producto.id_producto
                                join familia in context.FAMILIA on producto.id_familia equals familia.id_familia
                                join marca in context.MARCA on producto.id_marca equals marca.id_marca
                                join presentacion in context.PRESENTACION on pp.ID_presentacion equals presentacion.ID_presentacion
                                join stockRegistro in context.stock on new { pp.id_producto, pp.ID_presentacion } equals new { stockRegistro.id_producto, stockRegistro.ID_presentacion } into stockJoin
                                from stockRegistro in stockJoin.DefaultIfEmpty()
                                from proveedor in marca.PROVEEDOR.DefaultIfEmpty()
                                select new { pp, producto, familia, marca, presentacion, stockRegistro, proveedor };

                    if (activo.HasValue)
                    {
                        bool estado = activo.Value;
                        query = query.Where(x => x.pp.activo == estado);
                    }

                    if (idFamilia.HasValue)
                    {
                        int familiaId = idFamilia.Value;
                        query = query.Where(x => x.producto.id_familia == familiaId);
                    }

                    if (idMarca.HasValue)
                    {
                        int marcaId = idMarca.Value;
                        query = query.Where(x => x.producto.id_marca == marcaId);
                    }

                    if (!string.IsNullOrWhiteSpace(termino))
                    {
                        string terminoNormalizado = termino.Trim().ToLower();
                        int codigoBuscado;
                        bool terminoEsNumero = int.TryParse(termino.Trim(), out codigoBuscado);

                        query = query.Where(x =>
                            x.producto.nombre.ToLower().Contains(terminoNormalizado) ||
                            x.marca.nombre.ToLower().Contains(terminoNormalizado) ||
                            x.familia.descripcion.ToLower().Contains(terminoNormalizado) ||
                            x.presentacion.descripcion.ToLower().Contains(terminoNormalizado) ||
                            (terminoEsNumero && x.pp.cod_producto == codigoBuscado));
                    }

                    return query
                        .OrderBy(x => x.producto.nombre)
                        .ThenBy(x => x.presentacion.descripcion)
                        .Select(x => new
                        {
                            Dto = new ProductoCatalogoDto
                            {
                                IdProducto = x.pp.id_producto,
                                IdPresentacion = x.pp.ID_presentacion,
                                Codigo = x.pp.cod_producto,
                                Nombre = x.producto.nombre,
                                Marca = x.marca.nombre,
                                Familia = x.familia.descripcion,
                                Presentacion = x.presentacion.descripcion,
                                PrecioLista = x.pp.precioLista,
                                UnidadesPorBulto = x.pp.unidades_bulto,
                                Activo = x.pp.activo,
                                StockActual = x.stockRegistro != null ? x.stockRegistro.stock_actual : 0,
                                UmbralStock = x.stockRegistro != null ? x.stockRegistro.umbral_stock : 0
                            },
                            ProveedorNombre = x.proveedor != null ? x.proveedor.nombre : string.Empty
                        })
                        .AsEnumerable()
                        .GroupBy(x => new { x.Dto.IdProducto, x.Dto.IdPresentacion })
                        .Select(g =>
                        {
                            var producto = g.First().Dto;
                            var proveedores = g
                                .Select(x => x.ProveedorNombre)
                                .Where(nombre => !string.IsNullOrWhiteSpace(nombre))
                                .Distinct()
                                .ToList();

                            producto.Proveedor = proveedores.Any()
                                ? string.Join(" / ", proveedores)
                                : string.Empty;

                            return producto;
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al buscar productos: " + ex.Message);
                return new List<ProductoCatalogoDto>();
            }
        }
        //cambiar estado activo/inactivo de la presentación
        public bool CambiarEstadoProducto(int idProducto, int idPresentacion, bool activo)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    ErroresValidacion.Clear();

                    var presentacion = context.producto_presentacion.FirstOrDefault(pp => pp.id_producto == idProducto && pp.ID_presentacion == idPresentacion);
                    if (presentacion == null)
                    {
                        ErroresValidacion.Add("No se encontró la presentación indicada.");
                        return false;
                    }

                    presentacion.activo = activo;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al actualizar el estado del producto: " + ex.Message);
                return false;
            }
        }
        //obtener productos con stock crítico
        public List<ProductoCatalogoDto> ObtenerProductosConStockCritico(
             int? idFamilia = null,
             int? idProveedor = null,
             int? stockMaximo = null,
             bool soloStockInsuficiente = false)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    ErroresValidacion.Clear();

                    var query = from stockRegistro in context.stock
                                join pp in context.producto_presentacion on new { stockRegistro.id_producto, stockRegistro.ID_presentacion } equals new { pp.id_producto, pp.ID_presentacion }
                                join producto in context.PRODUCTO on stockRegistro.id_producto equals producto.id_producto
                                join familia in context.FAMILIA on producto.id_familia equals familia.id_familia
                                join marca in context.MARCA on producto.id_marca equals marca.id_marca
                                join presentacion in context.PRESENTACION on stockRegistro.ID_presentacion equals presentacion.ID_presentacion
                                from proveedor in marca.PROVEEDOR.DefaultIfEmpty()
                                select new { stockRegistro, pp, producto, familia, marca, presentacion, proveedor };

                    if (soloStockInsuficiente)
                    {
                        query = query.Where(x => x.stockRegistro.stock_actual < x.stockRegistro.umbral_stock);
                    }

                    if (stockMaximo.HasValue)
                    {
                        int maximo = stockMaximo.Value;
                        query = query.Where(x => x.stockRegistro.stock_actual <= maximo);
                    }

                    if (idFamilia.HasValue)
                    {
                        int familiaId = idFamilia.Value;
                        query = query.Where(x => x.producto.id_familia == familiaId);
                    }

                    if (idProveedor.HasValue)
                    {
                        int proveedorId = idProveedor.Value;
                        query = query.Where(x => x.proveedor != null && x.proveedor.id_proveedor == proveedorId);
                    }

                    return query
                        .OrderBy(x => x.stockRegistro.stock_actual - x.stockRegistro.umbral_stock)
                        .ThenBy(x => x.producto.nombre)
                        .Select(x => new
                        {
                            Dto = new ProductoCatalogoDto
                            {
                                IdProducto = x.pp.id_producto,
                                IdPresentacion = x.pp.ID_presentacion,
                                Codigo = x.pp.cod_producto,
                                Nombre = x.producto.nombre,
                                Marca = x.marca.nombre,
                                Familia = x.familia.descripcion,
                                Presentacion = x.presentacion.descripcion,
                                PrecioLista = x.pp.precioLista,
                                UnidadesPorBulto = x.pp.unidades_bulto,
                                Activo = x.pp.activo,
                                StockActual = x.stockRegistro.stock_actual,
                                UmbralStock = x.stockRegistro.umbral_stock
                            },
                            ProveedorNombre = x.proveedor != null ? x.proveedor.nombre : string.Empty
                        })
                        .AsEnumerable()
                        .GroupBy(x => new { x.Dto.IdProducto, x.Dto.IdPresentacion })
                        .Select(g =>
                        {
                            var producto = g.First().Dto;
                            var proveedores = g
                                .Select(x => x.ProveedorNombre)
                                .Where(nombre => !string.IsNullOrWhiteSpace(nombre))
                                .Distinct()
                                .ToList();

                            producto.Proveedor = proveedores.Any()
                                ? string.Join(" / ", proveedores)
                                : string.Empty;

                            return producto;
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al obtener los productos con stock crítico: " + ex.Message);
                return new List<ProductoCatalogoDto>();
            }
        }
        //ajustar stock actual en base a un movimiento (positivo o negativo)
        public bool AjustarStock(int idProducto, int idPresentacion, int cantidad)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    ErroresValidacion.Clear();

                    var registroStock = context.stock.FirstOrDefault(s => s.id_producto == idProducto && s.ID_presentacion == idPresentacion);
                    if (registroStock == null)
                    {
                        ErroresValidacion.Add("No existe un registro de stock para el producto indicado.");
                        return false;
                    }

                    int nuevoStock = registroStock.stock_actual + cantidad;
                    if (nuevoStock < 0)
                    {
                        ErroresValidacion.Add("El ajuste de stock dejaría el stock en negativo.");
                        return false;
                    }

                    registroStock.stock_actual = nuevoStock;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al ajustar el stock del producto: " + ex.Message);
                return false;
            }
        }
        //actualizar datos del producto y su presentación
        public bool ActualizarProductoCompleto(PRODUCTO datosProducto, producto_presentacion datosPresentacion)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    ErroresValidacion.Clear();

                    var productoExistente = context.PRODUCTO.FirstOrDefault(p => p.id_producto == datosProducto.id_producto);
                    if (productoExistente == null)
                    {
                        ErroresValidacion.Add("No se encontró el producto indicado.");
                        return false;
                    }

                    var presentacionExistente = context.producto_presentacion.FirstOrDefault(pp => pp.id_producto == datosPresentacion.id_producto && pp.ID_presentacion == datosPresentacion.ID_presentacion);
                    if (presentacionExistente == null)
                    {
                        ErroresValidacion.Add("No se encontró la presentación asociada al producto.");
                        return false;
                    }

                    bool codigoDuplicado = context.producto_presentacion.Any(pp =>
                        pp.cod_producto == datosPresentacion.cod_producto &&
                        !(pp.id_producto == datosPresentacion.id_producto && pp.ID_presentacion == datosPresentacion.ID_presentacion));

                    if (codigoDuplicado)
                    {
                        ErroresValidacion.Add("El código de producto ya está asignado a otra presentación.");
                        return false;
                    }

                    productoExistente.nombre = datosProducto.nombre;
                    productoExistente.id_familia = datosProducto.id_familia;
                    productoExistente.id_marca = datosProducto.id_marca;

                    presentacionExistente.cod_producto = datosPresentacion.cod_producto;
                    presentacionExistente.precioLista = datosPresentacion.precioLista;
                    presentacionExistente.unidades_bulto = datosPresentacion.unidades_bulto;
                    presentacionExistente.activo = datosPresentacion.activo;

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al actualizar el producto: " + ex.Message);
                return false;
            }
        }
        //establecer stock actual y umbral
        public bool EstablecerStock(int idProducto, int idPresentacion, int stockActual, int umbralStock)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    ErroresValidacion.Clear();

                    if (stockActual < 0)
                    {
                        ErroresValidacion.Add("El stock no puede ser negativo.");
                        return false;
                    }

                    if (umbralStock < 0)
                    {
                        ErroresValidacion.Add("El umbral de stock no puede ser negativo.");
                        return false;
                    }

                    var presentacion = context.producto_presentacion.FirstOrDefault(pp => pp.id_producto == idProducto && pp.ID_presentacion == idPresentacion);
                    if (presentacion == null)
                    {
                        ErroresValidacion.Add("No se encontró la presentación asociada al producto.");
                        return false;
                    }

                    var registroStock = context.stock.FirstOrDefault(s => s.id_producto == idProducto && s.ID_presentacion == idPresentacion);
                    if (registroStock == null)
                    {
                        registroStock = new stock
                        {
                            id_producto = idProducto,
                            ID_presentacion = idPresentacion
                        };
                        context.stock.Add(registroStock);
                    }

                    registroStock.stock_actual = stockActual;
                    registroStock.umbral_stock = umbralStock;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al actualizar el stock del producto: " + ex.Message);
                return false;
            }
        }


        public List<PRESENTACION> ObtenerPresentacionesPorRango(int desde, int hasta)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    ErroresValidacion.Clear();
                    return context.PRESENTACION
                                  .Where(p => p.ID_presentacion >= desde && p.ID_presentacion <= hasta)
                                  .OrderBy(p => p.ID_presentacion)
                                  .ToList();
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al obtener las presentaciones: " + ex.Message);
                return new List<PRESENTACION>();
            }
        }
        //obtener lista de producto_presentacion
        public List<producto_presentacion> ListarProductoPresentacion()
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.producto_presentacion.ToList();
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add(ex.Message);
                return new List<producto_presentacion>();
            }
        }
        //listar productos
        public List<PRODUCTO> ListarProductos()
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.PRODUCTO.ToList();
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add(ex.Message);
                return new List<PRODUCTO>();
            }
        }
        //listar presentaciones
        public List<PRESENTACION> ListarPresentaciones()
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.PRESENTACION.ToList();
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add(ex.Message);
                return new List<PRESENTACION>();
            }
        }
        //obtener lista de producto_presentacion activo y stock > 0
        public List<producto_presentacion> ListarProductoPresentacionActivosConStock()
        {
            //lista para usar en combo de productos en formulario de pedidos
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    var lista = (from pp in context.producto_presentacion
                                 join p in context.PRODUCTO on pp.id_producto equals p.id_producto
                                 join s in context.stock on new { pp.id_producto, pp.ID_presentacion } equals new { s.id_producto, s.ID_presentacion }
                                 where pp.activo == true && s.stock_actual > 0
                                 select pp).ToList();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add(ex.Message);
                return new List<producto_presentacion>();
            }
        }
        //obtener producto_presentacion por id_producto_presentacion
        public producto_presentacion ObtenerProductoPresentacionPorId_productoId_ID_presentacion(int id_producto, int ID_presentacion)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.producto_presentacion.FirstOrDefault(p => p.id_producto == id_producto && p.ID_presentacion == ID_presentacion);
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add(ex.Message);
                return null;
            }
        }
        //obtener producto por familia
        public List<PRODUCTO> ObtenerProductosPorFamilia(int familia)
        {


            using (var context = new ArimaERPEntities())
            {
                return context.PRODUCTO.Where(p => p.id_familia == familia).ToList();
            }
        }
        //obtener productos por marca
        public List<PRODUCTO> ObtenerProductoPorMarca(int marca)
        {
            using (var context = new ArimaERPEntities())
            {
                return context.PRODUCTO.Where(p => p.id_marca == marca).ToList();
            }
        }
        
    }

     }
