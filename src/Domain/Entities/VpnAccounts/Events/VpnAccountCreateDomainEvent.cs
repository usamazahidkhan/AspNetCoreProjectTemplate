using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain
{
    public class VpnAccountCreateDomainEvent : BaseDomainEvent
    {
        public VpnAccountCreateDomainEvent(VpnAccount vpnAccount)
        {
            this.vpnAccount = vpnAccount;
        }

        public VpnAccount vpnAccount { get; }
    }
}
