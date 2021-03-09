using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.Data
{
    public partial class Convocatoria
    {
        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaCierre { get; set; }
        public int? Cupo { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
