namespace ProjectTemplate.Domain
{
    /// <summary>
    /// User can create many vpn accounts, userId property in this entity 
    /// is represent the owner of this database record
    /// </summary>
    public class VpnAccount : BaseAuditableEntity<string>
    {
        private VpnAccount() { }

        public VpnAccount(string userName, string password, string userId, DateTime? expiredOn)
        {
            id = PrimaryKey.Generate();
            this.userName = userName ?? throw new ArgumentNullException(nameof(userName));
            this.password = password ?? throw new ArgumentNullException(nameof(password));
            this.userId = userId ?? throw new ArgumentNullException(nameof(userId));
            this.expiredOn = expiredOn;
            this.status = VpnAccountStatus.pending;

            AddDomainEvent(new VpnAccountCreateDomainEvent(this));
        }

        public string userName { get; private set; }
        public string password { get; private set; }
        public string userId { get; private set; }
        public string? vpnApiId { get; private set; }
        public DateTime? expiredOn { get; set; }
        public VpnAccountStatus status { get; set; }
    }
}
