using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.entities
{
    public partial class TareaEntrega
    {
        public int Id { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string RutaArchivo { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }
        public int IdTarea { get; set; }

        public virtual Tarea IdTareaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
