using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TareaDTO> GetAllTareas()
        {
            var allTarea = _unitOfWork.tareaRepository.GetAll();
            if (allTarea == null)
            {
                return NotFound("No hay tareas hechas");
            }
            var cleanData = _mapper.Map<IEnumerable<TareaDTO>>(allTarea);
            return Ok(cleanData);
        }


        [HttpPost(nameof(CreateTarea))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TareaDTO>> CreateTarea(TareaDTO tareaDTO)
        {
            if (!ModelState.IsValid) BadRequest("Modelo de tarea no valido");

            var tarea = _mapper.Map<Tarea>(tareaDTO);
            await _unitOfWork.tareaRepository.Add(tarea);
            await _unitOfWork.CommitAsync();
            return Ok(tareaDTO);
        }

        [HttpGet(nameof(GetTarea)+"/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Tarea>> GetTarea(int id)
        {
            var tarea = await _unitOfWork.tareaRepository.GetById(id);
            if (tarea == null)
            {
                return NotFound("Tarea no encontrada");
            }
            return Ok(tarea);
        }

        [HttpPut(nameof(UpdateTarea))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Tarea>> UpdateTarea(TareaDTO tareaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo de tarea no valido");
            }
            var tarea = _mapper.Map<Tarea>(tareaDTO);
            if(tareaDTO == null)
            {
                return NotFound("Debe de enviar los datos de la tarea a editar");
            }
            await _unitOfWork.tareaRepository.Update(tarea);
            await _unitOfWork.CommitAsync();

            return Ok(tarea);
        }


        [HttpDelete(nameof(DeleteTarea)+"/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Tarea>> DeleteTarea(int id) 
        {
            var tarea = await _unitOfWork.tareaRepository.GetById(id);
            if(tarea == null)
            {
                return NotFound($"La tarea con el id {id} no existe");
            }
            await _unitOfWork.tareaRepository.Remove(id);
            await _unitOfWork.CommitAsync();
            return Ok(tarea);
        }
       

    }
}
