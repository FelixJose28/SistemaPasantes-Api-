using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.Data
{
    public partial class Grupo
    {
        public Grupo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
