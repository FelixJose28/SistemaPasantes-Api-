using System;
using System.Collections.Generic;
using SistemaPasantes.Core.Entities;

#nullable disable

namespace SistemaPasantes.Core.entities
{
    public partial class RespuestaFormulario
    {
        public int Id { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string JsonData { get; set; }
        public int? Calificacion { get; set; }
        public int IdTipoRespuesta { get; set; }
        public int IdUsuario { get; set; }
        public int IdFormulario { get; set; }

        public virtual Formulario IdFormularioNavigation { get; set; }
        public virtual TipoRespuestaEvaluacion IdTipoRespuestaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
