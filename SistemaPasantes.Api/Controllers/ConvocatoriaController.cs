using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<Convocatoria>> GetAllConvocatorias()
        {
            return Ok(_repository.GetAllConvocatorias());
        }

        [HttpGet("{id}")] // GET: api/convocatoria/id
        public async Task<ActionResult<Convocatoria>> GetConvocatoria(int id)
        {
            var convocatoria  = await _repository.GetConvocatoriaById(id);

            if (convocatoria == null)
            {
                return NotFound();
            }

            return Ok(convocatoria);
        }

        [HttpPost] // POST: api/convocatoria/
        public async Task<ActionResult<Convocatoria>> CreateConvocatoria(ConvocatoriaDTO convocatoria)
        {
            if (convocatoria == null)
            {
                return BadRequest();
            }

            var entity = _mapper.Map<Convocatoria>(convocatoria);
            await _repository.CreateConvocatoria(entity);
            return Ok(convocatoria);
        }

        [HttpPut("{id}")] // PUT: api/convocatoria/id
        public async Task<ActionResult> UpdateConvocatoria(int id, ConvocatoriaDTO newConvocatoria)
        {
            if (newConvocatoria == null)
            {
                return BadRequest();
            }

            try
            {
                var entity = _mapper.Map<Convocatoria>(newConvocatoria);
                await _repository.UpdateConvocatoria(id, entity);
            }
            catch
            {
                return NotFound($"Convocatoria con id ${id} no existe");
            }

            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE: api/convocatoria/id
        public async Task<ActionResult> DeleteConvocatoria(int id)
        {
            try
            {
                await _repository.RemoveConvocatoria(id);
            }
            catch
            {
                return NotFound($"Convocatoria con ${id} no existe");
            }

            return NoContent();
        }
    }
}
