using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
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

        public async Task<Usuario> Loggin(UserLoginCustom usuario)
        {   
            Usuario userLogger = await _context.Usuarios.FirstOrDefaultAsync(x=>x.Correo == usuario.Correo && x.Clave.ToString() == usuario.Clave.ToString() );
            return userLogger;
        }

        public async Task<Usuario> ValidateCorreo(Usuario usuario)
        {
            Usuario user =  await _context.Usuarios.FirstOrDefaultAsync(x =>x.Correo == usuario.Correo);
            return user;
        }
    }
}
