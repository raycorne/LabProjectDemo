using LabProjectDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LabProjectDemo.Infrastructure.EFCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Markcode> Markcode { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
                :base(options){ }
    }
}
