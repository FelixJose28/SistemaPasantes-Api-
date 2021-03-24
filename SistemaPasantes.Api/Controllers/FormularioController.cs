using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using SistemaPasantes.Core.entities;

namespace SistemaPasantes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormularioController : GenericController<Formulario, FormularioDTO, IFormularioRepository>
    {
        public FormularioController(IUnitOfWork unitOfWork, IFormularioRepository repository, IMapper mapper)
            : base(unitOfWork, repository, mapper) { }

        [HttpGet("{formularioId}/respuestas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<RespuestaFormularioDTO>>> GetRespuestas(int formularioId)
        {
            var formulario = await repository.GetById(formularioId);

            if (formulario == null)
            {
                return NotFound();
            }

            var respuestas = formulario.RespuestaFormularios;
            var respuestasFormularioDTO = mapper.Map<IEnumerable<RespuestaFormularioDTO>>(respuestas);
            return Ok(respuestasFormularioDTO);
        }
    }
}
