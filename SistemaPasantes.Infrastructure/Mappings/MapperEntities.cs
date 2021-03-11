﻿using AutoMapper;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;

namespace SistemaPasantes.Infrastructure.Mappings
{
    public class MapperEntities: Profile
    {
        public MapperEntities()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Convocatoria, ConvocatoriaDTO>().ReverseMap();
            CreateMap<Formulario, FormularioDTO>().ReverseMap();
        }
    }
}
