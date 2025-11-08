using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;

namespace Capa_Logica
{
    public class ClassAuditoriaLogica
    {
        ClassAuditoria auditoria = new ClassAuditoria();
        public List<string> ErroresValidacion => auditoria.ErroresValidacion;

        public bool Registrar(string valorAnterior, string valorNuevo, string nombreAccion, string nombreEntidad, string usuario)
        {
            using (var context = new ArimaERPEntities())
            {
                var accion = context.ACCION.FirstOrDefault(a => a.descripcion == nombreAccion);
                var entidad = context.entidad.FirstOrDefault(e => e.nombre == nombreEntidad);

                if (accion == null || entidad == null)
                {
                    auditoria.ErroresValidacion.Add("Acción o entidad no encontrada.");
                    return false;
                }

                return auditoria.RegistrarAuditoria(valorAnterior, valorNuevo, accion.ID_accion, entidad.entidad_id, usuario);
            }
        }
        public List<entidad> ObtenerEntidades()
        {            
             return auditoria.ObtenerEntidades();            
        }


        public List<ACCION> ObtenerAcciones()
        {
            return auditoria.ObtenerAcciones();
            
        }
        public List<AUDITORIA> ObtenerAuditoriasPorEntidad(int entidad_id)
        {          
                return auditoria.ObtenerAuditoriasPorEntidad(entidad_id);
        }

        public List<AUDITORIA> ObtenerAuditoriasPorAccion(int ID_accion)
        {            
                return auditoria.ObtenerAuditoriasPorAccion(ID_accion);
        }
        public entidad ObtenerEntidadPorId(int entidad_id)
        {
            return auditoria.ObtenerEntidadPorId(entidad_id);
        }

        public ACCION ObtenerAccionPorId(int ID_accion)
        {
            return auditoria.ObtenerAccionPorId(ID_accion);
        }
        public List<AUDITORIA> ObtenerAuditoriasPorUsuario(string nombreUsuario)
        {
            return auditoria.ObtenerAuditoriasPorUsuario(nombreUsuario);
        }
        public List<AUDITORIA> ObtenerAuditoriasPorFecha(DateTime desde, DateTime hasta)
        {
            return auditoria.ObtenerAuditoriasPorFecha(desde, hasta);
        }

    }
}

