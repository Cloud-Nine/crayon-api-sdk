using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crayon.Api.Sdk.Filtering
{
    public class ManagementLinkFilter : IHttpFilter
    {
        public int TenantId { get; set; }

        public List<string> AxDataAreaIds { get; set; }

        public List<int> SubscriptionIds { get; set; }

        public List<int> ResellerCustomerIds { get; set; } = new List<int>();

        public string ToQueryString()
        {
            return this.ToQuery();
        }
    }
}
