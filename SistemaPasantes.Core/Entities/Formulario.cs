using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class Formulario
    {
        public Formulario()
        {
            Convocatoria = new HashSet<Convocatorium>();
            Evaluacions = new HashSet<Evaluacion>();
            RespuestaFormularios = new HashSet<RespuestaFormulario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string JsonData { get; set; }

        public virtual ICollection<Convocatorium> Convocatoria { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
        public virtual ICollection<RespuestaFormulario> RespuestaFormularios { get; set; }
    }
}
