using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users {get; set;}
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Admin> Admin{ get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<TicketsTypes> TicketsTypes { get; set; }
        public MyContext (DbContextOptions<MyContext> options) : base(options) {

            


        }


        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<UserEntity> (new UserMap().Configure);
        }
    }
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyContext>();
            var serverVersion = new MySqlServerVersion(new System.Version(8, 0, 26));
            var connectionString = "Server=localhost;Port=3306;Database=mevents_db;Uid=root;Pwd=root123";
            builder.UseMySql(connectionString, serverVersion);
            return new MyContext(builder.Options);
        }
    }
}