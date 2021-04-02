using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class Convocatoria
    {
        public Convocatoria()
        {
            Evaluacion = new HashSet<Evaluacion>();
            Grupo = new HashSet<Grupo>();
            Pasante = new HashSet<Pasante>();
            Tarea = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public int Cupo { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdAdminUsuario { get; set; }
        public int IdFormulario { get; set; }

        public virtual Usuario IdAdminUsuarioNavigation { get; set; }
        public virtual Formulario IdFormularioNavigation { get; set; }
        public virtual ICollection<Evaluacion> Evaluacion { get; set; }
        public virtual ICollection<Grupo> Grupo { get; set; }
        public virtual ICollection<Pasante> Pasante { get; set; }
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
