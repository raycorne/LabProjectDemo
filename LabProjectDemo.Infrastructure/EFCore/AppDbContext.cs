using LabProjectDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabProjectDemo.Infrastructure.EFCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Markcode> Markcode { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
                :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
