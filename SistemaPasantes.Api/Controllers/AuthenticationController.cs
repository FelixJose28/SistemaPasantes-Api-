using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPasantes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationCService _authenticationService;
        private readonly IMapper _mapper;
        public AuthenticationController(IAuthenticationCService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
   

        [HttpPost(nameof(RegisterUser))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser(UsuarioDTO usuarioDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            var user = _mapper.Map<Usuario>(usuarioDTO);
            await _authenticationService.RegisterUser(user);
            return Ok(usuarioDTO);
        }
        [HttpGet(nameof(GetAllUser))]
        public IEnumerable<Usuario> GetAllUser()
        {
            return _authenticationService.GetAllUsers();
        }
            
    }
}
