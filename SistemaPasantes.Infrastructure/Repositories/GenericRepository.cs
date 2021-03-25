using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<T> Add(T entity)
        {
            var entityEntry = await _dbSetEntities.AddAsync(entity);
            return entityEntry.Entity;
        }

        public Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }

        public async Task<T> Remove(int id)
        {
            T entity = await GetById(id);
            var entityEntry = _dbSetEntities.Remove(entity);
            return entityEntry.Entity;
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _dbSetEntities.FindAsync(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSetEntities.AsEnumerable();
        }
    }
}
