using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class EnvironmentalFootprintTrackerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<EnvironmentalFootprintTrackerDbContext>
    {
        public EnvironmentalFootprintTrackerDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../WebUI");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();


            var conn = configuration.GetConnectionString("CodeSnippetManagerMainDbConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<EnvironmentalFootprintTrackerDbContext>();


            optionsBuilder.UseNpgsql(conn);

            return new EnvironmentalFootprintTrackerDbContext(optionsBuilder.Options);
        }
    }
}
