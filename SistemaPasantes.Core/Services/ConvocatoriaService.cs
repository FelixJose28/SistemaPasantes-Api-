using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

#nullable enable

namespace SistemaPasantes.Core.Services
{
    public class ConvocatoriaService : IConvocatoriaService
    {
        private readonly IConvocatoriaRepository _repository;

        public ConvocatoriaService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.convocatoriaRepository;
        }

        public Task<Convocatoria> CreateConvocatoria(Convocatoria convocatoria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Convocatoria> GetAllConvocatorias()
        {
            throw new NotImplementedException();
        }

        public Task<Convocatoria> GetConvocatoriaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Convocatoria> RemoveConvocatoria(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Convocatoria> UpdateConvocatoria(int id, Convocatoria convocatoria)
        {
            throw new NotImplementedException();
        }
    }
}
