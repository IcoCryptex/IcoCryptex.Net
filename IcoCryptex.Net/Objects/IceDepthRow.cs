namespace IcoCryptex.Net.Objects
{
    public class IceDepthRow
    {
        public decimal Price { get; }
        public decimal Amount { get; }

        internal IceDepthRow(decimal price, decimal amount)
        {
            Price = price;
            Amount = amount;
        }
    }
}