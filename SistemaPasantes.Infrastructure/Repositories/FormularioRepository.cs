using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class FormularioRepository : GenericRepository<Formulario>, IFormularioRepository
    {
        public FormularioRepository(SistemaPasantesContext context) : base(context) { }
    }
}
