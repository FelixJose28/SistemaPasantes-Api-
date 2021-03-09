using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaPasantesContext _context;
        public AuthenticationRepository _authenticationRepository { get; private set; }
        public UnitOfWork(SistemaPasantesContext context)
        {
            _context = context;
            _authenticationRepository = new AuthenticationRepository(_context);
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
