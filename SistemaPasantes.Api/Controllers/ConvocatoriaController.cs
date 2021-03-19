using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConvocatoriaController : GenericController<Convocatoria, ConvocatoriaDTO, IConvocatoriaRepository>
    {
        public ConvocatoriaController(IUnitOfWork unitOfWork, IConvocatoriaRepository repository, IMapper mapper) 
            : base(unitOfWork, repository, mapper) { }

        [HttpGet("{evaluacionId}/formulario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FormularioDTO>>> GetFormulario(int evaluacionId)
        {
            var evaluacion = await repository.GetById(evaluacionId);

            if (evaluacion == null || evaluacion.IdFormularioNavigation == null)
            {
                return NotFound();
            }

            var formulario = evaluacion.IdFormularioNavigation;
            var formularioDTO = mapper.Map<FormularioDTO>(formulario);
            return Ok(formularioDTO);
        }
    }
}
