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
        public DbSet<Employees> Employee { get; set; }
        public DbSet<Menus> Menu { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<EmployeeRoleClaims> EmployeeRoleClaim { get; set; }
        public DbSet<RoleMenuClaims> RoleMenuClaims { get; set; }
        public DbSet<EmployeeHistory> EmployeeHistory { get; set; }

    }
}
