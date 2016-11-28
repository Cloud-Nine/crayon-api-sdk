using Crayon.Api.Sdk.Domain;
using Crayon.Api.Sdk.Filtering;

namespace Crayon.Api.Sdk.Resources
{
    public class ProductContainerResource
    {
        private readonly CrayonApiClient _client;

        public ProductContainerResource(CrayonApiClient client)
        {
            _client = client;
        }

        public CrayonApiClientResult<ApiCollection<ProductContainer>> Get(string token, ProductContainerFilter filter = null)
        {
            var uri = "/api/v1/productcontainers/".Append(filter);
            return _client.Get<ApiCollection<ProductContainer>>(token, uri);
        }

        public CrayonApiClientResult<ProductContainer> GetById(string token, int id)
        {
            var uri = $"/api/v1/productcontainers/{id}";
            return _client.Get<ProductContainer>(token, uri);
        }
    }
}