using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPasantes.Core.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; }
        public int? IdGrupo { get; set; }
    }
}
