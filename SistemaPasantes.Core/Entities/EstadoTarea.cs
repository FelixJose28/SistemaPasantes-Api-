using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.entities
{
    public partial class EstadoTarea
    {
        public EstadoTarea()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
