using ProjectTemplate.EFCoreAndIdentity.Persistence;

namespace ProjectTemplate.Infrastructure.EfCore
{
    internal class RepositoryBase<TEntity, TKey> : GenericRepository<TEntity, TKey> where TEntity : class
    {
        public RepositoryBase(ApplicationDbContext context) : base(context)
        { }
    }
}
