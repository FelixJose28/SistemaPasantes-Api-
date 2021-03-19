using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class RespuestaFormularioRepository : GenericRepository<RespuestaFormulario>, IRespuestaFormularioRepository
    {
        public RespuestaFormularioRepository(SistemaPasantesContext context) : base(context) { }
    }
}
