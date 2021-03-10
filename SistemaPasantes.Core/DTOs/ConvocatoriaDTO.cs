using System;

namespace SistemaPasantes.Core.DTOs
{
    public class ConvocatoriaDTO
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public int Cupo { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public int IdFormulario { get; set; }
    }
}
