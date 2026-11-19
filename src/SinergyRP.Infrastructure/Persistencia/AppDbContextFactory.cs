using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SinergyRP.Infrastructure.Persistencia;

namespace RfidTraceability.Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
            ?? "Host=localhost;Port=5434;Database=sinergyrp;Username=postgres;Password=postgres";

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(connectionString).UseSnakeCaseNamingConvention()
            .Options;

        return new ApplicationDbContext(options);
    }
}
