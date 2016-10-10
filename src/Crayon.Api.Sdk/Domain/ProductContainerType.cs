using System;

namespace Crayon.Api.Sdk.Domain
{
    [Flags]
    public enum ProductContainerType
    {
        None = 0,
        Draft = 1,
        Request = 2,
        Order = 4,
        Quote = 8,
        Template = 16
    }
}