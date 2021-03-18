using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Core.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PerfilService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<Usuario> GetAllUsuario()
        {
            return _unitOfWork.perfilRepository.GetAll();
        }
        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _unitOfWork.perfilRepository.GetById(id);
        }
        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            var updatedUsuario = await _unitOfWork.perfilRepository.Update(usuario);
            await _unitOfWork.CommitAsync();
            return updatedUsuario;
        }

    } 
}
