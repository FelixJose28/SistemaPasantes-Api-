using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class RespuestaFormularioRepository : GenericRepository<RespuestaFormulario>, IRespuestaFormularioRepository
    {
        public RespuestaFormularioRepository(sistemapasanteContext context) : base(context) { }
    }
}
