﻿using Microsoft.EntityFrameworkCore;
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
        private readonly sistemapasantesContext _context;

        private readonly DbSet<T> _dbSetEntities;
        public GenericRepository(sistemapasantesContext context)
        {
            _context = context;
            _dbSetEntities = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSetEntities.AddAsync(entity); // TODO: No es necesario DbContext.SaveChangesAsync()?
        }

        public void AddNoAsync(T entity)
        {
            _dbSetEntities.Add(entity);
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

        public void Update(T entity)
        {
            _dbSetEntities.Update(entity);
        }
    }
}
