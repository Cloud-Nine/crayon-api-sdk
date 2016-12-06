using System;

namespace Crayon.Api.Sdk.Filtering
{
    public class UsageRecordFilter : IHttpFilter
    {
        public int? OrganizationId { get; set; }

        public int? SubscriptionId { get; set; }

        public int? CloudAccountId { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset To { get; set; }

        public string Search { get; set; }
        
        public string ToQueryString()
        {
            return this.ToQuery();
        }
    }
}
