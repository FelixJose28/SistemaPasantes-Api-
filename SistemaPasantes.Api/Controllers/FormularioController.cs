using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<Formulario>> GetAllFormularios() //TODO: Return FormularioDTO
        {
            return Ok(_repository.GetAllFormularios());
        }

        [HttpGet("{id}")] // GET: api/formulario/id
        public async Task<ActionResult<Formulario>> GetFormulario(int id)
        {
            var formulario  = await _repository.GetFormularioById(id);

            if (formulario == null)
            {
                return NotFound();
            }

            return Ok(formulario);
        }

        [HttpPost] // POST: api/formulario/
        public async Task<ActionResult<Formulario>> CreateFormulario(FormularioDTO formulario)
        {
            if (formulario == null)
            {
                return BadRequest();
            }

            var entity = _mapper.Map<Formulario>(formulario);
            await _repository.CreateFormulario(entity);
            return Ok(formulario);
        }

        [HttpPut("{id}")] // PUT: api/formulario/id
        public async Task<ActionResult> UpdateFormulario(FormularioDTO newFormulario)
        {
            var entity = _mapper.Map<Formulario>(newFormulario);
            await _repository.UpdateFormulario(entity);

            return NoContent();
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
