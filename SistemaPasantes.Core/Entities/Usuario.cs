using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Convocatoria = new HashSet<Convocatorium>();
            Evaluacions = new HashSet<Evaluacion>();
            RespuestaFormularios = new HashSet<RespuestaFormulario>();
            TareaEntregas = new HashSet<TareaEntrega>();
            Tareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; }
        public int? IdGrupo { get; set; }

        public virtual Grupo IdGrupoNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
        public virtual Pasante Pasante { get; set; }
        public virtual ICollection<Convocatorium> Convocatoria { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
        public virtual ICollection<RespuestaFormulario> RespuestaFormularios { get; set; }
        public virtual ICollection<TareaEntrega> TareaEntregas { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
