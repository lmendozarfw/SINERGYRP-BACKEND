using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RfidTraceability.Infrastructure.Security;
using SinergyRP.Application.Comun.Interfaces;
using SinergyRP.Application.Seguridad;
using SinergyRP.Infrastructure.Persistencia;

namespace SinergyRP.Infrastructure;

public static class InjeccionDependencias
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");

        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGeneradorJWT, GeneradorJWT>();
        services.AddScoped<IGeneradorTokensRenovacion, GeneradorTokensRenovacion>();
        services.AddScoped<IHasheadorDeContrasenas, HasheadorDeContrasenas>();
        
        return services;
    }
}