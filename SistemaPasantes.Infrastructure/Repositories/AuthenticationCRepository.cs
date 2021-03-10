using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class AuthenticationCRepository: GenericRepository<Usuario>, IAuthenticationCRepository
    {
        private readonly SistemaPasantesContext _context;
        public AuthenticationCRepository(SistemaPasantesContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> Loggin(Usuario usuario)
        {
            Usuario userLogger = await _context.Usuarios.FirstOrDefaultAsync(x=>x.Correo == usuario.Correo && x.Clave == usuario.Clave);
            return userLogger;
        }
    }
}
