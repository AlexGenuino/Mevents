using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Domain.Repository
{
    public interface ILoginService
    {
        Task<object> Login(LoginDto user);

        

    }
}