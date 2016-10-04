using Crayon.Api.Sdk.Domain;
using Crayon.Api.Sdk.Filtering;

namespace Crayon.Api.Sdk.Resources
{
    public class ManagementLinkResource
    {
        private readonly CrayonApiClient _client;

        public ManagementLinkResource(CrayonApiClient client)
        {
            _client = client;
        }

        public CrayonApiClientResult<ApiCollection<ManagementLink>> Get(string token, ManagementLinkFilter filter = null)
        {
            var uri = "/api/v1/ManagementLinks/".Append(filter);
            return _client.Get<ApiCollection<ManagementLink>>(token, uri);
        }

        public CrayonApiClientResult<ApiCollection<ManagementLinkGrouped>> GetAsGrouped(string token, ManagementLinkFilter filter = null)
        {
            var uri = "/api/v1/ManagementLinks/grouped/".Append(filter);
            return _client.Get<ApiCollection<ManagementLinkGrouped>>(token, uri);
        }
    }
}
