using System;
using System.Linq;
using System.Collections.Generic;

namespace Crayon.Api.Sdk.Domain
{
    public class ProductContainer
    {
        public int Id { get; set; }

        public int? OrderListId { get; set; }

        public string Note { get; set; } = string.Empty;

        public DateTimeOffset UsageMonth { get; set; }

        public string Name { get; set; }

        public bool ActiveDraft { get; set; }

        public bool Removed { get; set; }

        public string CreatedByUserId { get; set; } = string.Empty;

        public UserProfile ContactUser { get; set; }

        public OrganizationReference Organization { get; set; }

        public ObjectReference Tenant { get; set; }

        public ObjectReference Publisher { get; set; }

        public ObjectReference Program { get; set; }

        public virtual List<ProductRow> ProductRows { get; set; } = new List<ProductRow>();

        public virtual List<ProductContainerComment> Comments { get; set; } = new List<ProductContainerComment>();

        public InvoiceProfile InvoiceProfile { get; set; }

        public ProductContainerType Type { get; set; } = ProductContainerType.Draft;

        public ProductContainerCategory Category { get; set; }

        public DateTimeOffset QuoteValidToDate { get; set; }

        public List<Price> TotalPurchasePrice { get; set; } = new List<Price>();

        public List<Price> TotalSalesPrice { get; set; } = new List<Price>();

        public ProductContainerCommentUser SubmittedBy => GetCreatedLog()?.User;

        public DateTimeOffset? Sent => GetCreatedLog()?.TimeStamp;

        public List<ProductRow> GetValidRows()
        {
            return ProductRows.Where(x => x.Product != null && !string.IsNullOrEmpty(x.Agreement.Name)).ToList();
        }

        private ProductContainerComment GetCreatedLog()
        {
            ProductContainerComment commentLog = null;

            if (Type == ProductContainerType.Draft)
            {
                commentLog = Comments.OrderByDescending(o => o.TimeStamp).FirstOrDefault(c => c.ProductContainerCommentType == ProductContainerCommentType.DraftCreated);
            }

            if (Type == ProductContainerType.Template)
            {
                commentLog = Comments.OrderByDescending(o => o.TimeStamp).FirstOrDefault(c => c.ProductContainerCommentType == ProductContainerCommentType.TemplateCreated);
            }

            if (Type == ProductContainerType.Quote)
            {
                commentLog = Comments.OrderByDescending(o => o.TimeStamp).FirstOrDefault(c => c.ProductContainerCommentType == ProductContainerCommentType.QuoteCreated);
            }

            if (Type == ProductContainerType.Request)
            {
                commentLog = Comments.OrderByDescending(o => o.TimeStamp).FirstOrDefault(c => c.ProductContainerCommentType == ProductContainerCommentType.RequestCreated);
            }

            if (Type == ProductContainerType.Order)
            {
                commentLog = Comments.OrderByDescending(o => o.TimeStamp).FirstOrDefault(c => c.ProductContainerCommentType == ProductContainerCommentType.OrderSubmitted);
            }
            return commentLog;
        }
    }
}
