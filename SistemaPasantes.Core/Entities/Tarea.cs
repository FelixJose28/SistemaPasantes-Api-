using System;
using System.Collections.Generic;
using SistemaPasantes.Core.Entities;

#nullable disable

namespace SistemaPasantes.Core.entities
{
    public partial class Tarea
    {
        public Tarea()
        {
            TareaEntregas = new HashSet<TareaEntrega>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCierre { get; set; }
        public int IdAdminUsuario { get; set; }
        public int IdEstado { get; set; }

        public virtual Usuario IdAdminUsuarioNavigation { get; set; }
        public virtual EstadoTarea IdEstadoNavigation { get; set; }
        public virtual ICollection<TareaEntrega> TareaEntregas { get; set; }
    }
}
