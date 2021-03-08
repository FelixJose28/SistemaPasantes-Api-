using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPasantes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TareaController : Controller
    {
        private readonly ITareaRepository _service; 

        public TareaController(ITareaRepository service) {
            _service = service; 
        }

        [HttpGet]
        public  async Task<IEnumerable<Tarea>> Tarea()
        {
            var tareas = await _service.GetTarea();
            return tareas; 
        }
    }
}
