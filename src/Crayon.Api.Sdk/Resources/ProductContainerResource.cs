using Crayon.Api.Sdk.Domain;
using Crayon.Api.Sdk.Filtering;
using System.Net;

namespace Crayon.Api.Sdk.Resources
{
    public class ProductContainerResource
    {
        private readonly CrayonApiClient _client;

        internal ProductContainerResource(CrayonApiClient client)
        {
            _client = client;
        }

        public CrayonApiClientResult<ProductContainer> GetOrCreateShoppingCart(string token, int organizationId)
        {
            var uri = $"/api/v1/productcontainers/shoppingcart/?organizationId={organizationId}";
            var result = _client.Get<ProductContainer>(token, uri);

            if (result.StatusCode == HttpStatusCode.NotFound)
            {
                result = _client.Post<ProductContainer>(token, uri, null);
            }

            return result;
        }

        public CrayonApiClientResult<ProductContainer> GetById(string token, int id)
        {
            var uri = $"/api/v1/productcontainers/{id}/";
            return _client.Get<ProductContainer>(token, uri);
        }

        public CrayonApiClientResult<ApiCollection<ProductContainer>> Get(string token, ProductContainerFilter filter)
        {
            var uri = "/api/v1/productcontainers/".Append(filter);
            return _client.Get<ApiCollection<ProductContainer>>(token, uri);
        }

        public CrayonApiClientResult<ProductContainer> Update(string token, ProductContainer draft)
        {
            var uri = $"/api/v1/productcontainers/{draft.Id}/";
            return _client.Put<ProductContainer>(token, uri, draft);
        }

        public CrayonApiClientResult<bool> Delete(string token, int id)
        {
            var uri = $"/api/v1/productcontainers/{id}/";
            return _client.Delete(token, uri);
        }

        public CrayonApiClientResult<ProductContainer> SaveAsTemplate(string token, ProductContainer productContainer, string templateName)
        {
            var uri = $"/api/v1/productcontainers/saveastemplate/?templateName={templateName}";
            return _client.Post<ProductContainer>(token, uri, productContainer);
        }

        public CrayonApiClientResult<ProductContainer> CreateNewFromTemplate(string token, int templateId)
        {
            var uri = $"/api/v1/productcontainers/createnewfromtemplate";
            return _client.Post<ProductContainer>(token, uri, templateId);
        }
    }
}