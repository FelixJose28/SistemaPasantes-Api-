using System;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthenticationCRepository authenticationRepository { get; }

        IConvocatoriaRepository convocatoriaRepository { get; }

        IFormularioRepository formularioRepository { get; }

        Task CommitAsync();

        void Commit();
    }
}
