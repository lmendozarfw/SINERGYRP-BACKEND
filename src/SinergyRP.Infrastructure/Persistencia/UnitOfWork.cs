using SinergyRP.Application.Comun.Interfaces;
using SinergyRP.Infrastructure.Persistencia;

namespace SinergyRP.Infrastructure;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}