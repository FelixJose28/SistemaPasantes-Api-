using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly SistemaPasantesContext _context;

        public TareaRepository(SistemaPasantesContext context) {
            _context = context; 
        }

        public async Task<IEnumerable<Tarea>> GetTarea()
        { 
            var tareas = await _context.Tareas.ToListAsync();

            return tareas; 
        }
    }
}
