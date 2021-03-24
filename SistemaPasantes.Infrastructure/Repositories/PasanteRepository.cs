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
        private readonly sistemapasanteContext _context;

        public PasanteRepository(sistemapasanteContext context) : base(context)
        {
            _context = context;
        }
    }
}
