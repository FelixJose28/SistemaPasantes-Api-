using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task AddUser(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetUserById(int id)
        {
            return await _unitOfWork.
        }

        public Task RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
