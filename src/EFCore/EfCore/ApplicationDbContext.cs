using System.Reflection;
using ProjectTemplate.Application;
using ProjectTemplate.Domain;
using ProjectTemplate.EFCoreAndIdentity.Identity;
using ProjectTemplate.EFCoreAndIdentity.Persistence.Interceptors;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjectTemplate.EFCoreAndIdentity.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IMediator _mediator;
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IMediator mediator,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
            : base(options)
        {
            _mediator = mediator;
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public DbSet<UserAccountDetail> UserAccountDetails => Set<UserAccountDetail>();
        public DbSet<VpnAccount> VpnAccounts => Set<VpnAccount>();
        public DbSet<VpnAccountPurchase> VpnAccountPurchases => Set<VpnAccountPurchase>();
        public DbSet<UserWallet> UserWallets => Set<UserWallet>();
        public DbSet<UserWalletCreditTransaction> UserWalletCreditTransactions => Set<UserWalletCreditTransaction>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}