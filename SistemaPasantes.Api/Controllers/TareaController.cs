using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPasantes.Api.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TareaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet(nameof(GetAllTareas))]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllTareas()
        {
            var allTarea = _unitOfWork.tareaRepository.GetAll();
            if (allTarea == null)
            {
                return NotFound("No hay tareas hechas");
            }
            var cleanData = _mapper.Map<IEnumerable<TareaDTO>>(allTarea);
            return Ok(cleanData);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTarea(TareaDTO tareaDTO)
        {
            if (!ModelState.IsValid) BadRequest("Modelo de tarea no valido");

            var tarea = _mapper.Map<Tarea>(tareaDTO);
            await _unitOfWork.tareaRepository.Add(tarea);
            await _unitOfWork.CommitAsync();
            return Ok(tareaDTO);
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetTarea(int id)
        {
            var tarea = await _unitOfWork.tareaRepository.GetById(id);
            if (tarea == null)
            {
                return NotFound("Tarea no encontrada");
            }
            return Ok(tarea);
        }
        [HttpPut]
        public async Task<IActionResult> EditTarea(TareaDTO tareaDTO)
        {
            var tarea = _mapper.Map<Tarea>(tareaDTO);
            await _unitOfWork.tareaRepository.Update(tarea);
            await _unitOfWork.CommitAsync();
            return Ok(tarea);
        }

       

    }
}
