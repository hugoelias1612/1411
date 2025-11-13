using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using Capa_Datos;

namespace Capa_Logica
{
    public class ClassFamiliaLogica
    {
        //obtener todas las familias
        private ClassFamilia familia = new ClassFamilia();
        public List<string> ErroresValidacion => familia.ErroresValidacion;
        public List<FAMILIA> ObtenerTodasLasFamilias()
        {
            return familia.ObtenerTodasLasFamilias();
        }

        public List<FAMILIA> ObtenerFamiliasPorProveedor(int idProveedor)
        {
            return familia.ObtenerFamiliasPorProveedor(idProveedor);
        }
    }
}
