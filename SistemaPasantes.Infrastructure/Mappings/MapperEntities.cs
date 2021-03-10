using AutoMapper;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPasantes.Infrastructure.Mappings
{
    public class MapperEntities: Profile
    {
        public MapperEntities()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
