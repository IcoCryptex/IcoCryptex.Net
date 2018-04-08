using IcoCryptex.Net.Objects.Enums;

namespace IcoCryptex.Net.Objects
{
    public class IceOrder
    {
        public long Id { get; set; }
        public string SymbolPair { get; set; }
        public OrderType OrderType { get; set; }
        public decimal PrimaryPrice { get; set; }
        public decimal TotalSecondaryAmount { get; set; }
        public decimal RemainingSecondaryAmount { get; set; }
        public decimal FeePercentage { get; set; }
        public long UnixOpenTimestamp { get; set; }
        public long UnixUpdateTimestamp { get; set; }
    }
}