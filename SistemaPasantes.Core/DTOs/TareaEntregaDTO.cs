using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPasantes.Core.DTOs
{
    public class TareaEntregaDTO
    {
        public int Id { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public IFormFile Archivo { get; set; }
        public string Comentarios { get; set; }
        public int? Calificacion { get; set; }
        public string Ruta { get; set; }
        public int IdUsuario { get; set; }
        public int IdTarea { get; set; }
    }
}
