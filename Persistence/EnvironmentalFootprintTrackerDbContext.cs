using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class EnvironmentalFootprintTrackerDbContext : DbContext
    {
        public EnvironmentalFootprintTrackerDbContext(DbContextOptions<EnvironmentalFootprintTrackerDbContext> options) : base(options)
        {
                
        }
    }
}
