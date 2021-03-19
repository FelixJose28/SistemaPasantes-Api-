using System;

namespace SistemaPasantes.Core.entities
{
    public partial class RespuestaFormularioDTO
    {
        public int Id { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string JsonData { get; set; }
        public int? Calificacion { get; set; }
        public int IdTipoRespuesta { get; set; }
        public int IdUsuario { get; set; }
        public int IdFormulario { get; set; }
    }
}
