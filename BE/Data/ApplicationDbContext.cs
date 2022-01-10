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
          /*   modelBuilder.Entity<tr_course>()
                .HasMany(c => c.bands)
                .WithMany(c => c.courses)
                .UsingEntity<tr_course_band>(
                    j => j
                        .HasOne(cb => cb.bands)
                        .WithMany(b => b.course_band)
                        .HasForeignKey(cb => cb.bands),
                    j => j
                        .HasOne(cb => cb.course)
                        .WithMany(c => c.course_band)
                        .HasForeignKey(cb => cb.course_no),
                    j =>
                    {
                        j.HasKey(b => new { b.course_no, b.band });
                        j.HasIndex(b =>  b.band_text );
                    } );*/

            modelBuilder
            .Entity<tr_course_master>()
            .Property(e => e.level)
            .HasConversion(
                v => v.ToString(),
                v => (Level)Enum.Parse(typeof(Level), v));

            modelBuilder
            .Entity<tr_course_score>()
            .Property(e => e.pre_test_grade)
            .HasConversion(
                v => v.ToString(),
                v => (Grade)Enum.Parse(typeof(Grade), v));

            modelBuilder
            .Entity<tr_course_score>()
            .Property(e => e.post_test_grade)
            .HasConversion(
                v => v.ToString(),
                v => (Grade)Enum.Parse(typeof(Grade), v));
            
            modelBuilder
            .Entity<tr_course_master>()
            .Property(e => e.level)
            .HasConversion(
                v => v.ToString(),
                v => (Level)Enum.Parse(typeof(Level), v));

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
