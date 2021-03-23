using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class PerfilRepository :  GenericRepository<Usuario>, IPerfilRepository
    {
        private readonly SistemaPasantesContext _context;
        public PerfilRepository(SistemaPasantesContext context) : base (context)
        {
            _context = context;
        }

        public async Task<Usuario> GetDataByCredentials(UserLoginCustom usuario)
        {
            var user = await _context.Usuarios.Where(x => x.Correo == usuario.Correo && x.Clave == usuario.Clave).SingleOrDefaultAsync();
            return  user;
        }
    }
}
