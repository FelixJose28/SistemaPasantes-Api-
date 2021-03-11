using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class ConvocatoriaRepository : GenericRepository<Convocatoria>, IConvocatoriaRepository
    {
        public ConvocatoriaRepository(SistemaPasantesContext context) : base(context) { }
    }
}
