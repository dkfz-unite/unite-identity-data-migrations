using Microsoft.EntityFrameworkCore.Design;
using Unite.Identity.Data.Migrations.Configuration.Options;
using Unite.Identity.Data.Services;

namespace Unite.Identity.Data.Migrations;

public class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
{
    public IdentityDbContext CreateDbContext(string[] args)
    {
        var options = new SqlOptions();
        var dbContext = new IdentityDbContext(options);

        return dbContext;
    }
}
