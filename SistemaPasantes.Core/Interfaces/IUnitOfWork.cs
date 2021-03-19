using System;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthenticationCRepository authenticationRepository { get; }

        IConvocatoriaRepository convocatoriaRepository { get; }

        IFormularioRepository formularioRepository { get; }

        IPerfilRepository perfilRepository { get; }

        ITareaRepository tareaRepository { get; }

        ITareaEntregaRepository tareaEntregaRepository {get;}

        Task CommitAsync();

        void Commit();
    }
}
