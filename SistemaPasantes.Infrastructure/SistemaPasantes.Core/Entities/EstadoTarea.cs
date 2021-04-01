using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.SistemaPasantes.Core.Entities
{
    public partial class EstadoTarea
    {
        public EstadoTarea()
        {
            Tarea = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
