using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;
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
        Task<Usuario> LogginUser(UserLoginDto usuario);
        Task RegisterUser(Usuario usuario);
        Task DeleteUser(int id);
    }
}
