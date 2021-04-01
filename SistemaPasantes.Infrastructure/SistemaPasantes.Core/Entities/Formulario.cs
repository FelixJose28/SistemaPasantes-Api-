using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.SistemaPasantes.Core.Entities
{
    public partial class Formulario
    {
        public Formulario()
        {
            Convocatoria = new HashSet<Convocatoria>();
            Evaluacion = new HashSet<Evaluacion>();
            RespuestaFormulario = new HashSet<RespuestaFormulario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string JsonData { get; set; }
        public int IdTipoFormulario { get; set; }

        public virtual TipoFormulario IdTipoFormularioNavigation { get; set; }
        public virtual ICollection<Convocatoria> Convocatoria { get; set; }
        public virtual ICollection<Evaluacion> Evaluacion { get; set; }
        public virtual ICollection<RespuestaFormulario> RespuestaFormulario { get; set; }
    }
}
