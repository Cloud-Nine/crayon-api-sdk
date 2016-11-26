
namespace Crayon.Api.Sdk.Domain
{
    public class ProductRow
    {
        public int Id { get; set; }

        public int ProductContainerId { get; set; }

        public int Quantity { get; set; }

        public string Comment { get; set; } = string.Empty;

        public string UsageCountryCode { get; set; } = string.Empty;

        /// <summary>
        /// Price in Pact
        /// </summary>
        public Price PurchaseUnitPrice { get; set; }

        /// <summary>
        /// Price without margin and discount in agreement currency
        /// </summary>
        public Price UnitPrice { get; set; }

        /// <summary>
        /// Price with margin and discount
        /// </summary>
        public Price SalesUnitPrice { get; set; }

        public ObjectReference Publisher { get; set; }

        public ObjectReference Program { get; set; }

        public AgreementIdentityReference Agreement { get; set; }

        public ProductReference Product { get; set; }

        public ProductRowUser User { get; set; }

        public ObjectReference ProductVariant { get; set; }

        public ObjectReference InvoiceProfile { get; set; }
    }
}
