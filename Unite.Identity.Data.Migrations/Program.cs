using Microsoft.EntityFrameworkCore;
using Unite.Identity.Data.Migrations.Configuration.Options;
using Unite.Identity.Data.Services;


Console.WriteLine($"[{DateTime.UtcNow}] - Migration service started");


Console.WriteLine($"[{DateTime.UtcNow}] - Configuring migration service...");

var options = new SqlOptions();


Console.WriteLine($"[{DateTime.UtcNow}] - Creating database context...");

var dbContext = new IdentityDbContext(options);


Console.WriteLine($"[{DateTime.UtcNow}] - Starting migration...");

try
{
    dbContext.Database.Migrate();

    Console.WriteLine($"[{DateTime.UtcNow}] - Migration completed successfully");
}
catch (Exception exception)
{
    Console.WriteLine($"[{DateTime.UtcNow}] - Migration failed");

    Console.WriteLine(exception.Message);

    if (exception.InnerException != null)
    {
        Console.WriteLine(exception.InnerException.Message);
    }
}

Console.WriteLine($"[{DateTime.UtcNow}] - Migration service stopped");
