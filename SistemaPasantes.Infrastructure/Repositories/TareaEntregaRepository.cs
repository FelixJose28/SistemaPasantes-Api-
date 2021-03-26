using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class TareaEntregaRepository: GenericRepository<TareaEntrega>, ITareaEntregaRepository
    {
        private readonly sistemapasanteContext _context;
        public TareaEntregaRepository(sistemapasanteContext context) : base(context)
        {
            _context = context;
        }
    }
}
