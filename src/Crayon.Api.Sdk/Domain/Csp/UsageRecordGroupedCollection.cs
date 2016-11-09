using System.Collections.Generic;

namespace Crayon.Api.Sdk.Domain.Csp
{
    public class UsageRecordGroupedCollection : ApiCollection<UsageRecordGrouped>
    {
        public List<Price> TotalSalesPrices { get; set; }
    }
}
