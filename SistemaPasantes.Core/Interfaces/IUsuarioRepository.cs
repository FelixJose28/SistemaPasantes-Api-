using System;
using System.Collections.Generic;
using System.Text;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> GetDataByCredentials(string usuario);
    }
}
