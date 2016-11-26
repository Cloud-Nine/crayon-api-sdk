
namespace Crayon.Api.Sdk.Domain
{
    public class OrganizationReference
    {
        public int Id { get; set; }

        public ObjectReference Tenant { get; set; }

        public string Name { get; set; }

        public string AxDataAreaId { get; set; }

        public string AxOrganizationId { get; set; }
    }
}
