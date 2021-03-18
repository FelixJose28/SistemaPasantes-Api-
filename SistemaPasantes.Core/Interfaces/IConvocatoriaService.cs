using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;

#nullable enable

namespace SistemaPasantes.Core.Interfaces
{
    public interface IConvocatoriaService
    {
        public IEnumerable<Convocatorium> GetAllConvocatorias();

        public Task<Convocatorium?> GetConvocatoriaById(int id);

        public Task<Convocatorium> CreateConvocatoria(Convocatorium convocatoria);

        public Task<Convocatorium?> UpdateConvocatoria(Convocatorium convocatoria);

        public Task<Convocatorium?> RemoveConvocatoria(int id);
    }
}
