using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.Data
{
    public partial class Evaluacion
    {
        public Evaluacion()
        {
            AdminEvaluacions = new HashSet<AdminEvaluacion>();
            PasanteEvaluacions = new HashSet<PasanteEvaluacion>();
        }

        public int Id { get; set; }
        public int? Calificacion { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<AdminEvaluacion> AdminEvaluacions { get; set; }
        public virtual ICollection<PasanteEvaluacion> PasanteEvaluacions { get; set; }
    }
}
