using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class FormularioRepository : GenericRepository<Formulario>, IFormularioRepository
    {
        public FormularioRepository(SistemaPasantesContext context) : base(context) { }
    }
}
