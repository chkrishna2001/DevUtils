using DevUtils.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DevUtils.Core
{
    public class DevUtilContext : DbContext
    {
        internal DbSet<DatabaseServer> DatabaseServers { get; set; }
        internal DbSet<DatabaseEnvironment> DatabaseEnvironments { get; set; }
        public DevUtilContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
