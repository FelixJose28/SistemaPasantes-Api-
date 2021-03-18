using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;

#nullable enable

namespace SistemaPasantes.Core.Interfaces
{
    public interface IConvocatoriaService
    {
        public IEnumerable<Convocatoria> GetAllConvocatorias();

        public Task<Convocatoria?> GetConvocatoriaById(int id);

        public Task<Convocatoria> CreateConvocatoria(Convocatoria convocatoria);

        public Task<Convocatoria?> UpdateConvocatoria(Convocatoria convocatoria);

        public Task<Convocatoria?> RemoveConvocatoria(int id);
    }
}
