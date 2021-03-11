using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class AuthenticationCRepository: GenericRepository<Usuario>, IAuthenticationCRepository
    {
        private readonly sistemapasantesContext _context;
        public AuthenticationCRepository(sistemapasantesContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> Loggin(UserLoginCustom usuario)
        {
            Usuario userLogger = await _context.Usuarios.FirstOrDefaultAsync(x=>x.Correo == usuario.Correo && x.Clave == usuario.Clave);
            return userLogger;
        }

        public async Task<Usuario> ValidateCorreo(Usuario usuario)
        {
            Usuario user =  await _context.Usuarios.FirstOrDefaultAsync(x =>x.Correo == usuario.Correo);
            return user;
        }
    }
}
