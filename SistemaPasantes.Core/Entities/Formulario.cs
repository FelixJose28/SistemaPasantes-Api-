using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class Formulario
    {
        public Formulario()
        {
            Convocatoria = new HashSet<Convocatorium>();
            Evaluacions = new HashSet<Evaluacion>();
            Repuesta = new HashSet<Repuestum>();
        }

        public int Id { get; set; }
        public string Ruta { get; set; }

        public virtual ICollection<Convocatorium> Convocatoria { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
        public virtual ICollection<Repuestum> Repuesta { get; set; }
    }
}
