using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.Entities;


namespace SistemaPasantes.Core.Interfaces
{
    public interface IConvocatoriaService
    {
        public IEnumerable<Convocatoria> GetAllConvocatorias();

        public Task<Convocatoria> GetConvocatoriaById(int id);

        public Task<Convocatoria> CreateConvocatoria(Convocatoria convocatoria);

        public Task UpdateConvocatoria(int id, Convocatoria convocatoria);

        public Task RemoveConvocatoria(int id);
    }
}
