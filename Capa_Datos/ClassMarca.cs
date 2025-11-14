using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capa_Datos
{
    public class ClassMarca
    {
        
        public List<string> ErroresValidacion { get; private set; } = new List<string>();
        //obtener todas las marcas
        public List<MARCA> ObtenerTodasLasMarcas()
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.MARCA.ToList();
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al obtener las marcas: " + ex.Message);
                return new List<MARCA>();
            }
        }
        //obtener marca por id
        public MARCA ObtenerMarcaPorId(int id_marca)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.MARCA.FirstOrDefault(m => m.id_marca == id_marca);
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al obtener la marca: " + ex.Message);
                return null;
            }
        }
        public MARCA CrearMarca(MARCA nuevaMarca)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    context.MARCA.Add(nuevaMarca);
                    context.SaveChanges();
                    return nuevaMarca;
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
                ErroresValidacion.Add("Error al crear la marca: " + ex.Message);
                return null;
            }
        }

        public List<MARCA> ObtenerMarcasPorProveedor(int idProveedor)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.PROVEEDOR
                        .Where(p => p.id_proveedor == idProveedor)
                        .SelectMany(p => p.MARCA)
                        .Distinct()
                        .OrderBy(m => m.nombre)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al obtener las marcas por proveedor: " + ex.Message);
                return new List<MARCA>();
            }
        }
    }
}
