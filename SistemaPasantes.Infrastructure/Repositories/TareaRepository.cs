using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class TareaRepository : IGenericRepository<Tarea>
    {
        private readonly IGenericRepository<Tarea> _context;

        public TareaRepository(IGenericRepository<Tarea> context)
        {
            _context = context;
        }

        public async Task Add(Tarea entity)
        {
         /*   await _context.Add(entity);

            var saveResult = await _context.SaveChangesAsync(); 

           return  saveResult == 1 ; 
         */
        }

        public void AddNoAsync(Tarea entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tarea> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Tarea> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Tarea entity)
        {
            throw new NotImplementedException();
        }
    }

}
