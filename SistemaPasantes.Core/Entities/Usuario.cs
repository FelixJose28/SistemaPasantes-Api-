using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            AdminEvaluacions = new HashSet<AdminEvaluacion>();
            Convocatoria = new HashSet<Convocatorium>();
            Entregas = new HashSet<Entrega>();
            Evaluacions = new HashSet<Evaluacion>();
            PasanteEvaluacions = new HashSet<PasanteEvaluacion>();
            Tareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; }
        public int IdGrupo { get; set; }

        public virtual Grupo IdGrupoNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<AdminEvaluacion> AdminEvaluacions { get; set; }
        public virtual ICollection<Convocatorium> Convocatoria { get; set; }
        public virtual ICollection<Entrega> Entregas { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
        public virtual ICollection<PasanteEvaluacion> PasanteEvaluacions { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
