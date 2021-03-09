using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IAuthenticationService
    {
        //IEnumerable<Usuario> GetAllUsers();
        Task<Usuario> GetUserById(int id);
        Task<Usuario> LogginUser(Usuario usuario);
        Task RegisterUser(Usuario usuario);
        Task DeleteUser(int id);
    }
}
