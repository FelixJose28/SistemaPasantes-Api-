using SistemaPasantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly sistemapasantesContext _context;
        public IAuthenticationCRepository authenticationRepository { get; }
        public IAuthenticationCRepository _authenticationRepository { get; private set; }

       

        public UnitOfWork(sistemapasantesContext context)
        {
            _context = context;
            authenticationRepository = new AuthenticationCRepository(_context);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
