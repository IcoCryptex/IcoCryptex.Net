using IcoCryptex.Net.Objects.Enums;

namespace IcoCryptex.Net.Objects
{
    public class IceCreateOrder
    {
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public OrderType Type { get; set; }
    }
}