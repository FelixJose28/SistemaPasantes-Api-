using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaPasantesContext _context;

        public IAuthenticationRepository authenticationRepository { get;  }

        public IConvocatoriaRepository convocatoriaRepository { get; }

        public IFormularioRepository formularioRepository { get; }

        public IUsuarioRepository usuarioRepository  { get;  }

        public ITareaRepository tareaRepository { get;  }

        public ITareaEntregaRepository tareaEntregaRepository { get;  }

        public IRespuestaFormularioRepository respuestaFormulario { get;  }

        public IGrupoRepository grupoRepository { get; }

        public IPasanteRepository pasanteRepository { get; }



        public UnitOfWork(SistemaPasantesContext context)
        {
            _context = context;
            authenticationRepository = new AuthenticationRepository(_context);
            convocatoriaRepository = new ConvocatoriaRepository(_context);
            formularioRepository = new FormularioRepository(_context);
            usuarioRepository = new UsuarioRepository(_context);
            tareaRepository = new TareaRepository(_context);
            tareaEntregaRepository = new TareaEntregaRepository(_context);
            respuestaFormulario = new RespuestaFormularioRepository(_context);
            grupoRepository = new GrupoRepository(_context);
            pasanteRepository = new PasanteRepository(_context);
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