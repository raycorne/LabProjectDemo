using LabProjectDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabProjectDemo.Infrastructure.EFCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductMarkcode> ProductMarkcodes { get; set; }
        public DbSet<BoxMarkcode> BoxMarkcodes { get; set; }
        public DbSet<PalletMarkcode> PalletMarkcodes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
                :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
