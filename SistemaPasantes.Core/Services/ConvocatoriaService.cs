﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

#nullable enable

namespace SistemaPasantes.Core.Services
{
    public class ConvocatoriaService : IConvocatoriaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConvocatoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Convocatorium> CreateConvocatoria(Convocatorium convocatoria)
        {
            await _unitOfWork.convocatoriaRepository.Add(convocatoria);
            await _unitOfWork.CommitAsync();
            return convocatoria;
        }

        public IEnumerable<Convocatorium> GetAllConvocatorias()
        {
            return _unitOfWork.convocatoriaRepository.GetAll();
        }

        public Task<Convocatorium?> GetConvocatoriaById(int id)
        {
            return _unitOfWork.convocatoriaRepository.GetById(id);
        }

        public async Task<Convocatorium?> RemoveConvocatoria(int id)
        {
            var entityToRemove = await _unitOfWork.convocatoriaRepository.GetById(id);
            if (entityToRemove == null)
            {
                return null;
            }

            var removedConvocatoria = await _unitOfWork.convocatoriaRepository.Remove(id);
            await _unitOfWork.CommitAsync();
            return removedConvocatoria;
        }

        public async Task<Convocatorium?> UpdateConvocatoria(Convocatorium convocatoria)
        {
            var updatedConvocatoria = await _unitOfWork.convocatoriaRepository.Update(convocatoria);
            await _unitOfWork.CommitAsync();
            return updatedConvocatoria;
        }
    }
}
