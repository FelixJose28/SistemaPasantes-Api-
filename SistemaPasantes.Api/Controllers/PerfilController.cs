using System.Collections.Generic;
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
    public class PerfilController : ControllerBase
    {

        private readonly IPerfilService _repository;
        private readonly IMapper _mapper;

        public PerfilController(IPerfilService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet] // GET: api/usuario/

        public ActionResult<IEnumerable<Usuario>> GetAllUsuario() //TODO: Return UsuarioDTO
        {
            return Ok(_repository.GetAllUsuario());
        }

        [HttpGet("{id}")] // GET: api/usuario/id

        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _repository.GetUsuarioById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


        [HttpPut("{id}")] // PUT: api/usuario/id
        public async Task<ActionResult<Usuario>> UpdateUsuario(UsuarioDTO newUsuario)
        {
            if (newUsuario == null)
            {
                return BadRequest();
            }

            var entity = _mapper.Map<Usuario>(newUsuario);

            try
            {
                var updatedUsuario = await _repository.UpdateUsuario(entity);
                return Ok(updatedUsuario);
            }
            catch
            {
                return NotFound($"Usuario con id ${entity.Id} no existe");
            }
        }
    }
}
