using System;

namespace Crayon.Api.Sdk.Domain
{
    [Flags]
    public enum ProductContainerCategory
    {
        None = 0,
        Seat = 1, //Shoppingcart, Quote, Review, Template
        Report = 2 //Usage report
    }
}