using SistemaPasantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IPasanteRepository : IGenericRepository<Pasante>
    {
        Task<IEnumerable<Usuario>> GetAspirantes();
    }
}