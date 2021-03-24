using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class Pasante
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdConvocatoria { get; set; }

        public virtual Convocatorium IdConvocatoriaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
