using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class TareaEntregaRepository: GenericRepository<TareaEntrega>, ITareaEntregaRepository
    {
        private readonly SistemaPasantesContext _context;
        public TareaEntregaRepository(SistemaPasantesContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> validateTareaEnviada(TareaEntregaDTO tareaEntregaDTO)
        {
            var tareaentrega = await _context.TareaEntrega.Where(x => x.IdUsuario == tareaEntregaDTO.IdUsuario && x.IdTarea == tareaEntregaDTO.IdTarea).SingleOrDefaultAsync();
            if(tareaentrega != null)
            {
                return true;
            }
            return false;
        }
    }
}
