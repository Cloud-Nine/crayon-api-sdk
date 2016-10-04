using Crayon.Api.Sdk.Domain;

namespace Crayon.Api.Sdk.Filtering
{
    public class ManagementLinkGrouped
    {
        public string Link { get; set; }
        public ObjectReference ResellerCustomer { get; set; }
        public string Text { get; set; }
    }
}
