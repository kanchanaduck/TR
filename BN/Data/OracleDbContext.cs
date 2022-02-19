using Microsoft.EntityFrameworkCore;
using api_hrgis.Models;

namespace api_hrgis.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext (DbContextOptions<OracleDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<cpt_employees>();
            modelBuilder.Ignore<cpt_holidays>();
            modelBuilder.Ignore<cpt_organization>();
        }
        public virtual DbSet<cpt_employees> cpt_employees { get; set; }
        public virtual DbSet<cpt_organization> cpt_organization { get; set; }
        public virtual DbSet<cpt_holidays> cpt_holidays { get; set; }
    }
}