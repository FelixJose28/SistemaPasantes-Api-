using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class EvaluacionRepository : GenericRepository<Evaluacion>, IEvaluacionRepository
    {
        public EvaluacionRepository(SistemaPasantesContext context) : base(context) { }
    }
}
