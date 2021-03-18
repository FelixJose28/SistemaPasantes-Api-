using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPasantes.Core.DTOs
{
    public class TareaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string RutaArchivo { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }
    }
}
