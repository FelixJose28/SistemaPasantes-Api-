using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.entities
{
    public partial class Formulario
    {
        public Formulario()
        {
            Convocatoria = new HashSet<Convocatoria>();
            Evaluacions = new HashSet<Evaluacion>();
            RespuestaFormularios = new HashSet<RespuestaFormulario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string JsonData { get; set; }

        public virtual ICollection<Convocatoria> Convocatoria { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
        public virtual ICollection<RespuestaFormulario> RespuestaFormularios { get; set; }
    }
}
