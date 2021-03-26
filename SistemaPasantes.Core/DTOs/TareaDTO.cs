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
        public DateTime FechaCierre { get; set; }
        public int IdAdminUsuario { get; set; }
        public int IdEstado { get; set; }
    }
}
