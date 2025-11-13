using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class ClassProveedor
    {
        public List<string> ErroresValidacion { get; private set; } = new List<string>();
        //obtener todos los proveedores
        public List<PROVEEDOR> ObtenerTodosLosProveedores()
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.PROVEEDOR.ToList();
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al obtener los proveedores: " + ex.Message);
                return new List<PROVEEDOR>();
            }
        }
        public PROVEEDOR CrearProveedor(PROVEEDOR nuevoProveedor)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    context.PROVEEDOR.Add(nuevoProveedor);
                    context.SaveChanges();
                    return nuevoProveedor;
                }
            }
            catch (DbEntityValidationException ex)
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
                ErroresValidacion.Add("Error al crear el proveedor: " + ex.Message);
                return null;
            }
        }
        public bool ActualizarProveedor(PROVEEDOR proveedorActualizado)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    var proveedorExistente = context.PROVEEDOR.FirstOrDefault(p => p.id_proveedor == proveedorActualizado.id_proveedor);
                    if (proveedorExistente == null)
                    {
                        ErroresValidacion.Clear();
                        ErroresValidacion.Add("El proveedor seleccionado no existe.");
                        return false;
                    }

                    context.Entry(proveedorExistente).CurrentValues.SetValues(proveedorActualizado);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (DbEntityValidationException ex)
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
                return false;
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al actualizar el proveedor: " + ex.Message);
                return false;
            }
        }
        public PROVEEDOR ObtenerProveedorPorId(int idProveedor)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.PROVEEDOR.FirstOrDefault(p => p.id_proveedor == idProveedor);
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al obtener el proveedor: " + ex.Message);
                return null;
            }
        }
    }
}
