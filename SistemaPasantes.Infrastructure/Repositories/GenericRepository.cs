using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SistemaPasantesContext _context;

        private readonly DbSet<T> _dbSetEntities;

        public GenericRepository(SistemaPasantesContext context)
        {
            _context = context;
            _dbSetEntities = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSetEntities.AddAsync(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSetEntities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _dbSetEntities.FindAsync(id);
            return entity;
        }

        public async Task Remove(int id)
        {
            T entity = await GetById(id);
            _dbSetEntities.Remove(entity);
        }

        public async Task Update(int id, T entity)
        {
            var entityToUpdate = await _dbSetEntities.FindAsync(id);
            _dbSetEntities.Update(entityToUpdate);
        }
    }
}
