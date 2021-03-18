using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class ConvocatoriaRepository : GenericRepository<Convocatorium>, IConvocatoriaRepository
    {
        public ConvocatoriaRepository(sistemapasanteContext context) : base(context) { }
    }
}
