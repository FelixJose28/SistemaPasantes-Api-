using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;

namespace SistemaPasantes.Api.Controllers
{
    /// <summary>
    /// A generic implementation of a <a cref="ControllerBase"/>
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to store in the repositoy.</typeparam>
    /// <typeparam name="TEntityDTO">The type of the entity data transfer object, don't needed must be the same as TEntity.</typeparam>
    /// <typeparam name="TRepository">The type of the repository.</typeparam>
    /// <seealso cref="ControllerBase" />
    public abstract class GenericController<TEntity, TEntityDTO, TRepository> : ControllerBase 
        where TRepository : IGenericRepository<TEntity> 
        where TEntity : class
        where TEntityDTO : class
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly TRepository repository;
        protected readonly IMapper mapper;

        public GenericController(IUnitOfWork unitOfWork, TRepository repository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("{id}")] // GET: api/[controller]/id
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async virtual Task<ActionResult<TEntityDTO>> GetByID(int id)
        {
            TEntity entity = await repository.GetById(id);

            if(entity == null)
            {
                return NotFound();
            }

            if (typeof(TEntity) == typeof(TEntityDTO))
            {
                var entityFound = entity as TEntityDTO;
                return Ok(entityFound);
            }
            else
            {
                var mappedEntity = mapper.Map<TEntityDTO>(entity);
                return Ok(mappedEntity);
            }
        }

        [HttpGet] // GET: api/[controller]/
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual ActionResult<IEnumerable<TEntityDTO>> GetAll()
        {
            IEnumerable<TEntity> entities = repository.GetAll();

            if (typeof(TEntity) == typeof(TEntityDTO))
            {
                var result = entities.Select(e => e as TEntityDTO);
                return Ok(result);
            }
            else
            {
                var result = mapper.Map<IEnumerable<TEntityDTO>>(entities);
                return Ok(result);
            }
        }

        [HttpPost] // POST: api/[controller]/
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async virtual Task<ActionResult<TEntityDTO>> Create(TEntityDTO entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            try
            {
                TEntityDTO entityTDO = null;

                if (typeof(TEntity) == typeof(TEntityDTO))
                {
                    entityTDO = await repository.Add(entity as TEntity) as TEntityDTO;
                }
                else
                {
                    var mappedEntity = mapper.Map<TEntity>(entity);
                    var newEntity = await repository.Add(mappedEntity);
                    entityTDO = mapper.Map<TEntityDTO>(newEntity);
                }

                await unitOfWork.CommitAsync();
                return entityTDO;
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is not null)
                {
                    // The inner message contains the exact reason of the error, like a missing column
                    return BadRequest(e.InnerException.Message);
                }
                else
                {
                    return BadRequest(e.ToString());
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }


        [HttpPut] // PUT: api/[controller]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async virtual Task<ActionResult<TEntityDTO>> Update(TEntityDTO entity)
        {
            if (entity == null)
            {
                return NotFound();
            }

            try
            {
                TEntityDTO entityTDO = null;

                if (typeof(TEntity) == typeof(TEntityDTO))
                {
                    entityTDO = await repository.Update(entity as TEntity) as TEntityDTO;
                }
                else
                {
                    var mappedEntity = mapper.Map<TEntity>(entity);
                    var newEntity = await repository.Update(mappedEntity);
                    entityTDO = mapper.Map<TEntityDTO>(newEntity);
                }

                await unitOfWork.CommitAsync();
                return entityTDO;
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")] // DELETE: api/[controller]/id
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async virtual Task<ActionResult<TEntityDTO>> Delete(int id)
        {
            try
            {
                var removed = await repository.Remove(id);
                if (removed == null)
                {
                    return NotFound();
                }

                await unitOfWork.CommitAsync();

                var entityDTO = mapper.Map<TEntityDTO>(removed);
                return Ok(entityDTO);
            }
            catch
            {
                return NotFound();
            }
        }
    }

    public abstract class GenericController<TEntity, TRepository> : GenericController<TEntity, TEntity, TRepository> 
        where TRepository : IGenericRepository<TEntity>
        where TEntity : class
    {
        public GenericController(IUnitOfWork unitOfWork, TRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper) { }
    }
}
