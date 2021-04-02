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
        public DateTime FechaCierre { get; set; }
        public int IdAdminUsuario { get; set; }
        public int IdFormulario { get; set; }
        public int IdConvocatoria { get; set; }

        public virtual Usuario IdAdminUsuarioNavigation { get; set; }
        public virtual Convocatoria IdConvocatoriaNavigation { get; set; }
        public virtual Formulario IdFormularioNavigation { get; set; }
    }
}
