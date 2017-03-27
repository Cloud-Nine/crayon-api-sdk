using System;
namespace Crayon.Api.Sdk.Domain.Csp
{
    public class UsageRecord
    {
        public int Id { get; set; }

        public int PublisherId { get; set; }
        
        public string PublisherName { get; set; }

        public DateTime UsageStartTime { get; set; }

        public DateTime UsageEndTime { get; set; }
        
        public string MeterName { get; set; }

        public string MeterId { get; set; }

        public string MeterCategory { get; set; }

        public string MeterSubCategory { get; set; }

        public string Unit { get; set; }

        public decimal Quantity { get; set; }

        public decimal IncludedQuantity { get; set; }

        public string InstanceData { get; set; }
        
        public string OperatingUnit { get; set; }
        
        public DateTime ReportStartDate { get; set; }

        public DateTime ReportEndDate { get; set; }

        public int? AgreementId { get; set; }

        public int? SubscriptionId { get; set; }

        public string SubscriptionName { get; set; }

        public string PublisherSubscriptionId { get; set; }

        public string TenantName { get; set; }

        public string TenantReference { get; set; }

        public string OrganizationName { get; set; }

        public int? TenantId { get; set; }

        public decimal? SalesUnitPrice { get; set; }

        public string SalesUnitPriceCurrencyCode { get; set; }

        //public decimal? UnitPrice { get; set; }

        //public string UnitPriceCurrencyCode { get; set; }

        public int? PriceId { get; set; }

        public int? ExternalProductId { get; set; }

        public DateTime Created { get; set; }

        //public decimal Margin { get; set; }
    }
}
