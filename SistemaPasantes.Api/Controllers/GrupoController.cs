using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SistemaPasantes.Api.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("[controller]")]
    public class GrupoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GrupoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAllGrupos))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<TareaDTO> GetAllGrupos()
        {
            var allGrupo = _unitOfWork.grupoRepository.GetAll();
            if (allGrupo == null)
            {
                return NotFound("No hay grupos creados");
            }
            var cleanData = _mapper.Map<IEnumerable<GrupoDTO>>(allGrupo);
            return Ok(cleanData);
        }

        [HttpPost(nameof(CreateGrupo))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GrupoDTO>> CreateGrupo(GrupoDTO grupoDTO)
        {
            if (!ModelState.IsValid) BadRequest("Modelo de grupo no valido");

            var grupo = _mapper.Map<Grupo>(grupoDTO);
            await _unitOfWork.grupoRepository.Add(grupo);
            await _unitOfWork.CommitAsync();
            return Ok(grupoDTO);
        }

        [HttpGet(nameof(GetGrupo) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Grupo>> GetGrupo(int id)
        {
            var grupo = await _unitOfWork.grupoRepository.GetById(id);
            if (grupo == null)
            {
                return NotFound("Grupo no encontrado");
            }
            return Ok(grupo);
        }

        [HttpPut(nameof(UpdateGrupo))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Grupo>> UpdateGrupo(GrupoDTO grupoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo de grupo no valido");
            }
            var grupo = _mapper.Map<Grupo>(grupoDTO);
            if (grupoDTO == null)
            {
                return NotFound("Debes completar los datos del grupo antes de enviar");
            }
            await _unitOfWork.grupoRepository.Update(grupo);
            await _unitOfWork.CommitAsync();

            return Ok(grupo);
        }

        [HttpDelete(nameof(DeleteGrupo) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Grupo>> DeleteGrupo(int id)
        {
            var grupo = await _unitOfWork.grupoRepository.GetById(id);
            if (grupo == null)
            {
                return NotFound($"El grupo con el id {id} no existe");
            }
            await _unitOfWork.grupoRepository.Remove(id);
            await _unitOfWork.CommitAsync();
            return Ok(grupo);
        }
    }
}
