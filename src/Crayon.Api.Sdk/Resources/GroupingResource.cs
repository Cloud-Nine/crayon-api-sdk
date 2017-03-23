using Crayon.Api.Sdk.Domain;
using Crayon.Api.Sdk.Filtering;

namespace Crayon.Api.Sdk.Resources
{
    public class GroupingResource
    {
        private readonly CrayonApiClient _client;

        public GroupingResource(CrayonApiClient client)
        {
            _client = client;
        }

        public CrayonApiClientResult<ApiCollection<Grouping>> Get(string token, GroupingFilter filter = null)
        {
            var uri = "/api/v1/groupings/".Append(filter);
            return _client.Get<ApiCollection<Grouping>>(token, uri);
        }

        public CrayonApiClientResult<Grouping> GetById(string token, int id)
        {
            if (id <= 0)
            {
                return CrayonApiClientResult.NotFound<Grouping>();
            }

            var uri = $"/api/v1/groupings/{id}";
            return _client.Get<Grouping>(token, uri);
        }

        public CrayonApiClientResult<Grouping> Create(string token, Grouping grouping)
        {
            var uri = "/api/v1/groupings/";
            return _client.Post<Grouping>(token, uri, grouping);
        }

        public CrayonApiClientResult<Grouping> Update(string token, Grouping grouping)
        {
            Guard.NotNull(grouping, nameof(grouping));

            var uri = $"/api/v1/groupings/{grouping.Id}";
            return _client.Put<Grouping>(token, uri, grouping);
        }

        public CrayonApiClientResult Delete(string token, int id)
        {
            var uri = $"/api/v1/groupings/{id}/";
            return _client.Delete(token, uri);
        }
    }
}