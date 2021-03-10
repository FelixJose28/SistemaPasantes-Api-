using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IAuthenticationCService
    {
        //IEnumerable<Usuario> GetAllUsers();
        Task<Usuario> GetUserById(int id);
        IEnumerable<Usuario> GetAllUsers();
        Task<Usuario> LogginUser(Usuario usuario);
        Task RegisterUser(Usuario usuario);
        Task DeleteUser(int id);
    }
}
