using Microsoft.EntityFrameworkCore;
using AngularFirst.Models;

namespace AngularFirst.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext (DbContextOptions<OracleDbContext> options)
            : base(options)
        {
        }
    }
}