using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using Capa_Datos;

namespace Capa_Logica
{
    public class ClassMarcaLogica
    {
        ClassMarca marca = new Capa_Datos.ClassMarca();
        public List<string> ErroresValidacion { get; private set; } = new List<string>();
        //obtener todas las marcas
        public List<MARCA> ObtenerTodasLasMarcas()
        {
            try
            {
                var marcas = marca.ObtenerTodasLasMarcas();
                ErroresValidacion = marca.ErroresValidacion;
                return marcas;
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
                var marcaObj = marca.ObtenerMarcaPorId(id_marca);
                ErroresValidacion = marca.ErroresValidacion;
                return marcaObj;
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
            var marcaCreada = marca.CrearMarca(nuevaMarca);
            return marcaCreada;
        }

        public List<MARCA> ObtenerMarcasPorProveedor(int idProveedor)
        {
            var marcas = marca.ObtenerMarcasPorProveedor(idProveedor);
            ErroresValidacion = marca.ErroresValidacion;
            return marcas;
        }


    }
}
