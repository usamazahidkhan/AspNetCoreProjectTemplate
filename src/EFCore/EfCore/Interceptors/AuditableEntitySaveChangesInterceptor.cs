using ProjectTemplate.Application;
using ProjectTemplate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ProjectTemplate.EFCoreAndIdentity.Persistence.Interceptors
{
    public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public AuditableEntitySaveChangesInterceptor(
            ICurrentUserService currentUserService,
            IDateTime dateTime)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<IBaseAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.createdOn = _dateTime.Now;

                    //if (string.IsNullOrEmpty(entry.Entity.createdBy))
                    //{
                    //    entry.Entity.createdBy = _currentUserService.UserId;
                    //}
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || HasChangedOwnedEntities(entry))
                {
                    entry.Entity.lastModifiedBy = _currentUserService.UserId;
                    entry.Entity.lastModifiedOn = _dateTime.Now;
                }
            }
        }

        private static bool HasChangedOwnedEntities(EntityEntry entry) =>
              entry.References.Any(r =>
                  r.TargetEntry != null &&
                  r.TargetEntry.Metadata.IsOwned() &&
                  (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }

}
