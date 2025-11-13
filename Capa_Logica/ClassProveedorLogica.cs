using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using Capa_Datos;

namespace Capa_Logica
{
    public class ClassProveedorLogica
    {
        ClassProveedor proveedor = new ClassProveedor();
        public List<string> ErroresValidacion => proveedor.ErroresValidacion;
        //obtener todos los proveedores
        public List<PROVEEDOR> ObtenerTodosLosProveedores()
        {
            try
                {
                var proveedores = proveedor.ObtenerTodosLosProveedores();
                return proveedores;
            }
            catch (Exception ex)
            {
                proveedor.ErroresValidacion.Clear();
                proveedor.ErroresValidacion.Add("Error al obtener los proveedores: " + ex.Message);
                return new List<PROVEEDOR>();
            }
        
        }

        public PROVEEDOR CrearProveedor(PROVEEDOR nuevoProveedor)
        {
            var proveedorCreado = proveedor.CrearProveedor(nuevoProveedor);
            return proveedorCreado;
        }
        public bool ActualizarProveedor(PROVEEDOR proveedorActualizado)
        {
            var actualizado = proveedor.ActualizarProveedor(proveedorActualizado);
            return actualizado;
        }
        public PROVEEDOR ObtenerProveedorPorId(int idProveedor)
        {
            var proveedorEncontrado = proveedor.ObtenerProveedorPorId(idProveedor);
            return proveedorEncontrado;
        }

    }
}
