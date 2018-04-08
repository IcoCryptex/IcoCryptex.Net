using System;

namespace IcoCryptex.Net.Objects
{
    public class IceWithdrawalFeeQuote
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public long UnixValidUntil { get; set; }
    }
}