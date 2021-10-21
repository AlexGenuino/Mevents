using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services.Encripty;
using Domain.Response;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserResponse> Get(Guid id)
        {
            try
            {
                UserEntity User = new UserEntity();
                User.Id = id;
                var Result = await _repository.SelectAsync(User.Id);
                if (Result != null)
                {
                    return new UserResponse
                         (
                             "Sucess",
                             true,
                             Result.Name,
                             Result.Email,
                             Result.CPF,
                             Result.Phone,
                             Result.Tickets
                       );
                }
                return new UserResponse("Falha ao buscar o usuario");
            }
            catch(Exception e)
            {
                return new UserResponse("Falha ao buscar o usuario" + e.Message);
            }
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {

            var ListResponseUsers = new List<UserResponse>();
            var Users = await _repository.SelectAsync();
            if(Users != null) 
            {
                foreach(var user in Users)
                {
                    ListResponseUsers.Add(new UserResponse
                    (
                        "Sucess",
                        true,
                        user.Name,
                        user.Email,
                        user.CPF,
                        user.Phone,
                        user.Tickets
                    ));
                }

                return ListResponseUsers;
            }

            return null;
        }

        public async Task<UserResponse> Post(UserEntity user)
        {
            try
            {
                user.Password = EncriptyPassword.CreateMD5(user.Password);
                var User = await _repository.InsertAsync(user);
                if (User != null)
                {
                    return new UserResponse
                    (
                        "Sucess",
                        true,
                        User.Name,
                        User.Email,
                        User.CPF,
                        User.Phone,
                        User.Tickets
                    );

                }
                return new UserResponse("Falha ao atualizar o usuario"); 
            }
            catch (Exception e)
            {
                return new UserResponse("Falha ao atualizar o usuario" + e.Message);
            }
        }

        public async Task<UserResponse> Put(UserEntity user)
        {
            try
            {
                user.Password = EncriptyPassword.CreateMD5(user.Password);
                var User = await _repository.UpdateAsync(user);
                if (User != null)
                {
                    return new UserResponse
                    (
                        "Sucess",
                        true,
                        User.Name,
                        User.Email,
                        User.CPF,
                        User.Phone,
                        User.Tickets
                    );

                }
                return null;
            }
            catch(Exception e)
            {
                return new UserResponse("Falha ao atualizar o usuario" + e.Message);
            }
           
        }

    }
}