using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{

    public class TareaRepository : ITareaRepository 
    {

        private readonly SistemaPasantesContext _context;

        public TareaRepository(SistemaPasantesContext context)
        {
            _context = context;
        }

       
        public async Task<IEnumerable<Tarea>> GetTarea()
        {
            var tareas = await _context.Tareas.ToListAsync();
            return tareas;
        }



        public async Task<Tarea> GetTarea(int id)
        {
            var tarea = await _context.Tareas.FirstOrDefaultAsync(x => x.Id == id);
            return tarea;
        }



        public async Task<Tarea> PostTarea(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            var saveResult = await _context.SaveChangesAsync();


            var check = await _context.Tareas.FirstOrDefaultAsync(x => x.Id == tarea.Id);
            if (check == null) return null;

            return tarea;

        }



        public async Task<Tarea> PutTarea(Tarea tarea)
        {
            var item = await _context.Tareas
               .Where(x => x.Id == tarea.Id)
               .SingleOrDefaultAsync();

            if (item == null) return null;

            _context.Entry(item).CurrentValues.SetValues(tarea);
            var saveResult = await _context.SaveChangesAsync();

            return tarea;
        }


        public async Task<bool> DeleteTarea(int id)
        {
            var item = await _context.Tareas
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            _context.Entry(item).State = EntityState.Deleted;
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        } 
    }

}
