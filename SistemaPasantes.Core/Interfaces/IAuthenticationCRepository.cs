using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IAuthenticationCRepository: IGenericRepository<Usuario>
    {
        Task<Usuario> Loggin(UserLoginCustom usuario);
        Task<Usuario> ValidateCorreo(Usuario usuario);
    }
}
