using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<Admin> Login(string Email, string Password);
    }
}
