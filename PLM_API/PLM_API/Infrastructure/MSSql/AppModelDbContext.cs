using Microsoft.EntityFrameworkCore;
using PLM_API.PLM.Models.ERP;
using PLM_API.PLM.Models.LogDB;

namespace PLM_API.Infrastructure.MSSql
{
    public class AppModelDbContext : DbContext
    {
        public AppModelDbContext(DbContextOptions<AppModelDbContext> options) : base(options) { }

        public DbSet<INVTL> GetItemChangeOrder { get; set; } = null!;

        public DbSet<INVTM> INVTM { get; set; } = null!;

        public DbSet<CMSMC> GetWarehouse { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<INVTL>()
            .ToTable("INVTL")
            .HasKey(e => new { e.TL001, e.TL004 });

            modelBuilder.Entity<INVTM>()
            .ToTable("INVTM")
            .HasKey(e => new { e.TM001, e.TM002, e.TM003 });

            modelBuilder.Entity<CMSMC>()
            .ToTable("CMSMC")
            .HasKey(e => new { e.MC001 });
        }
    }
}
