using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        //[Authorize]
        [HttpDelete(nameof(DeleteUser) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userFind = await _unitOfWork.usuarioRepository.GetById(id);
            if (userFind == null)
            {
                return NotFound($"Usuario con el id: {id} no encontrado");
            }

            await _unitOfWork.usuarioRepository.Remove(userFind.Id);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }

        //SOLO ADMIN
        //[Authorize]

            

        [HttpGet(nameof(GetAllUser))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllUser()
        {
            var users = _unitOfWork.usuarioRepository.GetAll();
            if (users == null)
            {
                return NotFound("No hay usuarios registrados");
            }
            var usersDto = _mapper.Map<IEnumerable<UsuarioDTO>>(users);
            return Ok(usersDto);
        }
        [HttpGet(nameof(GetUserByCredentials)+ "/{usuario}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByCredentials(string usuario )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo de datos invalido");
            }
            var user = await _unitOfWork.usuarioRepository.GetDataByCredentials(usuario);
            if(user == null)
            {
                return NotFound("Los datos del usuario no coinciden con ninguno registrado");
            }
            var userDto = _mapper.Map<UsuarioDTO>(user);
            return Ok(userDto);

        }




        [HttpGet(nameof(GetUsuarioById)+"/{id}")] 

        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _unitOfWork.usuarioRepository.GetById(id);

            if (usuario == null)
            {
                return NotFound("Usuario no econtrado");
            }
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return Ok(usuarioDTO);
        }


        [HttpPut(nameof(UpdateUsuario))] // PUT: api/usuario/id
        public async Task<ActionResult<Usuario>> UpdateUsuario(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest();
            }

            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            try
            {
                var updatedUsuario = await _unitOfWork.usuarioRepository.Update(usuario);
                await _unitOfWork.CommitAsync();
                return Ok(usuarioDTO);
            }
            catch
            {
                return NotFound($"A ocurrido un error con el Usuario con id ${usuario.Id}");
            }
        }
    }
}
