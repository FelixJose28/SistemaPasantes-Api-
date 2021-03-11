﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaPasantes.Core.DTOs;
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
        private readonly IAuthenticationCService _authenticationService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IAuthenticationCService authenticationService, IMapper mapper, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _configuration = configuration;
        }
   

        [HttpPost(nameof(RegisterUser))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser(UsuarioDTO usuarioDTO)
        {
            var user = _mapper.Map<Usuario>(usuarioDTO);
            await _authenticationService.RegisterUser(user);
            return Ok(user);
        }

        [Authorize]
        [HttpGet(nameof(GetAllUser))]
        public IActionResult GetAllUser()
        {
            var users = _authenticationService.GetAllUsers();
            var usersDto = _mapper.Map<IEnumerable<UsuarioDTO>>(users);
            return Ok(usersDto);
        }



        [HttpPost(nameof(Loggin))]
        public async Task<IActionResult> Loggin(UserLoginCustom logginusuario)
        {
            //si el usuario es valido 
            var validation = await IsValidUser(logginusuario);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token = token });
            }
            return NotFound();
        }

        private async Task<(bool, Usuario)> IsValidUser(UserLoginCustom login)
        {
            var user = await _authenticationService.LogginUser(login);
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
                DateTime.UtcNow.AddMinutes(3)
            );
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }
            
    }
}
