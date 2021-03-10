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
            Entregas = new HashSet<Entrega>();
            Evaluacions = new HashSet<Evaluacion>();
            Repuesta = new HashSet<Respuesta>();
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
        public virtual ICollection<Convocatoria> Convocatoria { get; set; }
        public virtual ICollection<Entrega> Entregas { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
        public virtual ICollection<Respuesta> Repuesta { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
