using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.Data
{
    public partial class Tarea
    {
        public Tarea()
        {
            Entregas = new HashSet<Entrega>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaEntreaga { get; set; }
        public string RutaArchivo { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Entrega> Entregas { get; set; }
    }
}
