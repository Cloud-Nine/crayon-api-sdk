using Crayon.Api.Sdk.Domain.Csp;
using Crayon.Api.Sdk.Filtering;

namespace Crayon.Api.Sdk.Resources
{
    public class UsageRecordResource
    {
        private readonly CrayonApiClient _client;

        public UsageRecordResource(CrayonApiClient client)
        {
            _client = client;
        }

        public CrayonApiClientResult<UsageRecordCollection> Get(string token, UsageRecordFilter filter = null)
        {
            var uri = "/api/v1/usagerecords/".Append(filter);

            return _client.Get<UsageRecordCollection>(token, uri);
        }

        public CrayonApiClientResult<UsageRecordGroupedCollection> GetAsGrouped(string token, UsageRecordGroupedFilter filter = null)
        {
            var uri = "/api/v1/usagerecords/grouped/".Append(filter);

            return _client.Get<UsageRecordGroupedCollection>(token, uri);
        }
    }
}