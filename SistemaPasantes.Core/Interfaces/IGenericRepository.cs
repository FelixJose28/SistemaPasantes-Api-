using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<T> Remove(int id);

        Task<T> GetById(int id);

        IEnumerable<T> GetAll();
    }
}
