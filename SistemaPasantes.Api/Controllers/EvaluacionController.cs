using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluacionController : GenericController<Evaluacion, EvaluacionDTO, IEvaluacionRepository>
    {
        public EvaluacionController(IUnitOfWork unitOfWork, IEvaluacionRepository repository, IMapper mapper) 
            : base(unitOfWork, repository, mapper) { }
    }
}
