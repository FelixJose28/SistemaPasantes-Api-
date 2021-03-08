using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Infrastructure.Data
{
    public partial class Entrega
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string Archivo { get; set; }
        public int IdUsuario { get; set; }
        public int IdTarea { get; set; }

        public virtual Tarea IdTareaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
