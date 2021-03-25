using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{

    public class TareaRepository : GenericRepository<Tarea>, ITareaRepository
    {
        private readonly SistemaPasantesContext _context;

        public TareaRepository(SistemaPasantesContext context): base(context)
        {
            _context = context;
        }

       
    }

}
