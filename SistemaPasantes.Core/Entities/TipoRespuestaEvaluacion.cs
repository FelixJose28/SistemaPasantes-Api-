using System;
using System.Collections.Generic;
using SistemaPasantes.Core.Entities;

#nullable disable

namespace SistemaPasantes.Core.entities
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
