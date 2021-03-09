using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IAuthenticationService
    {
        IEnumerable<Usuario> GetAllUsers();
        Task<Usuario> GetUserById(int id);
        Task AddUser(Usuario usuario);
        void UpdateUser(Usuario usuario);
        Task RemoveUser(int id);
    }
}
