using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Core.Services
{
    public class FormularioService : IFormularioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FormularioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Formulario> CreateFormulario(Formulario formulario)
        {
            var newFormulario = await _unitOfWork.formularioRepository.Add(formulario);
            await _unitOfWork.CommitAsync();
            return newFormulario;
        }

        public async Task<Formulario> UpdateFormulario(Formulario formulario)
        {
            var updatedFormulario = await _unitOfWork.formularioRepository.Update(formulario);
            await _unitOfWork.CommitAsync();
            return updatedFormulario;
        }

        public async Task<Formulario> RemoveFormulario(int id)
        {
            var formulario = await _unitOfWork.formularioRepository.Remove(id);
            if (formulario == null)
            {
                return null;
            }

            return formulario;
        }

        public IEnumerable<Formulario> GetAllFormularios()
        {
            return _unitOfWork.formularioRepository.GetAll();
        }

        public Task<Formulario> GetFormularioById(int id)
        {
            return _unitOfWork.formularioRepository.GetById(id);
        }

        public async Task<RespuestaFormulario> GetRespuestaFormulario(int formularioId)
        {
            throw new NotImplementedException();
        }
    }
}
