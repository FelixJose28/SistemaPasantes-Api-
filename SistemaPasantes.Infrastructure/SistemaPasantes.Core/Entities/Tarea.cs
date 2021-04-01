using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.SistemaPasantes.Core.Entities
{
    public partial class Tarea
    {
        public Tarea()
        {
            TareaEntrega = new HashSet<TareaEntrega>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCierre { get; set; }
        public int IdAdminUsuario { get; set; }
        public int IdEstado { get; set; }

        public virtual Usuario IdAdminUsuarioNavigation { get; set; }
        public virtual EstadoTarea IdEstadoNavigation { get; set; }
        public virtual ICollection<TareaEntrega> TareaEntrega { get; set; }
    }
}
