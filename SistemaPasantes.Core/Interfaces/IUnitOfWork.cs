using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthenticationCRepository authenticationRepository { get; }
        IConvocatoriaRepository convocatoriaRepository { get; }

        Task CommitAsync();
        void Commit();
    }
}
