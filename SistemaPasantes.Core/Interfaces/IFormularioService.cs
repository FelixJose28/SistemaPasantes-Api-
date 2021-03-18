using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;


namespace SistemaPasantes.Core.Interfaces
{
    public interface IFormularioService
    {
        public IEnumerable<Formulario> GetAllFormularios();

        public Task<Formulario> GetFormularioById(int id);

        public Task<Formulario> CreateFormulario(Formulario convocatoria);

        public Task UpdateFormulario(Formulario convocatoria);

        public Task RemoveFormulario(int id);
    }
}
