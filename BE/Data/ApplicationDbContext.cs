using AngularFirst.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularFirst.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<tr_course>()
                .HasMany(p => p.trainers)
                .WithMany(p => p.courses)
                .UsingEntity(j => j.ToTable("tr_course_trainer"));

            modelBuilder
                .Entity<tr_course>()
                .HasMany(p => p.bands)
                .WithMany(p => p.courses)
                .UsingEntity(j => j.ToTable("tr_course_band"));

            
            modelBuilder
                .Entity<tr_trainer>()
                .HasMany(p => p.courses)
                .WithMany(p => p.trainers)
                .UsingEntity(j => j.ToTable("tr_course_trainer"));

            modelBuilder
                .Entity<tb_band>()
                .HasMany(p => p.courses)
                .WithMany(p => p.bands)
                .UsingEntity(j => j.ToTable("tr_course_band"));

            modelBuilder
                .Entity<tr_course_master>()
                .HasMany(p => p.bands)
                .WithMany(p => p.course_masters)
                .UsingEntity(j => j.ToTable("tr_course_master_band"));

            

            modelBuilder
                .Entity<tb_band>()
                .HasData(
                    new tb_band { band = "E" },
                    new tb_band { band = "J1" },
                    new tb_band { band = "J2" },
                    new tb_band { band = "J3" },
                    new tb_band { band = "J4" },
                    new tb_band { band = "M1" },
                    new tb_band { band = "M2" },
                    new tb_band { band = "JP" }
                );

            
        }
        public DbSet<tb_band> tb_band { get; set; }
        public DbSet<tb_employee_role_claims> tb_employee_role_claims { get; set; }
        public DbSet<tb_employee> tb_employee { get; set; }
        public DbSet<tb_menus> tb_menus { get; set; }
        public DbSet<tb_role_menu_claims> tb_role_menu_claims { get; set; }
        public DbSet<tb_role> tb_role { get; set; }
        public DbSet<tr_center> tr_center { get; set; }
        public DbSet<tr_course_master_band> tr_course_master_band { get; set; }
        public DbSet<tr_course_master> tr_course_master { get; set; }
        public DbSet< tr_course_registration>  tr_course_registration { get; set; }
        public DbSet<tr_course_score> tr_course_score { get; set; }
        public DbSet<tr_course_trainer> tr_course_trainer { get; set; }
        public DbSet<tr_course_band> tr_course_band { get; set; }
        public DbSet<tr_course> tr_course { get; set; }
        public DbSet<tr_stakeholder> tr_stakeholder { get; set; }
        public DbSet<tr_survey_detail> tr_survey_detail { get; set; }
        public DbSet<tr_survey_file> tr_survey_file{ get; set; }
        public DbSet<tr_survey_setting> tr_survey_setting { get; set; }
        public DbSet<tr_trainer> tr_trainer { get; set; }
    }
}
