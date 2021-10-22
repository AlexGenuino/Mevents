using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.Data.Implementations
{
    public class AdminImplementation : BaseRepository<Admin>, IAdminRepository
    {
        private DbSet<Admin> _dataset;

        public AdminImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<Admin>();
        }

        public async Task<Admin> Login(string Email, string Password)
        {
            return await _context.Admin.FirstOrDefaultAsync(
                x => x.Email == Email && x.Password == Password);
        }
    }
}
