using Microsoft.EntityFrameworkCore;
using PLM_API.PLM.Models.LogDB;

namespace PLM_API.Infrastructure.MSSql
{
    public class AppLogDbContext : DbContext
    {
        public AppLogDbContext(DbContextOptions<AppLogDbContext> options) : base(options) { }

        public DbSet<PLMApiTrace> AppLogs { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
