using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConvocatoriaController : GenericController<Convocatoria, ConvocatoriaDTO, IConvocatoriaRepository>
    {
        public ConvocatoriaController(IUnitOfWork unitOfWork, IConvocatoriaRepository repository, IMapper mapper) 
            : base(unitOfWork, repository, mapper) { }

    }
}
