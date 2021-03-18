using AutoMapper;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;

namespace SistemaPasantes.Infrastructure.Mappings
{
    public class MapperEntities: Profile
    {
        public MapperEntities()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Convocatorium, ConvocatoriaDTO>().ReverseMap();
            CreateMap<Formulario, FormularioDTO>().ReverseMap();
            CreateMap<Tarea, TareaDTO>().ReverseMap();
        }
    }
}
