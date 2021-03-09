using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class AuthenticationRepository: GenericRepository<Usuario>, IAuthenticationRepository
    {
        private readonly SistemaPasantesContext _context;
        public AuthenticationRepository(SistemaPasantesContext context) : base(context)
        {
            _context = context;
        }
    }
}
