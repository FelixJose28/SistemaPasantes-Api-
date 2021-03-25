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
    public class GrupoRepository : GenericRepository<Grupo>, IGrupoRepository
    {
        private readonly SistemaPasantesContext _context;

        public GrupoRepository(SistemaPasantesContext context) : base(context)
        {
            _context = context;
        }
    }
}
