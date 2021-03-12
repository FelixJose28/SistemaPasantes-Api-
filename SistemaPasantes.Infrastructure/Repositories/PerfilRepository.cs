﻿using SistemaPasantes.Core.Entities;
using SistemaPasantes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPasantes.Infrastructure.Repositories
{
    public class PerfilRepository :  GenericRepository<Usuario>, IPerfilRepository
    {

        public PerfilRepository(SistemaPasantesContext context) : base (context)
        {
            
        }
    }
}