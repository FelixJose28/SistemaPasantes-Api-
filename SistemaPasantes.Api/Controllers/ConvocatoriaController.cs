using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvocatoriaController : GenericController<Convocatoria, ConvocatoriaDTO, IConvocatoriaRepository>
    {
        public ConvocatoriaController(IUnitOfWork unitOfWork, IConvocatoriaRepository repository, IMapper mapper) 
            : base(unitOfWork, repository, mapper) { }
    }
}
