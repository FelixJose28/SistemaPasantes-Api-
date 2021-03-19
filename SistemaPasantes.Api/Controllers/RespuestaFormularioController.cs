using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SistemaPasantes.Core.DTOs;
using System.Collections.Generic;

namespace SistemaPasantes.Api.Controllers
{
    [Route("api/respuestas")]
    [ApiController]
    public class RespuestaFormularioController : GenericController<RespuestaFormulario, RespuestaFormularioDTO, IRespuestaFormularioRepository>
    {
        public RespuestaFormularioController(IUnitOfWork unitOfWork, IRespuestaFormularioRepository repository, IMapper mapper)
            : base(unitOfWork, repository, mapper) { }

        [HttpGet("{respuestaId}/formulario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormularioDTO>> GetFormulario(int respuestaId)
        {
            var respuesta = await repository.GetById(respuestaId);

            if(respuesta == null || respuesta.IdFormularioNavigation == null)
            {
                return NotFound();
            }

            var respuestaDTO = mapper.Map<FormularioDTO>(respuesta.IdFormularioNavigation);
            return Ok(respuestaDTO);
        }
    }
}
