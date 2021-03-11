using SistemaPasantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> GetTarea();

        Task<Tarea> GetTarea(int id);

        Task<Tarea> PostTarea(Tarea tarea);

        Task<Tarea> PutTarea(Tarea tarea);

        Task<bool> DeleteTarea(int id);

    }
}
