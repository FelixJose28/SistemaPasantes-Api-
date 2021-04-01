using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.SistemaPasantes.Core.Entities
{
    public partial class Grupo
    {
        public Grupo()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? IdConvocatoria { get; set; }

        public virtual Convocatoria IdConvocatoriaNavigation { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
