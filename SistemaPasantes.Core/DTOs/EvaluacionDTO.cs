using System;

namespace SistemaPasantes.Core.entities
{
    public partial class EvaluacionDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCierre { get; set; }
        public int IdAdminUsuario { get; set; }
        public int IdFormulario { get; set; }
    }
}
