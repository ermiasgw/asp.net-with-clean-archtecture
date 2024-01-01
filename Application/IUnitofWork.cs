
namespace Application;

public interface IUnitofWork
{
    Task SaveAsync(CancellationToken cancellationToken);

}
