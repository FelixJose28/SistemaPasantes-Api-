using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormularioController : ControllerBase
    {
        private readonly IFormularioService _repository;
        private readonly IMapper _mapper;

        public FormularioController(IFormularioService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet] // GET: api/formulario/
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<FormularioDTO>> GetAllFormularios()
        {
            return Ok(_repository.GetAllFormularios());
        }

        [HttpGet("{id}")] // GET: api/formulario/id
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormularioDTO>> GetFormulario(int id)
        {
            var formulario  = await _repository.GetFormularioById(id);

            if (formulario == null)
            {
                return NotFound();
            }

            var formularioDTO = _mapper.Map<FormularioDTO>(formulario);
            return Ok(formularioDTO);
        }

        [HttpPost] // POST: api/formulario/
        public async Task<ActionResult<FormularioDTO>> CreateFormulario(FormularioDTO formulario)
        {
            if (formulario == null)
            {
                return BadRequest();
            }

            try
            {
                var entity = _mapper.Map<Formulario>(formulario);
                var newFormulario = await _repository.CreateFormulario(entity);
                var formularioDTO = _mapper.Map<FormularioDTO>(newFormulario);
                return Created($"api/formulario/${formulario.Id}", formularioDTO);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is not null)
                {
                    // The inner message contains the exact reason of the error, like a missing column
                    return BadRequest(e.InnerException.Message);
                }
                else
                {
                    return BadRequest(e.ToString());
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPut("{id}")] // PUT: api/formulario/id
        public async Task<ActionResult<FormularioDTO>> UpdateFormulario(FormularioDTO newFormulario)
        {
            if (newFormulario == null)
            {
                return NotFound();
            }

            try
            {
                var entity = _mapper.Map<Formulario>(newFormulario);
                var updatedConvocatoria = await _repository.UpdateFormulario(entity);
                var convocatoriaDTO = _mapper.Map<ConvocatoriaDTO>(updatedConvocatoria);
                return Ok(convocatoriaDTO);
            }
            catch
            {
                return NotFound($"Formulario con id {newFormulario.Id} no fue encontrada");
            }
        }

        [HttpDelete("{id}")] // DELETE: api/formulario/id
        public async Task<ActionResult> DeleteFormulario(int id)
        {
            try
            {
                await _repository.RemoveFormulario(id);
            }
            catch
            {
                return NotFound($"Formulario con ${id} no existe");
            }

            return NoContent();
        }
    }
}
