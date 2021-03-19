﻿using System;
using System.Collections.Generic;
using SistemaPasantes.Core.Entities;

#nullable disable

namespace SistemaPasantes.Core.entities
{
    public partial class Convocatoria
    {
        public Convocatoria()
        {
            Pasantes = new HashSet<Pasante>();
        }

        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public int Cupo { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdAdminUsuario { get; set; }
        public int IdFormulario { get; set; }

        public virtual Usuario IdAdminUsuarioNavigation { get; set; }
        public virtual Formulario IdFormularioNavigation { get; set; }
        public virtual ICollection<Pasante> Pasantes { get; set; }
    }
}
