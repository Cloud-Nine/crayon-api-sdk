﻿using Crayon.Api.Sdk.Domain;
using System.Collections.Generic;

namespace Crayon.Api.Sdk.Filtering
{
    public class ProductContainerFilter : IHttpFilter
    {
        public int OrganizationId { get; set; }
        public List<int> OrganizationIds { get; set; }
        public string Search { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool ActiveDraft { get; set; }
        public int ProgramId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string UserId { get; set; }
        public string SentByUserId { get; set; }
        public ProductContainerType Type { get; set; }
        public ProductContainerCategory Category { get; set; }

        public string ToQueryString()
        {
            return this.ToQuery();
        }
    }
}