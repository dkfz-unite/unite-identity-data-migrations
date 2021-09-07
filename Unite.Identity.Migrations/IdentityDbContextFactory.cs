using Microsoft.EntityFrameworkCore.Design;
using Unite.Identity.Migrations.Configuration.Options;
using Unite.Identity.Services;

namespace Unite.Identity.Migrations
{
    public class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
    {
        public IdentityDbContext CreateDbContext(string[] args)
        {
            var options = new SqlOptions();
            var dbContext = new IdentityDbContext(options);

            return dbContext;
        }
    }
}
