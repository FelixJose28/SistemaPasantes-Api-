using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspiranteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AspiranteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UsuarioDTO>> GetAspirantes()
        {
            var aspirantes = _unitOfWork.authenticationRepository
                .GetAll()
                .Where(e => e.Id == (int)Roles.Usuario);

            var aspirantesDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(aspirantes);
            return Ok(aspirantesDTO);
        }

        [HttpGet("{usuarioId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UsuarioDTO> GetAspiranteByID(int usuarioId)
        {
            var aspirante = _unitOfWork.authenticationRepository
                .GetAll()
                .Where(e => e.Id == (int)Roles.Usuario)
                .FirstOrDefault(e => e.Id == usuarioId);

            if (aspirante == null)
            {
                return NotFound();
            }

            var aspiranteDTO = _mapper.Map<UsuarioDTO>(aspirante);
            return Ok(aspiranteDTO);
        }
    }
}
