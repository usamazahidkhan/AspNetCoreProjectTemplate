namespace ProjectTemplate.Domain
{
    public class VpnAccountPurchase : BaseAuditableEntity<string>
    {
        public decimal amount { get; set; }
        public string currency { get; set; } = "USD";
        public string vpnAccountId { get; set; }
        public VpnAccount vpnAccount { get; set; }
    }
}
