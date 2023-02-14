using Microsoft.EntityFrameworkCore;

namespace LabProjectDemo.Infrastructure.EFCore
{
    public class DatabaseConfiguration
    {
        public static DbContextOptions<AppDbContext> s_options { get; private set; } = null!;
        /*static DatabaseConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile("appsettings.json");
            //var config = builder.Build();
            string? connectionString = builder.GetConnectionString("DefaultConnection");
            //var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            s_options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString!).Options;
        }*/
    }
}
