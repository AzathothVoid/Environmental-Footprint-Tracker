using Application.Contracts.Persistence.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersisteneServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EnvironmentalFootprintTrackerDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("AIPortfolioMainDbConectionString")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
     
            return services;
        }
    }
}
