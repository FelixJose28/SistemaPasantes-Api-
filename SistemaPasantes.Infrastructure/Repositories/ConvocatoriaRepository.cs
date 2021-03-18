using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class ConvocatoriaRepository : GenericRepository<Convocatoria>, IConvocatoriaRepository
    {
        public ConvocatoriaRepository(SistemaPasantesContext context) : base(context) { }
    }
}
