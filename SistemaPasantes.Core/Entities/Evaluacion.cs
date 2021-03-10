using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class Evaluacion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int IdFormulario { get; set; }

        public virtual Usuario IdUsuario1 { get; set; }
        public virtual Formulario IdUsuarioNavigation { get; set; }
    }
}
