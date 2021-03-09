using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IAuthenticationRepository: IGenericRepository<Usuario>
    {
        Task<Usuario> Loggin(Usuario usuario);
    }
}
