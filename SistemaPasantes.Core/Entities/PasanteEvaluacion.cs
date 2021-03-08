using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.Data
{
    public partial class PasanteEvaluacion
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int IdEvaluacion { get; set; }

        public virtual Evaluacion IdEvaluacionNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
