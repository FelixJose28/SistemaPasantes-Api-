﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaPasantes.Core.Entities
{
    public partial class TareaEntrega
    {
        public TareaEntrega()
        {
            TareaEntregaGrupo = new HashSet<TareaEntregaGrupo>();
        }

        public int Id { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public byte[] Archivo { get; set; }
        public string Comentarios { get; set; }
        public int? Calificacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdTarea { get; set; }
        public string NombreArchivo { get; set; }

        public virtual Tarea IdTareaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<TareaEntregaGrupo> TareaEntregaGrupo { get; set; }
    }
}
