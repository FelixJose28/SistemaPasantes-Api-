using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaPasantes.Infrastructure.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaPasantes.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConvocatoriaController : ControllerBase
    {
        private readonly ILogger<ConvocatoriaController> _logger;

        public ConvocatoriaController(ILogger<ConvocatoriaController> logger)
        {
            _logger = logger;
        }

        // GET: api/<ConvocatoriaController>
        [HttpGet]
        public IEnumerable<Convocatoria> Get()
        {
            return null;
        }
    }
}
