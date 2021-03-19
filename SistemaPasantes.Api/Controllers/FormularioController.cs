using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormularioController : GenericController<Formulario, FormularioDTO, IFormularioRepository>
    {
        public FormularioController(IUnitOfWork unitOfWork, IFormularioRepository repository, IMapper mapper)
            : base(unitOfWork, repository, mapper) { }
    }
}
