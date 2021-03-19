using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.entities;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IFormularioService
    {
        public Task<Formulario> CreateFormulario(Formulario formulario);

        public Task<Formulario> UpdateFormulario(Formulario formulario);

        public Task<Formulario> RemoveFormulario(int id);

        public Task<Formulario> GetFormularioById(int id);

        public Task<RespuestaFormulario> GetRespuestaFormulario(int formularioId);

        public IEnumerable<Formulario> GetAllFormularios();
    }
}
