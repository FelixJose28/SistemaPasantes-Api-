using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.SistemaPasantes.Core.Entities
{
    public partial class TareaEntregaGrupo
    {
        public int Id { get; set; }
        public int IdTareaEntregada { get; set; }
        public int? Calificacion { get; set; }

        public virtual TareaEntrega IdTareaEntregadaNavigation { get; set; }
    }
}
