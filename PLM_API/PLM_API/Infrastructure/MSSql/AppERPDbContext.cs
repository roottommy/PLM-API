using Microsoft.EntityFrameworkCore;
using PLM_API.PLM.Models;
using PLM_API.PLM.Models.ERP;

namespace PLM_API.Infrastructure.MSSql
{
    public class AppERPDbContext : DbContext
    {
        public AppERPDbContext(DbContextOptions<AppERPDbContext> options) : base(options) { }

        public DbSet<CheckItemStatusResult> CheckItemStResult { get; set; }

        public DbSet<INVMB> GetItem { get; set; } = null!;

        public DbSet<INVMA> GetItemType { get; set; } = null!;

        public DbSet<CMSMC> GetWarehouse { get; set; } = null!;

        public DbSet<INVTL> GetItemChangeOrder { get; set; } = null!;

        public DbSet<INVTM> INVTM { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CheckItemStatusResult>()
                .HasNoKey()
                .ToView(null);

            modelBuilder.Entity<INVMA>()
                .ToTable("INVMA")
                .HasKey(e => new { e.MA001, e.MA002 });

            modelBuilder.Entity<INVMB>()
            .ToTable("INVMB")
            .HasKey(e => new { e.MB001 });

            modelBuilder.Entity<CMSMC>()
            .ToTable("CMSMC")
            .HasKey(e => new { e.MC001});

            modelBuilder.Entity<INVTL>()
            .ToTable("INVTL")
            .HasKey(e => new { e.TL001, e.TL004 });

            modelBuilder.Entity<INVTM>()
            .ToTable("INVTM")
            .HasKey(e => new { e.TM001, e.TM002, e.TM003 });
        }
    }
}
