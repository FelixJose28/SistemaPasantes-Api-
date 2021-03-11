using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities 
{
    public partial class Formulario
    {
        public Formulario()
        {
            Convocatoria = new HashSet<Convocatoria>();
            Evaluacions = new HashSet<Evaluacion>();
            Repuesta = new HashSet<Respuesta>();
        }

        public int Id { get; set; }
        public string Ruta { get; set; }

        public virtual ICollection<Convocatoria> Convocatoria { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
        public virtual ICollection<Respuesta> Repuesta { get; set; }
    }
}
