using Microsoft.EntityFrameworkCore;
using PLM_API.PLM.Models;
using PLM_API.PLM.Models.ERP;

namespace PLM_API.Infrastructure.MSSql
{
    public class AppERPSysDbContext : DbContext
    {
        public AppERPSysDbContext(DbContextOptions<AppERPSysDbContext> options) : base(options) { }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
