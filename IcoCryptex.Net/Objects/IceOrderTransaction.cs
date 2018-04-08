using System;
using IcoCryptex.Net.Objects.Enums;

namespace IcoCryptex.Net.Objects
{
    public class IceOrderTransaction
    {
        public long Id { get; set; }
        public OrderType Type { get; set; }
        public string SymbolPair { get; set; }
        public DateTime CloseTimestamp { get; set; }
        public decimal SecondaryAmount { get; set; }
        public decimal PrimaryPrice { get; set; }
        public decimal PrimaryAmount { get; set; }
    }
}