using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class Respuesta
    {
        public int Id { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string Data { get; set; }
        public int? Calificacion { get; set; }
        public bool? TipoRespuesta { get; set; }
        public int IdUsuario { get; set; }
        public int IdFormulario { get; set; }

        public virtual Formulario IdFormularioNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}