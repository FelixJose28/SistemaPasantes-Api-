using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.entities;
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

        public async Task<Convocatoria> CreateConvocatoria(Convocatoria convocatoria)
        {
            var newConvocatoria = await _unitOfWork.convocatoriaRepository.Add(convocatoria);
            await _unitOfWork.CommitAsync();
            return newConvocatoria;
        }

        public async Task<Convocatoria?> UpdateConvocatoria(Convocatoria convocatoria)
        {
            var updatedConvocatoria = await _unitOfWork.convocatoriaRepository.Update(convocatoria);
            await _unitOfWork.CommitAsync();
            return updatedConvocatoria;
        }

        public async Task<Convocatoria?> RemoveConvocatoria(int id)
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

        public Task<Convocatoria?> GetConvocatoriaById(int id)
        {
            return _unitOfWork.convocatoriaRepository.GetById(id);
        }

        public IEnumerable<Convocatoria> GetAllConvocatorias()
        {
            return _unitOfWork.convocatoriaRepository.GetAll();
        }
    }
}
