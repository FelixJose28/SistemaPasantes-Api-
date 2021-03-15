﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Usuario> GetPerfilUsuario(int id, string Nombre, string Apellido)
        {
            return await _unitOfWork.perfilRepository.GetById(id);
        }
        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _unitOfWork.perfilRepository.GetById(id);
        }
        public async Task UpdateUsuario(int id, Usuario usuario)
        {
            var entityToUpdate = await _unitOfWork.perfilRepository.GetById(id);
            if (entityToUpdate == null)
            {
                throw new Exception($"No se encontró el usuario con id: {id}");
            }
        }

    }
}
