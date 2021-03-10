using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity); // TODO: Esto debería devolver una Task igual, así todo ser async
        Task Remove(int id);
        void AddNoAsync(T entity);
    }
}
