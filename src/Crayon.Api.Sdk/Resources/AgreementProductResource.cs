﻿using Crayon.Api.Sdk.Domain;
using Crayon.Api.Sdk.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Crayon.Api.Sdk.Domain.Csp;

namespace Crayon.Api.Sdk.Resources
{
    public class AgreementProductResource
    {
        private readonly CrayonApiClient _client;

        public AgreementProductResource(CrayonApiClient client)
        {
            _client = client;
        }

        public CrayonApiClientResult<AgreementProductCollection> Get(string token, AgreementProductFilter filter = null)
        {
            var uri = "/api/v1/agreementproducts/".Append(filter);
            return _client.Get<AgreementProductCollection>(token, uri);
        }

        public CrayonApiClientResult<FileResponse> GetAsExcelFile(string token, AgreementProductFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var uri = "/api/v1/agreementproducts/file/xlsx";
            return _client.GetFile(HttpMethod.Post, token, uri, filter);
        }

        public CrayonApiClientResult<IEnumerable<BillingCycle>> GetSupportedBillingCycles(string token, int resellerCustomerId, string partNumber)
        {
            if (partNumber == null)
            {
                throw new ArgumentNullException(nameof(partNumber));
            }

            if (resellerCustomerId == null)
            {
                throw new ArgumentNullException(nameof(resellerCustomerId));
            }

            var uri = $"/api/v1/agreementproducts/{partNumber}/supportedbillingcycles?resellerCustomerId={resellerCustomerId}";
            return _client.Get<IEnumerable<BillingCycle>>(token, uri);
        }

        public CrayonApiClientResult<AgreementProductCollection> GetCspSeatProducts(string token, AgreementProductFilter filter, bool includeAddOns)
        {
            filter.Include = filter.Include ?? new AgreementProductsSubFilter();
            filter.Include.PublisherNames = filter.Include.PublisherNames ?? new List<string>();
            filter.Include.ProgramNames = filter.Include.ProgramNames ?? new List<string>();
            filter.Include.ProductTypeNames = filter.Include.ProductTypeNames ?? new List<string>();

            Action<List<string>, string> includeValue = (list, s) =>
            {
                string obj = list.FirstOrDefault(p => p.Equals(s, StringComparison.CurrentCultureIgnoreCase));
                if (obj == null)
                {
                    list.Add(s);
                }
            };

            includeValue(filter.Include.ProgramNames, "CSP");
            includeValue(filter.Include.ProductTypeNames, "Subscription");
            if (includeAddOns)
            {
                includeValue(filter.Include.ProductTypeNames, "Subscription Add-On");
            }

            return Get(token, filter);
        }
    }
}