using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
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
    public class PasanteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PasanteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetAllPasantes))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<PasanteDTO> GetAllPasantes()
        {
            var allPasante = _unitOfWork.grupoRepository.GetAll();
            if (allPasante == null)
            {
                return NotFound("No se encontraron pasantes");
            }
            var cleanData = _mapper.Map<IEnumerable<PasanteDTO>>(allPasante);
            return Ok(cleanData);
        }

        [HttpPost(nameof(CreatePasante))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PasanteDTO>> CreatePasante(PasanteDTO pasanteDTO)
        {
            if (!ModelState.IsValid) BadRequest("Modelo de pasante no valido");

            var pasante = _mapper.Map<Pasante>(pasanteDTO);
            await _unitOfWork.pasanteRepository.Add(pasante);
            await _unitOfWork.CommitAsync();
            return Ok(pasanteDTO);
        }

        [HttpGet(nameof(GetPasante) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Pasante>> GetPasante(int id)
        {
            var pasante = await _unitOfWork.pasanteRepository.GetById(id);
            if (pasante == null)
            {
                return NotFound("Pasante no encontrado");
            }
            return Ok(pasante);
        }

        [HttpPut(nameof(UpdatePasante))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Pasante>> UpdatePasante(PasanteDTO pasanteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo del pasante no valido");
            }
            var pasante = _mapper.Map<Pasante>(pasanteDTO);
            if (pasanteDTO == null)
            {
                return NotFound("Debes completar todos los datos del pasante antes de enviar");
            }
            await _unitOfWork.pasanteRepository.Update(pasante);
            await _unitOfWork.CommitAsync();

            return Ok(pasante);
        }

        [HttpDelete(nameof(DeletePasante) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Pasante>> DeletePasante(int id)
        {
            var pasante = await _unitOfWork.pasanteRepository.GetById(id);
            if (pasante == null)
            {
                return NotFound($"El pasante con el id {id} no existe");
            }
            await _unitOfWork.pasanteRepository.Remove(id);
            await _unitOfWork.CommitAsync();
            return Ok(pasante);
        }
    }
}
