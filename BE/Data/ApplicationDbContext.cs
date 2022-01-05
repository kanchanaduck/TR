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
        
        public DbSet<tb_menus> tb_menus { get; set; }
        public DbSet<tb_roles> tb_roles { get; set; }
        public DbSet<tb_employee_role_claims> tb_employee_role_claims { get; set; }
        public DbSet<tb_role_menu_claims> tb_role_menu_claims { get; set; }
        public DbSet<tb_course_band> tb_course_band { get; set; }
        public DbSet<tb_course_trainer> tb_course_trainer { get; set; }
        public DbSet<tb_employee> tb_employee { get; set; }
        public DbSet<tr_employee_history> tr_employee_history { get; set; }
        public DbSet<tb_master_course_band> tb_master_course_band { get; set; }
        public DbSet<tr_band> tr_band { get; set; }
        public DbSet<tr_course> tr_course { get; set; }
        public DbSet<tr_master_course> tr_master_course { get; set; }
        public DbSet<tr_trainer> tr_trainer { get; set; }
        public DbSet<tr_v_trainer> tr_v_trainer { get; set; }
    }
}
