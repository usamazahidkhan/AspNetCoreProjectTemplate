using ProjectTemplate.Application;
using ProjectTemplate.EFCoreAndIdentity.Persistence;
using ProjectTemplate.Domain;

namespace ProjectTemplate.Infrastructure.EfCore
{
    internal class UnitOfWorkWithRepositories : UnitOfWorkBase, IUnitOfWork, IAsyncDisposable
    {
        public IRepository<VpnAccount, string> VpnAccounts { get; }
        public IRepository<VpnAccountPurchase, string> VpnAccountPurchases { get; }
        public IRepository<UserWallet, string> UserWallets { get; }
        public IRepository<UserWalletCreditTransaction, int> UserWalletCreditTransactions { get; }
        public IRepository<UserAccountDetail, int> UserAccountDetails { get; }

        public UnitOfWorkWithRepositories(
            ApplicationDbContext context,
            IRepository<VpnAccount, string> vpnAccounts,
            IRepository<VpnAccountPurchase, string> vpnAccountPurchases,
            IRepository<UserWallet, string> userWallets,
            IRepository<UserWalletCreditTransaction, int> userWalletCreditTransactions,
            IRepository<UserAccountDetail, int> userAccountDetails) : base(context)
        {
            VpnAccounts = vpnAccounts;
            VpnAccountPurchases = vpnAccountPurchases;
            UserWallets = userWallets;
            UserWalletCreditTransactions = userWalletCreditTransactions;
            UserAccountDetails = userAccountDetails;
        }
    }
}
