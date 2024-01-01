
using Application;

namespace Infrastructure;

internal class UnitofWork : IUnitofWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitofWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task SaveAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
