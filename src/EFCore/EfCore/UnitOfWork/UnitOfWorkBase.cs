using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Application;
using System.Data;

namespace ProjectTemplate.Infrastructure.EfCore
{
    internal abstract class UnitOfWorkBase : IUnitOfWorkBase, IAsyncDisposable
    {
        private IDbContextTransaction _transaction;
        private readonly DbContext _context;

        public UnitOfWorkBase(DbContext context)
        {
            _context = context;
        }

        public async Task BeginAsync(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted, CancellationToken cancellationToken = default)
        {
            _transaction = await _context.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
                await _transaction.DisposeAsync();

            if (_context != null)
                await _context.DisposeAsync();
        }
    }
}
