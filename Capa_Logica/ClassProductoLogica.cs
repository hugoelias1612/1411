using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using Capa_Datos;

namespace Capa_Logica
{
    public class ClassProductoLogica
    {
        public List<string> ErroresValidacion { get; private set; } = new List<string>();
        //instanciar ClassProducto
        ClassProducto classProducto = new Capa_Datos.ClassProducto();
       
        private PRODUCTO producto = new PRODUCTO();
        private producto_presentacion  productoPresentacion = new producto_presentacion();
        //obtener producto_presentacion por cod_producto
        public producto_presentacion ObtenerProductoPresentacionPorCodigo(int cod_producto)
        {
            var productoPresentacion = classProducto.ObtenerProductoPresentacionPorCodigo(cod_producto);
            if (productoPresentacion == null)
            {
                ErroresValidacion = classProducto.ErroresValidacion;
            }
            return productoPresentacion;
        }
        //obtener producto por id_producto
        public PRODUCTO ObtenerProductoPorId(int id_producto)
        {
            var producto = classProducto.ObtenerProductoPorId(id_producto);
            if (producto == null)
            {
                ErroresValidacion = classProducto.ErroresValidacion;
            }
            return producto;
        }
        //obtener  PRESENTACION por id_presentacion
        public PRESENTACION ObtenerPresentacionPorId(int id_presentacion)
        {
            var presentacion = classProducto.ObtenerPresentacionPorId(id_presentacion);
            if (presentacion == null)
            {
                ErroresValidacion = classProducto.ErroresValidacion;
            }
            return presentacion;
        }
        //obtener objeto stock por id_producto y id_presentacion
        public stock ObtenerStockPorProductoYPresentacion(int id_producto, int id_presentacion)
        {
            var stock = classProducto.ObtenerStockPorProductoYPresentacion(id_producto, id_presentacion);
            if (stock == null)
            {
                ErroresValidacion = classProducto.ErroresValidacion;
            }
            return stock;
        }
        //obtener lista de producto_presentacion
        public List<producto_presentacion> ObtenerListaProductoPresentacion()
        {
            var lista = classProducto.ListarProductoPresentacion();
            if (lista == null)
            {
                ErroresValidacion = classProducto.ErroresValidacion;
            }
            return lista;
        }
        //obtener lista de productos
        public List<PRODUCTO> ObtenerListaProductos()
        {
            var lista = classProducto.ListarProductos();
            if (lista == null)
            {
                ErroresValidacion = classProducto.ErroresValidacion;
            }
            return lista;
        }
        //obtener lista de presentaciones
        public List<PRESENTACION> ObtenerListaPresentaciones()
        {
            var lista = classProducto.ListarPresentaciones();
            if (lista == null)
            {
                ErroresValidacion = classProducto.ErroresValidacion;
            }
            return lista;
        }
        public List<producto_presentacion> ListarProductoPresentacionActivosConStock()
        {
            var lista = classProducto.ListarProductoPresentacionActivosConStock();
            if (lista == null)
            {
                ErroresValidacion = classProducto.ErroresValidacion;
            }
            return lista;
        }
        //obtener producto_presentacion por id_producto id_presentacion
        public producto_presentacion ObtenerProductoPresentacionPorProductoYPresentacion(int id_producto, int id_presentacion)
        {
            var productoPresentacion = classProducto.ObtenerProductoPresentacionPorId_productoId_ID_presentacion(id_producto, id_presentacion);
            if (productoPresentacion == null)
            {
                ErroresValidacion = classProducto.ErroresValidacion;
            }
            return productoPresentacion;
        }
        //Obtener producto por familia
        public List<PRODUCTO> ObtenerProductosPorFamilia(int familia)
        {
            return classProducto.ObtenerProductosPorFamilia(familia);
        }
        public List<PRODUCTO> ObtenerProductoPorMarca(int marca)
        {
            return classProducto.ObtenerProductoPorMarca(marca);
        }
        public int CrearProducto(string nombre, int id_familia, int id_marca)
        {
            try
            {
                producto.nombre = nombre;
                producto.id_familia = id_familia;
                producto.id_marca = id_marca;
                return classProducto.CrearProducto(producto);
            }
            catch (Exception ex)
            {
                classProducto.ErroresValidacion.Clear();
                classProducto.ErroresValidacion.Add("Error al agregar el producto: " + ex.Message);
                return -1;
            }
        }
       public producto_presentacion CrearProductoPresentacion(int id_producto, int ID_presentacion, int cod_producto, decimal precioLista, int unidades_bulto, bool activo)
        {
            try
            {
                productoPresentacion.id_producto = id_producto;
                productoPresentacion.ID_presentacion = ID_presentacion;
                productoPresentacion.cod_producto = cod_producto;
                productoPresentacion.precioLista = precioLista;
                productoPresentacion.unidades_bulto = unidades_bulto;
                productoPresentacion.activo = activo;
                return classProducto.CrearProductoPresentacion(productoPresentacion);
            }
            catch (Exception ex)
            {
                classProducto.ErroresValidacion.Clear();
                classProducto.ErroresValidacion.Add("Error al agregar el producto: " + ex.Message);
                return null;
            }
        }
        public stock CrearStock(int stock_actual, int umbral_stock, int id_producto, int ID_presentacion)
        {
            try
            {
                stock nuevoStock = new stock();
                nuevoStock.stock_actual = stock_actual;
                nuevoStock.umbral_stock = umbral_stock;
                nuevoStock.id_producto = id_producto;
                nuevoStock.ID_presentacion = ID_presentacion;

                return classProducto.CrearStock(nuevoStock);
            }
            catch (Exception ex)
            {
                classProducto.ErroresValidacion.Clear();
                classProducto.ErroresValidacion.Add("Error al agregar el stock: " + ex.Message);
                return null;
            }
        }

    }
}

