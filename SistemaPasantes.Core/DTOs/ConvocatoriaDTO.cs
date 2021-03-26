using System;
using SistemaPasantes.Core.Entities;

namespace SistemaPasantes.Core.DTOs
{
    public record ConvocatoriaDTO
    {
        public int Id { get; set; }
        public int Cupo { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public int IdUsuario { get; set; }
        public int IdFormulario { get; set; }
    }
}
