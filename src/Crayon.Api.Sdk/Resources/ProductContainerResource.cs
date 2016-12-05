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

        public CrayonApiClientResult<ProductContainer> Put(string token, ProductContainer productContainer)
        {
            var uri = $"/api/v1/productcontainers/{productContainer.Id}";
            return _client.Put<ProductContainer>(token, uri, productContainer);
        }

        public CrayonApiClientResult<ProductContainer> CreateReport(string token, UserProfile userProfile, int organizationId, int programId, int year, int month, bool copyLast = false)
        {
            var uri = $"/api/v1/productcontainers/createreport/?organizationId={organizationId}&programId={programId}&year={year}&month={month}&copyLast={copyLast}";
            return _client.Put<ProductContainer>(token, uri, userProfile);
        }
    }
}