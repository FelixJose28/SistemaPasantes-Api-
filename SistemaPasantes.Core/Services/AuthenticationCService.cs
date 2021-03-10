using SistemaPasantes.Core.Interfaces;
using SistemaPasantes.Infrastructure.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPasantes.Core.Services
{
    public class AuthenticationCService : IAuthenticationCService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticationCService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task RegisterUser(Usuario usuario)
        {
            await _unitOfWork.authenticationRepository.Add(usuario);
            await _unitOfWork.CommitAsync();
        }



        public async Task<Usuario> GetUserById(int id)
        {
            var user = await _unitOfWork.authenticationRepository.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task DeleteUser(int id)
        {
            if (GetUserById(id) == null)
            {
                throw new Exception("User not found");
            }
            await _unitOfWork.authenticationRepository.Remove(id);
        }


        public async Task<Usuario> LogginUser(Usuario usuario)
        {
            Usuario userLogger = await _unitOfWork.authenticationRepository.Loggin(usuario);
            if(userLogger == null)
            {
                throw new Exception("Usuario o contrasena incorrectos");
            }
            return userLogger;
        }

        public IEnumerable<Usuario> GetAllUsers()
        {
            return _unitOfWork.authenticationRepository.GetAll();
        }

        //public IEnumerable<Usuario> GetAllUsers()
        //{
        //    return _unitOfWork.authenticationRepository.GetAll();
        //}
    }
}
