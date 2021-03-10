using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using SistemaPasantes.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaPasantes.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConvocatoriaController : ControllerBase
    {
        private readonly IGenericRepository<Convocatoria> _convocatorias;

        public ConvocatoriaController(SistemaPasantesContext context)
        {
            _convocatorias = new GenericRepository<Convocatoria>(context);
        }

        // GET: convocatoria/
        [HttpGet]
        public IEnumerable<Convocatoria> GetConvocatorias()
        {
            return _convocatorias.GetAll();
        }

        // GET: convocatoria/id
        [HttpGet]
        public async Task<Convocatoria> GetConvocatoria(int id)
        {
            return await _convocatorias.GetById(id);
        }

        // POST: convocatoria/id
        [HttpPost]
        public async Task AddConvocatoria(Convocatoria convocatoria)
        {
            await _convocatorias.Add(convocatoria);
        }

        // POST: convocatoria/id
        [HttpPost]
        public void UpdateConvocatoria(Convocatoria convocatoria)
        {
            _convocatorias.Update(convocatoria);
        }

        // DELETE: convocatoria/id
        [HttpDelete]
        public async Task DeleteConvocatoria(int id)
        {
            await _convocatorias.Remove(id);
        }
    }
}
