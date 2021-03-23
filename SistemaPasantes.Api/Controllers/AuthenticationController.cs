using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IMapper mapper, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }
   

        [HttpPost(nameof(RegisterUser))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser(UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Faltan algunos datos");
            }
            var user = _mapper.Map<Usuario>(usuarioDTO);
            
            
            var validateUser = await _unitOfWork.authenticationRepository.ValidateCorreo(user);
            if (validateUser != null && validateUser.Correo == user.Correo)
            {
                return NotFound("Este correo ya esta registrado, pruebe con otro correo.");
            }

            await _unitOfWork.authenticationRepository.Add(user);
            await _unitOfWork.CommitAsync();

            var userToken = GenerateToken(user);

            return Ok(new { token = userToken });
            //var usertoDto = _mapper.Map<UsuarioDTO>(user);
            //return Ok(usertoDto);
        }


        [HttpPost(nameof(Loggin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Loggin(UserLoginCustom logginusuario)
        {
            //si el usuario es valido 
            var validation = await IsValidUser(logginusuario);
            if (validation.Item1 == false)
            {
                return NotFound("Usuario o contrasena incorrectos");
            }
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token = token });
            }
            return NotFound("Ocurrio un error");
        }


        //[Authorize]
        [HttpDelete(nameof(DeleteUser)+"/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userFind = await _unitOfWork.authenticationRepository.GetById(id);
            if (userFind == null)
            {
                return NotFound($"Usuario con el id: {id} no encontrado");
            }

            await _unitOfWork.authenticationRepository.Remove(userFind.Id);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }








        private async Task<(bool, Usuario)> IsValidUser(UserLoginCustom login)
        {
            var user = await _unitOfWork.authenticationRepository.Loggin(login);
            return (user != null, user);
        }

        private string GenerateToken(Usuario usuario)
        {
            //Header
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signinCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signinCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim(ClaimTypes.Role, usuario.IdRol.ToString())
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddHours(16)
            );
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }
            
    }
}
