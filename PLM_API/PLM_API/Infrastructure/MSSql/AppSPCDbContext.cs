using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PLM_API.PLM.Models;
using PLM_API.PLM.Models.SPCAn;

namespace PLM_API.Infrastructure.MSSql
{
    public class AppSPCDbContext : DbContext
    {
        public AppSPCDbContext(DbContextOptions<AppSPCDbContext> options) : base(options) { }

        public DbSet<Cs1dataPicture> Cs1dataPictureRecords { get; set; } = null!;
        
    }
}
