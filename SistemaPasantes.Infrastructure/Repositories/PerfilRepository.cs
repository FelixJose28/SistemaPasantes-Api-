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
        private readonly sistemapasanteContext _context;
        public PerfilRepository(sistemapasanteContext context) : base (context)
        {
            _context = context;
        }

        public async Task<Usuario> GetDataByCredentials(string usuario)
        {
            var user = await _context.Usuarios.Where(x => x.Correo == usuario).SingleOrDefaultAsync();
            return  user;
        }
    }
}
