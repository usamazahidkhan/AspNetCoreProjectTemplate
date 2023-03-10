using ProjectTemplate.Domain;

namespace ProjectTemplate.Application
{
    public interface IUnitOfWork : IUnitOfWorkBase
    {
        IRepository<VpnAccount, string> VpnAccounts { get; }
        IRepository<VpnAccountPurchase, string> VpnAccountPurchases { get; }
        IRepository<UserWallet, string> UserWallets { get; }
        IRepository<UserWalletCreditTransaction, int> UserWalletCreditTransactions { get; }
        IRepository<UserAccountDetail, int> UserAccountDetails { get; }
    }
}