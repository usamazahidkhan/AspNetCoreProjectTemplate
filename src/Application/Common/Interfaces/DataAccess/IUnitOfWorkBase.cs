using System.Data;

namespace ProjectTemplate.Application
{
    public interface IUnitOfWorkBase : IAsyncDisposable
    {
        Task BeginAsync(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted, CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}