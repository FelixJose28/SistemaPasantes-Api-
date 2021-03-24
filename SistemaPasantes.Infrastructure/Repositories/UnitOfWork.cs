using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly sistemapasanteContext _context;

        public IAuthenticationCRepository authenticationRepository { get;  }

        public IConvocatoriaRepository convocatoriaRepository { get; }

        public IFormularioRepository formularioRepository { get; }

        public IPerfilRepository perfilRepository  { get;  }

        public ITareaRepository tareaRepository { get;  }

        public ITareaEntregaRepository tareaEntregaRepository { get;  }

        public IRespuestaFormularioRepository respuestaFormulario { get;  }

        public IGrupoRepository grupoRepository { get; }

        public IPasanteRepository pasanteRepository { get; }



        public UnitOfWork(sistemapasanteContext context)
        {
            _context = context;
            authenticationRepository = new AuthenticationCRepository(_context);
            convocatoriaRepository = new ConvocatoriaRepository(_context);
            formularioRepository = new FormularioRepository(_context);
            perfilRepository = new PerfilRepository(_context);
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