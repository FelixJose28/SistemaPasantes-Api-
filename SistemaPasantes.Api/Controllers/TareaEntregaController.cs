using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.entities;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPasantes.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TareaEntregaController : ControllerBase
    {
        private readonly IWebHostEnvironment _enviroment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TareaEntregaController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment enviroment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _enviroment = enviroment;
        }
        [HttpGet]
        public IActionResult GetAllTareaEntregadas()
        {
            var allTareas = _unitOfWork.tareaEntregaRepository.GetAll();
            if(allTareas == null)
            {
                return NotFound("No hay tareas entregadas");
            }
            return Ok(allTareas);
        }



        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> EntregarTarea([FromForm]TareaEntregaDTO tareaEntregaDTO)
        {
            

            var upload = tareaEntregaDTO.Archivo;
            using (var ms = new MemoryStream())
            {
                var tareaEntrega = new TareaEntrega();
                await upload.CopyToAsync(ms);
                tareaEntrega.FechaEntrega = tareaEntregaDTO.FechaEntrega;
                tareaEntrega.Archivo = ms.ToArray();
                tareaEntrega.Comentarios = tareaEntregaDTO.Comentarios;
                tareaEntrega.Calificacion = tareaEntregaDTO.Calificacion;
                tareaEntrega.IdUsuario = tareaEntregaDTO.IdUsuario;
                tareaEntrega.IdTarea = tareaEntregaDTO.IdTarea;
                await _unitOfWork.tareaEntregaRepository.Add(tareaEntrega);
                await _unitOfWork.CommitAsync();
            }

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
        [HttpPut]
        public async Task<IActionResult> UpdateTareaEntregada(TareaEntregaDTO tareaEntregaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo de tarea no valido");
            }

            //var existeTarea = await _unitOfWork.tareaEntregaRepository.GetById(tareaEntregaDTO.Id);
            //if (existeTarea == null)
            //{
            //    return NotFound($"La tarea con el id {tareaEntregaDTO.Id} que desea actualizar no existe");
            //}
            var entregatarea = _mapper.Map<TareaEntrega>(tareaEntregaDTO);
            await _unitOfWork.tareaEntregaRepository.Update(entregatarea);
            await _unitOfWork.CommitAsync();
            return Ok(entregatarea);
        }
    }
}
