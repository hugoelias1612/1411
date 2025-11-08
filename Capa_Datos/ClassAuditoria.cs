using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class ClassAuditoria
    {
        public List<string> ErroresValidacion { get; set; } = new List<string>();

        public List<entidad> ObtenerEntidades()
        {
            using (var context = new ArimaERPEntities())
            {
                return context.entidad.ToList();
            }
        }
               

        public List<ACCION> ObtenerAcciones()
        {
            using (var context = new ArimaERPEntities())
            {
                return context.ACCION.ToList();
            }
        }

        public List<AUDITORIA> ObtenerAuditoriasPorEntidad(int entidad_id)
        {
            using (var context = new ArimaERPEntities())
            {
                return context.AUDITORIA
                    .Where(a => a.entidad_id == entidad_id)
                    .OrderByDescending(a => a.fecha_hora)
                    .ToList();
            }
        }

        public List<AUDITORIA> ObtenerAuditoriasPorAccion(int ID_accion)
        {
            using (var context = new ArimaERPEntities())
            {
                return context.AUDITORIA
                    .Where(a => a.ID_accion == ID_accion)
                    .OrderByDescending(a => a.fecha_hora)
                    .ToList();
            }
        }

        public bool RegistrarAuditoria(string valorAnterior, string valorNuevo, int idAccion, int entidadId, string usuario)
        {
            try
            {
                using (var context = new ArimaERPEntities())
                {
                    var auditoria = new AUDITORIA
                    {
                        fecha_hora = DateTime.Now,
                        valor_nuevo = valorNuevo,
                        valor_anterior = valorAnterior,                        
                        ID_accion = idAccion,
                        entidad_id = entidadId,
                        usuario = usuario
                    };

                    context.AUDITORIA.Add(auditoria);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErroresValidacion.Clear();
                ErroresValidacion.Add("Error al registrar auditoría: " + ex.Message);
                return false;
            }
        }
        //Obtener entidad por id

        public entidad ObtenerEntidadPorId(int entidad_id)
        {
            using (var context = new ArimaERPEntities())
            {
                return context.entidad.FirstOrDefault(e => e.entidad_id == entidad_id);
            }
        }
        public ACCION ObtenerAccionPorId(int ID_accion)
        {
            using (var context = new ArimaERPEntities())
            {
                return context.ACCION.FirstOrDefault(a => a.ID_accion == ID_accion);
            }
        }
        public List<AUDITORIA> ObtenerAuditoriasPorUsuario(string nombreUsuario)
        {
            using(var context = new ArimaERPEntities())
            {
                return context.AUDITORIA
                    .Where(a => a.usuario == nombreUsuario)
                    .OrderByDescending(a => a.fecha_hora)
                    .ToList();
            }
        }
        public List<AUDITORIA> ObtenerAuditoriasPorFecha(DateTime desde, DateTime hasta)
        {
            using (var context = new ArimaERPEntities())
            {
                return context.AUDITORIA
                    .Where(a => a.fecha_hora >= desde && a.fecha_hora <= hasta)
                    .OrderByDescending(a => a.fecha_hora)
                    .ToList();
            }
        }

    }
}
