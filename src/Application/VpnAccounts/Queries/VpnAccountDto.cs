using ProjectTemplate.Domain;

namespace ProjectTemplate.Application
{
    public class VpnAccountDto
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string userId { get; set; }
        public string vpnApiId { get; set; }
        public DateTime? expiredOn { get; set; }
        public DateTime createdOn { get; set; }
        public VpnAccountStatus status { get; set; }
    }
}
