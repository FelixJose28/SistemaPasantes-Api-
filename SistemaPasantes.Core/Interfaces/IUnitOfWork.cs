using System;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthenticationCRepository authenticationRepository { get; }

        IConvocatoriaRepository convocatoriaRepository { get; }

        IPerfilRepository perfilRepository { get; }

        IFormularioRepository formularioRepository { get; }

        ITareaRepository tareaRepository { get; }

        Task CommitAsync();

        void Commit();
    }
}
