using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPasantes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaEntregaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TareaEntregaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllTareaEntregadas()
        {
            var allTareas = _unitOfWork.tareaEntregaRepository.GetAll();
            if(allTareas == null)
            {
                return NotFound("No hay tareas entregadas");
            }
            var tareadto = _mapper.Map<IEnumerable<TareaEntregaDTO>>(allTareas);
            return Ok(tareadto);
        }
        [HttpPost]
        public async Task<IActionResult> EntregarTarea(TareaEntregaDTO tareaEntregaDTO)
        {
            if (!ModelState.IsValid) return BadRequest("Modelo no valido");

            var tarea = _mapper.Map<TareaEntrega>(tareaEntregaDTO);
            await _unitOfWork.tareaEntregaRepository.Add(tarea);
            await _unitOfWork.CommitAsync();
            return Ok(tareaEntregaDTO);
        }
        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteTareaEntregada(int id)
        {
            var existeTarea = await _unitOfWork.tareaEntregaRepository.GetById(id);
            if(existeTarea == null)
            {
                return NotFound($"La tarea con el id {id} que desea borrar no existe");
            }
            await _unitOfWork.tareaEntregaRepository.Remove(id);
            await _unitOfWork.CommitAsync();
            return NoContent();
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetTareaEntregada(int id)
        {
            var existeTarea = await _unitOfWork.tareaEntregaRepository.GetById(id);
            if (existeTarea == null)
            {
                return NotFound($"La tarea con el id {id} que desea buscar no existe");
            }
            var tarea = _mapper.Map<TareaEntregaDTO>(existeTarea);
            return Ok(tarea);
        }
    }
}
