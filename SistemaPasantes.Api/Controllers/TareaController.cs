using AutoMapper;
using Microsoft.AspNetCore.Cors;
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
        

       

    }
}
