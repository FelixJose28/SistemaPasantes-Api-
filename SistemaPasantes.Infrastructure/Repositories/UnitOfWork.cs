using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaPasantesContext _context;

        public IAuthenticationCRepository authenticationRepository { get; private set; }

        public IConvocatoriaRepository convocatoriaRepository { get; private set; }

        public IFormularioRepository formularioRepository { get; private set; }

        public IPerfilRepository perfilRepository  { get; private set; }

        public ITareaRepository tareaRepository { get; private set; }

        public UnitOfWork(SistemaPasantesContext context)
        {
            _context = context;
            authenticationRepository = new AuthenticationCRepository(_context);
            convocatoriaRepository = new ConvocatoriaRepository(_context);
            formularioRepository = new FormularioRepository(_context);
            perfilRepository = new PerfilRepository(_context);
            tareaRepository = new TareaRepository(_context);
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