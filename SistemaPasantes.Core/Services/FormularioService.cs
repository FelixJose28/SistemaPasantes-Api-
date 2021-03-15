using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Core.Services
{
    public class FormularioService/* : IFormularioService*/
    {
        //private readonly IUnitOfWork _unitOfWork;

        //public FormularioService(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        //public async Task<Formulario> CreateFormulario(Formulario formulario)
        //{
        //    await _unitOfWork.formularioRepository.Add(formulario);
        //    await _unitOfWork.CommitAsync();
        //    return formulario;
        //}

        //public IEnumerable<Formulario> GetAllFormularios()
        //{
        //    return _unitOfWork.formularioRepository.GetAll();
        //}

        //public async Task<Formulario> GetFormularioById(int id)
        //{
        //    return await _unitOfWork.formularioRepository.GetById(id);
        //}

        //public async Task RemoveFormulario(int id)
        //{
        //    var entityToRemove = await _unitOfWork.formularioRepository.GetById(id);
        //    if (entityToRemove == null)
        //    {
        //        throw new Exception($"No se encontró el formulario con id: {id}");
        //    }

        //    await _unitOfWork.formularioRepository.Remove(id);
        //    await _unitOfWork.CommitAsync();
        //}

        //public async Task UpdateFormulario(int id, Formulario formulario)
        //{
        //    var entityToUpdate = await _unitOfWork.formularioRepository.GetById(id);
        //    if (entityToUpdate == null)
        //    {
        //        throw new Exception($"No se encontró el formulario con id: {id}");
        //    }

        //    if(entityToUpdate.Id != formulario.Id)
        //    {
        //        throw new Exception("El id del nuevo formulario no corresponde con el formulario a actualizar");
        //    }

        //    await _unitOfWork.formularioRepository.Update(id, formulario);
        //    await _unitOfWork.CommitAsync();
        //}
    }
}
