using SistemaPasantes.Core.DTOs;
using SistemaPasantes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Interfaces
{
    public interface ITareaEntregaRepository: IGenericRepository<TareaEntrega>
    {
        Task<bool> validateTareaEnviada(TareaEntregaDTO tareaEntregaDTO);
    }
}
