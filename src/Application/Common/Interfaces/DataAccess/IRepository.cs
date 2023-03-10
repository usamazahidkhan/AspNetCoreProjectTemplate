using Microsoft.EntityFrameworkCore;

namespace ProjectTemplate.Application
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<long> CountAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> QueryAll();
    }
}
