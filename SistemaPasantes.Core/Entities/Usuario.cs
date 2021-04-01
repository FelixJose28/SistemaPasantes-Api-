using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Convocatoria = new HashSet<Convocatoria>();
            Evaluacion = new HashSet<Evaluacion>();
            RespuestaFormulario = new HashSet<RespuestaFormulario>();
            Tarea = new HashSet<Tarea>();
            TareaEntrega = new HashSet<TareaEntrega>();
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
        public virtual ICollection<Convocatoria> Convocatoria { get; set; }
        public virtual ICollection<Evaluacion> Evaluacion { get; set; }
        public virtual ICollection<RespuestaFormulario> RespuestaFormulario { get; set; }
        public virtual ICollection<Tarea> Tarea { get; set; }
        public virtual ICollection<TareaEntrega> TareaEntrega { get; set; }
    }
}
