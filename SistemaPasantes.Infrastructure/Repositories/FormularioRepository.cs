using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class FormularioRepository : GenericRepository<Formulario>, IFormularioRepository
    {
        public FormularioRepository(sistemapasanteContext context) : base(context) { }
    }
}
