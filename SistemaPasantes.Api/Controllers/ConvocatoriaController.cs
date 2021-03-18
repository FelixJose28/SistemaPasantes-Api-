using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvocatoriaController : ControllerBase
    {
        private readonly IConvocatoriaService _repository;
        private readonly IMapper _mapper;

        public ConvocatoriaController(IConvocatoriaService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet] // GET: api/convocatoria/
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ConvocatoriaDTO>> GetAllConvocatorias()
        {
            var convocatorias = _repository.GetAllConvocatorias();
            var convocatoriasDTO = _mapper.Map<IEnumerable<ConvocatoriaDTO>>(convocatorias);
            return Ok(convocatoriasDTO);
        }

        [HttpGet("{id}")] // GET: api/convocatoria/id
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConvocatoriaDTO>> GetConvocatoria(int id)
        {
            var convocatoria  = await _repository.GetConvocatoriaById(id);

            if (convocatoria == null)
            {
                return NotFound($"No se encontró la convocatoria con id '{id}'");
            }

            var convocatoriaDTO = _mapper.Map<ConvocatoriaDTO>(convocatoria);
            return Ok(convocatoriaDTO);
        }

        [HttpPost] // POST: api/convocatoria/
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ConvocatoriaDTO>> CreateConvocatoria(ConvocatoriaDTO convocatoria)
        {
            if (convocatoria == null)
            {
                return BadRequest();
            }

            try
            {
                var entity = _mapper.Map<Convocatoria>(convocatoria);
                var newConvocatoria = await _repository.CreateConvocatoria(entity);
                var convocatoriaDTO = _mapper.Map<ConvocatoriaDTO>(newConvocatoria);
                return Created($"api/convocatorias/${convocatoria.Id}", convocatoriaDTO);
            }
            catch(DbUpdateException e)
            {
                if(e.InnerException is not null)
                {
                    // The inner message contains the exact reason of the error, like a missing column
                    return BadRequest(e.InnerException.Message);
                }
                else
                {
                    return BadRequest(e.ToString());
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPut] // PUT: api/convocatoria
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConvocatoriaDTO>> UpdateConvocatoria(ConvocatoriaDTO newConvocatoria)
        {
            if (newConvocatoria == null)
            {
                return NotFound();
            }

            try
            {
                var entity = _mapper.Map<Convocatoria>(newConvocatoria);
                var updatedConvocatoria = await _repository.UpdateConvocatoria(entity);
                var convocatoriaDTO = _mapper.Map<ConvocatoriaDTO>(updatedConvocatoria);
                return Ok(convocatoriaDTO);
            }
            catch
            {
                return NotFound($"Convocatoria con id {newConvocatoria.Id} no fue encontrada");
            }
        }

        [HttpDelete("{id}")] // DELETE: api/convocatoria/id
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConvocatoriaDTO>> DeleteConvocatoria(int id)
        {
            try
            {
                var removedConvocatoria = await _repository.RemoveConvocatoria(id);
                if (removedConvocatoria == null)
                {
                    return NotFound($"Convocatoria con ${id} no encontrada");
                }

                var convocatoriaDTO = _mapper.Map<ConvocatoriaDTO>(removedConvocatoria);
                return Ok(convocatoriaDTO);
            }
            catch
            {
                return NotFound($"Convocatoria con ${id} no encontrada");
            }
        }
    }
}
