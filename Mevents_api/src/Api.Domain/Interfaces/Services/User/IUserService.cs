using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Domain.Response;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserResponse> Get(Guid id);
        Task<IEnumerable<UserResponse>> GetAll();
        Task<UserResponse> Post (UserEntity user);
        Task<UserResponse> Put (UserEntity user);
        Task<bool> Delete (Guid id);
    }
}