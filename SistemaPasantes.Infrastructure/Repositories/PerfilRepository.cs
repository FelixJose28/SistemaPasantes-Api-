using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class PerfilRepository :  GenericRepository<Usuario>, IPerfilRepository
    {
        private readonly SistemaPasantesContext _context;
        public PerfilRepository(SistemaPasantesContext context) : base (context)
        {
            _context = context;
        }
    }
}
