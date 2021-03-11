using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class Convocatoria
    {
        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public int Cupo { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public int IdFormulario { get; set; }

        public virtual Formulario IdFormularioNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
