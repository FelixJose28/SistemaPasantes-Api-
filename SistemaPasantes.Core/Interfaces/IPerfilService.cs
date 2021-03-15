﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPasantes.Core.Entities;

namespace SistemaPasantes.Core.Interfaces
{
    public interface IPerfilService
    {
        public IEnumerable<Usuario> GetAllUsuario();

        public Task<Usuario> GetUsuarioById(int id);

        public Task UpdateUsuario(int id, Usuario usuario);

    }
}
