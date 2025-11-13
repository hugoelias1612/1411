using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Capa_Entidades;

namespace Capa_Datos
{
    public class ClassFamilia
    {
        public List<string> ErroresValidacion { get; private set; } = new List<string>();
        //obtener todas las familias
        public List<FAMILIA> ObtenerTodasLasFamilias()
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.FAMILIA.ToList();
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al obtener las familias: " + ex.Message);
                return new List<FAMILIA>();
            }
        }

        public List<FAMILIA> ObtenerFamiliasPorProveedor(int idProveedor)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    return context.PROVEEDOR
                        .Where(p => p.id_proveedor == idProveedor)
                        .SelectMany(p => p.MARCA)
                        .SelectMany(m => m.PRODUCTO)
                        .Select(producto => producto.FAMILIA)
                        .Where(familia => familia != null)
                        .Distinct()
                        .OrderBy(familia => familia.descripcion)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al obtener las familias por proveedor: " + ex.Message);
                return new List<FAMILIA>();
            }
        }
    }
}