using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

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
            await _unitOfWork.convocatoriaRepository.Add(convocatoria);
            await _unitOfWork.CommitAsync();
            return convocatoria;
        }

        public IEnumerable<Convocatoria> GetAllConvocatorias()
        {
            return _unitOfWork.convocatoriaRepository.GetAll();
        }

        public async Task<Convocatoria> GetConvocatoriaById(int id)
        {
            return await _unitOfWork.convocatoriaRepository.GetById(id);
        }

        public async Task RemoveConvocatoria(int id)
        {
            var entityToRemove = await _unitOfWork.convocatoriaRepository.GetById(id);
            if (entityToRemove == null)
            {
                throw new Exception($"No se encontró la convocatoria con id: {id}");
            }

            await _unitOfWork.convocatoriaRepository.Remove(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateConvocatoria(int id, Convocatoria convocatoria)
        {
            var entityToUpdate = await _unitOfWork.convocatoriaRepository.GetById(id);
            if (entityToUpdate == null)
            {
                throw new Exception($"No se encontró la convocatoria con id: {id}");
            }

            if(entityToUpdate.Id != convocatoria.Id)
            {
                throw new Exception("El id de la nueva convocatoria no corresponde con la convocatoria a actualizar");
            }

            await _unitOfWork.convocatoriaRepository.Update(id, convocatoria);
            await _unitOfWork.CommitAsync();
        }
    }
}
