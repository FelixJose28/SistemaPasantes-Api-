using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class TipoRespuestaEvaluacion
    {
        public TipoRespuestaEvaluacion()
        {
            RespuestaFormularios = new HashSet<RespuestaFormulario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<RespuestaFormulario> RespuestaFormularios { get; set; }
    }
}
