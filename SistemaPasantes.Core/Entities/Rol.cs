using System;
using System.Collections.Generic;
using SistemaPasantes.Core.Entities;

#nullable disable

namespace SistemaPasantes.Core.entities
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
