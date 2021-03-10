using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class Entrega
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string RutaArchivo { get; set; }
        public int IdUsuario { get; set; }
        public int IdTarea { get; set; }

        public virtual Tarea IdTareaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
