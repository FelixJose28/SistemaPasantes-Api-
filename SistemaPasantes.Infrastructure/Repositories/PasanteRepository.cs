using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class PasanteRepository : GenericRepository<Pasante>, IPasanteRepository
    {
        private readonly SistemaPasantesContext _context;

        public PasanteRepository(SistemaPasantesContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetAspirantes()
        {
            var usuarios = await _context.Usuarios.Where(x => x.IdRol == (int)Roles.Usuario).ToListAsync();
            return usuarios;
        }
    }
}
