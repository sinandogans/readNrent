using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;

namespace UserService.Persistence.EntityFramework.Context
{
    public class UserServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sinan;Database=readNrent_UserService_db;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        DbSet<User> Users { get; set; }
        DbSet<UserBook> UserBooks { get; set; }
    }
}
