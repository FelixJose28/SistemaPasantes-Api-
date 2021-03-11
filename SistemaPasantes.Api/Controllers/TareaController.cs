using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
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
        public async Task<IEnumerable<Tarea>> GetTarea()
        {
            var tareas = await _service.GetTarea();
            return tareas;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarea(int id)
        {
            if (id < 0) return BadRequest("invalid id");

            var tarea = await _service.GetTarea(id);

            if (tarea == null) return NotFound();

            return Ok(tarea);
        }


        [HttpPost("{tarea}")]
        public async Task<IActionResult> PostTarea(Tarea tarea)
        {
            if (!ModelState.IsValid) return BadRequest("invalid data");

            var result = await _service.PostTarea(tarea);
            if (result == null) return NotFound(); 
           
            return Ok(result);
        }


        [HttpPut("{tarea}")]
        public async Task<IActionResult> PutTarea(Tarea tarea) 
        {
            if (!ModelState.IsValid) return BadRequest("invalid data");

            var result = await _service.PutTarea(tarea);

            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id) 
        {
            if (id < 0) return BadRequest("invalid id ");

            var result =  await _service.DeleteTarea(id);
            if (!result) return BadRequest("Can't delete tarea");

            return Ok(result); 

        }

    }
}
