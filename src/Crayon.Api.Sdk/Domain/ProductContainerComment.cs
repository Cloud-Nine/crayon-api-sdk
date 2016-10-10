using System;

namespace Crayon.Api.Sdk.Domain
{
    public class ProductContainerComment
    {
        public int Id { get; set; }

        public int ProductContainerId { get; set; }

        public ProductContainerCommentUser User { get; set; }

        public string Message { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public DateTimeOffset? Modified { get; set; }

        public bool Removed { get; set; }

        public ProductContainerCommentType ProductContainerCommentType { get; set; }
    }
}