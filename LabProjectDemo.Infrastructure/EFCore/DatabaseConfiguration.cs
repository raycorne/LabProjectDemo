using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabProjectDemo.Infrastructure.EFCore
{
    public class DatabaseConfiguration
    {
        public static DbContextOptions<AppDbContext> s_options { get; private set; } = null!;
        static DatabaseConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();
            string? connectionString = builder.GetConnectionString("DefaultConnection");
            s_options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString!, options => options.EnableRetryOnFailure()).Options;
        }
    }
}
