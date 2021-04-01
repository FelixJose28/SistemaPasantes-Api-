using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class AuthenticationRepository: GenericRepository<Usuario>, IAuthenticationRepository
    {
        private readonly SistemaPasantesContext _context;
        public AuthenticationRepository(SistemaPasantesContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> Loggin(UserLoginCustom usuario)
        {   
            Usuario userLogger = await _context.Usuario.FirstOrDefaultAsync(x=>x.Correo == usuario.Correo && x.Clave == usuario.Clave);
            return userLogger;
        }

        public async Task<Usuario> ValidateCorreo(Usuario usuario)
        {
            Usuario user =  await _context.Usuario.FirstOrDefaultAsync(x =>x.Correo == usuario.Correo);
            return user;
        }
    }
}
