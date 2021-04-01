using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.SistemaPasantes.Core.Entities
{
    public partial class TipoFormulario
    {
        public TipoFormulario()
        {
            Formulario = new HashSet<Formulario>();
            RespuestaFormulario = new HashSet<RespuestaFormulario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Formulario> Formulario { get; set; }
        public virtual ICollection<RespuestaFormulario> RespuestaFormulario { get; set; }
    }
}
