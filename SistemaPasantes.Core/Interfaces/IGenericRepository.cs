using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> GetAll();

        Task<T> GetById(int id);

        Task<T> Add(T entity);

        Task<T> Update(int id, T entity);

        Task<T> Remove(int id);
    }
}
