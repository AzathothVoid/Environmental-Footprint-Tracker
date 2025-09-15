using Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class EnvironmentalFootprintTrackerIdentityDesignTimeDbContextFactory : IDesignTimeDbContextFactory<EnvrionmentalFootprintTrackerIdentityDbContext>
    {
        public EnvrionmentalFootprintTrackerIdentityDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Client");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();


            var conn = configuration.GetConnectionString("EnvironmentalFootprintTrackerIdentityDbConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<EnvrionmentalFootprintTrackerIdentityDbContext>();


            optionsBuilder.UseNpgsql(conn);

            return new EnvrionmentalFootprintTrackerIdentityDbContext(optionsBuilder.Options);
        }
    }
}
