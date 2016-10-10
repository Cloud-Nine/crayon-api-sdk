namespace Crayon.Api.Sdk.Domain
{
    public class Price
    {
        public decimal Value { get; set; }

        public string CurrencyCode { get; set; }

        public Price()
        {
        }

        public Price(decimal value, string currencyCode)
        {
            Value = value;
            CurrencyCode = currencyCode;
        }
    }
}